/// \class Employee
/// 
/// \brief Contains base employee information
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
        * \brief Sets the firstName attibute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the firstName attribute within
        * the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - string - The desired employee first name given 
        * by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetFirstName(string userInput)
        {
            bool setStatus = false;
            


            return setStatus;
        }

        /**
        * \brief Retreives the firstName attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the firstName attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set firstName attribute within the 
        * Employee class
        */
        public string GetFirstName()
        {
            return firstName;
        }

        /**
        * \brief Sets the lastName attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the lastName attribute within
        * the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribe was set successfully.
        * 
        * \param userInput - string - The desired employee last name given 
        * by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetLastName(string userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retreives the lastName attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the lastName attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set lastName attribute within the 
        * Employee class
        */
        public string GetLastName()
        {
            return lastName;
        }

        /**
        * \brief Sets the socialInsuranceNumber attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the socialInsuranceNumber attribute 
        * within the Employee class to the user input string. Returns a true 
        * or false depending on weather or not the attribe was set successfully.
        * 
        * \param userInput - string - The employee social insurance
        * number given by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSocialInsuranceNumber(string userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retreives the socialInsuranceNumber attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the socialInsuranceNumber attribute as a string to the
        * calling method.
        * 
        * \param None
        * 
        * \return string - The currently set socialInsuranceNumber attribute within the 
        * Employee class
        */
        public string GetSocialInsuranceNumber()
        {
            return socialInsuranceNumber;
        }

        /**
        * \brief Sets the dateOfBirth attribute within the Employee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the dateOfBirth attribute within the Employee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on weather or not the attribe was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of birth
        * given by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfBirth(DateTime userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retreives the dateOfBirth attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the dateOfBirth attribute as a DateTime data tyoe
        * to the calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set dateOfBirth attribute within the 
        * Employee class
        */
        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }
    }
}