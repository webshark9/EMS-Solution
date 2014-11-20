/// \class SeasonalEmployee
/// 
/// \brief Contains seasonal employee information
/// 
/// File: SeasonalEmployee.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the SeasonalEmployee child class which
/// holds the information to be used in the seasonal employee
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
    public class SeasonalEmployee : Employee
    {
        string season;
        float piecePay;

        public bool SetSeson(string userInput);
        public string GetSeason();
        public bool SetPiecePay(float userInput);
        public float GetPiecePay();
    }
}