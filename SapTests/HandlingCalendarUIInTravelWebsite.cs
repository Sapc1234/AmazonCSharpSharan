using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.SapTests
{
    [Parallelizable(ParallelScope.Self)]
    public  class HandlingCalendarUIInTravelWebsite

    {
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions eo = new EdgeOptions();
            eo.AcceptInsecureCertificates = true;
            driver.Value = new EdgeDriver(eo);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Value.Url = "https://www.path2usa.com/travel-companion/";
        }

        [Test]
        public void HandlingCalendarUI()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver.Value;
            js.ExecuteScript("window.scrollBy(0,600);");

            Thread.Sleep(4000);

            driver.Value.FindElement(By.CssSelector("input[id='form-field-travel_comp_date']")).Click();
            //driver.Value.FindElement(By.XPath("//div[@class='flatpickr-month']/div[@class='flatpickr-current-month']")).Text.Contains("November ");
            while(!driver.Value.FindElement(By.XPath("//div[@class='flatpickr-month']/div[@class='flatpickr-current-month']")).Text.Contains("December"))

            {
                driver.Value.FindElement(By.XPath("//div[@class='flatpickr-month']/span[@class='flatpickr-next-month']")).Click();
            }

            IList<IWebElement> hdates  = driver.Value.FindElements(By.XPath("//div[@class='flatpickr-days']/div[@class='dayContainer']/span"));
            int cdays =  driver.Value.FindElements(By.XPath("//div[@class='flatpickr-days']/div[@class='dayContainer']/span")).Count;
            for(int i = 0; i < cdays; i++)
            {
                String text = driver.Value.FindElements(By.XPath("//div[@class='flatpickr-days']/div[@class='dayContainer']/span"))[i].Text;
                if(text.Equals("23"))
                {
                    driver.Value.FindElements(By.XPath("//div[@class='flatpickr-days']/div[@class='dayContainer']/span"))[i].Click();
                    break;
                }
            }
        }

       
    }
}
