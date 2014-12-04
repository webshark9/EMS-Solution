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

            if (Validation.ValidateSeason(userInput, ref errorMessage))
            {
                setStatus = true;
                season = userInput;
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
        * \param userInput - string - The employee salary per job
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
                if (Validation.ValidatePiecePay(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    piecePay = userInputFloat;
                }
            }
            else
            {
                //UIMenu.printErrorMessage("\"Piece Pay\" is not formatted correctly\nPlease be sure to use the format\n$\"00.00\"     ex.$56.78\n\n");
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