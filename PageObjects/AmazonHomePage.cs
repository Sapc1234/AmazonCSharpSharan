using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Amazon.PageObjects
{
    public class AmazonHomePage
    {
        private By static_Dropdown = By.XPath("//select[contains(@class,'nav-search-dropdown')]");
       

        private IWebDriver driver;
        public AmazonHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void DropDowns()

        {
            IWebElement selectDropDown = driver.FindElement(static_Dropdown);
            SelectElement se = new SelectElement(selectDropDown);

            ArrayList actualDropdownValues = new ArrayList();
            foreach (IWebElement element in se.Options)
            {
         
                TestContext.Progress.WriteLine(element.Text);
                actualDropdownValues.Add(element.Text);
            }

            ArrayList expectedDropdownValues = new ArrayList();
            expectedDropdownValues.Add("All Categories");
            expectedDropdownValues.Add("Alexa Skills");
            expectedDropdownValues.Add("Amazon Devices");
            expectedDropdownValues.Add("Amazon Fashion");
            expectedDropdownValues.Add("Amazon Fresh");
            expectedDropdownValues.Add("Amazon Pharmacy");
            expectedDropdownValues.Add("Appliances");
            expectedDropdownValues.Add("Apps & Games");
            expectedDropdownValues.Add("Baby");
            expectedDropdownValues.Add("Beauty");
            expectedDropdownValues.Add("Books");
            expectedDropdownValues.Add("Car & Motorbike");
            expectedDropdownValues.Add("Clothing & Accessories");
            expectedDropdownValues.Add("Collectibles");
            expectedDropdownValues.Add("Computers & Accessories");
            expectedDropdownValues.Add("Deals");
            expectedDropdownValues.Add("Electronics");
            expectedDropdownValues.Add("Furniture");
            expectedDropdownValues.Add("Garden & Outdoors");
            expectedDropdownValues.Add("Gift Cards");
            expectedDropdownValues.Add("Grocery & Gourmet Foods");
            expectedDropdownValues.Add("Health & Personal Care");
            expectedDropdownValues.Add("Home & Kitchen");
            expectedDropdownValues.Add("Industrial & Scientific");
            expectedDropdownValues.Add("Jewellery");
            expectedDropdownValues.Add("Kindle Store");
            expectedDropdownValues.Add("Luggage & Bags");
            expectedDropdownValues.Add("Luxury Beauty");
            expectedDropdownValues.Add("Movies & TV Shows");
            expectedDropdownValues.Add("Music");
            expectedDropdownValues.Add("Musical Instruments");
            expectedDropdownValues.Add("Office Products");
            expectedDropdownValues.Add("Pet Supplies");
            expectedDropdownValues.Add("Prime Video");
            expectedDropdownValues.Add("Shoes & Handbags");
            expectedDropdownValues.Add("Software");
            expectedDropdownValues.Add("Sports, Fitness & Outdoors");
            expectedDropdownValues.Add("Subscribe & Save");
            expectedDropdownValues.Add("Tools & Home Improvement");
            expectedDropdownValues.Add("Toys & Games");
            expectedDropdownValues.Add("Under ₹500");
            expectedDropdownValues.Add("Video Games");
            expectedDropdownValues.Add("Watches");

            for (int i = 0; i < actualDropdownValues.Count; i++)
            {
                TestContext.Progress.WriteLine("Actual :" + actualDropdownValues[i] + " &Expected :" + expectedDropdownValues[i]);
                Assert.IsTrue(actualDropdownValues[i].Equals(expectedDropdownValues[i]));
            }

        }
    }
}
