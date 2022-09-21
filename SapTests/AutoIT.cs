using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.SapTests
{
    [Parallelizable(ParallelScope.Self)]
    public class AutoIT
    {
        //public IWebDriver driver;
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void OpenBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions eo = new EdgeOptions();
            eo.AcceptInsecureCertificates = true;   
            driver.Value = new EdgeDriver(eo);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            

        }

        [Test]

        public void HandlingWindowAuthenticationpopup()
        {
            
            driver.Value.Url = "https://admin:admin@the-internet.herokuapp.com/";
            driver.Value.FindElement(By.CssSelector("a[href='/basic_auth']")).Click();
        }

        [Test]
        //[DeploymentItem("Data/localdb.mdf")]
        public void Uplaoding_file_with_AutoIT()
        {
            driver.Value.Url = "https://www.ilovepdf.com/jpg_to_pdf";
            driver.Value.FindElement(By.XPath("//div[@id='uploader']/a[@id='pickfiles']/span")).Click();
            //now we need to call the .exe file
            
            Thread.Sleep(3000);

            ProcessStartInfo pi = new ProcessStartInfo();
            //ProcessStartInfo method will trigger our execution
            pi.FileName = @"G:\SeleniumAutomationCsharp\Sapc1234\AmazonCSharpSharan\Resources\AutoItFile.exe";

          



            //Process process =  Process.Start(pi);
            //process.WaitForExit();
            //process.Close();

            //this method will close after every thing is done
            using (var process = Process.Start(pi))
            {
                process.WaitForExit();
            }
            Thread.Sleep(3000);

            driver.Value.FindElement(By.CssSelector("#processTask")).Click();
            WebDriverWait wait = new WebDriverWait(driver.Value,TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='download']/a")));
            driver.Value.FindElement(By.XPath("//div[@id='download']/a")).Click();


        }

    }
}
