
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateDateOfHire(DateTime dateOfHire)
        {
            bool validateStatus = false;



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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateDateOfTermination(DateTime dateOfTermination)
        {
            bool validateStatus = false;



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
        * \return bool - Returns true if the attribute is valid.
        * Returns false if the attribute is not valid.
        */
        private bool validateSalary(float salary)
        {
            bool validateStatus = false;



            return validateStatus;
        }

        /**
        * \brief Sets the <i>dateOfHire</i> attribute within the FulltimeEmployee class
        *
        * \details <b>Details</b>
        *
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the <i>dateOfHire</i> attribute within the FulltimeEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on whether or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of hire
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfHire(DateTime userInput)
        {
            bool setStatus = false;



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
        * This method will take in a DateTime variable, given by the user, and call on
        * a separate method to validate it. If the user input DateTime variable is 
        * valid, then the method will set the <i>dateOfTermination</i> attribute within the FulltimeEmployee class 
        * to the user input DateTime variable. Returns a true or false depending 
        * on whether or not the attribute was set successfully.
        * 
        * \param userInput - DateTime - The employee's date of termination
        * given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetDateOfTermination(DateTime userInput)
        {
            bool setStatus = false;



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
        * \brief Sets the <i>salary</i> attribute within the FulltimeEmployee class 
        *
        * \details <b>Details</b>
        *
        * This method will take in a floating integer from the user and call on
        * a separate method to validate it. If the user input floating integer is 
        * valid, then the method will set the <i>salary</i> attribute 
        * within the FulltimeEmployee class to the user input floating integer. Returns a true 
        * or false depending on whether or not the attribute was set successfully.
        * 
        * \param userInput - float - The employee salary
        *  given by the user.
        * 
        * \return bool - Returns true if the attribute was set successfully.
        * Returns false if the attribute was not set successfully.
        */
        public bool SetSalary(float userInput)
        {
            bool setStatus = false;



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