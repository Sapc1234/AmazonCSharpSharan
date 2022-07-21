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
        //public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        //threadLocal class maintain all drivers 
        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            //here our working Directory is Utilities
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//Extentreports/Amazon.html";
            //if you want to create one new folder inside the project itself
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            //ExtenhtmlReporter class expects a path where your report should be created and ExtentHtmlReporter basically responsible for craeting report
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", "sharan Padashetty");
        }
        [SetUp]
        public void extentSetup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
        }

        [OneTimeSetUp]
        public void StartBrowser()
        {
            String BrowserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(BrowserName);
            //InitBrowser("chrome");
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            //test.Log(Status.Info, "Amazon");
            driver.Value.Url = "https://www.amazon.in/";
            
            String ActualResult;
            String ExpectedResult = "amazon";
            ActualResult = driver.Value.Url;
            if(ActualResult.Contains(ExpectedResult))
            {
                TestContext.Progress.WriteLine("Setup is Passed");
            }

            else
            {
                TestContext.Progress.WriteLine("Setup is not Passeed");
            }
            Assert.IsTrue(driver.Value.Url.Contains("amazon"));

        }
        public  IWebDriver getDriver()
        {
            return driver.Value;
        }
        public void InitBrowser(String browserName)
        {
            switch(browserName)

            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void extentClose()

        {
          /*  //this will give the test is pass or fail
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            //var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", takeScreenShot(driver, fileName));
                //test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
                //all the failure o/p stack stored in the log file
                test.Log(Status.Fail,"Test Fail");
            }
            else if (status == TestStatus.Passed)
            {
                
            }*/

            extent.Flush();
            //It releases all the objects & it will freshly create next time when  u run ur whole framework
        }
       
        [OneTimeTearDown]
        public void AfterTest()
        {
            driver.Value.Quit();
        }

        public MediaEntityModelProvider takeScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,screenShotName).Build();
        }

    }
}
