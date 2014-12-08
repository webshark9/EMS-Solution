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
using AllEmployees;
using Supporting;

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
        private List<Employee> virtualDB;///< our container for storing all of our employees
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
            virtualDB = new List<Employee>();
        }


        /**
        * \brief Constructor: Used to create a new Container object and add entries at the same time
        * \details <b>Details</b>
        *
        * This method takes in a List of string arrays and creates employees using each one. It makes sure the employee is valid
        * before adding the employee to the <i>virtualDB</i> data member. It logs the number of valid and invalid employees.
        * 
        * \param employeeStrings - string[] - used to hold all of the strings that hold the information for the employees.
        * 
        * \return Nothing
        *
        */
        public Container(List<string[]> employeesList)
        {
            lastIndex = 0;// initialize the data member
            virtualDB = new List<Employee>();
            FulltimeEmployee FTemployee = new FulltimeEmployee();
            ParttimeEmployee PTemployee = new ParttimeEmployee();
            ContractEmployee CTemployee = new ContractEmployee();
            SeasonalEmployee SNemployee = new SeasonalEmployee();
            int totalEmployees = employeesList.Count;
            int numEmpoyeesAdded = 0;// the number of employees that were added
            int numInvalidEmployees = 0;// the number of employees that were invalid and not added
            bool invalidSIN = false;// used to tell if employees have identical SIN/BN numbers

            foreach(string[] employeeString in employeesList)
            {
                Logging.LogEvent("[Container.Constructor] String: " + employeeString[0] + "    " + employeeString[1]);

                if (employeeString[0] == "FT")
                {
                    DateTime dateOfBirth = new DateTime();
                    DateTime dateOfHire = new DateTime();
                    DateTime dateOfTermination = new DateTime();
                    float salary = 0;

                    if (!DateTime.TryParse(employeeString[4], out dateOfBirth))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[5], out dateOfHire))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[6], out dateOfTermination))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if(!float.TryParse(employeeString[7], out salary))
                    {
                        ++numInvalidEmployees;
                        continue;// invalid float and we don't store invalid objects in the database so continue (don't add)
                    }

                    FTemployee = new FulltimeEmployee(dateOfHire, dateOfTermination, salary, employeeString[2], employeeString[1], employeeString[3], dateOfBirth);

                    if (FTemployee.Validate())// check if the employee was valid
                    {

                        foreach( Employee emp in virtualDB)
                        {
                            if(emp.GetSocialInsuranceNumber() == FTemployee.GetSocialInsuranceNumber())
                            {
                                invalidSIN = true;
                                Logging.LogEvent("[Container.Constructor] Duplicate SIN/BN found. SIN/BN: " + emp.GetSocialInsuranceNumber());
                                ++numInvalidEmployees;
                                break;
                            }
                        }

                        if(invalidSIN == true)
                        {
                            invalidSIN = false;
                        }
                        else
                        {
                            virtualDB.Add(FTemployee);
                            ++numEmpoyeesAdded;
                        }
                        
                    }
                    else
                    {
                        ++numInvalidEmployees;
                    }

                }
                else if (employeeString[0] == "PT")
                {
                    DateTime dateOfBirth = new DateTime();
                    DateTime dateOfHire = new DateTime();
                    DateTime dateOfTermination = new DateTime();
                    float hourlyRate = 0;

                    if (!DateTime.TryParse(employeeString[4], out dateOfBirth))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[5], out dateOfHire))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[6], out dateOfTermination))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!float.TryParse(employeeString[7], out hourlyRate))
                    {
                        ++numInvalidEmployees;
                        continue;// invalid float and we don't store invalid objects in the database so continue (don't add)
                    }

                    PTemployee = new ParttimeEmployee(dateOfHire, dateOfTermination, hourlyRate, employeeString[2], employeeString[1], employeeString[3], dateOfBirth);

                    if (PTemployee.Validate())// check if the employee was valid
                    {
                        foreach (Employee emp in virtualDB)
                        {
                            if (emp.GetSocialInsuranceNumber() == PTemployee.GetSocialInsuranceNumber())
                            {
                                invalidSIN = true;
                                Logging.LogEvent("[Container.Constructor] Duplicate SIN/BN found. SIN/BN: " + emp.GetSocialInsuranceNumber());
                                ++numInvalidEmployees;
                                break;
                            }
                        }

                        if (invalidSIN == true)
                        {
                            invalidSIN = false;
                        }
                        else
                        {
                            virtualDB.Add(PTemployee);
                            ++numEmpoyeesAdded;
                        }

                    }
                    else
                    {
                        ++numInvalidEmployees;
                    }

                }
                else if (employeeString[0] == "CT")
                {
                    DateTime dateOfIncorporation = new DateTime();
                    DateTime contractStartDate = new DateTime();
                    DateTime contractStopDate = new DateTime();
                    float contractAmount = 0;

                    if (!DateTime.TryParse(employeeString[4], out dateOfIncorporation))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[5], out contractStartDate))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!DateTime.TryParse(employeeString[6], out contractStopDate))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!float.TryParse(employeeString[7], out contractAmount))
                    {
                        ++numInvalidEmployees;
                        continue;// invalid float and we don't store invalid objects in the database so continue (don't add)
                    }
                    CTemployee = new ContractEmployee(contractStartDate, contractStopDate, contractAmount, employeeString[2], employeeString[3], dateOfIncorporation);

                    if (CTemployee.Validate())// check if the employee was valid
                    {
                        foreach (Employee emp in virtualDB)
                        {
                            if (emp.GetSocialInsuranceNumber() == CTemployee.GetSocialInsuranceNumber())
                            {
                                invalidSIN = true;
                                Logging.LogEvent("[Container.Constructor] Duplicate SIN/BN found. SIN/BN: " + emp.GetSocialInsuranceNumber());
                                ++numInvalidEmployees;
                                break;
                            }
                        }

                        if (invalidSIN == true)
                        {
                            invalidSIN = false;
                        }
                        else
                        {
                            virtualDB.Add(CTemployee);
                            ++numEmpoyeesAdded;
                        }

                    }
                    else
                    {
                        ++numInvalidEmployees;
                    }

                }
                else if (employeeString[0] == "SN")
                {
                    DateTime dateOfBirth = new DateTime();
                    float piecePay = 0;

                    if (!DateTime.TryParse(employeeString[4], out dateOfBirth))// convert string to a dateTime variable
                    {
                        ++numInvalidEmployees;
                        continue;// invalid date and we don't store invalid objects in the database so continue (don't add)
                    }

                    if (!float.TryParse(employeeString[6], out piecePay))
                    {
                        ++numInvalidEmployees;
                        continue;// invalid float and we don't store invalid objects in the database so continue (don't add)
                    }

                    SNemployee = new SeasonalEmployee(employeeString[5], piecePay, employeeString[2], employeeString[1], employeeString[3], dateOfBirth);

                    if (SNemployee.Validate())// check if the employee was valid
                    {
                        foreach (Employee emp in virtualDB)
                        {
                            if (emp.GetSocialInsuranceNumber() == SNemployee.GetSocialInsuranceNumber())
                            {
                                invalidSIN = true;
                                Logging.LogEvent("[Container.Constructor] Duplicate SIN/BN found. SIN/BN: " + emp.GetSocialInsuranceNumber());
                                ++numInvalidEmployees;
                                break;
                            }
                        }

                        if (invalidSIN == true)
                        {
                            invalidSIN = false;
                        }
                        else
                        {
                            virtualDB.Add(SNemployee);
                            ++numEmpoyeesAdded;
                        }

                    }
                    else
                    {
                        ++numInvalidEmployees;
                    }

                }

                // do nothing if the employee type is invalid 

            }// end 'foreach'

            Logging.LogEvent("[Container.Constructor] Total Employees: " + totalEmployees + ". Employees Added: " + numEmpoyeesAdded.ToString() + "\n\tInvalid Employees Found: " + numInvalidEmployees);

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
            bool sameSIN = false;
            FulltimeEmployee FTemployee = new FulltimeEmployee();
            ParttimeEmployee PTemployee = new ParttimeEmployee();
            ContractEmployee CTemployee = new ContractEmployee();
            SeasonalEmployee SNemployee = new SeasonalEmployee();

            foreach (Employee emp in virtualDB)// make sure that the employee that is going to be added doesn't have the same SIN or business number as an existing employee in the database
            {
                if (emp.GetSocialInsuranceNumber() == newEmployee.GetSocialInsuranceNumber())
                {
                    errorMessage = "Another Employee has the same SIN number. Employee was not added";
                    Logging.LogEvent("[Container.AddEmployee] Employee failed to be Added due to duplicate SINS. The SIN is: " + emp.GetSocialInsuranceNumber());
                    sameSIN = true;
                    break;
                }

            }

            if (FTemployee.GetType() == newEmployee.GetType() && sameSIN == false)
            {
                FTemployee = (FulltimeEmployee)newEmployee;

                if(FTemployee.Validate())
                {
                    virtualDB.Add(FTemployee);
                    addSuccessful = true;
                }
                else
                {
                    errorMessage = "Employee did not pass Full-Time Employee validation test.";
                    Logging.LogEvent("[Container.AddEmployee] Employee failed to be Added. Employee information: " + FTemployee.Details());
                }
            }
            else if (PTemployee.GetType() == newEmployee.GetType() && sameSIN == false)
            {
                PTemployee = (ParttimeEmployee)newEmployee;

                if (PTemployee.Validate())
                {
                    virtualDB.Add(PTemployee);
                    addSuccessful = true;
                }
                else
                {
                    errorMessage = "Employee did not pass Part-Time Employee validation test.";
                    Logging.LogEvent("[Container.AddEmployee] Employee failed to be Added. Employee information: " + PTemployee.Details());
                }
            }
            else if (CTemployee.GetType() == newEmployee.GetType() && sameSIN == false)
            {
                CTemployee = (ContractEmployee)newEmployee;

                if (CTemployee.Validate())
                {
                    virtualDB.Add(CTemployee);
                    addSuccessful = true;
                }
                else
                {
                    errorMessage = "Employee did not pass Contract Employee validation test.";
                    Logging.LogEvent("[Container.AddEmployee] Employee failed to be Added. Employee information: " + CTemployee.Details());
                }
            }
            else if (SNemployee.GetType() == newEmployee.GetType() && sameSIN == false)
            {
                SNemployee = (SeasonalEmployee)newEmployee;

                if (SNemployee.Validate())
                {
                    virtualDB.Add(SNemployee);
                    addSuccessful = true;
                }
                else
                {
                    errorMessage = "Employee did not pass Seasonal Employee validation test.";
                    Logging.LogEvent("[Container.AddEmployee] Employee failed to be Added. Employee information: " + SNemployee.Details());
                }
            }
            
            if (addSuccessful == true)
            {
                Logging.LogEvent("[Container.AddEmployee] Employee Added. SIN: " + newEmployee.GetSocialInsuranceNumber());
            }
            

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
                    Logging.LogEvent("[Container.RemoveEmployee] Employee removed. Employee SIN: " + employeeToRemove.GetSocialInsuranceNumber());
                    break;// we don't allow duplicate SIN's in our database so as soon as we find a match we can exit
                }

            }

            if(removeSuccessful == false)
            {
                errorMessage = "Remove was unsuccessful. The SIN number could not be found.";
                Logging.LogEvent("[Container.RemoveEmployee] Employee failed to be removed. The SIN: " + employeeToRemove.GetSocialInsuranceNumber() + " could not be found");
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
        public bool ModifyEmployee(Employee employeeToModify, ref string errorMessage)
        {
            bool modifySuccessful = false;// will be set to 'true' if there were no errors
            //string unusedString = "";
            FulltimeEmployee FTemployee = new FulltimeEmployee();
            ParttimeEmployee PTemployee = new ParttimeEmployee();
            ContractEmployee CTemployee = new ContractEmployee();
            SeasonalEmployee SNemployee = new SeasonalEmployee();
            //string originalValues = "";
            //string newValues = "";
            int i = 0;


            for(i = 0; i < virtualDB.Count; i++)
            {
                if (virtualDB[i].GetSocialInsuranceNumber() == employeeToModify.GetSocialInsuranceNumber())
                {
                    Logging.LogEvent("[Container.ModifyEmployee] Employee modified. Original Values: " + virtualDB[i].Details() + "\nNew Values: " + employeeToModify.Details());
                    virtualDB[i] = employeeToModify;
                    modifySuccessful = true;

                    
                    /*
                    if (FTemployee.GetType() == virtualDB[i].GetType())
                    {
                        FTemployee = (FulltimeEmployee)employeeToModify;                
                        originalValues = FTemployee.Details();

                        FTemployee = (FulltimeEmployee)virtualDB[i];
                        newValues = FTemployee.Details();
                    }
                    else if (PTemployee.GetType() == virtualDB[i].GetType())
                    {
                        PTemployee = (ParttimeEmployee)virtualDB[i];                
                        originalValues = PTemployee.Details();

                        PTemployee = (ParttimeEmployee)virtualDB[i];
                        newValues = PTemployee.Details();                  
                    }
                    else if (CTemployee.GetType() == virtualDB[i].GetType())
                    {
                        CTemployee = (ContractEmployee)virtualDB[i];                                         
                        originalValues = CTemployee.Details();

                        CTemployee = (ContractEmployee)virtualDB[i];
                        newValues = CTemployee.Details();                    
                    }
                    else if (SNemployee.GetType() == virtualDB[i].GetType())
                    {
                        SNemployee = (SeasonalEmployee)virtualDB[i];                
                        originalValues = SNemployee.Details();

                        SNemployee = (SeasonalEmployee)virtualDB[i];
                        newValues = SNemployee.Details();                  
                    }*/

                    
                    break;

                }// end 'if' statement

            }// end 'for' loop

            if(modifySuccessful == false)
            {
                errorMessage = "The Employee SIN could not be found, therefore the Employee was not modified.";
                Logging.LogEvent("[Container.ModifyEmployee] Employee FAILED to be modified. SIN: " + employeeToModify.GetSocialInsuranceNumber());
            }

            /*
            foreach (Employee storedEmployee in virtualDB)
            {
                if (storedEmployee.GetSocialInsuranceNumber() == employeeToModify.GetSocialInsuranceNumber())
                {
                    storedEmployee.SetFirstName
                    
                    virtualDB.Remove(storedEmployee);// remove the old employee

                    if(AddEmployee(newEmployee, ref unusedString) == false)// check if the new employee is valid
                    {
                        modifySuccessful = false;
                        // errorMessage = "";
                    }
                    else// the add was successful
                    {
                        

                        if (FTemployee.GetType() == newEmployee.GetType())
                        {
                            FTemployee = (FulltimeEmployee)employeeToModify;                
                            originalValues = FTemployee.Details();

                            FTemployee = (FulltimeEmployee)newEmployee;
                            newValues = FTemployee.Details();
                        }
                        else if (PTemployee.GetType() == newEmployee.GetType())
                        {
                            PTemployee = (ParttimeEmployee)newEmployee;                
                            originalValues = FTemployee.Details();

                            PTemployee = (ParttimeEmployee)newEmployee;
                            newValues = FTemployee.Details();                  
                        }
                        else if (CTemployee.GetType() == newEmployee.GetType())
                        {
                            CTemployee = (ContractEmployee)newEmployee;                                         
                            originalValues = FTemployee.Details();

                            CTemployee = (ContractEmployee)newEmployee;
                            newValues = FTemployee.Details();                    
                        }
                        else if (SNemployee.GetType() == newEmployee.GetType())
                        {
                            SNemployee = (SeasonalEmployee)newEmployee;                
                            originalValues = SNemployee.Details();

                            SNemployee = (SeasonalEmployee)newEmployee;
                            newValues = SNemployee.Details();                  
                        }

                        Logging.LogEvent("[Container.ModifyEmployee] Employee modified. Original Values: " + originalValues + "\nNew Values: " + newValues);
                    }                

                    break;// we don't allow duplicate SIN's in our database so as soon as we find a match we can exit
                }
             

            }*/
            /*
            if((modifySuccessful == false) && (errorMessage == ""))// if both conditions are true then the employee could not be found
            {
                errorMessage = "The employee to modify could not be found.";
            }
            */

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
            
            if(lastIndex >= virtualDB.Count)// check if indexing the virtualDB to what the index is will cause an exception
            {
                return null;// returned all employees, so return null
            }
            else// index is valid
            {
                return virtualDB[lastIndex++];// return the element and increase the 'lastIndex' data member so the next time this method is called the next index will be returned
            }

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


        /**
        * \brief To return an employee in the data base 
        * \details <b>Details</b>
        *
        * This method checks if the parameter is 
        * \param employeeIndex - int - the 
        * 
        * \return An object that will be a member of the <i>virtualDB</i> data member or <i>null</i> if the index was invalid. 
        *
        */
        public object ReturnObject(string sinNumber)
        {
            foreach(Employee emp in virtualDB)
            {
                if(emp.GetSocialInsuranceNumber() == sinNumber)
                {
                    return emp;
                }
            }
            
            return null;
        }



    }
}
