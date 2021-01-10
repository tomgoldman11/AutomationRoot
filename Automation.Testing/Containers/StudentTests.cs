using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [DataTestMethod]
        [DataRow("{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")] //Json (this is the context, the test parameters, DataDriven)
        public void SearchStudentUiTest(string testParams)
        {
            //Generate Test Parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //Execute with parameters
            var actual = new SearchStudents().WithTestParams(parameters).Execute().Actual;

            //Assert results
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'CHROME','firstName':'cSharp','lastName':'Goldman','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")] //Json (this is the context, the test parameters, DataDriven)
        public void CreateStudentUiTest(string testParams)
        {
            //Generate Test Parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //Execute with parameters
            var actual = new CreateStudent().WithTestParams(parameters).Execute().Actual;

            //Assert results
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void StudentDetailsUiTest(string testParams)
        {
            //Generate Test Parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            //Execute with parameters
            var actual = new StudentDetails().WithTestParams(parameters).Execute().Actual;

            //Assert results
            Assert.IsTrue(actual);
        }
    }
}
