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
            Console.WriteLine("5.Multiplke Contact Details /Dictionary Added");
            Console.WriteLine("Enter a option");
            AddressBook addressBook = new AddressBook();
            switch (Console.ReadLine())
            {
                case "1":
                  
                    addressBook.GetContact();
                    addressBook.ListContact();
                    

                    break;
                case "2":
                    addressBook.GetContact();
                    addressBook.EditContact();
                    addressBook.ListContact();
                    break;
                case "3":
                    addressBook.GetContact();
                    addressBook.ListContact();
                    break;
                case "4":
                    addressBook.GetContact();
                    addressBook.DeletePeople();

                    break;
                case "5":
                    addressBook.GetContact();
                    addressBook.ListContact();
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;

            }


        }
    }
}
