
// Self note: I am in the middle of editting the menu structure.


/// \class UIMenu
/// 
/// \brief Displays and handles user interface
/// 
/// File: UIMenu.cs
/// Project: EMS Term Project
/// First Version: Nov.20/2014
///
/// This file contains UI class which allows user to navigate through multiple 
/// options to access different functionalities of the program.
/// 
/// Menu map:
/// 
/// - Main Menu *DONE*
///     - Manage DBase files *DONE*
///         - Load EMS DBase from file
///         - Save Employee Set to EMS DBase file
///         - Return to Main Menu
///     - Manage Employees *DONE*
///         - Display Employee Set *DONE*
///             - Display all emplyees
///             - Search Employee(s)
///                 (Search Employee(s))
///                 - Search by first name
///                 - Search by last name
///                 - Search by SIN
///                     (Display Matchinging Employee(s))
///                     - Return to Search Employee(s)
///                 - Return to Display Employee Set
///             - Return to Manage Employees
///         - Create a New Employee *DONE*
///             - Specify Employee Details
///             - Save
///             - Return to Manage Employees
///         - Modify an Existing Employee *DONE*
///             (Search Employee(s))
///             - Search by first name
///             - Search by last name
///             - Search by SIN
///                 (Display Matchinging Employee(s))
///                 - Select Employee
///                     (Modify Employee)
///                     - Save
///                     - Cancel
///                 - Return to Search Employee(s)
///             - Return to Manage Employees
///         - Remove an Existing Employee *DONE*
///             (Search Employee(s))
///             - Search by first name
///             - Search by last name
///             - Search by SIN
///                 (Display Matchinging Employee(s))
///                 - Select Employee
///                     - Confirmation Yes
///                     - Confirmation No
///             - Return to Manage Employees
///         - Return to Main Menu
///     - Exit EMS
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class UIMenu
    {

        /**
        * \method mainMenu
        * 
        * \brief Displays Main Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in main menu, then take an 
         * user input to lead to different method.
         *
         * Available options:
         * 
         * Manage DBase Files
         * Manage Employees
         * Exit EMS
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void mainMenu()
        {
            char userInput = '0';
        }

        /**
        * \method manageDBaseFilesMenu
        * 
        * \brief Displays Manage DBase Files Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Manage DBase Files Menu, 
         * then take an user input to lead to different method.
         * 
         * Available options:
         * 
         * Load EMS DBase from file
         * Save Employee Set to EMS DBase file
         * Return to Main Menu
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void manageDBaseFilesMenu()
        {
            char userInput = '0';
        }

        /**
        * \method manageEmployeesMenu
        * 
        * \brief Displays Manage Employees Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Manage Employees Menu, then 
         * take an user input to lead to different method.
         * 
         * Available options:
         * 
         * Display Employee Set
         * Create a New Employee
         * Modify an existing employee
         * Removean existing employee
         * Return to Main Menu
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void manageEmployeesMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief Displays Display Employee Set Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Display Employee Set Menu, 
         * then take an user input to lead to different method.
         * 
         * Available options:
         * 
         * Display all employees
         * Search specific employee
         * Return to Manage Employees Menu
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void displayEmployeeSetMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief Displays Create a New Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Create a New Employee Menu, 
         * then take an user input to lead to different method.
         * 
         * Available options:
         * 
         * Specify employee detail
         * Save
         * Return to Manage Employee Menu
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void createANewEmployeeMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief Displays Modify an Existing Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method first call searchEmployees method. Once an employee has been 
         * selected, it will then display options available in Modify an Existing 
         * Employee Menu, then take an user input to lead to different method.
         * 
         * Available options (after search):
         * 
         * Specify employee detail
         * Save
         * Return to Manage Employee Menu
         * 
        * \param userInput - char - stores one key entry from user.
        */
        private void modifyAnExistingEmployeeMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief Displays Remove an Existing Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will take user to searchEmployee method. Once an employee 
        * is selected, it will ask user with confirmation of whether the employee 
        * should be deleted.
         * 
         * Available options (after search) (for confirmation):
         * 
         * Yes
         * No
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void removeAnExistingEmployeeMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief This method handles the user interface portion of searching an employee
        *
        * \details <b>Details</b>
        *
        * This method will first prompt user to choose the parameter for the search 
        * (first name, last name, or SIN) then call the proper method from a different 
        * class library to perform the search. After the search is completed, all matching 
        * employees will be displayed on the screen. The user will choose one of the 
        * displayed employee, and the record of that employee will be the return value.
        * 
        * \param userInput - char - stores one key entry from user.
        * \param employeeRecord - string - stores the record of an employee
        * 
        * \return string - the employee record of the search result..
        */
        private string searchEmployee()
        {
            char userInput = '0';
            string employeeRecord = "";

            return employeeRecord;

        }

    }
}