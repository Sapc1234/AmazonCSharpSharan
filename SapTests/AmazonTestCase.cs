using Amazon.PageObjects;
using Amazon.utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace Amazon
{
    [Parallelizable(ParallelScope.Self)]
    public class Tests : Base
    {
        [Test, Order(1)]
        [TestCase("sapadashetty2110@gmail.com", "Sapc@1234")]
        //[TestCase("sapdashetty2110@gmail.com","Sapc@5678")]
       
        public void Varify_Login_Functionality_Of_LoginPage(String UsrName, String Password)
        {
                LoginPage lp = new LoginPage(getDriver());
                lp.PointerMoveOnSignIn();
                lp.AmazonUserName(UsrName);
                test.Log(Status.Info, "UserName is Entered");
                lp.ClickOnContinue();
                test.Log(Status.Info, "Click On Continue Button");
                lp.AmazonPassword(Password);
                test.Log(Status.Info, "Password Enter Successfully");
                lp.ClickOnSigninButton();
                test.Log(Status.Info, "Click On SignIn Button");
                var actualName = driver.Value.FindElement(By.XPath("//div[@class='nav-line-1-container']/span[@id='nav-link-accountList-nav-line-1']"));
                Assert.AreEqual("Hello, sharan", actualName.Text);
        }

        [Test, Order(2)]
        public void Varify_Amazon_User_Able_To_Search_The_Products()
        {
                ProductSearch ps = new ProductSearch(getDriver());
                ps.SearchItem("Samsung Galaxy M53 5G");
                test.Log(Status.Info, "Item Search Successfully");
                ps.ClickOnSearchButton();
                test.Log(Status.Info, "pointer click on searchButton");
                String atext = ps.getText().Text;
                String[] splittedText = atext.Split("(");
                String trimmedAText = splittedText[0].Trim();
                Assert.AreEqual("Samsung Galaxy M53 5G", trimmedAText);
        }
       
        [Test, Order(3)]
        public void Varify_Amazon_User_Able_To_Add_The_Products_Into_TheCart()
        {
                ProductDescription pd = new ProductDescription(getDriver());
                String parentWindow = driver.Value.CurrentWindowHandle;
                pd.Product_Name();
                String childWindow = driver.Value.WindowHandles[1];
                driver.Value.SwitchTo().Window(childWindow);
                pd.SelectQuantity();
                test.Log(Status.Info, "User required Quantity added");
                pd.ClickOnAddToCart();
                test.Log(Status.Info, "Items added into the cart ");
                driver.Value.SwitchTo().Window(parentWindow);
                Assert.AreEqual(2, driver.Value.WindowHandles.Count);
        }

        [Test, Order(4)]
        public void Varify_Amazon_User_Able_To_Navigate_The_CartPage()
        {  
                NavigationPage np = new NavigationPage(getDriver());
                np.backToCart();
                test.Log(Status.Info, "pointer clickon AmazonLogo");
                np.footer();
                test.Log(Status.Info, "webPage scrollDown Successfully");
                Assert.IsTrue(driver.Value.FindElement(By.CssSelector("a[id='nav-cart']")).Enabled);
        }

        [Test, Order(5)]
        public void Varify_Amazon_User_Able_To_Select_The_Radio_Button()
        {
                driver.Value.SwitchTo().DefaultContent();
                LanguageSettingPage ls = new LanguageSettingPage(getDriver());
                ls.radioButton();
                test.Log(Status.Info, "User Select the Language as a Kannada");
                Assert.IsTrue(driver.Value.FindElement(By.XPath("//div[@class='a-radio a-radio-fancy']/label/input[@value='kn_IN']")).Selected);
        }

        [Test, Order(6)]
        public void Varify_Amazon_User_Able_To_Click_On_SignOut_Button()
        {
            LogoutPage lo = new LogoutPage(getDriver());
            lo.pointerMovesHoverAccountandList();
            test.Log(Status.Info, "Click On SignOut Button Successfully");
        }
    }
}
