﻿/// \class FulltimeEmployee
/// 
/// \brief Contains FulltimeEmployee information
/// 
/// File: FulltimeEmployee.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the FulltimeEmployee child class which
/// holds the information to be used in the FulltimeEmployee
/// model contained in the EMS Term Project.
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class FulltimeEmployee : Employee
    {
        DateTime dateOfTermination;
        DateTime dateOfHire;
        float salary;

        /**
        * \brief Sets the dateOfHire attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the dateOfHire attribute within the FulltimeEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on weather or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of hire
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfHire(DateTime userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the dateOfHire attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the dateOfHire attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set dateOfHire attribute within the 
        * FulltimeEmployee class
        */
        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }

        /**
        * \brief Sets the dateOfTermination attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the dateOfTermination attribute within the FulltimeEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on weather or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of termination
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfTermination(DateTime userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the dateOfTermination attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the dateOfTermination attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set dateOfTermination attribute within the 
        * FulltimeEmployee class
        */
        public DateTime GetDateOfTermination()
        {
            return dateOfTermination;
        }

        /**
        * \brief Sets the salary attribute within the FulltimeEmployee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer from the user and call on
        * a separate method to validate it. If the user input floating integer is 
        * valid, then the method will set the salary attribute 
        * within the FulltimeEmployee class to the user input floating integer. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - float - The employee salary
        *  given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSalary(float userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retrieves the salary attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the salary attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set salary attribute within the 
        * FulltimeEmployee class
        */
        public float GetSalary()
        {
            return salary;
        }
    }
}