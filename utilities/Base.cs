using Amazon.PageObjects;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;
        public IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "sharan Padashetty");

        }
        [SetUp]
        public void extentSetup()

        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

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

        [TearDown]

        public void extentEnd()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", takeScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();
        }
       
            
        [OneTimeTearDown]
        public void AfterTest()
        {
           
            driver.Quit();
        }


        public MediaEntityModelProvider takeScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }

    }
}
