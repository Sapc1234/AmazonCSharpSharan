using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Amazon.StepDefinitionFile
{
    [Binding]
    public  class ExtendedSteps
    {
        public readonly EmployeeDetails employee;
      public ExtendedSteps(EmployeeDetails emp)
        {
            this.employee = emp;
        }

        [Then(@"i should get the same value from the Extended steps")]
        public void ThenIShouldGetTheSameValueFromTheExtendedSteps()
        {
            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Age);
            Console.WriteLine(employee.Email);
            Console.WriteLine(employee.Phone);
        }

    }
}
