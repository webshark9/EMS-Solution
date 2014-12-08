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
        public void Invalid_FirstName_Test()
        {
            string testInput = "(123)/+Billy-.-";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = false;
            bool actual = employeeObj.SetFirstName(testInput, ref unusedString);

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
        public void Valid_FirstName_Test()
        {
            string testInput = "Matthew";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = true;
            bool actual = employeeObj.SetFirstName(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid first name was found invalid");
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
        public void Invalid_LastName_Test()
        {
            string testInput = "\\\\\\456/////";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = false;
            bool actual = employeeObj.SetFirstName(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid last name was found valid");
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
        public void Valid_LastName_Test()
        {
            string testInput = "Smith";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = true;
            bool actual = employeeObj.SetFirstName(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid last name was found invalid");
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
        public void Valid_SIN_Test()
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
        public void Invalid_DateOfBirth_Test()
        {
            string testInput = "1234567890";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = false;
            bool actual = employeeObj.SetDateOfBirth(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid date of birth was found valid");
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
        public void Valid_DateOfBirth_Test()
        {
            string testInput = "6/15/1994";
            string unusedString = "";
            Employee employeeObj = new Employee();
            bool expected = true;
            bool actual = employeeObj.SetDateOfBirth(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid date of birth was found invalid");
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
        public void Invalid_DateOfHire_Test()
        {
            string testInput = "-98-980-";
            string unusedString = "";
            FulltimeEmployee employeeObj = new FulltimeEmployee();
            bool expected = false;
            bool actual = employeeObj.SetDateOfHire(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid date of hire was found valid");
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
        public void Valid_DateOfHire_Test()
        {
            string testInput = "2011/06/11";
            string unusedString = "";
            FulltimeEmployee employeeObj  = new FulltimeEmployee();
            bool expected = true;
            bool actual = employeeObj.SetDateOfHire(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid date of hire was found invalid");
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
        public void Invalid_DateOfTermination_Test()
        {
            string testInput = "////////";
            string unusedString = "";
            FulltimeEmployee employeeObj = new FulltimeEmployee();
            bool expected = false;
            bool actual = employeeObj.SetDateOfTermination(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid date of termination was found valid");
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
        public void Valid_DateOfTermination_Test()
        {
            string testInput = "2011/06/30";
            string unusedString = "";
            FulltimeEmployee employeeObj = new FulltimeEmployee();
            bool expected = true;
            bool actual = employeeObj.SetDateOfTermination(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid date of termination was found invalid");
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
        public void Invalid_Salary_Test()
        {
            string testInput = "-12.12";
            string unusedString = "";
            FulltimeEmployee employeeObj = new FulltimeEmployee();
            bool expected = false;
            bool actual = employeeObj.SetSalary(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid salary was found valid");
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
        public void Valid_Salary_Test()
        {
            string testInput = "53000.78";
            string unusedString = "";
            FulltimeEmployee employeeObj = new FulltimeEmployee();
            bool expected = true;
            bool actual = employeeObj.SetSalary(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid salary was found invalid");
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
        public void Invalid_HourlyRate_Test()
        {
            string testInput = "0.00";
            string unusedString = "";
            ParttimeEmployee employeeObj = new ParttimeEmployee();
            bool expected = false;
            bool actual = employeeObj.SetHourlyRate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid hourly rate was found valid");
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
        public void Valid_HourlyRate_Test()
        {
            string testInput = "12.45";
            string unusedString = "";
            ParttimeEmployee employeeObj = new ParttimeEmployee();
            bool expected = true;
            bool actual = employeeObj.SetHourlyRate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid hourly rate was found invalid");
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
        public void Invalid_Season_Test()
        {
            string testInput = "november";
            string unusedString = "";
            SeasonalEmployee employeeObj = new SeasonalEmployee();
            bool expected = false;
            bool actual = employeeObj.SetSeason(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid season was found valid");
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
        public void Valid_Season_Test()
        {
            string testInput = "summer";
            string unusedString = "";
            SeasonalEmployee employeeObj = new SeasonalEmployee();
            bool expected = true;
            bool actual = employeeObj.SetSeason(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid season was found invalid");
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
        public void Invalid_PiecePay_Test()
        {
            string testInput = "-45.80";
            string unusedString = "";
            SeasonalEmployee employeeObj = new SeasonalEmployee();
            bool expected = false;
            bool actual = employeeObj.SetPiecePay(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid piece pay was found valid");
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
        public void Valid_PiecePay_Test()
        {
            string testInput = "123.54";
            string unusedString = "";
            SeasonalEmployee employeeObj = new SeasonalEmployee();
            bool expected = true;
            bool actual = employeeObj.SetPiecePay(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid piece pay was found invalid");
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
        public void Invalid_ContractStartDate_Test()
        {
            string testInput = "Matthew Is The BEST Project Manager";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = false;
            bool actual = employeeObj.SetContractStartDate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid contract start date was found valid");
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
        public void Valid_ContractStartDate_Test()
        {
            string testInput = "2012/12/12";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = true;
            bool actual = employeeObj.SetContractStartDate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid contract start date was found invalid");
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
        public void Invalid_ContractStopDate_Test()
        {
            string testInput = "        ";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = false;
            bool actual = employeeObj.SetContractStopDate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid contract stop date was found valid");
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
        public void Valid_ContractStopDate_Test()
        {
            string testInput = "2012/12/13";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = true;
            bool actual = employeeObj.SetContractStopDate(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid contract stop date was found invalid");
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
        public void Invalid_FixedContractAmount_Test()
        {
            string testInput = "-12.123123";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = false;
            bool actual = employeeObj.SetFixedContractAmount(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid fixed contract amount was found valid");
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
        public void Valid_FixedContractAmount_Test()
        {
            string testInput = "12.12";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = true;
            bool actual = employeeObj.SetFixedContractAmount(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid fixed contract amount was found invalid");
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
        public void Invalid_BusinessNumber_Test()
        {
            string testInput = "123234345";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = false;
            bool actual = employeeObj.SetBusinessNumber(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Invalid business number contract amount was found valid");
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
        public void Valid_BusinessNumber_Test()
        {
            string testInput = "333333334";
            string unusedString = "";
            ContractEmployee employeeObj = new ContractEmployee();
            bool expected = true;
            bool actual = false;

            employeeObj.SetDateOfBirth("1933/12/12", ref unusedString);
            actual = employeeObj.SetBusinessNumber(testInput, ref unusedString);

            Assert.AreEqual(expected, actual, "Valid business number amount was found invalid");
        }
    }
}
