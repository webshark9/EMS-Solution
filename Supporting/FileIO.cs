/// \namespace Supporting
/// 
/// \brief Contains the FileIO class, Logging class, and the Validation class
/// 
/// File: FileIO.cs, Logging.cs, and Validation.cs \n
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
    /// \class FileIO
    /// 
    /// \brief Provides access to the database file
    /// 
    /// File: FileIO.cs \n
    /// Project: EMS Term Project \n
    /// First Version: Nov.17/2014 \n
    ///
    /// This class can open a database file, read 
    /// from/write to it, and close the file.
    /// 
    /// \authors Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin
    public class FileIO
    {
        private static string databaseName = "EMS_DB_FILE.txt";///< string used to hold the name of the file to use as the database
        private static StreamReader dbReader;///< stream used for reading from the database file
        private static StreamWriter dbWriter;///< stream used for writing to the database file

        /**
        * \brief To read the database file and validate the records
        * \details <b>Details</b>
        *
        * This method will open a StreamReader for the <i>dbReader</i> data member and call readRecord() to read each line
        * from a database file. Each line will be stored in as a separate string and once the read is done each string will
        * be checked if it is valid and the number of reads as well as valid and invalid records will be logged. The string
        * array of valid records will then be returned.
        * 
        * \param dbName - string - the full pathname of the database file
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *        an error occurs
        * 
        * \return An array of strings <i>validRecords</i> that will hold all of the valid records read in the database file
        *
        */
        public static List<string[]> OpenDBase(string dbName, ref string errorMessage)
        {
            List<string> stringsRead = new List<string>();// all of the lines read from the database file
            List<string[]> validRecords = new List<string[]>();// the VALID lines read from the database file
            int numRecordsRead = 0;// the total number of records read
            int numValidRecords = 0;// the number of valid records read
            int numInvalidRecords = 0;// the number of invalid records read

            int prevPipeIndex = 0;// used to hold the index of the last pipe character found
            int nextPipeIndex = 0;// used to hold the index of the next pipe character found

            databaseName = dbName;// save the name of the database file in the 'databaseName' data member

            //File.Open(databaseName, FileMode.OpenOrCreate, FileAccess.ReadWrite);// open/create the database file for read/write access

            dbReader = new StreamReader(databaseName);

            /* this loop reads the entire database file and stores each line separately into 'stringsRead' */
            while (dbReader.Peek() >= 0)
            {
                stringsRead.Add(ReadRecord());// add the string read from the file to the List container
                ++numRecordsRead;
            }

            /* this foreach find the valid records in 'stringsRead' and stores them into 'validRecords' */
            foreach (string record in stringsRead)
            {
                prevPipeIndex = 0;// used to hold the index of the last pipe character found
                nextPipeIndex = record.IndexOf('|');// used to hold the index of the current pipe character found
                string[] stringsInRecord = new string[8];// used to hold all of the separate words in a record
                int stringsInRecordIndex = 0;// used to index the 'stringsInRecord' variable

                if (nextPipeIndex == -1)// check if there are no pipe characters in the string (which would make it invalid)
                {
                    ++numInvalidRecords;
                    continue;
                }
                stringsInRecord[stringsInRecordIndex++] = record.Substring(0, nextPipeIndex);// add the first string (the type)

                prevPipeIndex = nextPipeIndex;
                nextPipeIndex = record.IndexOf('|', prevPipeIndex+1);// find the next pipe in the string
                while (nextPipeIndex != -1)// loop until all the pipe characters are found
                {
                    stringsInRecord[stringsInRecordIndex++] = record.Substring(prevPipeIndex+1, nextPipeIndex-prevPipeIndex-1);// add the new string

                    prevPipeIndex = nextPipeIndex;
                    nextPipeIndex = record.IndexOf('|', prevPipeIndex + 1);// find the next pipe in the string
                }

                if (stringsInRecordIndex != 8 && stringsInRecordIndex != 7)// each string read should have 8 or 7 strings associated with it (type plus 7 or 6 data members)
                {
                    ++numInvalidRecords;
                    continue;
                }
                else// right number of strings
                {
                    if (stringsInRecord[0].Length != 2)// first string should be the employee type as 2 characters
                    {
                        ++numInvalidRecords;
                        continue;
                    }
                    else
                    {
                        if (stringsInRecord[0][0] == 'F' && stringsInRecord[0][1] == 'T')
                        {

                        }
                        else if (stringsInRecord[0][0] == 'P' && stringsInRecord[0][1] == 'T')
                        {

                        }
                        else if (stringsInRecord[0][0] == 'C' && stringsInRecord[0][1] == 'T')
                        {

                        }
                        else if (stringsInRecord[0][0] == 'S' && stringsInRecord[0][1] == 'N')
                        {

                        }
                        else// invalid employee type
                        {
                            ++numInvalidRecords;
                            continue;
                        }

                    }// end 'else' statement


                }// end 'else' statement 

                validRecords.Add(stringsInRecord);
                ++numValidRecords;

                //validRecords[counter++] = record;
            }

            return validRecords;            
        }

        /**
        * \brief To close the database file by writing an array of strings to the database file
        * \details <b>Details</b>
        *
        * This method will take in an array of strings and write them to the database file that was specified when 
        * a database file was opened (and the name was stored in the <i>databaseName</i> data member). The number 
        * of records written as well as the number of valid and invalid records written will be logged.
        * 
        * \param stringsToWrite - string[] - a string array that holds the strings to write to the database file
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *        an error occurs
        * 
        * \return A bool <i>noErrors</i> that is used to tell if there was a problem. If it is false then the string 
        *         <i>errorMessage</i> can be checked to see what went wrong.
        *
        */
        public static bool CloseDBase(string[] stringsToWrite, ref string errorMessage)
        {
            bool noErrors = true;
            int numRecordsWritten = 0;// the total number of records written
            int numValidRecords = 0;// the number of valid records read
            int numInvalidRecords = 0;// the number of invalid records read

            dbWriter = new StreamWriter(databaseName);

            foreach( string record in stringsToWrite)
            {
                WriteRecord(record);
                ++numRecordsWritten;

            }

            return noErrors;
        }

        /**
        * \brief To read a single record from the database file
        * \details <b>Details</b>
        *
        * This method reads a line from the database file using the <i>dbReader</i> data member and returns the string read
        * 
        * \param None
        * 
        * \return Returns the line that was read as a string
        *
        */
        private static string ReadRecord()
        {
            //string[] records = null;



            return dbReader.ReadLine();
        }

        /**
        * \brief To write a single record to the database file
        * \details <b>Details</b>
        *
        * This method writes a string (and a newline) to the database file using the <i>dbWriter</i> data member and returns 
        * whether or not the write was successful
        * 
        * \param record - string - the string that the calling method would like to write to the
        * database file
        * 
        * \return Returns a string <i>record</i> which will hold the line read or be empty ("") if the
        * read failed
        *
        */
        private static bool WriteRecord(string record)
        {
            bool writeSuccessful = false;

            dbWriter.WriteLine(record);
            dbWriter.Flush();// actually write the data to the file

            return writeSuccessful;
        }   

    }

}
