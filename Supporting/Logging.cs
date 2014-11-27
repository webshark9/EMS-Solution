
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Supporting
{
    /// \class Logging
    /// 
    /// \brief Allows other classes to log events to a file
    /// 
    /// File: Logging.cs \n
    /// Project: EMS Term Project \n
    /// First Version: Nov.13/2014 \n
    ///
    /// This class is responsible for creating/opening a log file for
    /// the current day and logging events that occur in other classes
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    class Logging
    {
        private static StreamWriter logFileWriter = null;///< the stream used to write to the log file
        private static DateTime lastDate = new DateTime();///< the last day that something was logged (used to tell if a new log file needs to be created)

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
            string fileName = "";
            lastDate = DateTime.Today;

            //fileName += lastDate.ToString() + "_EMS_Log_File";
            fileName += lastDate.Year.ToString() + "-" + lastDate.Month.ToString() + "-" + lastDate.Day.ToString() + "_EMS_Log_File";


            logFileWriter = new StreamWriter(fileName, true);
        }


        /**
        * \brief To close the log file for the day
        * \details <b>Details</b>
        *
        * This method simply sets the <i>logFileWriter</i> data member to null.
        * 
        * \param None
        * 
        * \return Nothing is returned
        *
        */
        public static void CloseLogFile()
        {
            logFileWriter = null;
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
            string logString = "";// the string that gets written to the log file

            if ((lastDate == null) || (lastDate != DateTime.Today))// check if we are going to write the same log file as our last write or if we need to create a new log file
            {
                // need to open a new log file
                CloseLogFile();
                OpenLogFile();
                
            }

            logString = lastDate.Year.ToString() + "-" + lastDate.Month.ToString() + "-" + lastDate.Day.ToString();// add the YYYY-MM-DD
            logString += " " + lastDate.Hour.ToString() + ":" + lastDate.Minute.ToString() + ":" + lastDate.Second.ToString();// add the HH:MM:SS
            logString += " " + eventString;

            try
            {

                logFileWriter.WriteLine(logString);
                logSuccessful = true;
            }
            catch(Exception e)
            {
                // display in console
            }

            return logSuccessful;
        }

    }

}
