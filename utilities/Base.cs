using Amazon.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.utilities
{
    public class Base
    {
        public IWebDriver driver;

        //ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        //[SetUp]
         [OneTimeSetUp]
        public void StartBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            //InitBrowser("chrome");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.amazon.in/";
           
            
            String ActualResult;
            String ExpectedResult = "amazon";

            ActualResult = driver.Url;

            if(ActualResult.Contains(ExpectedResult))

            {
                TestContext.Progress.WriteLine("Setup is Passed");
            }

            else
            {
                TestContext.Progress.WriteLine("Setup is not Passeed");
            }

         Assert.IsTrue(driver.Url.Contains("amazon"));

        }
        public  IWebDriver getDriver()

        {
            return driver;
        }

        public void InitBrowser(String browserName)
        {
            switch(browserName)

            {
                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;


                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;



            }
        }
       
            
        [OneTimeTearDown]
        public void AfterTest()
        {
           //driver.Quit();
        }

    }
}
