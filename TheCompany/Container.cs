/// \namespace TheCompany
/// 
/// \brief Contains the Container class
/// 
/// File: Container.cs \n
/// Project: EMS Term Project \n
/// First Version: Nov.13/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TheCompany
{
    /// \class Container
    /// 
    /// \brief Stores Employee objects (acts as a virtual database)
    /// 
    /// File: Container.cs \n
    /// Project: EMS Term Project \n
    /// First Version: Nov.13/2014 \n
    ///
    /// This class is responsible for storing the employees as well 
    /// as allowing employees to be added, removed, modified, and accessed.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

    public class Container
    {
        private ArrayList virtualDB;///< our container for storing all of our employees
        private int lastIndex;///< used to tell what the last employee was that was returned from NextEmployee()

        /**
        * \brief To add a new employee to the data base
        * \details <b>Details</b>
        *
        * This method attempts to add the employee object passed as a parameter to the <i>virtualDB</i> data member.
        * If the employee is not valid it will not add it. This method also logs whether the log was successful or 
        * not.
        * 
        * \param newEmployee - AllEmployees.Employee - the employee to be added
        * 
        * \return A bool <i>addSuccessful</i> which will be 'true' if the employee was added successfully and 'false' otherwise
        *
        */
        public bool AddEmployee(AllEmployees.Employee newEmployee)
        {
            bool addSuccessful = false;
            
            //FulltimeEmployee possibleEmployee = (FulltimeEmployee)newEmployee;

            /*
            if (possibleEmployee.Validate() == true)
            {
                virtualDB.Add(possibleEmployee);
            }
            */

            return addSuccessful;
        }

        /**
        * \brief To remove an employee from the data base
        * \details <b>Details</b>
        *
        * This method attempts to remove the employee object passed as a parameter from the <i>virtualDB</i> data member
        * by searching the data base for the object. This method also logs whether the remove was successful or not.
        * 
        * \param employeeToRemove - AllEmployees.Employee - the employee that is to be removed
        * 
        * \return A bool <i>removeSuccessful</i> which will be 'true' if the employee was removed successfully and 'false' otherwise
        *
        */
        public bool RemoveEmployee(AllEmployees.Employee employeeToRemove)
        {
            bool removeSuccessful = false;

            foreach( AllEmployees.Employee storedEmployee in virtualDB)
            {
                if(storedEmployee.GetSocialInsuranceNumber() == (AllEmployees.Employee)employeeToRemove.GetSocialInsuranceNumber())
                {

                }


            }

            return removeSuccessful;
        }

        /**
        * \brief To modify an employee in the data base
        * \details <b>Details</b>
        *
        * This method searches the data base for the first parameter, and if it finds it the method then replaces it with the 
        * second parameter.
        * 
        * \param employeeToModify - AllEmployees.Employee - the employee that is to be modified
        * \param newEmployee - AllEmployees.Employee - the employee to replace the old employee
         * 
        * \return A bool <i>modifySuccessful</i> which will be 'true' if the employee was modified successfully and 'false' otherwise
        *
        */
        public bool ModifyEmployee(AllEmployees.Employee employeeToModify, AllEmployees.Employee newEmployee)
        {
            bool modifySuccessful = false;

            return modifySuccessful;
        }

        /**
        * \brief To return the next employee in the data base
        * \details <b>Details</b>
        *
        * This method first checks if the calling method wants the first element of the data base (determined
        * by the parameter), and then checks if all the employees in the data base have already been returned,
        * if so it returns <i>null</i> and if not it will return the next element in the <i>virtualDB</i> data member. 
        * 
        * \param returnFirst - bool - whether or not the calling method would like the first element of the data base.
        *                             It's default value is <i>false</i> but if set to true it will reset the <i>lastIndex</i>
        *                             data member
        * 
        * \return An object that will be a member of the <i>virtualDB</i> data member or <i>null</i> if the data base is
        *         empty or the last element has been reached 
        *
        */
        public object NextEmployee(bool returnFirst = false)
        {


            return virtualDB[0];
        }

        /**
        * \brief To return an employee in the data base using an index
        * \details <b>Details</b>
        *
        * This method checks if the parameter is valid and if so it returns the employee object requested, if
        * the parameter was invalid it returns <i>null</i>. The main purpose of this method is to help test the 
        * NextEmployee() method.
        * 
        * \param employeeIndex - int - the index for the <i>virtualDB</i> data member the calling method would like.
        * 
        * \return An object that will be a member of the <i>virtualDB</i> data member or <i>null</i> if the index was invalid. 
        *
        */
        public object GetEmployee(int employeeIndex)
        {
            if( (employeeIndex >= 0) && (employeeIndex < virtualDB.Count))
            {
                return virtualDB[employeeIndex];
            }
            else 
            {
                return null;
            }
            
        }


    }
}
