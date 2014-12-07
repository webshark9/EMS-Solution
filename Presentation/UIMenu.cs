﻿/// \namespace Presentation
/// 
/// \brief Contains the UIMenu class
/// 
/// File: UIMenu.cs \n
/// Project: EMS Term Project \n
/// First Version: Nov.20/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

// Self Note:
// - Give user the feedback for anything that happened.
// - ANYTHING displayed on the screen is done by presentation. Need more classes.
// - Make testing harness reuseable
// - Create a static method(?) for printing error messages
// - Test plan document will be part of the test harness

using System;
using System.Collections.Generic;
using System.Text;
using AllEmployees;
using TheCompany;
using Supporting;


namespace Presentation
{
    /// \class UIMenu
    /// 
    /// \brief Displays and handles user interface
    /// 
    /// File: UIMenu.cs \n
    /// Project: EMS Term Project \n
    /// First Version: Nov.20/2014 \n
    ///
    /// This file contains UI class which allows user to navigate through multiple 
    /// options to access different functionalities of the program.
    /// 
    /// Menu map:
    /// 
    /// - Main Menu
    ///     - Manage DBase files 
    ///         - Load EMS DBase from file
    ///         - Save Employee Set to EMS DBase file
    ///         - Return to Main Menu
    ///     - Manage Employees 
    ///         - Display Employee Set 
    ///             - Display all employees
    ///             - Search Employee(s)
    ///                 - Search by first name
    ///                 - Search by last name
    ///                 - Search by SIN
    ///                     (Display Matching Employee(s))
    ///                     - Return to Search Employee(s)
    ///                 - Return to Display Employee Set
    ///             - Return to Manage Employees
    ///         - Create a New Employee 
    ///             - Specify Employee Details
    ///             - Save
    ///             - Return to Manage Employees
    ///         - Modify an Existing Employee 
    ///             (Search Employee(s))
    ///             - Search by first name
    ///             - Search by last name
    ///             - Search by SIN
    ///                 (Display Matching Employee(s))
    ///                 - Select Employee
    ///                     (Modify Employee)
    ///                     - Save
    ///                     - Cancel
    ///                 - Return to Search Employee(s)
    ///             - Return to Manage Employees
    ///         - Remove an Existing Employee 
    ///             (Search Employee(s))
    ///             - Search by first name
    ///             - Search by last name
    ///             - Search by SIN
    ///                 (Display Matching Employee(s))
    ///                 - Select Employee
    ///                     - Confirmation Yes
    ///                     - Confirmation No
    ///             - Return to Manage Employees
    ///         - Return to Main Menu
    ///     - Exit EMS
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Ueng, and Tylor McLaughlin
    public class UIMenu
    {
        private Container companyContainer;

        /**
        * \brief Displays the Main Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in main menu, then get 
        * user input to lead to different method.
        *
        * Available options:
        * 
        * Manage DBase Files
        * Manage Employees
        * Exit EMS
        * 
        * \param None
        * 
        * \return Nothing is returned
        */

        // string sampleDataMember; ///< this is the commenting style for class data member.

        public void MainMenu()
        {
            ConsoleKeyInfo userInput;
            bool exit = false;

            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Manage Data Base Files");
                Console.WriteLine("\t2. Manage Employees");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Save and Exit EMS");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        ManageDBaseFilesMenu();
                        break;

                    case '2':
                        ManageEmployeesMenu();
                        break;

                    case '9':
                        SaveAndExitProgram();
                        exit = true;
                        break;
                }
            }
        }

        /**
        * \brief Displays the Manage DBase Files Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Manage DBase Files Menu, 
        * then take an user input to lead to different methods.
        * 
        * Available options:
        * 
        * Load EMS DBase from file
        * Save Employee Set to EMS DBase file
        * Return to Main Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void ManageDBaseFilesMenu()
        {
            ConsoleKeyInfo userInput;
            string errorMessage = "";
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("FILE MANAGEMENT MENU:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Load EMS Data Base From File");
                Console.WriteLine("\t2. Save Employee Set To EMS Data Base File");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Main Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        companyContainer = new Container(FileIO.OpenDBase("EMS_DB_FILE.txt", ref errorMessage));
                        Console.Clear();
                        Console.WriteLine("FILE HAS BEEN LOADED");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to continue...");
                        userInput = Console.ReadKey();
                        break;

                    case '2':

                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        /**
        * \brief Displays the Manage Employees Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Manage Employees Menu, then 
        * take an user input to lead to different methods.
        * 
        * Available options:
        * 
        * Display Employee Set
        * Create a New Employee
        * Modify an existing employee
        * Remove an existing employee
        * Return to Main Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void ManageEmployeesMenu()
        {
            ConsoleKeyInfo userInput;
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("EMPLOYEE MANAGMENT MENU:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Display Employee Set");
                Console.WriteLine("\t2. Create A New Employee");
                Console.WriteLine("\t3. Modify An Existing Employee");
                Console.WriteLine("\t4. Remove An Existing Employee");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Main Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        DisplayEmployeeSetMenu();
                        break;

                    case '2':
                        CreateANewEmployeeMenu();
                        break;

                    case '3':
                        ModifyAnExistingEmployeeMenu();
                        break;

                    case '4':
                        RemoveAnExistingEmployeeMenu();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }

        }

        /**
        * \brief Displays the Display Employee Set Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Display Employee Set Menu, 
        * then take an user input to lead to different methods.
        * 
        * Available options:
        * 
        * Display all employees
        * Search specific employee
        * Return to Manage Employees Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void DisplayEmployeeSetMenu()
        {
            ConsoleKeyInfo userInput;
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("DISPLAY EMPLOYEE SET:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Display All Employees");
                Console.WriteLine("\t2. Search Specific Employee");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        DisplayAllEmployees();
                        break;

                    case '2':
                        SearchEmployeeMenu();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        /**
        * \brief Displays the Create a New Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Create a New Employee Menu, 
        * then take an user input to lead to employee creation of different employee types.
        * 
        * Available options:
        * 
        * Full Time Employee
         * Part Time Employee
         * Contract Emplployee
         * Seasonal Employee
        * Return to Manage Employee Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateANewEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            bool back = false;

            while (back == false)
            {
                Console.Clear();
//                Console.WriteLine("Create a New Employee:");
//                Console.WriteLine("");
                Console.WriteLine("CHOOSE EMPLOYEE TYPE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Full-time Employee");
                Console.WriteLine("\t2. Part-time Employee");
                Console.WriteLine("\t3. Contract Employee");
                Console.WriteLine("\t4. Seasonal Employee");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        CreateFulltimeEmployee();
                        break;

                    case '2':
                        CreateParttimeEmployee();
                        break;

                    case '3':
                        CreateContractEmployee();
                        break;

                    case '4':
                        CreateSeasonalEmployee();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }


        /**
        * \brief Makes new full-time employee
        *
        * \details <b>Details</b>
        *
        * Creates a new FulltimeEmployee() and pass it to ModifyFulltimeEmployee to 
         * edit. Since there is no old record to remove the return value of 
         * ModifyFulltimeEmployee does not matter.
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateFulltimeEmployee()
        {
            FulltimeEmployee empObj = new FulltimeEmployee();

            ModifyFulltimeEmployee(empObj, true);
        }

        /**
        * \brief Makes new part-time employee
        *
        * \details <b>Details</b>
        *
        * Creates a new ParttimeEmployee() and pass it to ModifyParttimeEmployee to 
         * edit. Since there is no old record to remove the return value of 
         * ModifyParttimeEmployee does not matter.
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateParttimeEmployee()
        {
            ParttimeEmployee empObj = new ParttimeEmployee();

            ModifyParttimeEmployee(empObj, true);
        }

        /**
        * \brief Makes new contract employee
        *
        * \details <b>Details</b>
        *
        * Creates a new ContractEmployee() and pass it to ModifyContractEmployee to 
         * edit. Since there is no old record to remove the return value of 
         * ModifyContractEmployee does not matter.
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateContractEmployee()
        {
            ContractEmployee empObj = new ContractEmployee();

            ModifyContractEmployee(empObj, true);
        }

        /**
        * \brief Makes new seasonal employee
        *
        * \details <b>Details</b>
        *
        * Creates a new SeasonalEmployee() and pass it to ModifySeasonalEmployee to 
         * edit. Since there is no old record to remove the return value of 
         * ModifySeasonalEmployee does not matter.
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateSeasonalEmployee()
        {
            SeasonalEmployee empObj = new SeasonalEmployee();
            ModifySeasonalEmployee(empObj, true);
        }

        
        /**
        * \brief Displays the Modify an Existing Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method first calls the searchEmployees method. Once an employee has been 
        * selected, it will then display the options available in Modify an Existing 
        * Employee Menu, then get user input to lead to different methods.
        * 
        * Available options (after search):
        * 
        * Search By First Name
         * Search By Last Name/Business Name
         * Search By SIN/Business number
        * Return to Manage Employee Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void ModifyAnExistingEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("MODIFY AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By SIN/Business Number");
                Console.WriteLine("\t2. ----------");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        theObj = SearchBySIN("Search By SIN/BN To Modify:");
                        break;

                    case '2':
                        SearchFirstNameUI();
                        break;

                    case '3':
                        SearchLastNameUI();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        /**
        * \brief UI of full time employee modification
        *
        * \details <b>Details</b>
        *
        * This method will give user the option to enter each element of a full time 
         * employee. The elements that have been entered will also be displayed. 
         * User can choose to save the employee data in this menu.
        * 
        * Available options:
        * 
        * First Name
         * Last Name
         * SIN
         * Date of Birth
         * Date of Hire
         * Date of Termination
         * Salary
         * Save and Return to Manage Employee Menu
        * Return to Manage Employee Menu Without Saving
        * 
        * \param
         * FulltimeEmployee theObj: The employee object. Only used for initializing 
         *                          attributes.
         * isNew: whether the object is a new one (empty) or an existing one (not empty).
        * 
        * \return bool: whether the base object should be deleted (only apply to existing 
         *              object).
        * 
        */
        private bool ModifyFulltimeEmployee(FulltimeEmployee theObj, bool isNew)
        {
            ConsoleKeyInfo userInput;
            DateTime defaultDateTime = new DateTime();
            string userInputSentence = "";
            string errorMessage = "";
            bool back = false;
            bool removeOld = false;
            bool saveSuccess = false;

            while (back == false)
            {
                userInputSentence = "";
                Console.Clear();
                if (isNew == true)
                {
                    Console.WriteLine("CREATE A FULL-TIME EMPLOYEE:");
                }
                else
                {
                    Console.WriteLine("MODIFY A FULL-TIME EMPLOYEE:");
                }
                Console.WriteLine("");
                Console.WriteLine("\t1. Edit First Name");
                Console.WriteLine("\t2. Edit Last Name");
                Console.WriteLine("\t3. Edit SIN");
                Console.WriteLine("\t4. Edit Date of Birth");
                Console.WriteLine("\t5. Edit Date of Hire");
                Console.WriteLine("\t6. Edit Date of Termination");
                Console.WriteLine("\t7. Edit Salary");
                Console.WriteLine("\t8. Save Entry");
                Console.WriteLine("\t9. Return To Choose Employee Type");
                Console.WriteLine("");
                Console.WriteLine("CURRENT INFO:");
                Console.WriteLine("");
                Console.WriteLine("{0}", theObj.Details());
//                Console.WriteLine("First Name: {0}", theObj.GetFirstName());
//                Console.WriteLine("Last Name: {0}", theObj.GetLastName());
//                Console.WriteLine("SIN: {0}", theObj.GetSocialInsuranceNumber());
////                Console.WriteLine("SIN: {0}", displaySIN(theObj.GetSocialInsuranceNumber()));

//                if (DateTime.Compare(theObj.GetDateOfBirth(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Birth: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Birth: {0}", theObj.GetDateOfBirth());
//                }

//                if (DateTime.Compare(theObj.GetDateOfHire(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Hire: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Hire: {0}", theObj.GetDateOfHire());
//                }

//                if (DateTime.Compare(theObj.GetDateOfTermination(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Termination: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Termination: {0}", theObj.GetDateOfTermination());
//                }


//                Console.WriteLine("Salary: ${0}", theObj.GetSalary());

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        {
                            userInputSentence = TakeUserInputSentence("Enter First Name: ");
                            theObj.SetFirstName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '2':
                        {
                            userInputSentence = TakeUserInputSentence("Enter Last Name: ");
                            theObj.SetLastName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '3':
                        {
                            userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                            theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '4':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Birth (yyyy/mm/dd): ");
                            theObj.SetDateOfBirth(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '5':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Hire (yyyy/mm/dd): ");
                            theObj.SetDateOfHire(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '6':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Termination (yyyy/mm/dd): ");
                            theObj.SetDateOfTermination(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '7':
                        {
                            userInputSentence = TakeUserInputMoney("Enter Salary (2 decimal degits required): ");
                            theObj.SetSalary(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '8':
                        {
                            // uh don't know what to call to push the object into the container.
                            saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            if (saveSuccess == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Save Successful!");
                                userInput = Console.ReadKey();
                                if (isNew == false)
                                {
                                    removeOld = true;
                                }
                            }
                            else
                            {
                                PrintErrorMessage(errorMessage);
                            }

                        }
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
            return removeOld;
        }

        /**
        * \brief UI of part time employee modification
        *
        * \details <b>Details</b>
        *
        * This method will give user the option to enter each element of a part time 
         * employee. The elements that have been entered will also be displayed. 
         * User can choose to save the employee data in this menu.
        * 
        * Available options:
        * 
        * First Name
         * Last Name
         * SIN
         * Date of Birth
         * Date of Hire
         * Date of Termination
         * Hourly Rate
         * Save and Return to Manage Employee Menu
        * Return to Manage Employee Menu Without Saving
        * 
        * \param
         * ParttimeEmployee theObj: The employee object. Only used for initializing 
         *                          attributes.
         * isNew: whether the object is a new one (empty) or an existing one (not empty).
        * 
        * \return bool: whether the base object should be deleted (only apply to existing 
         *              object).
        * 
        */
        private bool ModifyParttimeEmployee(ParttimeEmployee theObj, bool isNew)
        {
            ConsoleKeyInfo userInput;
            DateTime defaultDateTime = new DateTime();
            string userInputSentence = "";
            string errorMessage = "";
            bool back = false;
            bool removeOld = false;
            bool saveSuccess = false;

            while (back == false)
            {
                userInputSentence = "";
                Console.Clear();
                if (isNew == true)
                {
                    Console.WriteLine("CREATE A PART-TIME EMPLOYEE:");
                }
                else
                {
                    Console.WriteLine("MODIFY A PART-TIME EMPLOYEE:");
                }
                Console.WriteLine("");
                Console.WriteLine("\t1. Edit First Name");
                Console.WriteLine("\t2. Edit Last Name");
                Console.WriteLine("\t3. Edit SIN");
                Console.WriteLine("\t4. Edit Date of Birth");
                Console.WriteLine("\t5. Edit Date of Hire");
                Console.WriteLine("\t6. Edit Date of Termination");
                Console.WriteLine("\t7. Edit Hourly Rate");
                Console.WriteLine("\t8. Save Entry");
                Console.WriteLine("\t9. Return To Choose Employee Type");
                Console.WriteLine("");
                Console.WriteLine("CURRENT INFO:");
                Console.WriteLine("");
//                Console.WriteLine("{0}", theObj.Details());
//                Console.WriteLine("First Name: {0}", theObj.GetFirstName());
//                Console.WriteLine("Last Name: {0}", theObj.GetLastName());
//                Console.WriteLine("SIN: {0}", theObj.GetSocialInsuranceNumber());
////                Console.WriteLine("SIN: {0}", displaySIN(theObj.GetSocialInsuranceNumber()));
//                if (DateTime.Compare(theObj.GetDateOfBirth(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Birth: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Birth: {0}", theObj.GetDateOfBirth());
//                }

//                if (DateTime.Compare(theObj.GetDateOfHire(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Hire: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Hire: {0}", theObj.GetDateOfHire());
//                }

//                if (DateTime.Compare(theObj.GetDateOfTermination(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Termination: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Termination: {0}", theObj.GetDateOfTermination());
//                }


//                Console.WriteLine("Hourly Rate: ${0}", theObj.GetHourlyRate());

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        {
                            userInputSentence = TakeUserInputSentence("Enter First Name: ");
                            theObj.SetFirstName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '2':
                        {
                            userInputSentence = TakeUserInputSentence("Enter Last Name: ");
                            theObj.SetLastName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '3':
                        {
                            userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                            theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '4':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Birth (yyyy/mm/dd): ");
                            theObj.SetDateOfBirth(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '5':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Hire (yyyy/mm/dd): ");
                            theObj.SetDateOfHire(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '6':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Termination (yyyy/mm/dd): ");
                            theObj.SetDateOfTermination(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '7':
                        {
                            userInputSentence = TakeUserInputMoney("Enter Hourly Rate (2 decimal degits required): ");
                            theObj.SetHourlyRate(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '8':
                        {
                            // uh don't know what to call to push the object into the container.
                            saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            if (saveSuccess == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Save Successful!");
                                userInput = Console.ReadKey();
                                if (isNew == false)
                                {
                                    removeOld = true;
                                }
                            }
                            else
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
            return removeOld;
        }

        /**
        * \brief UI of contract employee modification
        *
        * \details <b>Details</b>
        *
        * This method will give user the option to enter each element of a contract 
         * employee. The elements that have been entered will also be displayed. 
         * User can choose to save the employee data in this menu.
        * 
        * Available options:
        * 
        * Corporation Name (stored in Last Name)
         * Business Number
         * Date of Incorporation (stored in Date of Birth)
         * Contract Start Date
         * Contract Stop Date
         * Fixed Contract Amount
         * Save and Return to Manage Employee Menu
        * Return to Manage Employee Menu Without Saving
        * 
        * \param
         * ContractEmployee theObj: The employee object. Only used for initializing 
         *                          attributes.
         * isNew: whether the object is a new one (empty) or an existing one (not empty).
        * 
        * \return bool: whether the base object should be deleted (only apply to existing 
         *              object).
        * 
        */
        private bool ModifyContractEmployee(ContractEmployee theObj, bool isNew)
        {
            ConsoleKeyInfo userInput;
            DateTime defaultDateTime = new DateTime();
            string userInputSentence = "";
            string errorMessage = "";
            bool back = false;
            bool removeOld = false;
            bool saveSuccess = false;

            while (back == false)
            {
                userInputSentence = "";
                Console.Clear();
                if (isNew == true)
                {
                    Console.WriteLine("CREATE A CONTRACT EMPLOYEE:");
                }
                else
                {
                    Console.WriteLine("MODIFY A CONTRACT EMPLOYEE:");
                }
                Console.WriteLine("");
                Console.WriteLine("\t1. Edit Business Name");
                Console.WriteLine("\t2. Edit Business Number");
                Console.WriteLine("\t3. Edit Date of Incorporation");
                Console.WriteLine("\t4. Edit Contract Start Date");
                Console.WriteLine("\t5. Edit Contract Stop Date");
                Console.WriteLine("\t6. Edit Fixed Contract Amount");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. Save Entry");
                Console.WriteLine("\t9. Return To Choose Employee Type");
                Console.WriteLine("");
                Console.WriteLine("CURRENT INFO:");
                Console.WriteLine("");
                Console.WriteLine("{0}", theObj.Details());

//                Console.WriteLine("Business Name: {0}", theObj.GetLastName());
//                Console.WriteLine("Business Number: {0}", theObj.GetSocialInsuranceNumber());
////                Console.WriteLine("Business Number: {0}", displayBN(theObj.GetSocialInsuranceNumber()));
//
//                if (DateTime.Compare(theObj.GetDateOfBirth(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Incorporation: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Incorporation: {0}", theObj.GetDateOfBirth());
//                }

//                if (DateTime.Compare(theObj.GetContractStartDate(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Contract Start Date: ");
//                }
//                else
//                {
//                    Console.WriteLine("Contract Start Date: {0}", theObj.GetContractStartDate());
//                }

//                if (DateTime.Compare(theObj.GetContractStopDate(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Contract Stop Date: ");
//                }
//                else
//                {
//                    Console.WriteLine("Contract Stop Date: {0}", theObj.GetContractStopDate());
//                }


//                Console.WriteLine("Fixed Contract Amount: ${0}", theObj.GetFixedContractAmount());

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        {
                            userInputSentence = TakeUserInputSentence("Enter Business Name: ");
                            theObj.SetLastName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '2':
                        {
                            userInputSentence = TakeUserInputSIN("Enter Business Number: ");
                            theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '3':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Incorporation (yyyy/mm/dd): ");
                            theObj.SetDateOfBirth(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '4':
                        {
                            userInputSentence = TakeUserInputDate("Enter Contract Start Date (yyyy/mm/dd): ");
                            theObj.SetContractStartDate(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '5':
                        {
                            userInputSentence = TakeUserInputDate("Enter Contract Stop Date (yyyy/mm/dd): ");
                            theObj.SetContractStopDate(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '6':
                        {
                            userInputSentence = TakeUserInputMoney("Enter Fixed Contract Amount (2 decimal degits required): ");
                            theObj.SetFixedContractAmount(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '8':
                        {
                            // uh don't know what to call to push the object into the container.
                            saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            if (saveSuccess == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Save Successful!");
                                userInput = Console.ReadKey();
                                if (isNew == false)
                                {
                                    removeOld = true;
                                }
                            }
                            else
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
            return removeOld;
        }

        /**
        * \brief UI of seasonal employee modification
        *
        * \details <b>Details</b>
        *
        * This method will give user the option to enter each element of a seasonal 
         * employee. The elements that have been entered will also be displayed. 
         * User can choose to save the employee data in this menu.
        * 
        * Available options:
        * 
        * First Name
         * Last Name
         * SIN
         * Season
         * Piece Pay
         * Save and Return to Manage Employee Menu
        * Return to Manage Employee Menu Without Saving
        * 
        * \param
         * SeasonalEmployee theObj: The employee object. Only used for initializing 
         *                          attributes.
         * isNew: whether the object is a new one (empty) or an existing one (not empty).
        * 
        * \return bool: whether the base object should be deleted (only apply to existing 
         *              object).
        * 
        */
        private bool ModifySeasonalEmployee(SeasonalEmployee theObj, bool isNew)
        {
            ConsoleKeyInfo userInput;
            DateTime defaultDateTime = new DateTime();
            string userInputSentence = "";
            string errorMessage = "";
            bool back = false;
            bool removeOld = false;
            bool saveSuccess = false;

            while (back == false)
            {
                userInputSentence = "";
                Console.Clear();
                if (isNew == true)
                {
                    Console.WriteLine("CREATE A SEASONAL EMPLOYEE:");
                }
                else
                {
                    Console.WriteLine("MODIFY A SEASONAL EMPLOYEE:");
                }
                Console.WriteLine("");
                Console.WriteLine("\t1. Edit First Name");
                Console.WriteLine("\t2. Edit Last Name");
                Console.WriteLine("\t3. Edit SIN");
                Console.WriteLine("\t4. Edit Date of Birth");
                Console.WriteLine("\t5. Edit Season");
                Console.WriteLine("\t6. Edit Piece Pay");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. Save Entry");
                Console.WriteLine("\t9. Return To Choose Employee Type");
                Console.WriteLine("");
                Console.WriteLine("CURRENT INFO:");
                Console.WriteLine("");
                Console.WriteLine("{0}", theObj.Details());
//                Console.WriteLine("First Name: {0}", theObj.GetFirstName());
//                Console.WriteLine("Last Name: {0}", theObj.GetLastName());
//                Console.WriteLine("SIN: {0}", theObj.GetSocialInsuranceNumber());
////                Console.WriteLine("SIN: {0}", displaySIN(theObj.GetSocialInsuranceNumber()));
//
//                if (DateTime.Compare(theObj.GetDateOfBirth(), defaultDateTime) == 0)
//                {
//                    Console.WriteLine("Date of Birth: ");
//                }
//                else
//                {
//                    Console.WriteLine("Date of Birth: {0}", theObj.GetDateOfBirth());
//                }
//                Console.WriteLine("Season: {0}", theObj.GetSeason());
//                Console.WriteLine("Piece Pay: ${0}", theObj.GetPiecePay());

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        {
                            userInputSentence = TakeUserInputSentence("Enter First Name: ");
                            theObj.SetFirstName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '2':
                        {
                            userInputSentence = TakeUserInputSentence("Enter Last Name: ");
                            theObj.SetLastName(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '3':
                        {
                            userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                            theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '4':
                        {
                            userInputSentence = TakeUserInputDate("Enter Date of Birth (yyyy/mm/dd): ");
                            theObj.SetDateOfBirth(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '5':
                        {
                            userInputSentence = ChooseSeason();
                            theObj.SetSeason(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '6':
                        {
                            userInputSentence = TakeUserInputMoney("Enter Piece Pay (2 decimal degits required): ");
                            theObj.SetPiecePay(userInputSentence, ref errorMessage);
                            if (errorMessage != "")
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '8':
                        {
                            // uh don't know what to call to push the object into the container.
                            saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            if (saveSuccess == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Save Successful!");
                                userInput = Console.ReadKey();
                                if (isNew == false)
                                {
                                    removeOld = true;
                                }
                            }
                            else
                            {
                                PrintErrorMessage(errorMessage);
                            }
                        }
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
            return removeOld;
        }
        /**
        * \brief Displays the Remove an Existing Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will take the user to the searchEmployee method. Once an employee 
        * is selected, it will ask user with confirmation of whether the employee 
        * should be deleted.
        * 
        * Available options (after search) (for confirmation):
        * 
        * Search by First Name
         * Search by last name/business name
         * search by sin/bn
         * return to employee management menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void RemoveAnExistingEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("REMOVE AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By SIN/Business Number");
                Console.WriteLine("\t2. ----------");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        theObj = SearchBySIN("Search By SIN/BN To Remove:");
                        break;

                    case '2':
                        SearchFirstNameUI();
                        break;

                    case '3':
                        SearchLastNameUI();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        /**
        * \brief This method handles the user interface portion of searching for an employee
        *
        * \details <b>Details</b>
        *
        * This method will first prompt user to choose the parameter for the search 
        * (first name, last name, or SIN) then call the proper method from a different 
        * class library to perform the search. After the search is completed, all matching 
        * employees will be displayed on the screen. The user will choose one of the 
        * displayed employee, and the record of that employee will be the return value.
        * 
        * \param None
        * 
        * \return string - the employee record of the search result..
        */
        private void SearchEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("DISPLAY AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By SIN/Business Number");
                Console.WriteLine("\t2. ----------");
                Console.WriteLine("\t3. ----------");
                Console.WriteLine("\t4. ----------");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        theObj = SearchBySIN("Search By SIN/BN To Display:");
                        break;

                    case '2':
                        SearchFirstNameUI();
                        break;

                    case '3':
                        SearchLastNameUI();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }



        private void DisplayAllEmployees()
        {
            ConsoleKeyInfo userInput;
            Employee currentObj = new Employee();
            int counter = 0;
            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();

            Console.Clear();

            currentObj = (Employee)companyContainer.NextEmployee(true);

            while (currentObj != null)
            {
                
                if (currentObj.GetType() == FtEmployee.GetType())
                {
                    FtEmployee = (FulltimeEmployee)currentObj;
                    Console.WriteLine("{0}", FtEmployee.Details());
                }
                else if (currentObj.GetType() == PtEmployee.GetType())
                {
                    PtEmployee = (ParttimeEmployee)currentObj;
                    Console.WriteLine("{0}", PtEmployee.Details());
                }
                else if (currentObj.GetType() == CtEmployee.GetType())
                {
                    CtEmployee = (ContractEmployee)currentObj;
                    Console.WriteLine("{0}", CtEmployee.Details());
                }
                else if (currentObj.GetType() == SnEmployee.GetType())
                {
                    SnEmployee = (SeasonalEmployee)currentObj;
                    Console.WriteLine("{0}", SnEmployee.Details());
                }
                currentObj = (Employee)companyContainer.NextEmployee();

                if (counter >= 3 || currentObj == null)
                {
                    Console.WriteLine("Press any key to continue...");
                    userInput = Console.ReadKey();
                }
            }
        }

        private void DisplaySingleEmployee(Employee theObj)
        {
            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();

//            if (theObj.GetType() == FtEmployee.GetType())
//            { }

        }

        private void ModifySingleEmployee(Employee theObj)
        {
            
        }


        private void SearchFirstNameUI()
        {

        }

        private void SearchLastNameUI()
        {

        }

        private Employee SearchBySIN(string displayOrModifyOrRemove)
        {
            string searchParameter = "";
            Employee theObj = new Employee();

            searchParameter = TakeUserInputSIN(displayOrModifyOrRemove);

            theObj = (Employee)companyContainer.NextEmployee(true);

            while (theObj != null)
            {
                if (theObj.GetSocialInsuranceNumber() == searchParameter)
                {
                    break;
                }
                else
                {
                    theObj = (Employee)companyContainer.NextEmployee();
                }
            }

            return theObj;
        }
        
        private void LoadFromFileUI()
        {

        }

        private void SaveToFileUI()
        {

        }

        private void SpecifyEmployeeDetailsUI()
        {

        }

        private void SpecifyFirstNameUI()
        {

        }

        private void SpecifyLastNameUI()
        {

        }

        private void SpecifySINUI()
        {

        }

        private void SaveEmployeeUI()
        {

        }

        private void ModifyEmployeeUI()
        {

        }

        private void DeleteConfirmationUI()
        {

        }

        private void SaveAndExitProgram()
        {
            Console.Clear();
        }

        private int TakeUserInputNumber()
        {
            ConsoleKeyInfo userInput;
            int userInputNumber = -1;

            userInput = Console.ReadKey();

            switch (userInput.KeyChar)
            {
                case '0':
                    userInputNumber = 0;
                    break;

                case '1':
                    userInputNumber = 1;
                    break;

                case '2':
                    userInputNumber = 2;
                    break;

                case '3':
                    userInputNumber = 3;
                    break;

                case '4':
                    userInputNumber = 4;
                    break;

                case '5':
                    userInputNumber = 5;
                    break;

                case '6':
                    userInputNumber = 6;
                    break;

                case '7':
                    userInputNumber = 7;
                    break;

                case '8':
                    userInputNumber = 8;
                    break;

                case '9':
                    userInputNumber = 9;
                    break;

                case '.':
                    userInputNumber = -3;
                    break;

            }
            if (userInput.Key == ConsoleKey.Backspace)
            {
                userInputNumber = -2;
            }


            return userInputNumber;
        }

        private string TakeUserInputSentence(string nameType)
        {
            string currentInput = "";
            Console.Clear();
            Console.WriteLine("{0}", nameType);
            currentInput = Console.ReadLine();
            return currentInput;
        }

        private string TakeUserInputSIN(string sinOrBN)
        {
            string currentInput = "";
            int userInputNumber = 0;
            int counter = 0;

            if (sinOrBN.Contains("Search"))
            {
                while (counter < 9)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", sinOrBN);
                    Console.WriteLine("{0}", currentInput);
                    userInputNumber = TakeUserInputNumber();

                    if (userInputNumber == -2 && currentInput.Length > 0)
                    {
                        currentInput = currentInput.Remove(currentInput.Length - 1);
                        counter = counter - 1;
                    }
                    else if (userInputNumber > -1)
                    {
                        currentInput += userInputNumber.ToString();
                        counter = counter + 1;
                    }

                }
            }
            else if (sinOrBN.Contains("Social"))
            {
                while (counter < 11)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", sinOrBN);
                    Console.WriteLine("{0}", currentInput);
                    userInputNumber = TakeUserInputNumber();

                    if (userInputNumber == -2 && currentInput.Length > 0)
                    {
                        if (counter == 4 || counter == 8)
                        {
                            currentInput = currentInput.Remove(currentInput.Length - 2);
                            counter = counter - 2;
                        }
                        else
                        {
                            currentInput = currentInput.Remove(currentInput.Length - 1);
                            counter = counter - 1;
                        }
                    }
                    else if (userInputNumber > -1)
                    {
                        currentInput += userInputNumber.ToString();
                        counter = counter + 1;
                        if (counter == 3 || counter == 7)
                        {
                            counter = counter + 1;
                            currentInput += " ";
                        }
                    }

                }
            }
            else
            {
                while (counter < 10)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", sinOrBN);
                    Console.WriteLine("{0}", currentInput);
                    userInputNumber = TakeUserInputNumber();

                    if (userInputNumber == -2 && currentInput.Length > 0)
                    {
                        if (counter == 6)
                        {
                            currentInput = currentInput.Remove(currentInput.Length - 2);
                            counter = counter - 2;
                        }
                        else
                        {
                            currentInput = currentInput.Remove(currentInput.Length - 1);
                            counter = counter - 1;
                        }
                    }
                    else if (userInputNumber > -1)
                    {
                        currentInput += userInputNumber.ToString();
                        counter = counter + 1;
                        if (counter == 5)
                        {
                            counter = counter + 1;
                            currentInput += " ";
                        }
                    }

                }
            }
            Console.Clear();
            Console.WriteLine("{0}", sinOrBN);
            Console.WriteLine("{0}", currentInput);
            return currentInput;
        }




        private string TakeUserInputDate(string whichDate)
        {
            string currentInput = "";
            int userInputNumber = 0;
            int counter = 0;
            while (counter < 10)
            {
                Console.Clear();
                Console.WriteLine("{0}", whichDate);
                Console.WriteLine("{0}", currentInput);
                userInputNumber = TakeUserInputNumber();

                if (userInputNumber == -2 && currentInput.Length > 0)
                {
                    if (counter == 5 || counter == 8)
                    {
                        currentInput = currentInput.Remove(currentInput.Length - 2);
                        counter = counter - 2;
                    }
                    else
                    {
                        currentInput = currentInput.Remove(currentInput.Length - 1);
                        counter = counter - 1;
                    }


                }
                else if (userInputNumber > -1)
                {
                    currentInput += userInputNumber.ToString();
                    counter = counter + 1;
                    if (counter == 4 || counter == 7)
                    {
                        counter = counter + 1;
                        currentInput += "-";
                    }
                }

            }
            Console.Clear();
            Console.WriteLine("{0}", whichDate);
            Console.WriteLine("{0}", currentInput);
            return currentInput;
        }

        private string TakeUserInputMoney(string moneyType)
        {
            string currentInput = "";
            int userInputNumber = 0;
            int centCounter = 0;
            bool decimalFound = false;

            while (centCounter < 2)
            {
                Console.Clear();
                Console.WriteLine("{0}", moneyType);
                Console.WriteLine("${0}", currentInput);
                userInputNumber = TakeUserInputNumber();

                if (userInputNumber == -2 && currentInput.Length > 0)
                {
                    if (currentInput[currentInput.Length - 1] == '.')
                    {
                        decimalFound = false;
                    }
                    if (centCounter > 0)
                    {
                        centCounter = centCounter - 1;
                    }
                    currentInput = currentInput.Remove(currentInput.Length - 1);
                }
                else if (userInputNumber == -3 && decimalFound == false)
                {
                    currentInput += ".";
                    decimalFound = true;
                }
                else if (userInputNumber > -1)
                {
                    currentInput += userInputNumber.ToString();
                    if (decimalFound == true)
                    {
                        centCounter = centCounter + 1;
                    }
                }

            }

            Console.Clear();
            Console.WriteLine("{0}", moneyType);
            Console.WriteLine("${0}", currentInput);
            return currentInput;
        }

        private string displaySIN(string unparsed)
        {
            string parsed = "";

            if (unparsed != "")
            {
                parsed = unparsed.Insert(3, " ");
                unparsed = parsed;
                parsed = unparsed.Insert(7, " ");
            }

            return parsed;
        }

        private string displayBN(string unparsed)
        {
            string parsed = "";

            if (unparsed != "")
            {
                parsed = unparsed.Insert(5, " ");
            }
        
            return parsed;
        }

        /**
         * \brief UI of choosing season for seaonal employee creation
         *
         * \details <b>Details</b>
         *
         * This method allows user to choose one of the four seaon for 
         * setting seasonal employee's seasonal attribute.
         * 
         * Available options:
         * 
         * Spring
         * Summer
         * Fall
         * Winter
         * 
         * \param None
         * 
         * \return Nothing is returned
         * 
         */
        private string ChooseSeason()
        {
            string season = "";
            ConsoleKeyInfo userInput;

            while (season == "")
            {
                Console.Clear();
                Console.WriteLine("SELECT SEASON:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Spring");
                Console.WriteLine("\t2. Summer");
                Console.WriteLine("\t3. Fall");
                Console.WriteLine("\t4. Winter");
                Console.WriteLine("\t5. ----------");
                Console.WriteLine("\t6. ----------");
                Console.WriteLine("\t7. ----------");
                Console.WriteLine("\t8. ----------");
                Console.WriteLine("\t9. ----------");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        season = "Spring";
                        break;

                    case '2':
                        season = "Summer";
                        break;

                    case '3':
                        season = "Fall";
                        break;

                    case '4':
                        season = "Winter";
                        break;
                }

            }
            Console.Clear();
            Console.WriteLine("{0}", season);
            return season;
        }


        private void PrintErrorMessage(string errorMessage)
        {
            ConsoleKeyInfo userInput;
//            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("{0}", errorMessage);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            userInput = Console.ReadKey();
        }

    }
}