/// \namespace Presentation
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
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class UIMenu
    {
        private Container companyContainer = new Container();

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



                        exit = SaveAndExitProgram();
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
                        LoadFromFile();
                        break;

                    case '2':
                        SaveToFile();
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
                        ModifyEmployeeMenu();
                        break;

                    case '4':
                        RemoveEmployeeMenu();
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
                        DisplaySingleEmployeeMenu();
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
        private void ModifyEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("MODIFY AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By Fist Name");
                Console.WriteLine("\t2. Search By Last Name/Business Name");
                Console.WriteLine("\t3. Search By SIN/Business Number");
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
                        theObj = SearchByFirstName("SEARCH BY FIRST NAME TO MODIFY:");
                        ModifyEmployeeTypeDeterminer(theObj);
                        break;

                    case '2':
                        theObj = SearchByLastName("SEARCH BY LAST NAME/BUSINESS NAME TO MODIFY:");
                        ModifyEmployeeTypeDeterminer(theObj);
                        break;

                    case '3':
                        theObj = SearchBySIN("SEARCH BY SIN/BN TO MODIFY:");
                        ModifyEmployeeTypeDeterminer(theObj);
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        private void ModifyEmployeeTypeDeterminer(Employee theObj)
        {

            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();
            //ConsoleKeyInfo userInput;
            //if (theObj == null)
            //{
            //    Console.WriteLine("NO MATCHING EMPLOYEE FOUND");
            //    Console.WriteLine("");
            //    Console.WriteLine("Press any key to continue...");
            //    userInput = Console.ReadKey();
            //}
            if (theObj != null)
            {
                if (theObj.GetType() == FtEmployee.GetType())
                {
                    FtEmployee = (FulltimeEmployee)theObj;
                    ModifyFulltimeEmployee(FtEmployee, false);
                }
                else if (theObj.GetType() == PtEmployee.GetType())
                {
                    PtEmployee = (ParttimeEmployee)theObj;
                    ModifyParttimeEmployee(PtEmployee, false);
                }
                else if (theObj.GetType() == CtEmployee.GetType())
                {
                    CtEmployee = (ContractEmployee)theObj;
                    ModifyContractEmployee(CtEmployee, false);
                }
                else if (theObj.GetType() == SnEmployee.GetType())
                {
                    SnEmployee = (SeasonalEmployee)theObj;
                    ModifySeasonalEmployee(SnEmployee, false);
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
                if (isNew == true)
                {
                    Console.WriteLine("\t3. Edit SIN");
                }
                else
                {
                    Console.WriteLine("\t3. ----------");
                }
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
                            if (isNew == true)
                            {
                                userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                                theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                                if (errorMessage != "")
                                {
                                    PrintErrorMessage(errorMessage);
                                }
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
                            if (isNew == true)
                            {
                                saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            }
                            else
                            {
                                saveSuccess = companyContainer.ModifyEmployee(theObj, ref errorMessage);
                            }

                            if (saveSuccess == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Save Successful!");
                                userInput = Console.ReadKey();

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
                if (isNew == true)
                {
                    Console.WriteLine("\t3. Edit SIN");
                }
                else
                {
                    Console.WriteLine("\t3. ----------");
                }
                Console.WriteLine("\t4. Edit Date of Birth");
                Console.WriteLine("\t5. Edit Date of Hire");
                Console.WriteLine("\t6. Edit Date of Termination");
                Console.WriteLine("\t7. Edit Hourly Rate");
                Console.WriteLine("\t8. Save Entry");
                Console.WriteLine("\t9. Return To Choose Employee Type");
                Console.WriteLine("");
                Console.WriteLine("CURRENT INFO:");
                Console.WriteLine("");
                Console.WriteLine("{0}", theObj.Details());

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
                            if (isNew == true)
                            {
                                userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                                theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                                if (errorMessage != "")
                                {
                                    PrintErrorMessage(errorMessage);
                                }
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

                            if (isNew == true)
                            {
                                saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            }
                            else
                            {
                                saveSuccess = companyContainer.ModifyEmployee(theObj, ref errorMessage);
                            }

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
                if (isNew == true)
                {
                    Console.WriteLine("\t2. Edit Business Number");
                }
                else
                {
                    Console.WriteLine("\t2. ----------");
                }
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
                            if (isNew == true)
                            {
                                userInputSentence = TakeUserInputSIN("Enter Business Number: ");
                                theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                                if (errorMessage != "")
                                {
                                    PrintErrorMessage(errorMessage);
                                }
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
                            if (isNew == true)
                            {
                                saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            }
                            else
                            {
                                saveSuccess = companyContainer.ModifyEmployee(theObj, ref errorMessage);
                            }
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
                if (isNew == true)
                {
                    Console.WriteLine("\t3. Edit SIN");
                }
                else
                {
                    Console.WriteLine("\t3. ----------");
                }
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
                            if (isNew == true)
                            {
                                userInputSentence = TakeUserInputSIN("Enter Social Insurance Number: ");
                                theObj.SetSocialInsuranceNumber(userInputSentence, ref errorMessage);
                                if (errorMessage != "")
                                {
                                    PrintErrorMessage(errorMessage);
                                }
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
                            if (isNew == true)
                            {
                                saveSuccess = companyContainer.AddEmployee(theObj, ref errorMessage);
                            }
                            else
                            {
                                saveSuccess = companyContainer.ModifyEmployee(theObj, ref errorMessage);
                            }
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
        private void RemoveEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("REMOVE AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By First Name");
                Console.WriteLine("\t2. Search By Last Name/Business Name");
                Console.WriteLine("\t3. Search By SIN/Business Number");
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
                        theObj = SearchByFirstName("SEACH BY FIRST NAME TO REMOVE:");
                        RemoveEmployeeTypeDeterminer(theObj);
                        break;

                    case '2':
                        theObj = SearchByLastName("SEARCH BY LAST NAME/BUSINESS NAME TO REMOVE:");
                        RemoveEmployeeTypeDeterminer(theObj);
                        break;

                    case '3':
                        theObj = SearchBySIN("SEARCH BY SIN/BN TO REMOVE:");
                        RemoveEmployeeTypeDeterminer(theObj);
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        private void RemoveEmployeeTypeDeterminer(Employee theObj)
        {
            ConsoleKeyInfo userInput;
            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();
            string errorMessage = "";

            Console.Clear();

            //if (theObj == null)
            //{
            //    Console.WriteLine("NO MATCHING EMPLOYEE FOUND");
            //    Console.WriteLine("");
            //}
            if (theObj != null)
            {
                if (RemovalConfirmationUI(theObj) == true)
                {
                    if (theObj.GetType() == FtEmployee.GetType())
                    {
                        FtEmployee = (FulltimeEmployee)theObj;
                        companyContainer.RemoveEmployee(FtEmployee, ref errorMessage);
                    }
                    else if (theObj.GetType() == PtEmployee.GetType())
                    {
                        PtEmployee = (ParttimeEmployee)theObj;
                        companyContainer.RemoveEmployee(PtEmployee, ref errorMessage);
                    }
                    else if (theObj.GetType() == CtEmployee.GetType())
                    {
                        CtEmployee = (ContractEmployee)theObj;
                        companyContainer.RemoveEmployee(CtEmployee, ref errorMessage);
                    }
                    else if (theObj.GetType() == SnEmployee.GetType())
                    {
                        SnEmployee = (SeasonalEmployee)theObj;
                        companyContainer.RemoveEmployee(SnEmployee, ref errorMessage);
                    }

                    if (errorMessage != "")
                    {
                        PrintErrorMessage(errorMessage);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("EMPLOYEE HAS BEEN REMOVED");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to continue...");
                        userInput = Console.ReadKey();
                    }
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
        private void DisplaySingleEmployeeMenu()
        {
            ConsoleKeyInfo userInput;
            Employee theObj = new Employee();
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("DISPLAY AN EMPLOYEE:");
                Console.WriteLine("");
                Console.WriteLine("\t1. Search By First Name");
                Console.WriteLine("\t2. Search By Last Name/Business Name");
                Console.WriteLine("\t3. Search By SIN/Business Number");
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
                        theObj = SearchByFirstName("SEARCH BY FIRST NAME TO DISPLAY:");
                        DisplaySingleEmployeTypeDeterminer(theObj);

                        break;

                    case '2':
                        theObj = SearchByLastName("SEARCH BY LAST NAME/BUSINESS NAME TO DISPLAY:");
                        DisplaySingleEmployeTypeDeterminer(theObj);
                        break;

                    case '3':
                        theObj = SearchBySIN("SEARCH BY SIN/BN TO DISPLAY:");
                        DisplaySingleEmployeTypeDeterminer(theObj);
                        break;

                    case '9':
                        back = true;
                        break;
                }


            }
        }

        private void DisplaySingleEmployeTypeDeterminer(Employee theObj)
        {

            ConsoleKeyInfo userInput;
            Console.Clear();

            //if (theObj == null)
            //{
            //    Console.WriteLine("NO MATCHING EMPLOYEE FOUND");
            //    Console.WriteLine("");
            //}
            if (theObj != null)
            {
                DisplayEmployeeUnknownType(theObj);
                Console.WriteLine("Press any key to continue...");
                userInput = Console.ReadKey();
            }

        }

        private void DisplayEmployeeUnknownType(Employee theObj)
        {

            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();

            if (theObj.GetType() == FtEmployee.GetType())
            {
                FtEmployee = (FulltimeEmployee)theObj;
                Console.WriteLine("{0}", FtEmployee.Details());
            }
            else if (theObj.GetType() == PtEmployee.GetType())
            {
                PtEmployee = (ParttimeEmployee)theObj;
                Console.WriteLine("{0}", PtEmployee.Details());
            }
            else if (theObj.GetType() == CtEmployee.GetType())
            {
                CtEmployee = (ContractEmployee)theObj;
                Console.WriteLine("{0}", CtEmployee.Details());
            }
            else if (theObj.GetType() == SnEmployee.GetType())
            {
                SnEmployee = (SeasonalEmployee)theObj;
                Console.WriteLine("{0}", SnEmployee.Details());
            }
        }

        /**
         * \brief UI displaying all employee objects within companyContainer
         *
         * \details <b>Details</b>
         *
         * This method will display all the employee objects within companyContainer.
         * 3 objects will be displayed at once and user has to press a key to view the 
         * next 3 objects.
         * 
         * \param None
         * 
         * \return Nothing is returned
         * 
         */
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

            if (currentObj == null)
            {
                Console.WriteLine("THE DATABASE IS EMPTY");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                userInput = Console.ReadKey();
            }

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

        /**
         * \brief UI for search employee by name
         *
         * \details <b>Details</b>
         *
         * This method will take an user input, then match the input with objects within 
         * the companyContainer. It will compare the first name by defult, but is also 
         * capable to compare with the last name. It will display each of the matching 
         * object one by one, until user choose one of them.
         * 
         * \param string displayOrModifyOrRemove: the sentense to display at the top of 
         *                                        the UI
         *        bool lastName: if this is true, method will compare with last name instead.
         * 
         * \return Employee: The matching object that the user choose
         * 
         */
        private Employee SearchByFirstName(string displayOrModifyOrRemove, bool lastName = false)
        {
            string searchParameter = "";
            Employee theObj = new Employee();
            bool found = false;
            bool back = false;
            string dmr = "";
            ConsoleKeyInfo userInput;
            bool compareResult = false;

            if (displayOrModifyOrRemove.Contains("DISPLAY"))
            {
                dmr = "DISPLAY";
            }
            else if (displayOrModifyOrRemove.Contains("MODIFY"))
            {
                dmr = "MODIFY";
            }
            else
            {
                dmr = "REMOVE";
            }

            Console.Clear();
            searchParameter = TakeUserInputSentence(displayOrModifyOrRemove);

            theObj = (Employee)companyContainer.NextEmployee(true);

            while (theObj != null && found == false)
            {
                back = false;

                if (lastName == false)
                {
                    if (theObj.GetFirstName() == searchParameter)
                    {
                        compareResult = true;
                    }
                    else
                    {
                        compareResult = false;
                    }
                }
                else
                {
                    if (theObj.GetLastName() == searchParameter)
                    {
                        compareResult = true;
                    }
                    else
                    {
                        compareResult = false;
                    }
                }

                if (compareResult == true)
                {
                    while (back == false)
                    {
                        Console.Clear();
                        Console.WriteLine("{0} THIS EMPLOYEE?", dmr);
                        Console.WriteLine("");
                        Console.WriteLine("\t1. Yes");
                        Console.WriteLine("\t2. No");
                        Console.WriteLine("\t3. ----------");
                        Console.WriteLine("\t4. ----------");
                        Console.WriteLine("\t5. ----------");
                        Console.WriteLine("\t6. ----------");
                        Console.WriteLine("\t7. ----------");
                        Console.WriteLine("\t8. ----------");
                        Console.WriteLine("\t9. Return to {0} Menu", dmr);
                        Console.WriteLine("");
                        DisplayEmployeeUnknownType(theObj);
                        
                        
                        userInput = Console.ReadKey();

                        switch (userInput.KeyChar)
                        {
                            case '1':
                                found = true;
                                back = true;
                                break;

                            case '2':
                                theObj = (Employee)companyContainer.NextEmployee();
                                back = true;
                                break;

                            case '9':
                                found = true;
                                theObj = null;
                                back = true;
                                break;

                        }
                    }
                }
                else
                {
                    theObj = (Employee)companyContainer.NextEmployee();
                }
            }

            if (found != true && theObj == null)
            {
                Console.Clear();
                Console.WriteLine("NO MATCHING EMPLOYEE FOUND");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                userInput = Console.ReadKey();
            }

            return theObj;
        }


        private Employee SearchByLastName(string displayOrModifyOrRemove)
        {
            return SearchByFirstName(displayOrModifyOrRemove, true);
        }

        /**
         * \brief Searching employe by SIN or BN
         *
         * \details <b>Details</b>
         *
         * This method will look through each object within the companyContainer 
         * until it finds an object with matching SIN.
         * 
         * \param string displayOrModifyOrRemove: the instruction to remind user 
         *                                        what they are searching for
         * 
         * \return Employee: the object with matching SIN. If there is no object 
         *                   with matching SIN, it will return null.
         * 
         */
        private Employee SearchBySIN(string displayOrModifyOrRemove)
        {
            string searchParameter = "";
            Employee theObj = new Employee();
            ConsoleKeyInfo userInput;

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

            if (theObj == null)
            {
                Console.Clear();
                Console.WriteLine("NO MATCHING EMPLOYEE FOUND");
                Console.WriteLine("");
                userInput = Console.ReadKey();
            }

            return theObj;
        }

        private void LoadFromFile()
        {
            string errorMessage = "";
            ConsoleKeyInfo userInput;

            companyContainer = new Container(FileIO.OpenDBase("EMS_DB_FILE.txt", ref errorMessage));
            Console.Clear();
            Console.WriteLine("FILE HAS BEEN LOADED");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            userInput = Console.ReadKey();
        }

        private void SaveToFile()
        {
            string errorMessage = "";
            ConsoleKeyInfo userInput;

            companyContainer.SaveDataBase(ref errorMessage);
                        if (errorMessage != "")
                        {
                            PrintErrorMessage(errorMessage);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("FILE SAVED SUCCESSFULLY");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to contineu...");
                            userInput = Console.ReadKey();
                        }
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

        /**
         * \brief Employee removal confirmation UI
         *
         * \details <b>Details</b>
         *
         * This method will show the detail of the employee that has been 
         * chosen to be removed. It will prompt user for input of whether 
         * the user wants to delete the employee.
         * 
         * \param Employee theObj: The employee object that holds the employee
         *                         information.
         * 
         * \return bool: whether the employee should be deleted or not.
         * 
         */
        private bool RemovalConfirmationUI(Employee theObj)
        {
            ConsoleKeyInfo userInput;
            FulltimeEmployee FtEmployee = new FulltimeEmployee();
            ParttimeEmployee PtEmployee = new ParttimeEmployee();
            ContractEmployee CtEmployee = new ContractEmployee();
            SeasonalEmployee SnEmployee = new SeasonalEmployee();
            bool back = false;
            bool removeOrNot = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("ARE YOU DELETING THIS EMPLOYEE?");
                Console.WriteLine("");
                Console.WriteLine("\t1. No");
                Console.WriteLine("\t2. No");
                Console.WriteLine("\t3. No");
                Console.WriteLine("\t4. No");
                Console.WriteLine("\t5. No");
                Console.WriteLine("\t6. No");
                Console.WriteLine("\t7. Yes");
                Console.WriteLine("\t8. No");
                Console.WriteLine("\t9. No");
                Console.WriteLine("");
                Console.WriteLine("EMPLOYEE DETAIL:");

                if (theObj.GetType() == FtEmployee.GetType())
                {
                    FtEmployee = (FulltimeEmployee)theObj;
                    Console.WriteLine("{0}", FtEmployee.Details());
                }
                else if (theObj.GetType() == PtEmployee.GetType())
                {
                    PtEmployee = (ParttimeEmployee)theObj;
                    Console.WriteLine("{0}", PtEmployee.Details());
                }
                else if (theObj.GetType() == CtEmployee.GetType())
                {
                    CtEmployee = (ContractEmployee)theObj;
                    Console.WriteLine("{0}", CtEmployee.Details());
                }
                else if (theObj.GetType() == SnEmployee.GetType())
                {
                    SnEmployee = (SeasonalEmployee)theObj;
                    Console.WriteLine("{0}", SnEmployee.Details());
                }

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        back = true;
                        break;

                    case '2':
                        back = true;
                        break;

                    case '3':
                        back = true;
                        break;

                    case '4':
                        back = true;
                        break;

                    case '5':
                        back = true;
                        break;

                    case '6':
                        back = true;
                        break;

                    case '7':
                        removeOrNot = true;
                        back = true;
                        break;

                    case '8':
                        back = true;
                        break;

                    case '9':
                        back = true;
                        break;


                }
            }

            return removeOrNot;

        }

        private bool SaveAndExitProgram()
        {
            ConsoleKeyInfo userInput;
            bool exit = false;

            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("ARE YOU SURE YOU WANT TO EXIT EMS?");
                Console.WriteLine("");
                Console.WriteLine("\t1. Save And Exit");
                Console.WriteLine("\t2. Exit Without Saving");
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
                        SaveToFile();
                        exit = true;
                        back = true;
                        break;

                    case '2':
                        exit = true;
                        back = true;
                        break;

                    case '9':
                        back = true;
                        break;
                }

            }
            return exit;

        }

        /**
         * \brief method to make sure user only enters numbers
         *
         * \details <b>Details</b>
         *
         * This method uses switch() to make sure only numerical input 
         * will be recorded.
         * 
         * \param None
         * 
         * \return int: a numerical value of 0 ~ 9, depending on what 
         *              what a user has typed.
         * 
         */
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

        /**
         * \brief UI for entering SIN or BN
         *
         * \details <b>Details</b>
         *
         * This method only accepts 9 numerical input from user. The method 
         * will automatically append spaces to the input for displaying purposes 
         * depending on whether the user is entering SIN or BN. However the 
         * spaces will not be added if the method is called to perform search for 
         * that the method will not know whether the user is entering a SIN or BN 
         * in that case.
         * 
         * Format for SIN: ### ### ###
         * Format for BN:  ##### ####
         * Format for searching: #########
         * 
         * \param string sinOrBN: the instruction displayed in UI to remind user 
         *                        what they are entering the numbers for
         * 
         * \return string: The SIN or BN user has entered.
         * 
         */
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



        /**
         * \brief UI for taking date input from user
         *
         * \details <b>Details</b>
         *
         * This method only allows users to enter numerical characters, 
         * and it will automatically append "-" at the 5th and 8th 
         * characters to achieve the yyyy-mm-dd format.
         * 
         * \param string whichDate: instruction displayed in UI to remind 
         *                          which date they are entering
         * 
         * \return string: the date in string format.
         * 
         */
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


        /**
         * \brief UI for taking numerical input from user in money format
         *
         * \details <b>Details</b>
         *
         * This method will display UI prompting user to input an amount of 
         * money. It requires the user to enter 2 decimal digits to end the 
         * input process.
         * 
         * 
         * \param string moneyType: the instruction that will be displayed 
         *                          to tell the user what they should be 
         *                          entering
         * 
         * \return string: the amont of money in string format, minus "$".
         * 
         */
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


        /**
         * \brief UI for displaying error message
         *
         * \details <b>Details</b>
         *
         * This method will clear the screen and display the error message. 
         * It will prompt for an user input before ending.
         * 
         * \param string errorMessage: The error message to display
         * 
         * \return Nothing is returned
         * 
         */
        private void PrintErrorMessage(string errorMessage)
        {
            ConsoleKeyInfo userInput;
            Console.Clear();
            Console.WriteLine("{0}", errorMessage);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            userInput = Console.ReadKey();
        }

    }
}