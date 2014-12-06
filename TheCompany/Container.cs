﻿/// \namespace TheCompany
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
using AllEmployees;

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
        * \brief Constructor: Used to create a new Container object
        * \details <b>Details</b>
        *
        * This method initializes the data members of this class
        * 
        * \param None
        * 
        * \return Nothing
        *
        */
        public Container()
        {
            lastIndex = 0;
            virtualDB = new ArrayList();
        }


        /**
        * \brief Constructor: Used to create a new Container object and add entries at the same time
        * \details <b>Details</b>
        *
        * This method creates 
        * 
        * \param employeeStrings - string[] - used to hold all of the strings that hold the information for the employees.
        * 
        * \return Nothing
        *
        */
        public Container(string[] employeeStrings)
        {
            lastIndex = 0;

            Employee employeeToAdd = null;


        }

        /**
        * \brief To add a new employee to the data base
        * \details <b>Details</b>
        *
        * This method attempts to add the employee object passed as a parameter to the <i>virtualDB</i> data member.
        * If the employee is not valid it will not add it. This method also logs whether the log was successful or 
        * not.
        * 
        * \param newEmployee - Employee - the employee to be added
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *        an error occurs
        * 
        * \return A bool <i>addSuccessful</i> which will be 'true' if the employee was added successfully and 'false' otherwise
        *
        */
        public bool AddEmployee(Employee newEmployee, ref string errorMessage)
        {
            bool addSuccessful = false;
            FulltimeEmployee FTemployee = new FulltimeEmployee();
            ParttimeEmployee PTemployee = new ParttimeEmployee();
            ContractEmployee CTemployee = new ContractEmployee();
            SeasonalEmployee SNemployee = new SeasonalEmployee();
            
            //FulltimeEmployee possibleEmployee = (FulltimeEmployee)newEmployee;

            if (FTemployee.GetType() == newEmployee.GetType())
            {
                FTemployee = (FulltimeEmployee)newEmployee;

                if(FTemployee.Validate())
                {
                    virtualDB.Add(FTemployee);
                    addSuccessful = true;
                }
            }
            else if(PTemployee.GetType() == newEmployee.GetType())
            {
                PTemployee = (ParttimeEmployee)newEmployee;

                if (PTemployee.Validate())
                {
                    virtualDB.Add(PTemployee);
                    addSuccessful = true;
                }
            }
            else if(CTemployee.GetType() == newEmployee.GetType())
            {
                CTemployee = (ContractEmployee)newEmployee;

                if (CTemployee.Validate())
                {
                    virtualDB.Add(CTemployee);
                    addSuccessful = true;
                }
            }
            else if(SNemployee.GetType() == newEmployee.GetType())
            {
                SNemployee = (SeasonalEmployee)newEmployee;

                if (SNemployee.Validate())
                {
                    virtualDB.Add(SNemployee);
                    addSuccessful = true;
                }
            }


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
        * \param employeeToRemove - Employee - the employee that is to be removed
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *        an error occurs
        * 
        * \return A bool <i>removeSuccessful</i> which will be 'true' if the employee was removed successfully and 'false' otherwise
        *
        */
        public bool RemoveEmployee(Employee employeeToRemove, ref string errorMessage)
        {
            bool removeSuccessful = false;// set to 'true' if the employee is found and removed

            foreach(Employee storedEmployee in virtualDB)
            {
                if(storedEmployee.GetSocialInsuranceNumber() == employeeToRemove.GetSocialInsuranceNumber())
                {
                    virtualDB.Remove(storedEmployee);
                    removeSuccessful = true;
                    break;// we don't allow duplicate SIN's in our database so as soon as we find a match we can exit
                }

            }

            if(removeSuccessful == false)
            {
                // errorMessage = "";
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
        * \param employeeToModify - Employee - the employee that is to be modified
        * \param newEmployee - Employee - the employee to replace the old employee
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *        an error occurs
        * 
        * \return A bool <i>modifySuccessful</i> which will be 'true' if the employee was modified successfully and 'false' otherwise
        *
        */
        public bool ModifyEmployee(Employee employeeToModify, Employee newEmployee, ref string errorMessage)
        {
            bool modifySuccessful = true;// will be set to 'false' if there was a problem
            string unusedString = "";

            foreach (Employee storedEmployee in virtualDB)
            {
                if (storedEmployee.GetSocialInsuranceNumber() == employeeToModify.GetSocialInsuranceNumber())
                {
                    if(AddEmployee(newEmployee, ref unusedString) == false)// check if the new employee is valid
                    {
                        modifySuccessful = false;
                        // errorMessage = "";
                    }
                    else// the add was successful
                    {
                        virtualDB.Remove(storedEmployee);// remove the old employee
                    }                  

                    break;// we don't allow duplicate SIN's in our database so as soon as we find a match we can exit
                }

            }

            if((modifySuccessful == false) && (errorMessage == ""))// if both conditions are true then the employee could not be found
            {
                // errorMessage = "";
            }

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
            if(returnFirst == true)// check if the user wants the first element
            {
                lastIndex = 0;// reset the 'lastIndex' data member so that first element will be returned
            }

            return virtualDB[lastIndex++];// return the element and increase the 'lastIndex' data member so the next time this method is called the next index will be returned
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
