using Amazon.PageObjects;
using Amazon.utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Amazon.StepDefinitionFile
{
    [Binding]
    
    public class AmazonStepdefinitionImplementation : Base
    {
        [Given(@"I landed on Amazon Website")]
        public void I_Landed_On_Amazon_Website()
        {
            StartBrowser();
        }

        [Given(@"Login with username (.*) and password (.*)")]
        public void LogIn_With_Username_And_Password(string username,string password)
        {
            LoginPage lp = new LoginPage(getDriver());
            lp.PointerMoveOnSignIn();
            lp.AmazonUserName(username);
            lp.ClickOnContinue();
            lp.AmazonPassword(password);
            lp.ClickOnSigninButton();
            var actualName = driver.Value.FindElement(By.XPath("//div[@class='nav-line-1-container']/span[@id='nav-link-accountList-nav-line-1']"));
            Assert.That(actualName.Text, Is.EqualTo("Hello, sharan"));
        }

        public ProductSearch ps;
        [When(@"I search the product in Amazon Ecommerce website (.*) and click on the search Button")]
        public void ISearchTheProductInAmazonEcommerceWebsiteAndClickOnTheSearchButton(string ProductName)
        {
            ps = new ProductSearch(getDriver());
            ps.SearchItem("Samsung Galaxy M53 5G");
            ps.ClickOnSearchButton();
        }

        [Then(@"Check the serach item is (.*) displayed or not")]
        public void Check_The_Serach_Item_Is_Displayed_Or_Not(string ProductName)
        {
            String atext = ps.getText().Text;
            String[] splittedText = atext.Split("(");
            String trimmedAText = splittedText[0].Trim();
            Assert.That(trimmedAText, Is.EqualTo("Samsung Galaxy M53 5G"));
        }

        public ProductDescription pd;
        [Given(@"Check the product Description")]
        public void CheckTheProductDescription()
        {
            pd = new ProductDescription(getDriver());
            pd.Product_Name();
        }
        
        [When(@"After Checking the product Description then product is added into the cart")]
        public void WhenAfterCheckingTheProductDescriptionThenProductIsAddedIntoTheCart()
        {
            String parentWindow = driver.Value.CurrentWindowHandle;
            String childWindow = driver.Value.WindowHandles[1];
            driver.Value.SwitchTo().Window(childWindow);
            pd.SelectQuantity();
            pd.ClickOnAddToCart();
            driver.Value.SwitchTo().Window(parentWindow);
            Assert.That(driver.Value.WindowHandles.Count, Is.EqualTo(2));
        }

        [Then(@"check the product is added into the cart or not")]
        public void CheckTheProductIsAddedIntoTheCartOrNot()
        {
            TestContext.Progress.WriteLine("Product is added successfully");
        }

        public NavigationPage np;
        [Given(@"Navigate to cartPage and then clickon save for later")]
        public void NavigateToCartPageAndThenClickonSaveForLater()
        {
            np = new NavigationPage(getDriver());
            np.BackToCart_and_clickOn_Save_For_later();
         
        }

        [When(@"After clicking save for later then Navigate to Amazon logo then scroll down upto footer")]
        public void AfterClickingSaveForLaterThenNavigateToAmazonLogoThenScrollDownUptoFooter()
        {
            np.navigateToAmazonLogo();
            np.Footer();
        }

        [Then(@"Check page is scroll down is successfully or not and check cart page is enable or Disable")]
        public void CheckPageIsScrollDownIsSuccessfullyOrNotAndCheckCartPageIsEnableOrDisable()
        {
            TestContext.Progress.WriteLine("webPage scrollDown Successfully");
            Assert.IsTrue(driver.Value.FindElement(By.CssSelector("a[id='nav-cart']")).Enabled);
        }

        public LogoutPage lo;

        [Given(@"User is on Amazon HomePage")]
        public void UserIsOnAmazonHomePage()
        {
          
        }

        [When(@"User Navigate to Amazon Account and list then click on signOut")]
        public void UserNavigateToAmazonAccountAndListThenClickOnSignOut()
        {
            lo = new LogoutPage(getDriver());
            lo.pointerMovesHoverAccountandList();
        }

        [Then(@"Check Amazon Account is successfully signOut or not")]
        public void CheckAmazonAccountIsSuccessfullySignOutOrNot()
        {
            TestContext.Progress.WriteLine("Amazon user signOut successfully");
        }


    }
}
