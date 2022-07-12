using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
   public  class LanguageSettingPage
    {
        private IWebDriver driver;

        private By checkoutRadioButton = By.XPath("//div[@class='a-radio a-radio-fancy']/label/input[@value='kn_IN']");
        private By clickonCancel = By.XPath("//span[contains(@class,'a-button-inner')]/a[@class='a-button-text']");
     
        public LanguageSettingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void radioButton()
        {
            Actions a2 = new Actions(driver);
            a2.MoveToElement(driver.FindElement(checkoutRadioButton)).Click().Perform();



            /*     IList<IWebElement> rdos = driver.FindElements(checkoutRadioButton);

                   foreach (IWebElement radiosButton in rdos)
                   {
                       // rdos[5].GetAttribute("value").Equals("Kn_IN")
                       if (radiosButton.GetAttribute("value").Equals("kn_IN"))
                       {
                           radiosButton.Click();
                       }
                   }      */

            Thread.Sleep(5000);
           // driver.FindElement(clickonCancel).Click();
        }
    }
}
