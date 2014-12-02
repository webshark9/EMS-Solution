﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;

namespace AllEmployees
{
    /// \class FulltimeEmployee
    /// 
    /// \brief Contains full-time employee information
    /// 
    /// File: FulltimeEmployee.cs
    /// Project: EMS Term Project
    /// First Version: Nov.13/2014
    ///
    /// This file contains the FulltimeEmployee child class which
    /// holds the information to be used in the FulltimeEmployee
    /// model contained in the EMS Term Project.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class FulltimeEmployee : Employee
    {
        DateTime dateOfHire;///< used to hold the date the employee started working at the company
        DateTime dateOfTermination;///< used to hold the date the employee stopped working at the company
        float salary;///< used to hold the employees salary

        /**
        * \brief Sets the dateOfHire attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable representing the 
        * employee's date of hire and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param dateOfHire - DateTime - The date the employee was hired 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateDateOfHire(DateTime dateOfHire, ref string errorMessage)
        {
            bool validateStatus = true;



            return validateStatus;
        }

        /**
        * \brief Sets the dateOfTermination attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable representing the 
        * employee's date of termination and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param dateOfTermination - DateTime - The date the employee was terminated/fired 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateDateOfTermination(DateTime dateOfTermination, ref string errorMessage)
        {
            bool validateStatus = true;



            return validateStatus;
        }

        /**
        * \brief Sets the salary attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer representing the 
        * employee's wage and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param salary - float - The amount of money the employee makes
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateSalary(float salary, ref string errorMessage)
        {
            bool validateStatus = true;



            return validateStatus;
        }

        /**
        * \brief Sets the <i>dateOfHire</i> attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfHire</i> attribute within
        * the FulltimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's date of hire given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfHire(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if(DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (ValidateDateOfHire(userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    dateOfHire = userInputDateTime;
                }
            }
            else
            {
                //UIMenu.printErrorMessage("\"Date Of Hire\" is not formatted correctly\nPlease be sure to use the format\ndd/mm/yyyy     ex.29/08/2012\n\n");
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>dateOfHire</i> attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>dateOfHire</i> attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>dateOfHire</i> attribute within the 
        * FulltimeEmployee class
        */
        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }

        /**
        * \brief Sets the <i>dateOfTermination</i> attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfTermination</i> attribute within
        * the FulltimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's date of termination given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfTermination(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (ValidateDateOfTermination(userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    dateOfTermination = userInputDateTime;
                }
            }
            else
            {
                //UIMenu.printErrorMessage("\"Date Of Termination\" is not formatted correctly\nPlease be sure to use the format\ndd/mm/yyyy     ex.29/08/2012\n\n");
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>dateOfTermination</i> attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>dateOfTermination</i> attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>dateOfTermination</i> attribute within the 
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
        * This method will take in a string of user input, convert it
        * to a floating integer, making sure it is valid format, and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>salary</i> attribute within
        * the FulltimeEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee salary
        *  given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSalary(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            float userInputFloat = 0;

            if(float.TryParse(userInput, out userInputFloat))
            {
                if(ValidateSalary(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    salary = userInputFloat;
                }
            }
            else
            {
                //UIMenu.printErrorMessage("\"Salary\" is not formatted correctly\nPlease be sure to use the format\n$\"00.00\"     ex.$56.78\n\n");
            }


            return setStatus;
        }

        /**
        * \brief Retrieves the <i>salary</i> attribute from the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>salary</i> attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set <i>salary</i> attribute within the 
        * FulltimeEmployee class
        */
        public float GetSalary()
        {
            return salary;
        }
    }
}