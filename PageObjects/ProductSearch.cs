using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.PageObjects
{
    public class ProductSearch
    {
       private By searchBox = By.CssSelector("input[id='twotabsearchtextbox']");
       private By clickonSearchButton = By.XPath("//div[@class='nav-search-submit nav-sprite']/span[@id='nav-search-submit-text']/input[@id='nav-search-submit-button']");
       private By compareText = By.XPath("//div[contains(@class,'rush-component s-featured-result-item')]//span[@class='a-size-medium a-color-base a-text-normal'][contains(text(),'Samsung Galaxy M53 5G (Mystique Green, 6GB, 128GB ')]");
        
       private IWebDriver driver;
       
       public ProductSearch(IWebDriver driver)

        {
            this.driver = driver;
        }
       
        public void SearchItem(String Items)
        {
            driver.FindElement(searchBox).SendKeys(Items);
        }
        
        public IWebElement getText()
        {
            return driver.FindElement(compareText);
        }
       
        public void ClickOnSearchButton()
        {
            driver.FindElement(clickonSearchButton).Click();
        }
    }
}
