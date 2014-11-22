/// \class Employee
/// 
/// \brief Contains basic employee information
/// 
/// File: Employee.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the Employee parent class which
/// holds the base information to be used in all of the
/// other employee types contained in the EMS Term Project.
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class Employee
    {
        string firstName;
        string lastName;
        string socialInsuranceNumber;
        DateTime dateOfBirth;

        /**
        * \brief Validates the firstName attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * employee first name and check weather or not it is a
        * valid season. Returns a true or false depending on weather or not the 
        * attribute is valid.
        * 
        * \param firstName - string - The employee's first name 
        * given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateFirstName(string firstName)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Validates the lastName attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * employee last name and check weather or not it is a
        * valid season. Returns a true or false depending on weather or not the 
        * attribute is valid.
        * 
        * \param lastName - string - The employee's last name 
        * given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateLastName(string lastName)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Validates the socialInsuranceNumber attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * employee social insurance number and check weather or not it is a
        * valid season. Returns a true or false depending on weather or not the 
        * attribute is valid.
        * 
        * \param socialInsuranceNumber - string - The employee's social insurance
        * number given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateSocialInsuranceNumber(string socialInsuranceNumber)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the dateOfBirth attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a dateOfBirth variable representing the 
        * employee's date of birth and check weather or not it is a
        * valid entry. Returns a true or false depending on weather or not the 
        * attribute is valid.
        * 
        * \param dateOfBirth - DateTime - The employee's date of birth 
        * given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateDateOfBirth(DateTime dateOfBirth)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the <i>firstName</i> attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>firstName</i> attribute within
        * the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - string - The desired employee first name given 
        * by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetFirstName(string userInput)
        {
            bool setStatus = false;
            


            return setStatus;
        }

        /**
        * \brief Retrieves the <i>firstName</i> attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>firstName</i> attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set <i>firstName</i> attribute within the 
        * Employee class
        */
        public string GetFirstName()
        {
            return firstName;
        }

        /**
        * \brief Sets the <i>lastName</i> attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>lastName</i> attribute within
        * the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - string - The desired employee last name given 
        * by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetLastName(string userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the <i>lastName</i> attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the </i>lastName</i> attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set <i>lastName</i> attribute within the 
        * Employee class
        */
        public string GetLastName()
        {
            return lastName;
        }

        /**
        * \brief Sets the <i>socialInsuranceNumber</i> attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>socialInsuranceNumber</i> attribute 
        * within the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee social insurance
        * number given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSocialInsuranceNumber(string userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the <i>socialInsuranceNumber</i> attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>socialInsuranceNumber</i> attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set <i>socialInsuranceNumber</i> attribute within the 
        * Employee class
        */
        public string GetSocialInsuranceNumber()
        {
            return socialInsuranceNumber;
        }

        /**
        * \brief Sets the <i>dateOfBirth</i> attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the <i>dateOfBirth</i> attribute within the Employee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on weather or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of birth
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfBirth(DateTime userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the <i>dateOfBirth</i> attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>dateOfBirth</i> attribute as a DateTime data type
        * to the calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>dateOfBirth</i> attribute within the 
        * Employee class
        */
        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }
    }
}