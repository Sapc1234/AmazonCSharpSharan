using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;


namespace Amazon.StepDefinitionFile
{
    [Binding]
    public class SampleStepDefinition
    {
        public readonly EmployeeDetails employee;

        public SampleStepDefinition(EmployeeDetails emp)
        {
            this.employee = emp;
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
       
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {
            //ScenarioContext.Current.Pending();
            Console.WriteLine(num1);

        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
            //ScenarioContext.Current.Pending();
            Console.WriteLine(num2);
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("pressed the add Button");
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if (result == 120)//grab the object which has the value is 120 in the ui of your real application and replace that
                Console.WriteLine("The test is Passed");
            else
                Console.WriteLine("The test is not Passed");

        }

        [When(@"I fill all the mandatory details in form")]
        public void WhenIFillAllTheMandatoryDetailsInForm(Table table)
        {
            // i want to read the data from feature file
            //EmployeeDetails details = table.CreateInstance<EmployeeDetails>();
            //Console.WriteLine(details.Name);
            //Console.WriteLine(details.Age);
            //Console.WriteLine(details.Phone);
            //Console.WriteLine(details.Email);

            //If we have Multiple data
            /*   var details = table.CreateSet<EmployeeDetails>();
               foreach(EmployeeDetails emp  in details)
               {
                   Console.WriteLine($"The Details of Employee {emp.Name}");
                   Console.WriteLine("**************************");
                   Console.WriteLine(emp.Age);
                   Console.WriteLine(emp.Phone);
                   Console.WriteLine(emp.Email);
               }
            */

            //work with Dynamic Assist

            var details = table.CreateDynamicSet();

            //Iterate
            foreach(var emp in details )

            {
                Console.WriteLine($"The Details of Employee {emp.Name}");
                Console.WriteLine("**************************");
                Console.WriteLine(emp.Age);
                Console.WriteLine(emp.Phone);
                Console.WriteLine(emp.Email);
            }
        }

        [When(@"I fill all the mandatory details in form")]
        public void IFillAllTheMandatoryDetailsInForm(Table table)
        {
            var data = table.CreateDynamicSet();
            foreach(var item in data)
            {
                employee.Name = (string)item.Name;
                employee.Age = (int)item.Age;
                employee.Email = (string)item.Email;
                employee.Phone = (long)item.Phone;
                
            }
        }


        [When(@"I fill all the mandatory details in form(.*),(.*),(.*) and (.*)")]
        public void WhenIFillAllTheMandatoryDetailsInFormSharanAbcGmail_Com(string name,int age,long phone,dynamic email )
        {
            //  Console.WriteLine($"Height is {height}");


            Console.WriteLine($"Name :{name},Age :{age}");
            Console.WriteLine($"Age :{age}");
            Console.WriteLine($"Phone:{phone}");
            Console.WriteLine($"Email:{email}");

            ScenarioContext.Current["InfoNextStep"] = "Step1 Passed";
            Console.WriteLine(ScenarioContext.Current["InfoNextStep"].ToString());

            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>()

            {
                new EmployeeDetails()
                {
                    Name = "sharan",
                    Age = 26,
                    Phone = 9845610338,
                    Email = "Abc@gmail.com"
                },
                
                new EmployeeDetails()
                 {
                     Name = "sachin",
                     Age = 26,
                     Phone = 805010743,
                     Email = "def@gmail.com"
                 },

                new EmployeeDetails()
                 {
                     Name = "Ganesh",
                     Age = 26,
                     Phone = 8050107403,
                     Email = "ghi@gmail.com"
                 }

            };

            //save the value in the scenarioContext
            ScenarioContext.Current.Add("EmpDetails", employeeDetails);

            //Get the value from scenario context
          var empList =   ScenarioContext.Current.Get<IEnumerable<EmployeeDetails>>("EmpDetails");
            foreach(EmployeeDetails emp in empList)
            {
                Console.WriteLine($"The Employee name is :{emp.Name}");
                Console.WriteLine($"The Employee age is :{emp.Age}");
                Console.WriteLine($"The Employee phone is :{emp.Phone}");
                Console.WriteLine($"The Employee email is :{emp.Email}");
                Console.WriteLine("\n");
            }
            Console.WriteLine(ScenarioContext.Current.ScenarioInfo.Title);
            Console.WriteLine(ScenarioContext.Current.CurrentScenarioBlock);
        }

    }
}
