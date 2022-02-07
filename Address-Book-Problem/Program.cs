using System;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book_Problem
{
    class Program
    {
        public static Dictionary<string, List<AddressBook>> NumberNames = new Dictionary<string, List<AddressBook>>();
        public static Dictionary<string, List<AddressBook>> City = new Dictionary<string, List<AddressBook>>();
        public static Dictionary<string, List<AddressBook>> State = new Dictionary<string, List<AddressBook>>();
        static void Main(string[] args)
        {

            // Set the Foreground color to blue
            Console.ForegroundColor = ConsoleColor.Blue;

            // Display current Foreground color
           // Console.WriteLine("Changed Foreground Color: {0}",
                                   // Console.ForegroundColor);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------Welcome to Address Book System----------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter the number of address books: ");
            int noOfAddressBook = Convert.ToInt32(Console.ReadLine());
            
            while (0<noOfAddressBook)
            {
                Console.WriteLine("Enter the address book name : ");
                string addressbookname = Console.ReadLine();
                AddressBook addrBook = new AddressBook();
                Console.WriteLine("Enter the number of contacts in the address book: ");
                int noOfContact = Convert.ToInt32(Console.ReadLine());

                while (noOfContact > 0)
                {
                    Console.WriteLine("Enter the details of contact to be added: ");

                    Console.Write("Enter First Name: ");
                    string FirstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string LastName = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Address : ");
                    string Addresses = Console.ReadLine();

                    Console.Write("Enter City : ");
                    string City = Console.ReadLine();

                    Console.Write("Enter State : ");
                    string State = Console.ReadLine();

                    Console.Write("Enter ZipCode: ");
                    string ZipCode = Console.ReadLine();

                    Console.Write("Enter EmailId: ");
                    string EmailId = Console.ReadLine();
                    addrBook.CreateContact(FirstName, LastName, PhoneNumber, Addresses, City, State, ZipCode, EmailId);
                    noOfContact--;
                   

                }
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Press Y (If You Want To Change) Else n");
                Console.WriteLine("Do you want to Modify?(Y/N)");
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'Y')
                {

                    addrBook.Modify();
                }

                NumberNames.Add(addressbookname, addrBook.ContactArray);
                foreach (KeyValuePair<string, List<AddressBook>> kvp in NumberNames)
                {
                              
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value + "\n");
                }
                noOfAddressBook--;

            }

            Search();
        }
        public void Display(List<AddressBook> ContactArray, int N)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------ Details Of Address Book Dispaly All Fields And Conatines-------------------------------");
            int i;
            for (i = 0; i < N; i++)
            {
                Console.WriteLine("First Name: {0}\n Last Name: {1}\n Address: {2}\n City: {3}\n Zip: {4}\n State: {5}\n Phone Number: {6}\n EmailId: {7} \n", ContactArray[i].firstName, ContactArray[i].lastName, ContactArray[i].Address, ContactArray[i].city, ContactArray[i].zip, ContactArray[i].state, ContactArray[i].phoneNumber, ContactArray[i].email);

            }
        }



        public static void SortContactPerson()
        {

            Console.WriteLine("Enter 1.to Sort contact based on First Name");
            Console.WriteLine("Enter 2.to Sort Contact Based on State");
            Console.WriteLine("Enter 3.to Sort Contact based on City");
            Console.WriteLine("Enter 4.to Sort Contact based on zip");
            int option = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<string, List<AddressBook>> kvp in NumberNames)
            {
                Console.WriteLine("-------------Displaying sorted Contact Person Details in address book: {0}------------", kvp.Key);
                //Store value of Dictionary in a list
                List<AddressBook> listAddressBook = kvp.Value;
                //Create object for Class that implements IComparer<AddressBookSystem>  
                ComapareContactPerson contactPersonComparer = new ComapareContactPerson();
                switch (option)
                {
                    case 1:
                        //Set field based on the switch case Option
                        contactPersonComparer.compareThroughFields = ComapareContactPerson.sortBy.firstName;
                        //Call Sort Method
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 2:
                        contactPersonComparer.compareThroughFields = ComapareContactPerson.sortBy.state;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 3:
                        contactPersonComparer.compareThroughFields = ComapareContactPerson.sortBy.city;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 4:
                        contactPersonComparer.compareThroughFields = ComapareContactPerson.sortBy.zip;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                }

                foreach (var emp in listAddressBook)
                {
                    Console.WriteLine(emp.ToString());
                }

            }

        }

        public static void Search()
        {
            Console.WriteLine("Enter 1.to Seach a person through a City");
            Console.WriteLine("Enter 2.to Seach a person through a State");
            Console.WriteLine("Enter 3.to view people  in City list or State list");
            Console.WriteLine("Enter 4.to Sort Contact people in Address Book");
            Console.WriteLine("Enter 5.To Write AddressBook in File");
            Console.WriteLine("Enter 6.To Read a File");
            Console.WriteLine("Enter 7.Perform Csv Operations");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    SearchAddress(option);
                    break;
                case 2:
                    SearchAddress(option);
                    break;
                case 3:
                    DisplayCityorState();
                    break;
                case 4:
                    SortContactPerson();
                    break;
                case 5:
                    FileIo.GetDictionary(NumberNames);
                    break;
                case 6:
                    FileIo.ReadAddressBook();
                    break;
                case 7:
                    CsvOperation.CSVOperation(NumberNames);
                    break;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
        //Dispaly CIty 

        public static void DisplayCityorState()
        {
            Console.WriteLine("Enter 1-to view City list\n Enter 2-to view State list");
            int citystate = Convert.ToInt32(Console.ReadLine());
            if (citystate == 1)
            {
                foreach (var i in City)
                {
                    Console.WriteLine("Display List for City: {0}\n", i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in City {2}", j.firstName, j.lastName, j.city);
                    }
                    //Count number of people in Particular city
                    Console.WriteLine("Count of people in City is: {0}", i.Value.Count);

                }
            }
            else
            {
                foreach (var i in State)
                {
                    Console.WriteLine("Display List for State: {0}\n", i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in State {2}", j.firstName, j.lastName, j.state);
                    }
                    //Count number of people in Particular State
                    Console.WriteLine("Count of people in State is: {0}", i.Value.Count);
                }
            }

        }
        //Search a person through different Address Book based on City or State
        public static void SearchAddress(int option)
        {
            string city = "", state = "";
            if (option == 1)
            {
                Console.WriteLine("Enter the City Name");
                city = Console.ReadLine();
            }
            if (option == 2)
            {
                Console.WriteLine("Enter the City Name");
                state = Console.ReadLine();
            }

            // all Address Book present in Dictionary
            foreach (KeyValuePair<string, List<AddressBook>> kvp in NumberNames)
            {
                if (option == 1)
                {
                    StoreCity(kvp.Key, kvp.Value, city);
                }
                if (option == 2)
                {
                    StoreState(kvp.Key, kvp.Value, state);
                }

            }
        }

        public static void StoreCity(string key, List<AddressBook> ContactArray, string city)
        {
            List<AddressBook> CityList = ContactArray.FindAll(x => x.city.Equals(city)).ToList();
            foreach (var i in CityList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in City {2}", i.firstName, key, i.city);
            }
        }
        //Display Person names found in given State
        public static void StoreState(string key, List<AddressBook> ContactArray, string state)
        {
            List<AddressBook> StateList = ContactArray.FindAll(x => x.state.Equals(state)).ToList();
            foreach (var i in StateList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in State {2}", i.firstName, key, i.state);
            }
        }

    }
        }



