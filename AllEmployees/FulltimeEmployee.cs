/// \class FulltimeEmployee
/// 
/// \brief Contains fulltime employee information
/// 
/// File: FulltimeEmployee.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the FulltimeEmployee child class which
/// holds the information to be used in the fulltime employee
/// model contained in the EMS Term Project.
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class FulltimeEmployee : Employee
    {
        DateTime dateOfTermination;
        DateTime dateOfHire;
        float salary;

        public bool SetDateOfHire(DateTime userInput);
        public DateTime GetDateOfHire();
        public bool SetDateOfTermination(DateTime userInput);
        public DateTime GetDateOfTermination();
        public bool SetSalary(float userInput);
        public float GetSalary();
    }
}