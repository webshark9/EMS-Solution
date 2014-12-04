/// \namespace Supporting
/// 
<<<<<<< HEAD
/// \brief Contains the FileIO class, Logging class, and the Validation class
/// 
/// File: FileIO.cs, Logging.cs, and Validation.cs \n
=======
/// \brief Contains the FileIO class as well as the Logging class
/// 
/// File: FileIO.cs and Logging.cs \n
>>>>>>> origin/master
/// Project: EMS Term Project \n
/// First Version: Nov.17/2014 \n
/// 
/// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

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
            string fileName = "ems.";
            lastDate = DateTime.Today;

            fileName += lastDate.Year.ToString() + "-" + lastDate.Month.ToString() + "-" + lastDate.Day.ToString() + ".log.txt";

            logFileWriter = new StreamWriter(fileName, true);

            logFileWriter.AutoFlush = true;// have the streamWriter automatically print to the file
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
            bool logSuccessful = false;// used to tell if the event was logged successfully; will be set to 'true' if the log succeed
            bool invalidString = false;
            string logString = "";// the string that gets written to the log file

            // makes sure 'eventString' isn't empty or just whitespace
            if (eventString.Length <= 0)
            {
                invalidString = true;
            }
            else// check if the string only has spaces 
            {
                int stringIndex = 0;

                for (stringIndex = 0; stringIndex < eventString.Length; stringIndex++)
                {
                    if (eventString[stringIndex] != ' ')// check if the current character is not a space
                    {
                        break;// as soon as we have a character that isn't a space we can exit
                    }
                }
                if ((stringIndex + 1) == eventString.Length)// check if the 'for' loop above iterated through the entire string (in which case there were only spaces in the string)
                {
                    invalidString = true;
                }
            }

            if (invalidString == false)
            {
                if ((lastDate == null) || (lastDate != DateTime.Today))// check if we are going to write the same log file as our last write or if we need to create a new log file
                {
                    // need to open a new log file
                    CloseLogFile();
                    OpenLogFile();

                }
                else if (logFileWriter == null)// make sure we have a valid log file open
                {
                    OpenLogFile();
                }

                // construct the log string
                logString = lastDate.Year.ToString() + "-" + lastDate.Month.ToString() + "-" + lastDate.Day.ToString();// add the YYYY-MM-DD
                logString += " " + lastDate.Hour.ToString() + ":" + lastDate.Minute.ToString() + ":" + lastDate.Second.ToString();// add the HH:MM:SS
                logString += " " + eventString;

                try
                {
                    logFileWriter.WriteLine(logString);
                    logSuccessful = true;
                }
                catch (Exception)
                {
                    // try to do the log again
                    CloseLogFile();
                    OpenLogFile();
                    try
                    {
                        logFileWriter.WriteLine(logString);
                        logSuccessful = true;
                    }
                    catch (Exception)
                    {
                        // do nothing (user doesn't want to know about the log file
                    }
                }

            }// end 'if' statement

            return logSuccessful;
        }

    }

}
