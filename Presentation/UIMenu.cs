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
using System.Object;
// using System.Console;
using System.String;

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

        private void MainMenu()
        {
            char userInput = '0';
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
            char userInput = '0';
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
            char userInput = '0';
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
            char userInput = '0';
        }

        /**
        * \brief Displays the Create a New Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Create a New Employee Menu, 
        * then take an user input to lead to different methods.
        * 
        * Available options:
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
        private void CreateANewEmployeeMenu()
        {
            char userInput = '0';
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
        private string SearchEmployee()
        {
            char userInput = '0';
            string employeeRecord = "";

            return employeeRecord;

        }

        public static void printErrorMessage(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

    }
}