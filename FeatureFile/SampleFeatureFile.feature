Feature: FeatureFile
	Simple calculator for adding two numbers


Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Create new Employee with Mandatory Details 
#working with multiple data using Table
#Given I have opened My application
#Then I should see employee details Page
When I fill all the mandatory details in form
|	Name	| Age	| Phone		|	Email		   |
|	sharan	| 26	| 123456789	|	abc@gmail.com  |
|	Ashwat	| 26	| 987456321	|	def@gmail.com  |
#And I click on the save Button
#Then I should see all the details saved in My Application DB

Scenario Outline: Create new Employee with Mandatory Details for different iteration
#working with multiple data using Table
#Given I have opened My application
#Then I should see employee details Page
When I fill all the mandatory details in form <Name>,<Age>,<Phone> and <Email>
#And I click on the save Button
#Then I should see all the details saved in My Application DB

Examples: 
|	Name	| Age	| Phone		|	Email		   |
|	sharan	| 26	| 123456789	|	abc@gmail.com  |
|	Ashwat	| 26	| 987456321	|	def@gmail.com  |

Scenario: Check if i could get the details entered via Table from Extened Steps
When I fill all the mandatory details in form
|	Name	| Age	| Phone		|	Email		   |
|	sharan	| 26	| 123456789	|	abc@gmail.com  |
Then i should get the same value from the Extended steps
