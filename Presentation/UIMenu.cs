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
///             - Return to Manage Employees
///         - Create a New Employee
///             - Specify Employee Details
///             - Save
///             - Return to Manage Employees
///         - Modify an Existing Employee
///             - Search Employee(s)
///                 - Select Employee
///                     - Modify
///                     - Save
///                     - Return to Search Employee(s)
///                 - Return to Search Employee(s)
///             - Return to Manage Employees
///         - Remove an Existing Employee
///             - Search Employee(s)
///                 - Select Employee
///                     - Confirmation Yes
///                     - Confirmation No
///                 - Return to Search Employee(s)
///             - Return to Remove and Existing Employee
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
        * This method will display options available in main menu, then take an user input to lead to different method.
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
        * This method will display options available in Manage DBase Files Menu, then take an user input to lead to different method.
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
        * This method will display options available in Manage Employees Menu, then take an user input to lead to different method.
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
        * This method will display options available in Display Employee Set Menu, then take an user input to lead to different method.
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
        * This method will display options available in Create a New Employee Menu, then take an user input to lead to different method.
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void createANewEmployeeMenu()
        {
            char userInput = '0';
        }

        /**
        * \brief Displays Create a New Employee Menu
        *
        * \details <b>Details</b>
        *
        * This method will display options available in Create a New Employee Menu, then take an user input to lead to different method.
        * 
        * \param userInput - char - stores one key entry from user.
        */
        private void createANewEmployeeMenu()
        {
            char userInput = '0';
        }


    }
}