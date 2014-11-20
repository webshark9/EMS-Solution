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
/// \author Matthew Thiessen, Willi Boldt, Ping Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllEmployees
{
    public class ContractEmployee : Employee
    {
        DateTime contractStartDate;
        DateTime contractStopDate;
        float fixedContractAmount;

        public bool SetContractStartDate(DateTime userInput);
        public DateTime GetContractStartDate();
        public bool SetContractStopDate(DateTime userInput);
        public DateTime GetContractSatartDate();
        public bool SetFixedContractAmount(float userInput);
        public float GetFixedContractAmount();
    }
}