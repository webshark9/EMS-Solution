
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        * \brief Validates the season attribute within the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * season the employee will be working and check whether or not it is a
        * valid season. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param season - string - The season the employee will be employed in 
        * given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateSeason(string season)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Validates the piecePay attribute within the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer representing the desired
        * piece pay the employee will receive and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param piecePay - float - The piece pay the employee will recieve 
        * given by the user.
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validatePiecePay(float piecePay)
        {
            bool validateStatus = false;



            return validateStatus;
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
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSeason(string userInput)
        {
            bool setStatus = false;



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
        * \brief Sets the <i>piecePay</i> attribute within the SeasonalEmployee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer from the user and call on
        * a separate method to validate it. If the user input floating integer is 
        * valid, then the method will set the <i>piecePay</i> attribute 
        * within the SeasonalEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - float - The employee salary per job
        *  given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetPiecePay(float userInput)
        {
            bool setStatus = false;



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