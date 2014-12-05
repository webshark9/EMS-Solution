/// \namespace Supporting
/// 
/// \brief Contains the FileIO class, Logging class, and the Validation class
/// 
/// File: FileIO.cs, Logging.cs, and Validation.cs \n
/// Project: EMS Term Project \n
/// First Version: Nov.17/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Text;

namespace Supporting
{
    /// \class Validation
    /// 
    /// \brief Contains methods to validate employee atttributes
    /// 
    /// File: Validation.cs
    /// Project: EMS Term Project
    /// First Version: Dec.3/2014
    ///
    /// This file contains the Validation class which will
    /// take in attributes to be used in employee objects
    /// and make sure they are valid. These methods will also
    /// return a string which will contain the error should
    /// the attribute be invalid.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class Validation
    {
        /**
        * \brief Validates the first/lastName attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * employee first/last name and check whether or not it is a
        * valid name. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param firstName - string - The employee's first/last name 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateName(string name, ref string errorMessage)
        {
            bool validateStatus = true;
            errorMessage = "Invalid Characters Found:\n";

            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    if (name[i] != '\'' && name[i] != '-')
                    {
                        errorMessage += name[i] + " ";
                        validateStatus = false;
                    }
                }

                if (validateStatus == false)
                {
                    errorMessage += "\n\nPlease Be Sure To Only Enter:\nA-Z\na-z\n-\n'";
                }
                else
                {
                    errorMessage = "";
                }
            }

            return validateStatus;
        }

        /**
        * \brief Validates the socialInsuranceNumber attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a string of user input representing the desired
        * employee social insurance number and check whether or not it is a
        * valid social insurance number. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param socialInsuranceNumber - string - The employee's social insurance
        * number given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateSocialInsuranceNumber(string socialInsuranceNumber, ref string errorMessage)
        {
            bool validateStatus = true;
            string sinValNumTwoStr = "";
            int checkSum = 0;
            int sinNumLength = 9;
            int[] sinNumInt = new int[9];
            int sinValNumOne = 0;
            int sinValNumTwo = 0;
            int roundedUpInt = 0;
            errorMessage = "Invalid Characters Found:\n";

            if(socialInsuranceNumber.Length == sinNumLength)
            {
                for(int i = 0; i < socialInsuranceNumber.Length; i++)
                {
                    if (!Char.IsDigit(socialInsuranceNumber[i]))
                    {
                        errorMessage += socialInsuranceNumber[i] + " ";
                        validateStatus = false;
                    }
                    else
                    {
                        sinNumInt[i] = (Convert.ToInt32(socialInsuranceNumber[i]) - 48);
                    }
                }

                if(validateStatus)
                {
                    //add up all the numbers in the odd placeholders
                    for(int i = 0; i <= 6; i++)
                    {
                        sinValNumOne += sinNumInt[i];

                        i++;
                    }

                    //add up all the numbers in the even placeholders
                    for(int i = 1; i <= 7; i++)
                    {
                        sinValNumTwoStr += Convert.ToString((sinNumInt[i] * 2));
                        i++;
                    }

                    for(int i = 0; i < sinValNumTwoStr.Length; i++)
                    {
                        sinValNumTwo += (Convert.ToInt32(sinValNumTwoStr[i]) - 48);
                    }

                    sinValNumOne += sinValNumTwo;
                    roundedUpInt = sinValNumOne;

                    while ((roundedUpInt % 10) != 0)
                    {
                        roundedUpInt++;
                    }

                    checkSum = (Convert.ToInt32(socialInsuranceNumber[8]) - 48);
                    if(checkSum != (roundedUpInt - sinValNumOne))
                    {
                        validateStatus = false;
                        errorMessage = "Invalid SIN. Please Be Sure To Enter A Valid SIN.";
                    }
                }
                else
                {
                    errorMessage += "\n\nPlease Be Sure To Only Enter:\n0-9";
                }
            }
            else
            {
                errorMessage = "Please Be Sure You Social Insurance Number\nIs 9 Digits In Length\n";
                validateStatus = false;
            }

            if (validateStatus)
            {
                errorMessage = "";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the dateOfBirth attribute within the Employee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a dateOfBirth variable representing the 
        * employee's date of birth and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param dateOfBirth - DateTime - The employee's date of birth 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateDateOfBirth(DateTime dateOfBirth, ref string errorMessage)
        {
            bool validateStatus = true;
            int ageRequirement = 16;
            errorMessage = "";

            if ((DateTime.Today.Year - dateOfBirth.Year) < ageRequirement)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure The Employee Is Older Than 16 Years Old\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the dateOfHire attribute within the FulltimeEmployee class
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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateDateOfHire(DateTime dateOfHire, ref string errorMessage)
        {
            bool validateStatus = true;
            errorMessage = "";

            if (dateOfHire > DateTime.Today)//////////////////////////////////fix
            {
                validateStatus = false;
                errorMessage = "Please Be Sure The Date Of Hire Does Not Exceed The Present Day\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the dateOfTermination attribute within the FulltimeEmployee class
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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateDateOfTermination(DateTime dateOfTermination, ref string errorMessage)
        {
            bool validateStatus = true;
            errorMessage = "";

            if (dateOfTermination > DateTime.Today/* || dateOfTermination < dateOfHire*/)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure The Date Of Termination Does Not Exceed The Present Day\nOr Precede The Date Of Hire\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the salary attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer representing the 
        * employee's wage and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param salary - float - The amount of money the employee makes
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateSalary(float salary, ref string errorMessage)
        {
            bool validateStatus = true;
            float salaryMinimum = 0;

            if(salary < salaryMinimum)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure To Enter A Non-Negative Salary.\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the contractStartDate attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable representing the 
        * employee's contract starting date and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param contractStartDate - DateTime - The employee's contract starting date 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateContractStartDate(DateTime contractStartDate, ref string errorMessage)
        {
            bool validateStatus = true;
            errorMessage = "";

            if (contractStartDate > DateTime.Today)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure The Contract Start Date Does Not Exceed The Present Day\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the contractStopDate attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable representing the 
        * employee's contract ending date and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param contractStopDate - DateTime - The employee's contract ending date 
        * given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateContractStopDate(DateTime contractStopDate, ref string errorMessage)
        {
            bool validateStatus = true;
            errorMessage = "";

            if (contractStopDate > DateTime.Today/* || contractStopDate < contractStartDate*/)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure The Contract Stop Date Does Not Exceed The Present Day\nOr Precede The Contract Start Date\n";
            }

            return validateStatus;
        }

        /**
        * \brief Sets the salary fixedContractAmount within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer representing the 
        * employee's contract wage and check whether or not it is a
        * valid entry. Returns a true or false depending on whether or not the 
        * attribute is valid.
        * 
        * \param fixedContractAmount - float - The amount of money the employee will make
        * for the given contract given by the user.
        * 
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateFixedContractAmount(float fixedContractAmount, ref string errorMessage)
        {
            bool validateStatus = false;
            float amountMinimum = 0;

            if (fixedContractAmount < amountMinimum)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure To Enter A Non-Negative Amount.\n";
            }

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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateHourlyRate(float hourlyRate, ref string errorMessage)
        {
            bool validateStatus = true;
            float rateMinimum = 0;

            if (hourlyRate < rateMinimum)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure To Enter A Non-Negative Rate.\n";
            }

            return validateStatus;
        }

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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidateSeason(string season, ref string errorMessage)
        {
            bool validateStatus = true;
            season.ToLower();

            if(season != "summer" && season != "fall" && season != "winter" && season != "spring")
            {
                validateStatus = false;
                errorMessage = "Please Enter A Valid Season.\n";
            }

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
        * \param errorMessage - string - The error message container 
        * which is passed as a reference from the calling method
        * 
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        public static bool ValidatePiecePay(float piecePay, ref string errorMessage)
        {
            bool validateStatus = true;
            float payMinimum = 0;

            if (piecePay < payMinimum)
            {
                validateStatus = false;
                errorMessage = "Please Be Sure To Enter A Non-Negative Pay Amount.\n";
            }

            return validateStatus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool ValidateBusinessNumber(string businessNumber, ref string errorMessage)
        {
            bool validateStatus = true;

            return validateStatus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool ValidateDateOfCreation(DateTime dateOfCreation, ref string errorMessage)
        {
            bool validateStatus = true;

            return validateStatus;
        }
    }
}