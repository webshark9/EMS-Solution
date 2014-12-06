/// \namespace AllEmployees
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

        }

        /**
        * \brief Constructor for the SeasonalEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the SeasonalEmployee child
        * class which is in charge of creating the attributes
        * for the seasonal employee when called upon, taking in
        * a series of parameters ment to be inserted into the SeasonalEmployee
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
        SeasonalEmployee(string seas, float pPay, string fName, string lName, string sin, DateTime dob) : base(fName, lName, sin, dob)
        {
            string unused = "";

            if (Supporting.Validation.ValidateSeason(seas, ref unused))
            {
                season = seas;
            }

            if (Supporting.Validation.ValidatePiecePay(pPay, ref unused))
            {
                piecePay = pPay;
            }
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
        bool Validate()
        {
            bool validStatus = true;
            string unused = "";

            if(!Supporting.Validation.ValidatePiecePay(GetPiecePay(), ref unused))
            {
                validStatus = false;
            }
            else if(!Supporting.Validation.ValidateSeason(GetSeason(), ref unused))
            {
                validStatus = false;
            }
            else if(!Supporting.Validation.ValidateName(GetFirstName(), ref unused))
            {
                validStatus = false;
            }
            else if(!Supporting.Validation.ValidateName(GetLastName(), ref unused))
            {
                validStatus = false;
            }
            else if(!Supporting.Validation.ValidateDateOfBirth(GetDateOfBirth(), ref unused))
            {
                validStatus = false;
            }
            else if(!Supporting.Validation.ValidateSocialInsuranceNumber(GetSocialInsuranceNumber(), ref unused))
            {
                validStatus = false;
            }

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
                if (Supporting.Validation.ValidatePiecePay(userInputFloat, ref errorMessage))
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