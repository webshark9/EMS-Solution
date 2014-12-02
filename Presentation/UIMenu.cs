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
                Console.WriteLine("\n");
                Console.WriteLine("\t1. Manage Data Base Files");
                Console.WriteLine("\t2. Manage Employees");
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
            bool back = false;

            while(back == false)
            {
                Console.Clear();
                Console.WriteLine("FILE MANAGEMENT MENU:");
                Console.WriteLine("\n");
                Console.WriteLine("\t1. Load EMS Data Base From File");
                Console.WriteLine("\t2. Save EMployee Set To EMS Data Base File");
                Console.WriteLine("\t9. Return To Main Menu");

                userInput = Console.ReadKey();

                switch(userInput.KeyChar)
                {
                    case '1':

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

            while(back == false)
            {
                Console.Clear();
                Console.WriteLine("EMPLOYEE MANAGMENT MENU:");
                Console.WriteLine("\n");
                Console.WriteLine("\t1. Display Employee Set");
                Console.WriteLine("\t2. Create A New Employee");
                Console.WriteLine("\t3. Modify An Existing Employee");
                Console.WriteLine("\t4. Remove An Existing Employee");
                Console.WriteLine("\t9. Return To Main Menu");

                userInput = Console.ReadKey();

                switch(userInput.KeyChar)
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
                Console.WriteLine("\n");
                Console.WriteLine("\t1. Display All Employees");
                Console.WriteLine("\t2. Search Specific Employee");
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
                Console.WriteLine("Create a New Employee:");
                Console.WriteLine("\n");
                Console.WriteLine("Create Employee Type:");
                Console.WriteLine("\n");
                Console.WriteLine("\t1. Full Time Employee");
                Console.WriteLine("\t2. Part Time Employee");
                Console.WriteLine("\t3. Contract Employee");
                Console.WriteLine("\t4. Seasonal Employee");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        CreateFullTimeEmployee();
                        break;

                    case '2':
                        CreatePartTimeEmployee();
                        break;

                    case '3':
                        CreateContractEmployee();
                        break;

                    case '4':
                        CreatePartTimeEmployee();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }


        /**
        * \brief UI of full time employee creation
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
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateFullTimeEmployee()
        {
            ConsoleKeyInfo userInput;
            bool back = false;

            while (back == false)
            {
                Console.Clear();
                Console.WriteLine("Create a Full Time Employee:");
                Console.WriteLine("\n");
                Console.WriteLine("Current Info:");
                Console.WriteLine("First Name: {0}", Employee.GetFirstName());
                Console.WriteLine("Last Name: {0}", Employee.GetFirstName());
                Console.WriteLine("SIN: {0}", Employee.GetFirstName());
                Console.WriteLine("Date of Birth: {0}", Employee.GetFirstName());
                Console.WriteLine("Date of Hire: {0}", Employee.GetFirstName());
                Console.WriteLine("Date of Termination: {0}", Employee.GetFirstName());
                Console.WriteLine("Salary: {0}", Employee.GetFirstName());
                Console.WriteLine("\n");
                Console.WriteLine("Edit Info:");
                Console.WriteLine("\t1. Edit First Name");
                Console.WriteLine("\t2. Edit Last Name");
                Console.WriteLine("\t3. Edit SIN");
                Console.WriteLine("\t4. Edit Date of Birth");
                Console.WriteLine("\t5. Edit Date of Hire");
                Console.WriteLine("\t6. Edit Date of Termination");
                Console.WriteLine("\t7. Edit Salary");
                Console.WriteLine("\t9. Return To Employee Management Menu");

                userInput = Console.ReadKey();

                switch (userInput.KeyChar)
                {
                    case '1':
                        CreateFullTimeEmployee();
                        break;

                    case '2':
                        CreatePartTimeEmployee();
                        break;

                    case '3':
                        CreateContractEmployee();
                        break;

                    case '4':
                        CreatePartTimeEmployee();
                        break;

                    case '5':
                        CreateFullTimeEmployee();
                        break;

                    case '6':
                        CreatePartTimeEmployee();
                        break;

                    case '7':
                        CreateContractEmployee();
                        break;

                    case '9':
                        back = true;
                        break;
                }
            }
        }

        /**
        * \brief UI of part time employee creation
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
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreatePartTimeEmployee()
        {

        }

        /**
        * \brief UI of contract employee creation
        *
        * \details <b>Details</b>
        *
        * This method will give user the option to enter each element of a contract 
         * employee. The elements that have been entered will also be displayed. 
         * User can choose to save the employee data in this menu.
        * 
        * Available options:
        * 
        * Corporation Name
         * Business Number
         * Date of Incorporation
         * Contract Start Date
         * Contract Stop Date
         * Fixed Contract Amount
         * Save and Return to Manage Employee Menu
        * Return to Manage Employee Menu Without Saving
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateContractEmployee()
        {

        }

        /**
        * \brief UI of seasonal employee creation
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
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void CreateSeasonalEmployee()
        {

        }

        /**
         * \brief UI of enter first name
         *
         * \details <b>Details</b>
         *
         * This method allows user to enter first name of employee
         * 
         * Available Option:
         * 
         * 9. Cancel
         * 
         * \param None
         * 
         * \return Nothing is returned
         * 
         */
        private void EnterFirstName()
        {

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
        private void EnterLastName()
        {

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
        private void EnterSIN()
        {

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
        private void EnterDateOfBirth()
        {

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
        private void EnterDateOfHire()
        {

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
        private void EnterDateOfTermination()
        {

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
        private void EnterSalary()
        {

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
        private void EnterHourlyRate()
        {

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
        private void EnterContractStartDate()
        {

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
        private void EnterContractStopDate()
        {

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
        private void EnterFixedContractAmount()
        {

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
        private void EnterBusinessNumber()
        {

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
        private void EnterDateOfIncorporation()
        {

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
        private void EnterPiecePay()
        {

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

            return season;
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
        * Specify employee detail
        * Save
        * Return to Manage Employee Menu
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void ModifyAnExistingEmployeeMenu()
        {
            char userInput = '0';
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
        * Yes
        * No
        * 
        * \param None
        * 
        * \return Nothing is returned
        * 
        */
        private void RemoveAnExistingEmployeeMenu()
        {
            char userInput = '0';
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
        private string SearchEmployeeMenu()
        {
            char userInput = '0';
            string employeeRecord = "";

            return employeeRecord;
        }

        private void DisplayAllEmployees()
        {

        }

        
        private void SearchFirstNameUI()
        {
    
        }

        private void SearchLastNameUI()
        {
        
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

        private string TakeUserInputOption()
        {
            string userInput = "";
            return userInput;
        }

        private string TakeUserInputSentence()
        {
            string userInput = "";
            return userInput;
        }




        public static void printErrorMessage(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

    }
}