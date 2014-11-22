/// \class FileIO
/// 
/// \brief Contains the FileIO class that deals with the database file
/// 
/// File: FileIO.cs
/// Project: EMS Term Project
/// First Version: Nov.17/2014
///
/// This file contains the FileIO class which can open a database file, read 
/// from/write to it, and close the file.
/// 
/// \author Matthew Thiessen, Willi Boldt, Ping Chang Ueng, and Tylor McLaughlin

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Supporting
{
    public class FileIO
    {
        private static string databaseName;///< string used to hold the name of the file to use as the database
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
        * 
        * \return An array of strings <i>validRecords</i> that will hold all of the valid records read in the database file
        *
        */
        public static string[] OpenDBase(string dbName)
        {
            string[] stringsRead = null;// all of the lines read from the database file
            string[] validRecords = null;// the VALID records read from the database file

            databaseName = dbName;// save the name of the database file in the 'databaseName' data member
           
            //File.Open(databaseName, FileMode.OpenOrCreate, FileAccess.ReadWrite);// open/create the database file for read/write access

            dbReader = new StreamReader(databaseName);

            while (dbReader.Peek() >= 0) 
            {
                Console.WriteLine(readRecord());
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
        * 
        * \return Nothing is returned
        *
        */
        public static void CloseDBase(string[] stringsToWrite)
        {
            
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
        private static string readRecord()
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
        private static bool writeRecord(string record)
        {
            bool writeSuccessful = false;


            return writeSuccessful;
        }   

    }

}
