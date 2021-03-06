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
    /// \class SeasonalEmployee
    /// 
    /// \brief Contains seasonal employee information
    /// 
    /// File: SeasonalEmployee.cs
    /// Project: EMS Term Project
    /// First Version: Nov.13/2014
    ///
    /// This file contains the SeasonalEmployee child class which
    /// holds the information to be used in the seasonal employee
    /// model contained in the EMS Term Project.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class SeasonalEmployee : Employee
    {
        string season;///< used to hold the season the employee is working or did work
        float piecePay;///< used to hold the amount the employee is paid for a piece of work

        /**
        * \brief Default constructor for the SeasonalEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is the default constructor for the SeasonalEmployee child
        * class which is in charge of creating the attributes
        * for the seasonal employee when called upon. This
        * constructor also calls upon the default Employee class parent constructor.
        * 
        * \param void
        *
        * \return void
        */
        public SeasonalEmployee() : base()
        {
            season = "";
            piecePay = 0;
        }

        /**
        * \brief Constructor for the SeasonalEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the SeasonalEmployee child
        * class which is in charge of creating the attributes
        * for the seasonal employee when called upon, taking in
        * a series of parameters meant to be inserted into the SeasonalEmployee
        * object, and validating the parameters before trying to insert them.
        * Should a parameter be found invalid, the attribute will be left blank.
        * This constructor also calls upon the Employee class parent constructor.
        * 
        * \param seas - string - The season the employee will be employed in 
        * given by the user.
        *
        * \param pPay - float - The employee's salary per job
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
        * \param dob - DateTime - The employee's date of birth
        * given by the user.
        *  
        * \return void
        */
        public SeasonalEmployee(string seas, float pPay, string fName, string lName, string sin, DateTime dob) : base(fName, lName, sin)
        {
            string unused = "";

            season = "";
            piecePay = 0;

            if (Supporting.Validation.ValidateSeason(seas, ref unused))
            {
                season = seas;
            }

            if (Supporting.Validation.ValidatePiecePay(pPay, ref unused))
            {
                piecePay = pPay;
            }

            if (Supporting.Validation.ValidateDateOfBirth(dob, ref unused))
            {
                SetDateOfBirth(dob.ToString("d"), ref unused);
            }
        }

        public SeasonalEmployee(SeasonalEmployee oldEmployee) : base(oldEmployee.GetFirstName(), oldEmployee.GetLastName(), oldEmployee.GetSocialInsuranceNumber())
        {
            string unused = "";

            this.season = oldEmployee.season;
            this.piecePay = oldEmployee.piecePay;
            SetDateOfBirth(oldEmployee.GetDateOfBirth().ToString(), ref unused);

        }

        /**
        * \brief Compiles a list of the SeasonalEmployee's information
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the SeasonalEmployee information
        * and add it to a string in a list format. The method will then
        * return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the SeasonalEmployee information
        */
        override public string Details()
        {
            string empDetails = "";
            string sin = "";
            string dob = "";

            if (GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
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
            empDetails += "Season: " + GetSeason() + "\n";
            empDetails += "Piece Pay: $" + GetPiecePay().ToString() + "\n";

            Logging.LogEvent("[SeasonalEmployee.Details]\n" + empDetails);

            return empDetails;
        }

        /**
        * \brief Compiles a list of the SeasonalEmployee's information into database format
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the SeasonalEmployee information
        * and add it to a string in a list format to be added to the ems 
        * database. The method will then return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the SeasonalEmployee information
        */
        override public string ToString()
        {
            string empDetails = "SN|";
            string dob = "";

            if (GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
            }

            empDetails += GetLastName() + "|";
            empDetails += GetFirstName() + "|";
            empDetails += GetSocialInsuranceNumber() + "|";
            empDetails += dob + "|";
            empDetails += GetSeason() + "|";
            empDetails += GetPiecePay() + "|";

            return empDetails;
        }

        /**
        * \brief Check all attributes in the SeasonalEmployee object to ensure they are valid
        *
        * \details <b>Details</b>
        *
        * This method will go through each attribute within the SeasonalEmployee
        * object and makes sure that they are all valid. Will 
        * return a true or a false depending whether or not all attributes
        * are valid.
        * 
        * \param void
        * 
        * \return bool - Returns true if all attributes within the seasonal
        * employee are valid. Returns false if there is at least one invalid
        * attribute.
        */
        public bool Validate()
        {
            bool validStatus = true;
            string validStatusStr = "";
            string unused = "";

            if (!Supporting.Validation.ValidatePiecePay(GetPiecePay(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateSeason(GetSeason(), ref unused) || GetSeason() == "")
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

            Logging.LogEvent("[SeasonalEmployee.Validate] Employee " + GetLastName() + ", " + GetFirstName() + " SIN(" + GetSocialInsuranceNumber() + ") Was Found To Be " + validStatusStr);

            return validStatus;
        }

        /**
        * \brief Sets the season attribute within the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>season</i> attribute within
        * the SeasonalEmployee class to the user input string. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The season the employee will be employed in 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSeason(string userInput, ref string errorMessage)
        {
            bool setStatus = false;

            if (Supporting.Validation.ValidateSeason(userInput, ref errorMessage))
            {
                setStatus = true;
                season = userInput;
            }

            if (!setStatus)
            {
                Logging.LogEvent("[SeasonalEmployee.SetSeason] Attempted To Set season Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>season</i> attribute from the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>season</i> attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>season</i> attribute within the 
        * SeasonalEmployee class
        */
        public string GetSeason()
        {
            return season;
        }

        /**
        * \brief Sets the piecePay attribute within the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a floating integer, making sure it is valid format, and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>piecePay</i> attribute within
        * the SeasonalEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's salary per job
        *  given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetPiecePay(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            float userInputFloat = 0;

            if (float.TryParse(userInput, out userInputFloat))
            {
                userInputFloat = (float)Math.Round(userInputFloat, 2);

                if (Supporting.Validation.ValidatePiecePay(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    piecePay = userInputFloat;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Monetary Value Format.\n\nPlease Enter Monetary Values In The Following Format\n0.00     ex. 12.34\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[SeasonalEmployee.SetPiecePay] Attempted To Set piecePay Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the <i>piecePay</i> attribute from the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the <i>piecePay</i> attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set <i>piecePay</i> attribute within the 
        * SeasonalEmployee class
        */
        public float GetPiecePay()
        {
            return piecePay;
        }
    }
}