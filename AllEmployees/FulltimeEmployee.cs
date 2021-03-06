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
        * \brief Default constructor for the FulltimeEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is the default constructor for the FulltimeEmployee child
        * class which is in charge of creating the attributes
        * for the full-time employee when called upon. This
        * constructor also calls upon the default Employee class parent constructor.
        * 
        * \param void
        *
        * \return void
        */
        public FulltimeEmployee() : base()
        {
            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            salary = 0;
        }

        /**
        * \brief Constructor for the FulltimeEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the FulltimeEmployee child
        * class which is in charge of creating the attributes
        * for the full-time employee when called upon, taking in
        * a series of parameters meant to be inserted into the FulltimeEmployee
        * object, and validating the parameters before trying to insert them.
        * Should a parameter be found invalid, the attribute will be left blank.
        * This constructor also calls upon the Employee class parent constructor.
        * 
        * \param doh - DateTime - The employee's date of hire given 
        * by the user.
        * 
        * \param dot - DateTime - The employee's date of termination given 
        * by the user.
        * 
        * \param sal - float - The employee salary
        *  given by the user.
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
        public FulltimeEmployee(DateTime doh, DateTime dot, float sal, string fName, string lName, string sin, DateTime dob) : base(fName, lName, sin)
        {
            string unused = "";

            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            salary = 0;

            if (Supporting.Validation.ValidateDateOfHire(dob, doh, dot, ref unused))
            {
                dateOfHire = doh;
            }

            if (Supporting.Validation.ValidateDateOfTermination(dob, doh, dot, ref unused))
            {
                dateOfTermination = dot;
            }

            if (Supporting.Validation.ValidateSalary(sal, ref unused))
            {
                salary = sal;
            }

            if (Supporting.Validation.ValidateDateOfBirth(dob, doh, dot, ref unused))
            {
                SetDateOfBirth(dob.ToString("d"), ref unused);
            }
        }

        public FulltimeEmployee(FulltimeEmployee oldEmployee) : base(oldEmployee.GetFirstName(), oldEmployee.GetLastName(), oldEmployee.GetSocialInsuranceNumber())
        {
            string unused = "";

            this.dateOfHire = oldEmployee.dateOfHire;
            this.dateOfTermination = oldEmployee.dateOfTermination;
            this.salary = oldEmployee.salary;
            SetDateOfBirth(oldEmployee.GetDateOfBirth().ToString(), ref unused);
        }

        /**
        * \brief Compiles a list of the FulltimeEmployee's information
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the FulltimeEmployee information
        * and add it to a string in a list format. The method will then
        * return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the FulltimEmployee information
        */
        override public string Details()
        {
            string empDetails = "";
            string sin = "";
            string dob = "";
            string doh = "";
            string dot = "";

            if (GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
            }

            if (GetDateOfHire() != DateTime.MinValue)
            {
                doh = GetDateOfHire().ToString("d");
            }
            else
            {
                doh = "N/A";
            }

            if (GetDateOfTermination() != DateTime.MinValue)
            {
                dot = GetDateOfTermination().ToString("d");
            }
            else
            {
                dot = "N/A";
            }

            if (GetSocialInsuranceNumber() != "")
            {
                sin = GetSocialInsuranceNumber();

                sin = sin.Insert(6, " ");
                sin = sin.Insert(3, " ");
            }

            empDetails = "First Name: " + GetFirstName() + "\n";
            empDetails += "Last Name: " + GetLastName() + "\n";
            empDetails += "SIN: " + sin + "\n";
            empDetails += "Date Of Birth: " + dob + "\n";
            empDetails += "Date Of Hire: " + doh + "\n";
            empDetails += "Date Of Termination: " + dot + "\n";
            empDetails += "Salary: $" + GetSalary().ToString() + "\n";

            Logging.LogEvent("[FulltimeEmployee.Details]\n" + empDetails);

            return empDetails;
        }

        /**
        * \brief Compiles a list of the FulltimeEmployee's information into database format
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the FulltimeEmployee information
        * and add it to a string in a list format to be added to the ems 
        * database. The method will then return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the FulltimEmployee information
        */
        override public string ToString()
        {
            string empDetails = "FT|";
            string dob = "";
            string doh = "";
            string dot = "";

            if (GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
            }

            if (GetDateOfHire() != DateTime.MinValue)
            {
                doh = GetDateOfHire().ToString("d");
            }
            else
            {
                doh = "N/A";
            }

            if (GetDateOfTermination() != DateTime.MinValue)
            {
                dot = GetDateOfTermination().ToString("d");
            }
            else
            {
                dot = "N/A";
            }

            empDetails += GetLastName() + "|";
            empDetails += GetFirstName() + "|";
            empDetails += GetSocialInsuranceNumber() + "|";
            empDetails += dob + "|";
            empDetails += doh + "|";
            empDetails += dot + "|";
            empDetails += GetSalary() + "|";

            return empDetails;
        }

        /**
        * \brief Check all attributes in the FulltimeEmployee object to ensure they are valid
        *
        * \details <b>Details</b>
        *
        * This method will go through each attribute within the FulltimeEmployee
        * object and makes sure that they are all valid. Will 
        * return a true or a false depending whether or not all attributes
        * are valid.
        * 
        * \param void
        * 
        * \return bool - Returns true if all attributes within the full-time
        * employee are valid. Returns false if there is at least one invalid
        * attribute.
        */
        public bool Validate()
        {
            bool validStatus = true;
            string validStatusStr = "";
            string unused = "";


            if (!Supporting.Validation.ValidateDateOfHire(GetDateOfBirth(), GetDateOfHire(), GetDateOfTermination(), ref unused) || GetDateOfBirth() == DateTime.MinValue)
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateDateOfTermination(GetDateOfBirth(), GetDateOfHire(), GetDateOfTermination(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateSalary(GetSalary(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateName(GetFirstName(), ref unused) || GetFirstName() == "")
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateName(GetLastName(), ref unused) || GetLastName() == "")
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateDateOfBirth(GetDateOfBirth(), ref unused) || GetDateOfBirth() == DateTime.MinValue)
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateSocialInsuranceNumber(GetSocialInsuranceNumber(), ref unused))
            {
                validStatus = false;
            }

            if (validStatus)
            {
                validStatusStr = "Valid\n";
            }
            else
            {
                validStatusStr = "Invalid\n";
            }

            Logging.LogEvent("[FulltimeEmployee.Validate] Employee " + GetLastName() + ", " + GetFirstName() + " SIN(" + GetSocialInsuranceNumber() + ") Was Found To Be " + validStatusStr);

            return validStatus;
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

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (Supporting.Validation.ValidateDateOfHire(GetDateOfBirth(), userInputDateTime, dateOfTermination, ref errorMessage))
                {
                    setStatus = true;
                    dateOfHire = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format For A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[FulltimeEmployee.SetDateOfHire] Attempted To Set dateOfHire Attribute With Invalid Value: " + userInput);
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
                if (Supporting.Validation.ValidateDateOfTermination(GetDateOfBirth(), dateOfHire, userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    dateOfTermination = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format For A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[FulltimeEmployee.SetDateOfTermination] Attempted To Set dateOfTermination Attribute With Invalid Value: " + userInput);
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

            if (float.TryParse(userInput, out userInputFloat))
            {
                userInputFloat = (float)Math.Round(userInputFloat, 2);

                if (Supporting.Validation.ValidateSalary(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    salary = userInputFloat;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Monetary Value Format.\n\nPlease Enter Monetary Values In The Following Format\n0.00     ex. 12.34\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[FulltimeEmployee.SetSalary] Attempted To Set salary Attribute With Invalid Value: " + userInput);
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