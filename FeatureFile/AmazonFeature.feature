Feature: Add the items into the Amazon Cart Page

Background: 
Given I landed on Amazon Website


Scenario Outline: Login Amazon Application with valid Credentials and search the product
Given Login with username <username> and password <password>
When I search the product in Amazon Ecommerce website <ProductName> and click on the search Button
Then Check the serach item is  <ProductName> displayed or not


Given Check the product Description 
When After Checking the product Description then product is added into the cart 
Then check the product is added into the cart or not


Given Navigate to cartPage and then clickon save for later
When  After clicking save for later then Navigate to Amazon logo then scroll down upto footer
Then Check page is scroll down is successfully or not and check cart page is enable or Disable

Given User is on Amazon HomePage
When User Navigate to Amazon Account and list then click on signOut 
Then Check Amazon Account is successfully signOut or not

Examples: 
| username                   | password  | ProductName           |
| sapadashetty2110@gmail.com | Sapc@1234 | Samsung Galaxy M53 5G |


