using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp;

namespace PhoneBookTestApp
{
    internal class Program
    {
        private static PhoneBook phonebook = new PhoneBook();

        private static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */                                             
                // TODO: print the phone book out to System.out    
                Console.Write("\n\n************All Records in the PhoneBook Table!************\n");
                phonebook.GetAll();
                
                // TODO: insert the new person objects into the database
                Console.Write("************\n\nNew Person Added in the PhoneBook Table !\n"); 
                phonebook.AddPerson();


                // TODO: find Cynthia Smith and print out just her entry
                Console.Write("************\n\n Find the Person in PhoneBook Table !\n");
                phonebook.FindPerson("Cynthia", "Smith");
               
                Console.Write("End !");
                Console.ReadLine();

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }       
    }
}
// phonebook.FindPersonNew("Dave", "Williams"); 