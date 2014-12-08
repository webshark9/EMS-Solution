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
        * \brief Default constructor for the ParttimeEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is the default constructor for the ParttimeEmployee child
        * class which is in charge of creating the attributes
        * for the part-time employee when called upon. This
        * constructor also calls upon the default Employee class parent constructor.
        * 
        * \param void
        *
        * \return void
        */
        public ParttimeEmployee() : base()
        {
            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            hourlyRate = 0;
        }

        /**
        * \brief Constructor for the ParttimeEmployee child class
        *
        * \details <b>Details</b>
        *
        * This is a constructor for the ParttimeEmployee child
        * class which is in charge of creating the attributes
        * for the part-time employee when called upon, taking in
        * a series of parameters meant to be inserted into the ParttimeEmployee
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
        * \param hRate - float - The employee salary rate per hour
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
        public ParttimeEmployee(DateTime doh, DateTime dot, float hRate, string fName, string lName, string sin, DateTime dob) : base(fName, lName, sin)
        {
            string unused = "";

            dateOfHire = new DateTime();
            dateOfTermination = new DateTime();
            hourlyRate = 0;

            if (Supporting.Validation.ValidateDateOfHire(dob, doh, dot, ref unused))
            {
                dateOfHire = doh;
            }

            if (Supporting.Validation.ValidateDateOfTermination(dob, doh, dot, ref unused))
            {
                dateOfTermination = dot;
            }

            if (Supporting.Validation.ValidateHourlyRate(hRate, ref unused))
            {
                hourlyRate = hRate;
            }

            if (Supporting.Validation.ValidateDateOfBirth(dob, doh, dot, ref unused))
            {
                SetDateOfBirth(dob.ToString("d"), ref unused);
            }
        }

        public ParttimeEmployee(ParttimeEmployee oldEmployee) : base(oldEmployee.GetFirstName(), oldEmployee.GetLastName(), oldEmployee.GetSocialInsuranceNumber())
        {
            string unused = "";

            this.dateOfHire = oldEmployee.dateOfHire;
            this.dateOfTermination = oldEmployee.dateOfTermination;
            this.hourlyRate = oldEmployee.hourlyRate;
            SetDateOfBirth(oldEmployee.GetDateOfBirth().ToString(), ref unused);
        }

        /**
        * \brief Compiles a list of the ParttimeEmployee's information
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the ParttimeEmployee information
        * and add it to a string in a list format. The method will then
        * return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the ParttimeEmployee information
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
            empDetails += "Hourly Rate: $" + GetHourlyRate().ToString() + "\n";

            Logging.LogEvent("[ParttimeEmployee.Details]\n" + empDetails);

            return empDetails;
        }

        /**
        * \brief Compiles a list of the ParttimeEmployee's information into database format
        *
        * \details <b>Details</b>
        *
        * This Method will take all of the ParttimeEmployee information
        * and add it to a string in a list format to be added to the ems 
        * database. The method will then return the string to the calling method.
        * 
        * \param void
        * 
        * \return string - A list of all the ParttimeEmployee information
        */
        override public string ToString()
        {
            string empDetails = "PT|";
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
            empDetails += GetHourlyRate() + "|";

            return empDetails;
        }

        /**
        * \brief Check all attributes in the ParttimeEmployee object to ensure they are valid
        *
        * \details <b>Details</b>
        *
        * This method will go through each attribute within the ParttimeEmployee
        * object and makes sure that they are all valid. Will 
        * return a true or a false depending whether or not all attributes
        * are valid.
        * 
        * \param void
        * 
        * \return bool - Returns true if all attributes within the part-time
        * employee are valid. Returns false if there is at least one invalid
        * attribute.
        */
        public bool Validate()
        {
            bool validStatus = true;
            string validStatusStr = "";
            string unused = "";

            if (!Supporting.Validation.ValidateDateOfHire(GetDateOfBirth(), GetDateOfHire(), GetDateOfTermination(), ref unused) || GetDateOfHire() == DateTime.MinValue)
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateDateOfTermination(GetDateOfBirth(), GetDateOfHire(), GetDateOfTermination(), ref unused))
            {
                validStatus = false;
            }
            else if (!Supporting.Validation.ValidateHourlyRate(GetHourlyRate(), ref unused))
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

            Logging.LogEvent("[ParttimeEmployee.Validate] Employee " + GetLastName() + ", " + GetFirstName() + " SIN(" + GetSocialInsuranceNumber() + ") Was Found To Be " + validStatusStr);

            return validStatus;
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
                Logging.LogEvent("[ParttimeEmployee.SetDateOfHire] Attempted To Set dateOfHire Attribute With Invalid Value: " + userInput);
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
                Logging.LogEvent("[ParttimeEmployee.SetDateOfTermination] Attempted To Set dateOfTermination Attribute With Invalid Value: " + userInput);
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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetHourlyRate(string userInput, ref string errorMessage)
        {
            bool setStatus = false;
            float userInputFloat = 0;

            if (float.TryParse(userInput, out userInputFloat))
            {
                userInputFloat = (float)Math.Round(userInputFloat, 2);

                if (Supporting.Validation.ValidateHourlyRate(userInputFloat, ref errorMessage))
                {
                    setStatus = true;
                    hourlyRate = userInputFloat;
                }
            }
            else
            {
                errorMessage = userInput + " Is Not A Valid Monetary Value Format.\n\nPlease Enter Monetary Values In The Following Format\n0.00     ex. 12.34\n";
            }

            if (!setStatus)
            {
                Logging.LogEvent("[ParttimeEmployee.SetHourlyRate] Attempted To Set hourlyRate Attribute With Invalid Value: " + userInput);
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