/// \namespace Testing
/// 
/// \brief Contains the automated tests for the solution.
/// 
/// File: EmployeeTests.cs \n
/// Project: EMS Term Project \n
/// First Version: Dec.03/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllEmployees;

namespace Testing
{

    [TestClass]
    public class EmployeeTests
    {
        /**
         * \test
         * ID: \n
         * Name: \n
         * Description: \n
         * How is it conducted: \n
         * Type of test: \n
         * Data Used: \n
         * Expected outcome: 'false' return \n
         * Actual outcome: 
         */
        [TestMethod]
        public void Invalid_SIN_Test()
        {
            string testInput = "111111111";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = false;
            bool actual = employeeObj.SetSocialInsuranceNumber(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid SIN was found valid");
        }

        /**
         * \test
         * ID: \n
         * Name: \n
         * Description: \n
         * How is it conducted: \n
         * Type of test: \n
         * Data Used: \n
         * Expected outcome: 'false' return \n
         * Actual outcome: 
         */
        [TestMethod]
        public void Valid_SIN_Test_One()
        {
            string testInput = "333333334";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = true;
            bool actual = employeeObj.SetSocialInsuranceNumber(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid SIN was found invalid");
        }

        /**
         * \test
         * ID: \n
         * Name: \n
         * Description: \n
         * How is it conducted: \n
         * Type of test: \n
         * Data Used: \n
         * Expected outcome: 'false' return \n
         * Actual outcome: 
         */
        [TestMethod]
        public void Valid_SIN_Test_Two()
        {
            string testInput = "534302922";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = true;
            bool actual = employeeObj.SetSocialInsuranceNumber(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid SIN was found invalid");
        }





    }
}
