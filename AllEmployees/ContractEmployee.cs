
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateContractStartDate(DateTime contractStartDate)
        {
            bool validateStatus = false;



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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidateContractStopDate(DateTime contractStopDate)
        {
            bool validateStatus = false;



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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool ValidatefixedContractAmount(float fixedContractAmount)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the contractStartDate attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the contractStartDate attribute within the ContractEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on whether or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's contract start date
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetContractStartDate(DateTime userInput)
        {
            bool setStatus = false;



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
        * \brief Sets the contractStoptDate attribute within the ContractEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the contractStoptDate attribute within the ContractEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on whether or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's contract stop date
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetContractStopDate(DateTime userInput)
        {
            bool setStatus = false;



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
        * This method will take in a floating integer from the user and call on
        * a separate method to validate it. If the user input floating integer is 
        * valid, then the method will set the fixedContractAmount attribute 
        * within the ContractEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - float - The employee contract pay amount
        *  given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetFixedContractAmount(float userInput)
        {
            bool setStatus = false;



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