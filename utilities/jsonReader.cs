using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Amazon.utilities
{
    public class jsonReader
    {
        public jsonReader()
        {

        }
        public string extractData(String tokenName)
        {
            var myJsonString = File.ReadAllText(@"G:\SeleniumAutomationCsharp\Sapc1234\AmazonCSharpSharan\utilities\TestData.json");
            var jsonobject = JToken.Parse(myJsonString);
            //Console.WriteLine(jsonobject.SelectToken("Usrname").Value<string>());
            return jsonobject.SelectToken(tokenName).Value<string>();
        }
    }
}

    
