﻿/// \namespace AllEmployees
/// 
/// \brief Contains the following classes: Employee, ContractEmployee, FulltimeEmployee, ParttimeEmployee, and SeasonalEmployee
/// 
/// File: Employee.cs, ContractEmployee.cs, FulltimeEmployee.cs, ParttimeEmployee.cs, and SeasonalEmployee.cs \n
/// Project: EMS Term Project \n
/// First Version: Nov.13/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporting;

namespace AllEmployees
{
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
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class Employee
    {
        string firstName;///< string used to hold the employees first name
        string lastName;///< string used to hold the employees last name
        string socialInsuranceNumber;///< string used to hold the employees SIN
        DateTime dateOfBirth;///< used to hold the employees date of birth

        /**
        * \brief Default constructor for the Employee parent class
        *
        * \details <b>Details</b>
        *
        * This is the default constructor for the Employee parent
        * class which is in charge of creating the base attributes
        * for the employee when called upon.
        * 
        * \param void
        *
        * \return void
        */
        public Employee()
        {
            firstName = "";
            lastName = "";
            socialInsuranceNumber = "";
            dateOfBirth = new DateTime();
        }

        /**
        * \brief Constructor for the Employee parent class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the Employee parent
        * class which is in charge of creating the base attributes
        * for the employee when called upon, taking in
        * a series of parameters ment to be inserted into the Employee
        * object, and validating the parameters before trying to insert them.
        * Should a parameter be found invalid, the attribute will be left blank.
        * 
        * \param fName - string - The desired employee first name given 
        * by the user.
        * 
        * \param lName - string - The desired employee last name given 
        * by the user.
        * 
        * \param sin - string - The employee's social insurance
        * number given by the user.
        * 
        * \param dob - DateTime - The employee's date of birth given 
        * by the user.
        *
        * \return void
        */
        public Employee(string fName, string lName, string sin)
        {
            string unused = "";

            firstName = "";
            lastName = "";
            socialInsuranceNumber = "";
            dateOfBirth = new DateTime();

            if (Supporting.Validation.ValidateName(fName, ref unused))
            {
                firstName = fName;
            }

            if (Supporting.Validation.ValidateName(lName, ref unused))
            {
                lastName = lName;
            }

            if (Supporting.Validation.ValidateSocialInsuranceNumber(sin, ref unused))
            {
                socialInsuranceNumber = sin;
            }
        }

        
        public Employee(Employee oldEmployee)
        {
            this.firstName = oldEmployee.firstName;
            this.lastName = oldEmployee.lastName;
            this.socialInsuranceNumber = oldEmployee.socialInsuranceNumber;
            this.dateOfBirth = oldEmployee.dateOfBirth;
        }

        virtual public string Details()
        {
            string empDetails = "";

            return empDetails;
        }

        virtual public string ToString()
        {
            string empDetailsStr = "";

            return empDetailsStr;
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
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The desired employee first name given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        *
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetFirstName(string userInput, ref string errorMessage)
        {
            bool setStatus = false;

            if (Supporting.Validation.ValidateName(userInput, ref errorMessage))
            {
                setStatus = true;
                firstName = userInput;
            }

            if(!setStatus)
            {
                Logging.LogEvent("[Employee.SetFirstName] Attempted To Set firstName Attribute With Invalid Value: " +  userInput);
            }

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
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The desired employee last name given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetLastName(string userInput, ref string errorMessage)
        {
            bool setStatus = false;

            if (Supporting.Validation.ValidateName(userInput, ref errorMessage))
            {
                setStatus = true;
                lastName = userInput;
            }

            if (!setStatus)
            {
                Logging.LogEvent("[Employee.SetLastName] Attempted To Set lastName Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>lastName</i> attribute from the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>lastName</i> attribute as a string to the
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
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's social insurance
        * number given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        virtual public bool SetSocialInsuranceNumber(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            int sinLengthSpaces = 11;
            int sinLength = 9;

            if (userInput.Length == sinLengthSpaces || userInput.Length == sinLength)
            {
                if (userInput[3] == ' ' && userInput[7] == ' ')
                {
                    userInput = userInput.Remove(3, 1);
                    userInput = userInput.Remove(6, 1);
                    
                    if (Supporting.Validation.ValidateSocialInsuranceNumber(userInput, ref errorMessage))
                    {
                        setStatus = true;
                        socialInsuranceNumber = userInput;
                    }
                }
                else if(!userInput.Contains(" "))
                {
                    if (Supporting.Validation.ValidateSocialInsuranceNumber(userInput, ref errorMessage))
                    {
                        setStatus = true;
                        socialInsuranceNumber = userInput;
                    }
                }
                else
                {
                    errorMessage = "Please Be Sure The SIN Is In The Proper Format\nex. xxx xxx xxx\n";
                }

                
            }
            else
            {
                errorMessage = "Please Be Sure The SIN Is In The Proper Format\nex. xxx xxx xxx\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[Employee.SetSocialInsuranceNumber] Attempted To Set socialInsuranceNumber Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Sets the <i>socialInsuranceNumber</i> attribute within the Employee class
        *        as the company's business number
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>socialInsuranceNumber</i> attribute 
        * within the Employee class to the user input string. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The company's business
        * number given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetBusinessNumber(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            int bnLength = 9;
            int bnLengthSpaces = 10;

            if (userInput.Length == bnLengthSpaces || userInput.Length == bnLength)
            {
                if (userInput[5] == ' ')
                {
                    userInput = userInput.Remove(5, 1);

                    if (Supporting.Validation.ValidateBusinessNumber(userInput, GetDateOfBirth(), ref errorMessage))
                    {
                        setStatus = true;
                        socialInsuranceNumber = userInput;
                    }
                }
                else if(!userInput.Contains(" "))
                {
                    if (Supporting.Validation.ValidateBusinessNumber(userInput, GetDateOfBirth(), ref errorMessage))
                    {
                        setStatus = true;
                        socialInsuranceNumber = userInput;
                    }
                }
                else
                {
                    errorMessage = "Please Be Sure The BN Is In The Proper Format\nex. xxx xxx xxx\n";
                }
            }
            else
            {
                errorMessage = "Please Be Sure The SIN Is In The Proper Format\nex. xxx xxx xxx\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[Employee.SetBusinessNumber] Attempted To Set socialInsuranceNumber Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Sets the <i>dateOfBirth</i> attribute within the Employee class
        *        as the company's date of creation
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfBirth</i> attribute within
        * the ParttimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The company's date of creation given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfCreation(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (Supporting.Validation.ValidateDateOfCreation(GetSocialInsuranceNumber(), userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    dateOfBirth = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format For A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[Employee.SetDateOfCreation] Attempted To Set dateOfBirth Attribute With Invalid Value: " + userInput);
            }

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
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>dateOfBirth</i> attribute within
        * the ParttimeEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's date of birth given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        virtual public bool SetDateOfBirth(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;
            errorMessage = "";

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (Supporting.Validation.ValidateDateOfBirth(userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    dateOfBirth = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format Fot A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }
            
            if (!setStatus)
            {
                Logging.LogEvent("[Employee.SetDateOfBirth] Attempted To Set dateOfBirth Attribute With Invalid Value: " + userInput);
            }

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