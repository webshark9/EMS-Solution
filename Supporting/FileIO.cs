﻿/// \namespace Supporting
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

            try
            {
                dbReader = new StreamReader(dbName);
                databaseName = dbName;// save the name of the database file in the 'databaseName' data member so we can close the file later

                Logging.LogEvent("[FileIO.OpenDBase] The file: " + dbName + " has been opened for reading.");

                /* this loop reads the entire database file and stores each line separately into 'stringsRead' */
                while (dbReader.Peek() >= 0)
                {
                    stringsRead.Add(ReadRecord());// add the string read from the file to the List container
                    ++numRecordsRead;
                }
            }
            catch(FileNotFoundException)
            {
                errorMessage = "The Database file: " + dbName + " could not be found.";
                Logging.LogEvent("[FileIO.OpenDBase] The file: " + dbName + " could not be found for reading.");
            }
            catch (DirectoryNotFoundException)
            {
                errorMessage = "The Directory for the database file could not be found.";
                Logging.LogEvent("[FileIO.OpenDBase] The directory for the file: " + dbName + " could not be found for reading.");
            }
            catch(Exception e)
            {
                errorMessage = "Error opening the database file. Message: " + e.Message;
                Logging.LogEvent("[FileIO.OpenDBase] The file: " + dbName + " could not be opened for reading. Message: " + e.Message);
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

                returnedErrorMessage = "";// reset the error message in case it was set the last iteration

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
                        Logging.LogEvent("[FileIO.OpenDBase] Invalid Employee Type string length was found reading: " + record);
                        continue;
                    }
                    else// first string has the right number of characters
                    {
                        if (stringsInRecord[0] == "FT" || stringsInRecord[0] == "PT")// the only difference between FT and PT employees is the last string, so we can validate both at the same time
                        {
                            float salary = 0;// salary is unique to FT employees so we declare it here
                            float hourlyRate = 0;// the hourly rate is unique to PT employees so we declare it here

                            if(!ValidateFirstThree(stringsInRecord[1], stringsInRecord[2], stringsInRecord[3], ref returnedErrorMessage))// check if the first 3 data members are valid (starting at the 2nd string in record because the first one is the employee type)
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Error was found reading record: " + record +" Error: " + returnedErrorMessage);
                                continue;
                            }                            

                            if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                            {
                                if(!Validation.ValidateDateOfBirth(dateOfBirth, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of birth found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[4] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of birth FORMAT found reading record: " + record);
                                    continue;
                                }
                            }

                            if (DateTime.TryParse(stringsInRecord[5], out dateOfHire))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateDateOfHire(dateOfBirth, dateOfHire, DateTime.MinValue, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of hire found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[5] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of hire FORMAT found reading record: " + record);
                                    continue;
                                }

                            }

                            if (DateTime.TryParse(stringsInRecord[6], out dateOfTermination))// convert string to a dateTime variable
                            {
                                if(!Validation.ValidateDateOfTermination(dateOfBirth, dateOfHire, dateOfTermination, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of termination found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }                            
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if(stringsInRecord[6] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of termination FORMAT found reading record: " + record);
                                    continue;
                                }
                                
                            }                         

                            if(stringsInRecord[0] == "FT")// if true then the last field will be the salary
                            {
                                if (float.TryParse(stringsInRecord[7], out salary))// convert string to a float variable
                                {
                                    if (!Validation.ValidateSalary(salary, ref returnedErrorMessage))
                                    {
                                        ++numInvalidRecords;
                                        Logging.LogEvent("[FileIO.OpenDBase] Invalid salary found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                        continue;
                                    }
                                }
                                else// couldn't convert the string to a float
                                {
                                    if (stringsInRecord[7] != "N/A")
                                    {
                                        ++numInvalidRecords;
                                        Logging.LogEvent("[FileIO.OpenDBase] Invalid salary FORMAT found reading record: " + record);
                                        continue;
                                    }

                                }
                                
                            }
                            else// it is a PT employee, last field will be the hourlyRate
                            {
                                if (float.TryParse(stringsInRecord[7], out hourlyRate))// convert string to a float variable
                                {
                                    if (!Validation.ValidateSalary(hourlyRate, ref returnedErrorMessage))
                                    {
                                        ++numInvalidRecords;
                                        Logging.LogEvent("[FileIO.OpenDBase] Invalid hourly rate found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                        continue;
                                    }
                                }
                                else// couldn't convert the string to a float
                                {
                                    if (stringsInRecord[7] != "N/A")
                                    {
                                        ++numInvalidRecords;
                                        Logging.LogEvent("[FileIO.OpenDBase] Invalid hourly rate FORMAT found reading record: " + record);
                                        continue;
                                    }
                                }

                            }                        

                        }// end 'if' that validates both FT and PT employees                       
                        else if (stringsInRecord[0] == "CT")
                        {
                            float contractAmount = 0;// unique to CT employees so we declare it here
                            DateTime contractStartDate = new DateTime();// unique to CT employees so we declare it here
                            DateTime contractStopDate = new DateTime();// unique to CT employees so we declare it here

                            if (!Validation.ValidateName(stringsInRecord[1], ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid business name found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                continue;
                            }

                            if(stringsInRecord[2] != "")// the CT employee doesn't use the firstName field so it should be empty
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Non empty entry for CT employee first name found reading record: " + record);
                                continue;
                            }

                            if (!Validation.ValidateBusinessNumber(stringsInRecord[3], DateTime.MinValue, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid business number found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                continue;
                            }

                            if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateDateOfCreation(stringsInRecord[3], dateOfBirth, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of incorporation found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[4] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid date of incorporation FORMAT found reading record: " + record);
                                    continue;
                                }
                            }

                            if (DateTime.TryParse(stringsInRecord[5], out contractStartDate))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateContractStartDate(dateOfBirth, contractStartDate, DateTime.MinValue, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract start date found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[5] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract start date FORMAT found reading record: " + record);
                                    continue;
                                }
                            }

                            if (DateTime.TryParse(stringsInRecord[6], out contractStopDate))// convert string to a dateTime variable
                            {
                                if (!Validation.ValidateContractStopDate(dateOfBirth, contractStartDate, contractStopDate, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract stop date found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a dateTime variable
                            {
                                if (stringsInRecord[6] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract stop date FORMAT found reading record: " + record);
                                    continue;
                                }
                            }

                            if (float.TryParse(stringsInRecord[7], out contractAmount))// covert the string a float variable
                            {
                                if (!Validation.ValidateFixedContractAmount(contractAmount, ref returnedErrorMessage))
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract amount found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                    continue;
                                }
                            }
                            else// couldn't convert the string to a float
                            {
                                if (stringsInRecord[7] != "N/A")
                                {
                                    ++numInvalidRecords;
                                    Logging.LogEvent("[FileIO.OpenDBase] Invalid contract amount FORMAT found reading record: " + record);
                                    continue;
                                }
                            }

                        }// end 'if' that validates a CT employee
                        else// invalid employee type (for 8 strings)
                        {
                            ++numInvalidRecords;
                            Logging.LogEvent("[FileIO.OpenDBase] Invalid employee type found reading record: " + record);
                            continue;
                        }

                    }// end 'else' statement (that validates the correct number of strings for the employee type)

                }
                else if (stringsInRecordIndex == 7)// the SN employee type will have 7 strings in a record (the type of employee plus 6 data members)
                {
                    if (stringsInRecord[0] == "SN")// check to make sure it is a seasonal employee (SN)
                    {
                        float piecePay = 0;// unique to SN employees so we declare it here

                        if (!ValidateFirstThree(stringsInRecord[1], stringsInRecord[2], stringsInRecord[3], ref returnedErrorMessage))// check if the first 3 data members are valid (starting at the 2nd string in record because the first one is the employee type)
                        {
                            ++numInvalidRecords;
                            Logging.LogEvent("[FileIO.OpenDBase] Error was found reading record: " + record +" Error: " + returnedErrorMessage);
                            continue;
                        }

                        if (DateTime.TryParse(stringsInRecord[4], out dateOfBirth))// convert string to a dateTime variable
                        {
                            if (!Validation.ValidateDateOfBirth(dateOfBirth, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid date of birth found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                continue;
                            }
                        }
                        else// couldn't convert the string to a dateTime variable
                        {
                            if (stringsInRecord[4] != "N/A")
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid date of birth FORMAT found reading record: " + record);
                                continue;
                            }
                        } 

                        if (!Validation.ValidateSeason(stringsInRecord[5], ref returnedErrorMessage))
                        {
                            ++numInvalidRecords;
                            Logging.LogEvent("[FileIO.OpenDBase] Invalid season found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                            continue;
                        }

                        if (float.TryParse(stringsInRecord[6], out piecePay))// convert the string to a float variable
                        {
                            if (!Validation.ValidatePiecePay(piecePay, ref returnedErrorMessage))
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid piece pay amount found reading record: " + record +".\r\n\tError: " + returnedErrorMessage);
                                continue;
                            }
                        }
                        else// couldn't convert the string to a float
                        {
                            if (stringsInRecord[6] != "N/A")
                            {
                                ++numInvalidRecords;
                                Logging.LogEvent("[FileIO.OpenDBase] Invalid piece pay amount FORMAT found reading record: " + record);
                                continue;
                            }
                        }

                    }// end 'if' that validate SN employee
                    else// invalid employee type
                    {
                        ++numInvalidRecords;
                        Logging.LogEvent("[FileIO.OpenDBase] Invalid employee type found reading record: " + record);
                        continue;
                    }

                }
                else// wrong number of strings in record
                {
                    ++numInvalidRecords;
                    Logging.LogEvent("[FileIO.OpenDBase] Invalid number of strings found reading record: " + record);
                    continue;
                }// end 'else' statement 

                // if it reaches this point the record was valid
                validRecords.Add(stringsInRecord);
                ++numValidRecords;
                Logging.LogEvent("[FileIO.OpenDBase] Valid employee read. Record: " + record);

            }// end 'foreach'

            Logging.LogEvent("[FileIO.OpenDBase] Reading file: " + dbName + ". Total Records read: " + numRecordsRead.ToString() + ". Valid records read: " + numValidRecords.ToString() + ". Invalid records read: " + numInvalidRecords.ToString());

            if (dbReader != null)
            {
                dbReader.Close();
            }

            return validRecords;            
        }

        /**
        * \brief To close the database file by writing a List of strings to the database file
        * \details <b>Details</b>
        *
        * This method will take in a List of strings and writing them to the database file that was specified when 
        * a database file was opened (and the name was stored in the <i>databaseName</i> data member). The number 
        * of records written as well as the number of valid and invalid records written will be logged.
        * 
        * \param stringsToWrite - List<string> - a string List that holds the strings to write to the database file
        * \param errorMessage - string - a string that is passed as a reference and is used to hold an error message if 
        *                                an error occurs
        * 
        * \return A bool <i>noErrors</i> that is used to tell if there was a problem. If it is false then the string 
        *         <i>errorMessage</i> can be checked to see what went wrong.
        *
        */
        public static bool CloseDBase(List<string> stringsToWrite, ref string errorMessage)
        {
            bool noErrors = true;
            int numRecordsWritten = 0;// the total number of records written
            int numValidRecords = 0;// the number of valid records read
            int numInvalidRecords = 0;// the number of invalid records read                     

            try// opening the streamWriter could throw exception
            {
                dbWriter = new StreamWriter(databaseName);
                Logging.LogEvent("[FileIO.CloseDBase] The file: " + databaseName + " was opened for writing.");

                foreach (string record in stringsToWrite)
                {
                    int pipeIndex = 0;// used to hold the index of the first pipe character found
                    int numPipes = 0;// used to count the number of pipe characters found
                    string employeeType = "";

                    pipeIndex = record.IndexOf('|');
                    ++numPipes;
                    if (pipeIndex == -1)// check if there are no pipe characters in the string (which would make it invalid)
                    {
                        ++numInvalidRecords;
                        continue;
                    }
                    employeeType = record.Substring(0, pipeIndex);// extract the employee type from the string

                    pipeIndex = record.IndexOf('|', pipeIndex + 1);// find the next pipe in the string
                    while (pipeIndex != -1)// loop until all the pipe characters are found
                    {
                        ++numPipes;
                        pipeIndex = record.IndexOf('|', pipeIndex + 1);// find the next pipe in the string
                    }

                    if(numPipes == 8)
                    {
                        if(employeeType == "FT" || employeeType == "PT" || employeeType == "CT")
                        {
                            WriteRecord(record);
                            ++numRecordsWritten;
                            ++numValidRecords;
                            continue;
                        }
                        else// it is an invalid employee type
                        {
                            ++numInvalidRecords;
                            continue;
                        }

                    }
                    else if(numPipes == 7)
                    {
                        if (employeeType == "SN")
                        {
                            WriteRecord(record);
                            ++numRecordsWritten;
                            continue;
                        }
                        else
                        {
                            ++numInvalidRecords;
                            continue;
                        }
                    }
                    else
                    {
                        ++numInvalidRecords;
                        continue;
                    }
                    
                }// end 'foreach'

                dbWriter.Close();
            }
            catch (DirectoryNotFoundException)
            {
                errorMessage = "The Directory to save the database file could not be found.";
                Logging.LogEvent("[FileIO.CloseDBase] The directory for the file: " + databaseName + " could not be found for writing.");
            }
            catch(Exception e)
            {
                errorMessage = "Error saving to the database file. Message: " + e.Message;
                Logging.LogEvent("[FileIO.CloseDBase] There was an error opening the file: " + databaseName + " for writing. Message: " + e.Message);
            }

            Logging.LogEvent("[FileIO.CloseDBase] Total Records written: " + numRecordsWritten.ToString() + ". Valid records written: " + numValidRecords.ToString() + ". Invalid records written: " + numInvalidRecords.ToString());

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
            return dbReader.ReadLine();
        }

        /**
        * \brief To write a single record to the database file
        * \details <b>Details</b>
        *
        * This method writes a string (and a newline) to the database file using the <i>dbWriter</i> data member
        * 
        * \param record - string - the string that the calling method would like to write to the
        * database file
        * 
        * \return Nothing
        *
        */
        private static void WriteRecord(string record)
        {
            dbWriter.WriteLine(record);
            dbWriter.Flush();// actually write the data to the file
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

            errorMessage = returnedErrorMessage;// pass the errors back to 

            return isValid;
        }

    }

}
