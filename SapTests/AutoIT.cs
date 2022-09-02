using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon.SapTests
{
    public class AutoIT
    {
        public IWebDriver driver;

        [SetUp]
        public void OpenBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            

        }

        [Test]

        public void HandlingWindowAuthenticationpopup()
        {
            
            driver.Url = "https://admin:admin@the-internet.herokuapp.com/";
            driver.FindElement(By.CssSelector("a[href='/basic_auth']")).Click();
        }

    }
}
