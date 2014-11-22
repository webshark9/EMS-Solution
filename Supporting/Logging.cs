/// \class Logging
/// 
/// \brief Contains the Logging class that deals with logging events that occur in other classes
/// 
/// File: Logging.cs
/// Project: EMS Term Project
/// First Version: Nov.13/2014
///
/// This file contains the Logging class which is responsible for creating/opening a log file for
/// the current day and logging events that occur in other classes
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Supporting
{
    class Logging
    {
        private static StreamWriter logFileWriter;///< the stream used to write to the log file
        private static DateTime lastDate;///< the last day that something was logged (used to tell if a new log file needs to be created)

        /**
        * \brief To create/open (for appending) the log file for the day
        * \details <b>Details</b>
        *
        * The format for the log file name is: date (YYYY-MM-DD) followed by "EMS_Log_File"
        * 
        * \param None
        * 
        * \return Nothing is returned
        *
        */
        public static void OpenLogFile()
        {

        }


        /**
        * \brief To close the log file for the day
        * \details <b>Details</b>
        *
        * This method does nothing special
        * 
        * \param None
        * 
        * \return Nothing is returned
        *
        */
        public static void CloseLogFile()
        {

        }


        /**
        * \brief To write an entry to the log file
        * \details <b>Details</b>
        *
        * This method checks to make sure the log file that is currently open is the log file for the
        * current day, if not it closes the one that is open and calls OpenLogFile() to open a new one. 
        * It then writes the date and time (in the format 'YYYY-MM-DD HH:MM:SS') as well as the string 
        * passed as a parameter to the log file.
        * 
        * \param eventString - string - the event that the calling method would like to log. Proper format is:
        *                               [class.method] evenDeatails
        * 
        * \return Returns a bool <i>logSuccessful</i> which will be 'true' if the log was successful and 'false' otherwise
        *
        */
        public static bool LogEvent(string eventString)
        {
            bool logSuccessful = false;



            // if new day
            // CloseLogFile
            // OpenLogFile


            return logSuccessful;
        }

    }

}
