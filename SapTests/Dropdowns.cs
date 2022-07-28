using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.SapTests
{
    [Parallelizable(ParallelScope.Self)]
    public class SeleniumDropDowns
    {
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void StartBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver.Value = new ChromeDriver();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/dropdownsPractise/";

        }

        [Test]
        public void selectDropdowns()

        {
            IWebElement sd = driver.Value.FindElement(By.Id("ctl00_mainContent_DropDownListCurrency"));
            SelectElement dd = new SelectElement(sd);
            dd.SelectByValue("USD"); 
            TestContext.Progress.WriteLine(dd.SelectedOption.Text);
            dd.SelectByText("AED");
            TestContext.Progress.WriteLine(dd.SelectedOption.Text);
            Thread.Sleep(1500);
            dd.SelectByIndex(1);
            TestContext.Progress.WriteLine(dd.SelectedOption.Text);
        }

        [Test]
        public void updatedDropdowns()

        {
            driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Click();
            Thread.Sleep(2000);
            
            /*for(int i=1;i<5;i++)
            {
                driver.Value.FindElement(By.XPath("//span[@id='hrefIncAdt']")).Click();
                Thread.Sleep(2000);
            }*/

            int j = 1;
            while(j<4)
            {
                driver.Value.FindElement(By.XPath("//span[@id='hrefIncAdt']")).Click();
                j++;
                Thread.Sleep(2000);
            }
            driver.Value.FindElement(By.XPath("//input[@id='btnclosepaxoption']")).Click();
            Assert.AreEqual(driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Text,"5 Adult");
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Text);
        }

        [Test]
        public void dynamicDropdowns()

        {
            //a[@value='AMD']
            //div[@id='glsctl00_mainContent_ddl_destinationStation1_CTNR']//a[@value='BLR']

            driver.Value.FindElement(By.Id("ctl00_mainContent_ddl_originStation1_CTXT")).Click();
            driver.Value.FindElement(By.XPath("//a[@value='AMD']")).Click();
            Thread.Sleep(2000);
            driver.Value.FindElement(By.XPath("//div[@id='glsctl00_mainContent_ddl_destinationStation1_CTNR']//a[@value='BLR']")).Click();

            driver.Value.FindElement(By.CssSelector(".ui-state-default.ui-state-highlight")).Click();
            
            
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.Id("Div1")).GetAttribute("style"));
            //display: block; opacity: 0.5;
            driver.Value.FindElement(By.Id("ctl00_mainContent_rbtnl_Trip_1")).Click();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.Id("Div1")).GetAttribute("style"));
            //display: block; opacity: 1;

            if(driver.Value.FindElement(By.Id("Div1")).GetAttribute("style").Contains("1"))
            {
                TestContext.Progress.WriteLine("is enabled");
                Assert.IsTrue(true);

            }

            else
            {
                TestContext.Progress.WriteLine("is disabled");
                Assert.IsTrue(false);
            }


        }

        [Test]
        public void autoSuggestiveDropdowns()

        {
            driver.Value.FindElement(By.XPath("//input[@id='autosuggest']")).SendKeys("Ind");
            Thread.Sleep(3000);
            IList<IWebElement> options =  driver.Value.FindElements(By.XPath("//li[@class='ui-menu-item']"));

            foreach(IWebElement option in options)

            {
                if (option.Text.Equals("India"))

                    option.Click();
                    break;
            }
        }

        [Test]

        public void handlingCheckBoxes()

        {
            TestContext.Progress.WriteLine(driver.Value.FindElements(By.XPath("//input[@type='checkbox']")).Count);

            Assert.IsFalse(driver.Value.FindElement(By.XPath("//input[contains(@id,'friendsandfamily')]")).Selected);
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.XPath("//input[contains(@id,'friendsandfamily')]")).Selected);
            driver.Value.FindElement(By.XPath("//input[contains(@id,'friendsandfamily')]")).Click();
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.XPath("//input[contains(@id,'friendsandfamily')]")).Selected);
            Assert.IsTrue(driver.Value.FindElement(By.XPath("//input[contains(@id,'friendsandfamily')]")).Selected);
        }

        [Test]

        public void EndToEnd()

        {   //autosuggestiveDropdown
            driver.Value.FindElement(By.XPath("//input[@id='autosuggest']")).SendKeys("Ind");
            Thread.Sleep(3000);
            IList<IWebElement> options = driver.Value.FindElements(By.XPath("//li[@class='ui-menu-item']"));

            foreach (IWebElement option in options)

            {
                if (option.Text.Equals("India"))

                    option.Click();
                break;
            }

            driver.Value.FindElement(By.Id("ctl00_mainContent_ddl_originStation1_CTXT")).Click();
            driver.Value.FindElement(By.XPath("//a[@value='AMD']")).Click();
            Thread.Sleep(2000);
            driver.Value.FindElement(By.XPath("//div[@id='glsctl00_mainContent_ddl_destinationStation1_CTNR']//a[@value='BLR']")).Click();

            //journeyDate
            driver.Value.FindElement(By.CssSelector(".ui-state-default.ui-state-highlight")).Click();

            //updatedDropdowns
            driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Click();
            Thread.Sleep(2000);

            for(int i=1;i<5;i++)
            {
                driver.Value.FindElement(By.XPath("//span[@id='hrefIncAdt']")).Click();
                Thread.Sleep(2000);
            }
            driver.Value.FindElement(By.XPath("//input[@id='btnclosepaxoption']")).Click();
            Assert.AreEqual(driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Text, "5 Adult");
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.XPath("//div[@id='divpaxinfo']")).Text);

            IWebElement sd = driver.Value.FindElement(By.Id("ctl00_mainContent_DropDownListCurrency"));
            SelectElement dd = new SelectElement(sd);
            dd.SelectByValue("USD");

           //driver.Value.FindElement(By.Id("#ctl00_mainContent_btn_FindFlights")).Click();

        }



        [TearDown]
        public void browserEnd()
        {
            driver.Value.Quit();
        }
    }
}
