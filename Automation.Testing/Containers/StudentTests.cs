﻿using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void SearchStudentUiTest()
        {
            var actual = new SearchStudents().Execute().Actual;
            Assert.IsTrue(actual);
        }
    }
}
