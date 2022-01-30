using System;

namespace Address_Book_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adding Contact
            Console.WriteLine("------------Welcome To Adderess Book Program-------------");
            Address_Book_Problem.AddressBook.GetContact();
            //Editing -Contact
            AddressBook.EditContact();
            Address_Book_Problem.AddressBook.ListContact();
        }
    }
}
