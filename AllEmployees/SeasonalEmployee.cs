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
/// \author Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class SeasonalEmployee : Employee
    {
        string season;
        float piecePay;

        /**
        * \brief Sets the season attibute within the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the season attribute within
        * the SeasonalEmployee class to the user input string. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - string - The season the employee will be employed in 
        * given by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSeason(string userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retreives the season attribute from the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the season attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set season attribute within the 
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
        * This method will take in a floating integer from the user and call on
        * a separate method to validate it. If the user input floating integer is 
        * valid, then the method will set the piecePay attribute 
        * within the SeasonalEmployee class to the user input floating integer. Returns a true 
        * or false depending on weather or not the attribute was set successfully.
        * 
        * \param userInput - float - The employee salary per job
        *  given by the user.
        * 
        * \return bool - Returns true if the attibute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetPiecePay(float userInput)
        {
            bool setStatus = false;



            return setStatus;
        }

        /**
        * \brief Retreives the piecePay attribute from the SeasonalEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the piecePay attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set piecePay attribute within the 
        * SeasonalEmployee class
        */
        public float GetPiecePay()
        {
            return piecePay;
        }
    }
}