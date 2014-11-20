/// \class ParttimeEmployee
/// 
/// \brief Contains parttime employee information
/// 
/// File: ParttimeEmployee.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the ParttimeEmployee child class which
/// holds the information to be used in the parttime employee
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
    public class ParttimeEmployee : Employee
    {
        DateTime dateOfHire;
        DateTime dateOfTermination;
        float hourlyRate;

        public bool SetDateOfHire(DateTime userInput);
        public DateTime GetDateOfHire();
        public bool SetDateOfTermination(DateTime userInput);
        public DateTime GetDateOfTermination();
        public bool SetHourlyRate(float userInput);
        public float GetHourlyRate();
    }
}