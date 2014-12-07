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
            string returnedErrorMessage = "";



            databaseName = dbName;// save the name of the database file in the 'databaseName' data member so we can close the file later

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
                nextPipeIndex = 0;// used to hold the index of the current pipe character found
                string[] stringsInRecord = new string[8];// used to hold all of the separate words in a record
                int stringsInRecordIndex = 0;// used to index the 'stringsInRecord' variable

                DateTime dateOfBirth = new DateTime();
                DateTime dateOfHire = new DateTime();
                DateTime dateOfTermination = new DateTime();

                nextPipeIndex = record.IndexOf('|');
                if (nextPipeIndex == -1)// check if there are no pipe characters in the string (which would make it invalid)
                {
                    ++numInvalidRecords;
                    continue;
                }
                stringsInRecord[stringsInRecordIndex++] = record.Substring(0, nextPipeIndex);// add the first string (the type)

                prevPipeIndex = nextPipeIndex;
                nextPipeIndex = record.IndexOf('|', prevPipeIndex + 1);// find the next pipe in the string
                while (nextPipeIndex != -1)// loop until all the pipe characters are found
                {
                    stringsInRecord[stringsInRecordIndex++] = record.Substring(prevPipeIndex + 1, nextPipeIndex - prevPipeIndex - 1);// add the new string

                    prevPipeIndex = nextPipeIndex;// save the index of the current pipe
                    nextPipeIndex = record.IndexOf('|', prevPipeIndex + 1);// find the next pipe in the string
                }

                if (stringsInRecordIndex == 8)// FT, PT, and CT employee types will have 8 strings in a record (the type of employee plus 7 data members)
                {
                    if (stringsInRecord[0].Length != 2)// first string should be the employee type which is 2 characters
                    {
                        ++numInvalidRecords;
                        //Console.WriteLine("[FileIO.Open] Invalid Employee Type string length was found reading: " + record);
                        // log: "[FileIO.Open] Invalid Employee Type string length was found reading: " + record;
                        continue;
                    }
                    else// first string has the right number of characters
                    {
                        if (stringsInRecord[0] == "FT" || stringsInRecord[0] == "PT")// the only different between FT and PT employees is the last string, so we can check for both at the same time
                        {
                            float salary = 0;// salary is unique to FT employees so we declare it here
                            float hourlyRate = 0;// the hourly rate is unique to PT employees so we declare it here

                            if(!ValidateFirstThree(stringsInRecord[1], stringsInRecord[2], stringsInRecord[3], ref returnedErrorMessage))// check if the first 3 data members are valid (starting at the 2nd string in record because the first one is the employee type)
                            {
                                ++numInvalidRecords;
                                //Console.WriteLine("[FileIO.Open] Error was found reading record: " + record +" Error: " + returnedErrorMessage);
                                //log: "[FileIO.Open] Error was found reading record: " + record +" Error: " + returnedErrorMessage;
                                continue;
                            }                            

                            if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                            {
                                if(!Validation.ValidateDateOfBirth(dateOfBirth, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of birth found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of birth found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[4] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of birth format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of birth format found reading record: " + record;
                                    continue;
                                }

                            }

                            if (DateTime.TryParse(stringsInRecord[5], out dateOfHire))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateDateOfHire(dateOfBirth, dateOfHire, DateTime.MinValue, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of hire found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of hire found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[5] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of hire format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of hire format found reading record: " + record;
                                    continue;
                                }

                            }

                            if (DateTime.TryParse(stringsInRecord[6], out dateOfTermination))// convert string to a dateTime variable
                            {
                                if(!Validation.ValidateDateOfTermination(dateOfBirth, dateOfHire, dateOfTermination, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of termination found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of termination found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }                            
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if(stringsInRecord[6] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of termination format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of termination format found reading record: " + record;
                                    continue;
                                }
                                
                            }                         

                            if(stringsInRecord[0] == "FT")// if true then the last field will be the salary
                            {
                                if (float.TryParse(stringsInRecord[7], out salary))
                                {
                                    if (!Validation.ValidateSalary(salary, ref returnedErrorMessage))
                                    {
                                        ++numInvalidRecords;
                                        //Console.WriteLine("[FileIO.Open] Invalid salary found reading record: " + record);
                                        //log: "[FileIO.Open] Invalid salary found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                        continue;
                                    }
                                }
                                else// couldn't convert the string to a float
                                {
                                    if (stringsInRecord[7] != "N/A")
                                    {
                                        ++numInvalidRecords;
                                        //Console.WriteLine("[FileIO.Open] Invalid salary format found reading record: " + record);
                                        //log: "[FileIO.Open] Invalid salary format found reading record: " + record;
                                        continue;
                                    }

                                }

                                
                            }
                            else// it is a PT employee, last field will be the hourlyRate
                            {
                                if (float.TryParse(stringsInRecord[7], out hourlyRate))
                                {
                                    if (!Validation.ValidateSalary(hourlyRate, ref returnedErrorMessage))
                                    {
                                        ++numInvalidRecords;
                                        //Console.WriteLine("[FileIO.Open] Invalid hourly rate found reading record: " + record);
                                        //log: "[FileIO.Open] Invalid hourly rate found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                        continue;
                                    }
                                }
                                else// couldn't convert the string to a float
                                {
                                    if (stringsInRecord[7] != "N/A")
                                    {
                                        ++numInvalidRecords;
                                        //Console.WriteLine("[FileIO.Open] Invalid hourly rate format found reading record: " + record);
                                        //log: "[FileIO.Open] Invalid hourly rate format found reading record: " + record;
                                        continue;
                                    }

                                }
                            }                        

                        }// end 'if' that validates both FT and PT employees                       
                        else if (stringsInRecord[0] == "CT")
                        {
                            float contractAmount = 0;
                            DateTime contractStartDate = new DateTime();// specific to CT employees so we declare it here
                            DateTime contractStopDate = new DateTime();// specific to CT employees so we declare it here

                            if (!Validation.ValidateName(stringsInRecord[1], ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                //Console.WriteLine("[FileIO.Open] Invalid business name found reading record: " + record);
                                //log: "[FileIO.Open] Invalid business name found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                continue;
                            }

                            if(stringsInRecord[2] != "")// the CT employee doesn't use the firstName field so it should be empty
                            {
                                ++numInvalidRecords;
                                //Console.WriteLine("[FileIO.Open] Non empty entry for CT employee first name found reading record: " + record);
                                //log: "[FileIO.Open] Non empty entry for CT employee first name found reading record: " + record;
                                continue;
                            }

                            if (!Validation.ValidateBusinessNumber(stringsInRecord[3], DateTime.MinValue, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                //Console.WriteLine("[FileIO.Open] Invalid business number found reading record: " + record);
                                //log: "[FileIO.Open] Invalid business number found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                continue;
                            }

                            if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateDateOfCreation(stringsInRecord[3], dateOfBirth, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of incorporation found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of incorporation found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[4] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid date of incorporation format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid date of incorporation format found reading record: " + record;
                                    continue;
                                }

                            }

                            if (DateTime.TryParse(stringsInRecord[5], out contractStartDate))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateContractStartDate(dateOfBirth, contractStartDate, DateTime.MinValue, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract start date found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract start date found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[5] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract start date format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract start date format found reading record: " + record;
                                    continue;
                                }

                            }

                            if (DateTime.TryParse(stringsInRecord[6], out contractStopDate))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateContractStopDate(dateOfBirth, contractStartDate, contractStopDate, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract stop date found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract stop date found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[6] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract stop date format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract stop date format found reading record: " + record;
                                    continue;
                                }

                            }

                            if (float.TryParse(stringsInRecord[7], out contractAmount))
                            {
                                if (!Validation.ValidateFixedContractAmount(contractAmount, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract amount found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract amount found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a float
                            {
                                if (stringsInRecord[7] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    //Console.WriteLine("[FileIO.Open] Invalid contract amount format found reading record: " + record);
                                    //log: "[FileIO.Open] Invalid contract amount format found reading record: " + record;
                                    continue;
                                }

                            }

                        }// end 'if' that validates a CT employee
                        else// invalid employee type
                        {
                            ++numInvalidRecords;
                            //Console.WriteLine("[FileIO.Open] Invalid employee type found reading record: " + record);
                            //log: "[FileIO.Open] Invalid employee type found reading record: " + record;
                            continue;
                        }

                    }// end 'else' statement

                }
                else if (stringsInRecordIndex == 7)// the SN employee type will have 7 strings in a record (the type of employee plus 6 data members)
                {
                    if ((stringsInRecord[0].Length == 2) && (stringsInRecord[0] == "SN"))// check to make sure the first string has the 2 character code of a seasonal employee (SN)
                    {
                        float piecePay = 0;// unique to SN employees so we declare it here

                        if (!ValidateFirstThree(stringsInRecord[1], stringsInRecord[2], stringsInRecord[3], ref returnedErrorMessage))
                        {
                            ++numInvalidRecords;
                            //log: "[FileIO.Open] Error was found reading record: " + record +" Error: " + returnedErrorMessage;
                            continue;
                        }

                        if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                        {
                            if (!Validation.ValidateDateOfBirth(dateOfBirth, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                //log: "[FileIO.Open] Invalid date of birth found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                continue;
                            }
                        }
                        else// couldn't convert the string to a dateTime variable
                        {
                            if (stringsInRecord[4] != "N/A")
                            {
                                ++numInvalidRecords;
                                //log: "[FileIO.Open] Invalid date of birth format found reading record: " + record;
                                continue;
                            }

                        } 

                        if (!Validation.ValidateSeason(stringsInRecord[5], ref returnedErrorMessage))
                        {
                            ++numInvalidRecords;
                            //log: "[FileIO.Open] Invalid season found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                            continue;
                        }

                        if (float.TryParse(stringsInRecord[6], out piecePay))
                        {
                            if (!Validation.ValidatePiecePay(piecePay, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                //log: "[FileIO.Open] Invalid piece pay amount found reading record: " + record +".\n\tError: " + returnedErrorMessage;
                                continue;
                            }
                        }
                        else// couldn't convert the string to a float
                        {
                            if (stringsInRecord[6] != "N/A")
                            {
                                ++numInvalidRecords;
                                //log: "[FileIO.Open] Invalid piece pay amount format found reading record: " + record;
                                continue;
                            }

                        }

                    }
                    else// invalid employee type
                    {
                        ++numInvalidRecords;
                        //log: "[FileIO.Open] Invalid employee type found reading record: " + record;
                        continue;
                    }

                }
                else// wrong number of strings
                {
                    ++numInvalidRecords;
                    //log: "[FileIO.Open] Invalid number of strings found reading record: " + record;
                    continue;
                }// end 'else' statement 

                validRecords.Add(stringsInRecord);
                ++numValidRecords;
                //log: "[FileIO.Open] Valid employee read. Record: " + record;

            }// end 'foreach'

            //Console.WriteLine("Records Read: {0}", numRecordsRead);
            //Console.WriteLine("Valid Records: {0}", numValidRecords);
            //Console.WriteLine("Invalid Records: {0}", numInvalidRecords);


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

            dbWriter.Close();

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

        /**
        * \brief To validate three of the strings read in a record for the FT, PT, and SN employee types
        * \details <b>Details</b>
        *
        * This method takes in 3 strings and calls the proper validation methods to check if they are valid.
        * If one of them is invalid false will be returned and the parameter 'errorMessage' can be checked 
        * to see what the error was.
        * 
        * \param firstString - string - a string that will be validated using the ValidateName() method
        * \param secondString - string - another string that will be validated using the ValidateName() method
        * \param thirdString - string - a string that will be validated using the ValidateSocialInsuranceNumber() method
        * \param errorMessage - ref string - a string that will be used to hold error messages (if an error occurs)
        * 
        * \return Returns a bool <i>isValid</i> which will hold true if the strings were valid and false otherwise
        *
        */
        private static bool ValidateFirstThree(string firstString, string secondString, string thirdString, ref string errorMessage)
        {
            bool isValid = true;// used to tell if all the strings were valid; set to false if one of the strings is invalid
            string returnedErrorMessage = "";

            if (!Validation.ValidateName(firstString, ref returnedErrorMessage))
            {
                isValid = false;
            }
            else if (!Validation.ValidateName(secondString, ref returnedErrorMessage))
            {
                isValid = false;
            }
            else if (!Validation.ValidateSocialInsuranceNumber(thirdString, ref returnedErrorMessage))
            {
                isValid = false;
            }

            return isValid;
        }

    }

}
