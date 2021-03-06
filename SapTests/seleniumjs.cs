using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;


namespace Amazon.SapTests
{
    [Parallelizable(ParallelScope.Self)]
    public  class seleniumjs
    {
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void openBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver.Value = new ChromeDriver();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }

        [Test]
        
        public void JsDemo()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver.Value;
            js.ExecuteScript("window.scrollBy(0,500);");
            Thread.Sleep(3000);
            js.ExecuteScript("document.querySelector('.tableFixHead').scrollTop=5000");

            IList<IWebElement> values =  driver.Value.FindElements(By.CssSelector(".tableFixHead td:nth-child(4)"));

            int sum = 0;
            for(int i = 0; i < values.Count; i++)
            {
                //Console.WriteLine(Int32.Parse(values[i].Text));
                sum = sum + Int32.Parse(values[i].Text);
            }      
            Console.WriteLine(sum);
            //parsing String and compareing with generated value of sum
            //String  s = driver.FindElement(By.CssSelector(".totalAmount")).Text;
            int total = Int32.Parse(driver.Value.FindElement(By.CssSelector(".totalAmount")).Text.Split(":")[1].Trim());
            Assert.AreEqual(sum, total);
        }

        [Test]
        public void printstheRowsandColumn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver.Value;
            js.ExecuteScript("window.scrollBy(0,500);");

            IWebElement table = driver.Value.FindElement(By.CssSelector("#product"));
            Console.WriteLine(table.FindElements(By.TagName("tr")).Count);

            Console.WriteLine(table.FindElements(By.TagName("tr"))[0].FindElements(By.TagName("th")).Count);

            IList<IWebElement> secondrow = driver.Value.FindElements(By.TagName("tr"))[2].FindElements(By.TagName("td"));
            Console.WriteLine(secondrow[0].Text);
            Console.WriteLine(secondrow[1].Text);
            Console.WriteLine(secondrow[2].Text);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Value.Quit();
        }
    }
}
