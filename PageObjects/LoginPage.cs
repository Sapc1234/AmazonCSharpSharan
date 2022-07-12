using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.PageObjects
{
    public class LoginPage
    {
        private By userName = By.CssSelector("#ap_email");
        private By clickoncontinue = By.XPath("//input[@id='continue']");
        private By password = By.CssSelector("#ap_password");
        private By signinButton = By.CssSelector("#signInSubmit");
        private By action = By.XPath("//div[@id='nav-tools']/a[2]");

        private IWebDriver driver;
    
        public LoginPage(IWebDriver driver)
            {
             this.driver = driver;
            }

        public void pointerMoveOnsignIn()
        {
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(action)).Click().Perform();
        }
        public void amazonuserName(String user)
        {
            driver.FindElement(userName).SendKeys(user);
        }
        public void clickOnContinue()
        {
            driver.FindElement(clickoncontinue).Click();
        }
        public void amazonPassword(String pass)
        {
            driver.FindElement(password).SendKeys(pass);
        }
        public void clickOnSigninButton()
        {
            driver.FindElement(signinButton).Click();
        }
    }
}
