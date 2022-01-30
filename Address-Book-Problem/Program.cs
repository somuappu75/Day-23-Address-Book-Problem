using System;

namespace Address_Book_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adding Contact
            Console.WriteLine("------------Welcome To Adderess Book Program-------------");
            Console.WriteLine("1.Enter to add the details\n2.Enter to modify the details");
            Console.WriteLine("3.Listing the details..");
            Console.WriteLine("4.Remove or Delete the  COntact details");
            Console.WriteLine("5.Multiplke Contact Details");
            Console.WriteLine("Enter a option");
            switch (Console.ReadLine())
            {
                case "1":
                    AddressBook.GetContact();
                    AddressBook.ListContact();

                    break;
                case "2":
                    AddressBook.GetContact();
                    AddressBook.EditContact();
                    AddressBook.ListContact();
                    break;
                case "3":
                    AddressBook.GetContact();
                    AddressBook.ListContact();
                    break;
                case "4":
                    AddressBook.GetContact();
                    AddressBook.DeletePeople();

                    break;
                case "5":
                    AddressBook.GetContact();
                    AddressBook.GetContact();
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;

            }


        }
    }
}
