using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Address_Book_Problem
{
    class ContactCsvFile
    {
        public static void CSVOFile(Dictionary<string, List<AddressBook>> addressbooknames)
        {
          
            string csvFilePath = @"C:\Users\HP\source\repos\AddressBooks\AddressBooks\DataCsv.csv";
            File.WriteAllText(csvFilePath, string.Empty);

            foreach (KeyValuePair<string, List<AddressBook>> kvp in addressbooknames)
            {
                // file in Append Mode for adding List elements
                using var stream = File.Open(csvFilePath, FileMode.Append);
                using var writer = new StreamWriter(stream);
                using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                foreach (var value in kvp.Value)
                {
                    // add Records
                    List<AddressBook> list = new List<AddressBook>();
                    list.Add(value);
                    //Write List to CSV File
                    csvWriter.WriteRecords(list);
                }
                
                csvWriter.NextRecord();
            }
            
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Get all records from Csv File
                var records = csv.GetRecords<AddressBook>().ToList();

                foreach (AddressBook member in records)
                {
                    //To skip Headers in Csv File
                    if (member.firstName == "firstName")
                    {
                        Console.WriteLine("\n");
                        continue;
                    }
                    //Convert each Value to string and Print to Console
                    Console.WriteLine(member.ToString());
                }

            }
        }
    }
}
