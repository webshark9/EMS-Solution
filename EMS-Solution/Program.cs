/// \namespace EMS_Solution
/// 
/// \brief Contains the Program class which contains Main()
/// 
/// File: Program.cs \n
/// Project: EMS Term Project \n
/// First Version: Nov.13/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;

namespace EMS_Solution
{
    /// \class Program
    /// 
    /// \brief Runs the program
    /// 
    /// File: Program.cs \n
    /// Project: EMS Term Project \n
    /// First Version: Nov.13/2014 \n
    ///
    /// This class contains Main() which runs the program
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    class Program
    {
        /**
        * \brief To run the program
        *
        * \details <b>Details</b>
        *
        * This method is what is called when the program is started run.
        * 
        * \param args - string[] - Arguments to the program. Currently there are not suppose to be any
        * 
        * \return Nothing is returned
        */
        static void Main(string[] args)
        {
            UIMenu menu = new UIMenu();

            menu.MainMenu();
        }
    }
}