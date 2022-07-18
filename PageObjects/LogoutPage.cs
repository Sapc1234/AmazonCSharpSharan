using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
    public  class LogoutPage
    {
        private By action1 = By.XPath("//div[@id='nav-tools']/a[2]");
        private By signOut = By.XPath("//div[@id='nav-al-your-account']/a/span[text()='Sign Out']");

        public IWebDriver driver;

        public LogoutPage(IWebDriver driver)

        {
            this.driver = driver;   
        }

        public void pointerMovesHoverAccountandList()
        {
            Actions ac = new Actions(driver);
            ac.MoveToElement(driver.FindElement(action1)).Perform();
            Thread.Sleep(3000);
            driver.FindElement(signOut).Click();
        }
    }
}
