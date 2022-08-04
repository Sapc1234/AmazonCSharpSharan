using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amazon.PageObjects
{
    public class ProductDescription
    {
        private By item_Name = By.XPath("//div[contains(@class,'rush-component s-featured-result-item')]//span[@class='a-size-medium a-color-base a-text-normal'][contains(text(),'Samsung Galaxy M53 5G (Mystique Green, 6GB, 128GB ')]");
        private By selectquantity = By.XPath("//select[@id='quantity']");
        private By clickaddToCart = By.XPath("//input[@id='add-to-cart-button']");        
        
        private IWebDriver driver;

        public ProductDescription(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Product_Name()
        {
            driver.FindElement(item_Name).Click();
        }
       
        public void SelectQuantity()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500);");
            Thread.Sleep(4000);
            IWebElement staticdropDown = driver.FindElement(selectquantity);
            SelectElement sd = new SelectElement(staticdropDown);
            sd.SelectByValue("2");
        }
       
        public void ClickOnAddToCart()
        {
            driver.FindElement(clickaddToCart).Click();
        }
    }
}
