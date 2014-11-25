
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    /// \class ParttimeEmployee
    /// 
    /// \brief Contains part-time employee information
    /// 
    /// File: ParttimeEmployee.cs
    /// Project: EMS Term Project
    /// First Version: Nov.13/2014
    ///
    /// This file contains the ParttimeEmployee child class which
    /// holds the information to be used in the ParttimeEmployee
    /// model contained in the EMS Term Project.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class ParttimeEmployee : Employee
    {
        DateTime dateOfHire;///< used to hold the date the employee started working at the company
        DateTime dateOfTermination;///< used to hold the date the employee stopped working at the company
        float hourlyRate;///< used to hold the hourly pay for the employee

        /**
        * \brief Sets the dateOfHire attribute within the ParttimeEmployee class
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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateDateOfHire(DateTime dateOfHire)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the dateOfTermination attribute within the ParttimeEmployee class
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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateDateOfTermination(DateTime dateOfTermination)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the hourlyRate attribute within the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer representing the 
        * employee's hourly wage and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param hourlyRate - float - The amount of money the employee makes per
        * hour given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateHourlyRate(float hourlyRate)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the <i>dateOfHire</i> attribute within the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfHire</i> attribute within
        * the ParttimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's date of hire given 
        * by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfHire(string userInput)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if(ValidateDateOfHire(userInputDateTime))
                {
                    setStatus = true;
                    dateOfHire = userInputDateTime;
                }
            }
            else 
            { 
                //error statment
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>dateOfHire</i> attribute from the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>dateOfHire</i> attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>dateOfHire</i> attribute within the 
        * ParttimeEmployee class
        */
        public DateTime GetDateOfHire()
        {
            return dateOfHire;
        }

        /**
        * \brief Sets the <i>dateOfTermination</i> attribute within the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfTermination</i> attribute within
        * the ParttimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's date of termination given 
        * by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfTermination(string userInput)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (ValidateDateOfTermination(userInputDateTime))
                {
                    setStatus = true;
                    dateOfTermination = userInputDateTime;
                }
            }
            else
            {
                //error statment
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>dateOfTermination</i> attribute from the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>dateOfTermination</i> attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>dateOfTermination</i> attribute within the 
        * ParttimeEmployee class
        */
        public DateTime GetDateOfTermination()
        {
            return dateOfTermination;
        }

        /**
        * \brief Sets the hourlyRate attribute within the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a floating integer, making sure it is valid format, and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>hourlyRate</i> attribute within
        * the ParttimeEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee salary rate per hour
        *  given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetHourlyRate(string userInput)
        {
            bool setStatus = false;

            if(ValidateHourlyRate(userInput))
            {
                setStatus = true;
                hourlyRate = userInput;
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>hourlyRate</i> attribute from the ParttimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>hourlyRate</i> attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set <i>hourlyRate</i> attribute within the 
        * ParttimeEmployee class
        */
        public float GetHourlyRate()
        {
            return hourlyRate;
        }
    }
}