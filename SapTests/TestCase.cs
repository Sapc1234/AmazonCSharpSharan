using Amazon.PageObjects;
using Amazon.utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon
{
    public class Tests : Base
    {
        [Test, Order(1)]
        [TestCase("sapadashetty2110@gmail.com", "Sapc@5678")]
        //[TestCase("sapdashetty2110@gmail.com","Sapc@5678")]

        public void validLoginCredential(String UsrName, String Password)
        {
            try
            {
                LoginPage lp = new LoginPage(getDriver());
                lp.pointerMoveOnsignIn();
                lp.amazonuserName(UsrName);
                test.Log(Status.Info, "UserName is Entered");
                lp.clickOnContinue();
                lp.amazonPassword(Password);
                test.Log(Status.Info, "Password Enter Successfully");
                lp.clickOnSigninButton();
                var actualName = driver.FindElement(By.XPath("//div[@class='nav-line-1-container']/span[@id='nav-link-accountList-nav-line-1']"));
                Assert.AreEqual("Hello, sharan", actualName.Text);
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch(Exception e)

            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }

        [Test, Order(2)]
        public void productSearch()
        {
            try
            {
                ProductSearch ps = new ProductSearch(getDriver());

                ps.searchItem("Samsung Galaxy M53 5G");

                test.Log(Status.Info, "Item Search Successfully");

                ps.clickOnSearchbutton();

                test.Log(Status.Info, "pointer click on searchButton");

                String atext = ps.getText().Text;
                String[] splittedText = atext.Split("(");
                String trimmedAText = splittedText[0].Trim();
                // Assert.AreEqual("Samsung Galaxy M53 5G", trimmedAText);
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }
       
        [Test, Order(3)]
        public void productAddedintoTheCart()
        {
            try
            {
                String parentWindow = driver.CurrentWindowHandle;
                driver.FindElement(By.XPath("//div[contains(@class,'rush-component s-featured-result-item')]//span[@class='a-size-medium a-color-base a-text-normal'][contains(text(),'Samsung Galaxy M53 5G (Mystique Green, 6GB, 128GB ')]")).Click();
                String childWindow = driver.WindowHandles[1];
                driver.SwitchTo().Window(childWindow);
                ProductDescription pd = new ProductDescription(getDriver());
                pd.selecttQuantity();
                pd.clickonAddToCart();
                test.Log(Status.Info, "Items added into the cart ");
                driver.SwitchTo().Window(parentWindow);
                Assert.AreEqual(2, driver.WindowHandles.Count);
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }

        [Test, Order(4)]
        public void goBackToCart()

        {   try
            {
                NavigationPage np = new NavigationPage(getDriver());
                np.backToCart();
                test.Log(Status.Info, "pointer clickon AmazonLogo");
                np.footer();
                test.Log(Status.Info, "webPage scrollDown Successfully");
                Assert.IsTrue(driver.FindElement(By.CssSelector("a[id='nav-cart']")).Enabled);
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }

        [Test, Order(5)]
        public void clickOnRadioButtons()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                LanguageSettingPage ls = new LanguageSettingPage(getDriver());
                ls.radioButton();
                test.Log(Status.Info, "select a Language as a Kannada");
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='a-radio a-radio-fancy']/label/input[@value='kn_IN']")).Selected);
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch(Exception e)
            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }

        [Test,Order(6)]
        public void clickOnsignOutButtons()
        {
            try
            {
                LogoutPage lo = new LogoutPage(getDriver());
                lo.pointerMovesHoverAccountandList();
                test.Log(Status.Info, "clickOn SignOut Button Successfully");
                test.Log(Status.Pass, "Test Passed Successfully");
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.Message);
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", takeScreenShot(driver, fileName));
            }
        }
    }
}
