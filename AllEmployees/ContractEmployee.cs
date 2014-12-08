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
    /// \class ContractEmployee
    /// 
    /// \brief Contains contract employee information
    /// 
    /// File: ContractEmployee.cs
    /// Project: EMS Term Project
    /// First Version: Nov.13/2014
    ///
    /// This file contains the ContractEmployee child class which
    /// holds the information to be used in the contract employee
    /// model contained in the EMS Term Project.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class ContractEmployee : Employee
    {
        DateTime contractStartDate;///< used to hold the date the contract started
        DateTime contractStopDate;///< used to hold the date the contract ended
        float fixedContractAmount;///< used to hold the contract amount

        /**
        * \brief Default constructor for the ContractEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is the default constructor for the ContractEmployee child
        * class which is in charge of creating the attributes
        * for the contract employee when called upon. This
        * constructor also calls upon the default Employee class parent constructor.
        * 
        * \param void
        *
        * \return void
        */
        public ContractEmployee() : base()
        {
            contractStartDate = new DateTime();
            contractStopDate = new DateTime();
            fixedContractAmount = 0;
        }

        /**
        * \brief Constructor for the ContractEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the ContractEmployee child
        * class which is in charge of creating the attributes
        * for the contract employee when called upon, taking in
        * a series of parameters meant to be inserted into the ContractEmployee
        * object, and validating the parameters before trying to insert them.
        * Should a parameter be found invalid, the attribute will be left blank.
        * This constructor also calls upon the Employee class parent constructor.
        * 
        * \param conStarDate - DateTime - The employee's contract start date given 
        * by the user.
        *
        * \param conStopDate - DateTime - The employee's contract stop date given 
        * by the user.
        * 
        * \param fixedConAmount - float - The employee contract pay amount
        *  given by the user.
        *  
        * \param fName - string - The desired employee first name given 
        * by the user.
        * 
        * \param lName - string - The desired employee last name given 
        * by the user.
        * 
        * \param sin - string - The company's social insurance
        * number given by the user.
        * 
        * \param dob - DateTime - The company's date of creation given 
        * by the user.
        * 
        * \return void
        */
        public ContractEmployee(DateTime conStarDate, DateTime conStopDate, float fixedConAmount, string lName, string sin, DateTime dob) : base()
        {
            string unused = "";

            contractStartDate = new DateTime();
            contractStopDate = new DateTime();
            fixedContractAmount = 0;

            if (Supporting.Validation.ValidateContractStartDate(dob, conStarDate, conStopDate, ref unused))
            {
                contractStartDate = conStarDate;
            }

            if (Supporting.Validation.ValidateContractStopDate(dob, conStarDate, conStopDate, ref unused))
            {
                contractStopDate = conStopDate;
            }

            if (Supporting.Validation.ValidateFixedContractAmount(fixedConAmount, ref unused))
            {
                fixedContractAmount = fixedConAmount;
            }

            if(Supporting.Validation.ValidateName(lName, ref unused))
            {
                SetLastName(lName, ref unused);
            }

            if(Supporting.Validation.ValidateSocialInsuranceNumber(sin, ref unused))
            {
                SetSocialInsuranceNumber(sin, ref unused);
            }

            if (Supporting.Validation.ValidateDateOfCreation(sin, dob, ref unused))
            {
                SetDateOfBirth(dob.ToString(), ref unused);
            }
        }

        public ContractEmployee(ContractEmployee oldEmployee) : base("", oldEmployee.GetLastName(), oldEmployee.GetSocialInsuranceNumber())
        {
            string unused = "";

            this.contractStartDate = oldEmployee.contractStartDate;
            this.contractStopDate = oldEmployee.contractStopDate;
            this.fixedContractAmount = oldEmployee.fixedContractAmount;
            this.SetDateOfCreation(oldEmployee.GetDateOfBirth().ToString(), ref unused);

        }

        /**
        * \brief Compiles a list of the ContractEmployee's information
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the ContractEmployee information
        * and add it to a string in a list format. The method will then
        * return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the ContractEmployee information
        */
        override public string Details()
        {
            string empDetails = "";
            string bn = "";
            string dob = "";
            string cStarDate = "";
            string cStopDate = "";

            if(GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
            }

            if(GetContractStartDate() != DateTime.MinValue)
            {
                cStarDate = GetContractStartDate().ToString("d");
            }
            else
            {
                cStarDate = "N/A";
            }

            if(GetContractStopDate() != DateTime.MinValue)
            {
                cStopDate = GetContractStopDate().ToString("d");
            }
            else
            {
                cStopDate = "N/A";
            }

            if (GetSocialInsuranceNumber() != "")
            {
                bn = GetSocialInsuranceNumber();

                bn = bn.Insert(5, " ");
            }

            empDetails += "Business Name: " + GetLastName() + "\n";
            empDetails += "Business Number: " + bn + "\n";
            empDetails += "Business Date Of Creation: " + dob + "\n";
            empDetails += "Contract Start Date: " + cStarDate + "\n";
            empDetails += "Contract Stop Date: " + cStopDate + "\n";
            empDetails += "Fixed Contract Amount: " + GetFixedContractAmount().ToString() + "\n";

            Logging.LogEvent("[ContractEmployee.Details]\n" + empDetails);

            return empDetails;
        }

        /**
        * \brief Compiles a list of the ContractEmployee's information into database format
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the ContractEmployee information
        * and add it to a string in a list format to be added to the ems 
        * database. The method will then return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the ContractEmployee information
        */
        override public string ToString()
        {
            string empDetails = "CT|";

            string dob = "";
            string cStarDate = "";
            string cStopDate = "";

            if (GetDateOfBirth() != DateTime.MinValue)
            {
                dob = GetDateOfBirth().ToString("d");
            }
            else
            {
                dob = "N/A";
            }

            if (GetContractStartDate() != DateTime.MinValue)
            {
                cStarDate = GetContractStartDate().ToString("d");
            }
            else
            {
                cStarDate = "N/A";
            }

            if (GetContractStopDate() != DateTime.MinValue)
            {
                cStopDate = GetContractStopDate().ToString("d");
            }
            else
            {
                cStopDate = "N/A";
            }

            empDetails += GetLastName() + "|";
            empDetails += GetFirstName() + "|";
            empDetails += GetSocialInsuranceNumber() + "|";
            empDetails += dob + "|";
            empDetails += cStarDate + "|";
            empDetails += cStopDate + "|";
            empDetails += GetFixedContractAmount() + "|";

            return empDetails;
        }

        /**
        * \brief Check all attributes in the ContractEmployee object to ensure they are valid
        *
        * \details <b>Details</b>
        *
        * This method will go through each attribute within the ContractEmployee
        * object and makes sure that they are all valid. Will 
        * return a true or a false depending whether or not all attributes
        * are valid.
        * 
        * \param void
        * 
        * \return bool - Returns true if all attributes within the contract
        * employee are valid. Returns false if there is at least one invalid
        * attribute.
        */
        public bool Validate()
        {
            bool validStatus = true;
            string validStatusStr = "";
            string unused = "";

            if (!Supporting.Validation.ValidateContractStartDate(GetDateOfBirth(), GetContractStartDate(), GetContractStopDate(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateContractStopDate(GetDateOfBirth(), GetContractStartDate(), GetContractStopDate(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateFixedContractAmount(GetFixedContractAmount(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateName(GetLastName(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateDateOfCreation(GetSocialInsuranceNumber(), GetDateOfBirth(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateBusinessNumber(GetSocialInsuranceNumber(), GetDateOfBirth(), ref unused))
            {
                validStatus = false;
            }

            if(validStatus)
            {
                validStatusStr = "Valid\n";
            }
            else
            {
                validStatusStr = "Invalid\n";
            }

            Logging.LogEvent("[ContractEmployee.Validate] Employee " + GetLastName() + ", " + GetFirstName() + " SIN(" + GetSocialInsuranceNumber() + ") Was Found To Be " + validStatusStr);

            return validStatus;
        }

        /**
        * \brief Sets the <i>contractStartDate</i> attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>contractStartDate</i> attribute within
        * the ContractEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's contract start date given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetContractStartDate(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (Supporting.Validation.ValidateContractStartDate(GetDateOfBirth(), userInputDateTime, contractStopDate, ref errorMessage))
                {
                    setStatus = true;
                    contractStartDate = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format For A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[ContractEmployee.SetContractStartDate] Attempted To Set contractStartDate Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the contractStartDate attribute from the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the contractStartDate attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>contractStartDate</i> attribute within the 
        * ContractEmployee class
        */
        public DateTime GetContractStartDate()
        {
            return contractStartDate;
        }

        /**
        * \brief Sets the <i>contractStopDate</i> attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a DateTime variable, making sure it is valid format, and call on
        * a separate method to validate it. If the DateTime Variable is 
        * valid, then the method will set the <i>contractStopDate</i> attribute within
        * the ContractEmployee class to the user input DateTime. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee's contract stop date given 
        * by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetContractStopDate(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            DateTime userInputDateTime;

            if (DateTime.TryParse(userInput, out userInputDateTime))
            {
                if (Supporting.Validation.ValidateContractStopDate(GetDateOfBirth(), contractStartDate, userInputDateTime, ref errorMessage))
                {
                    setStatus = true;
                    contractStopDate = userInputDateTime;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Format For A Date.\n\nPlease Enter Dates In The Following Format\nyyyy-mm-dd     ex. 2012-08-29\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[ContractEmployee.SetContractStopDate] Attempted To Set contractStopDate Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the contractStopDate attribute from the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the contractStopDate attribute as a DateTime variable to the
        * calling method.
        * 
        * \param None
        * 
        * \return DateTime - The currently set <i>contractStopDate</i> attribute within the 
        * ContractEmployee class
        */
        public DateTime GetContractStopDate()
        {
            return contractStopDate;
        }

        /**
        * \brief Sets the fixedContractAmount attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input, convert it
        * to a floating integer, making sure it is valid format, and call on
        * a separate method to validate it. If the user input string is 
        * valid, then the method will set the <i>fixedContractAmount</i> attribute within
        * the ContractEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - string - The employee contract pay amount
        *  given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetFixedContractAmount(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            float userInputFloat = 0;

            if (float.TryParse(userInput, out userInputFloat))
            {
                if (Supporting.Validation.ValidateFixedContractAmount(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    fixedContractAmount = userInputFloat;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Monetary Value Format.\n\nPlease Enter Monetary Values In The Following Format\n0.00     ex. 12.34\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[ContractEmployee.SetFixedContractAmount] Attempted To Set fixedContractAmount Attribute With Invalid Value: " + userInput);
            }

            return setStatus;
        }

        /**
        * \brief Retrieves the fixedContractAmount attribute from the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will return the fixedContractAmount attribute as a floating integer to the
        * calling method.
        * 
        * \param None
        * 
        * \return float - The currently set <i>fixedContractAmount</i> attribute within the 
        * ContractEmployee class
        */
        public float GetFixedContractAmount()
        {
            return fixedContractAmount;
        }
    }
}