using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using PhoneBookTestApp;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private readonly Person person;

        public void GetAll()
        {
            var con = DatabaseUtil.GetConnection();
            string name, phone, address;

            using (con)
            {
                DbCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from PHONEBOOK";
                DbDataReader reader = cmd.ExecuteReader();
             
                while (reader.Read())
                    Console.WriteLine("Name: " + reader["NAME"] + "\tPHONENUMBER: " + reader["PHONENUMBER"] +
                                      "\tADDRESS: " + reader["ADDRESS"]);
                Console.ReadLine();
            }
        }

        public void FindPerson(string fName, string lName)
        {
            var con = DatabaseUtil.GetConnection();
        
            using (con)
            {
                DbCommand cmd = con.CreateCommand();
               
                cmd.CommandText = "Select * from PHONEBOOK where NAME like '%"+fName+"%'";
                DbDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                        Console.WriteLine("Name: " + reader["NAME"] + "\tPHONENUMBER: " + reader["PHONENUMBER"] +
                                          "\tADDRESS: " + reader["ADDRESS"]);    
                }
                catch (Exception)
                {                    
                    Console.WriteLine("Record no Found!");
                }
               
                
               
                
                Console.ReadLine();
            }
        }

        public void AddPerson()
        {
            var context = DatabaseUtil.GetConnection();


            string sql =
                "insert into PHONEBOOK (NAME, PHONENUMBER, ADDRESS) " +
                "values ('John Smith', '(248) 123-4567', '1234 Sand Hill Dr, Royal Oak, MI')";
            SQLiteCommand command = new SQLiteCommand(sql, context);
            command.ExecuteNonQuery();

            sql = "insert into PHONEBOOK (NAME, PHONENUMBER, ADDRESS) " +
                  "values ('Cynthia Smith', '(824) 128-8758', '875 Main St, Ann Arbor, MI')";
            command = new SQLiteCommand(sql, context);
            command.ExecuteNonQuery();

            Console.WriteLine("\nAfter Adding New Records: \n\n");
            GetAll();            
        }

        //public Person FindPersonNew(string firstName, string lastName)
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        var persons = from a in context.Persons
        //                      where a.Name.EndsWith("Johnson")
        //                      orderby a.Name
        //                      select a;

        //        foreach (var p in persons)
        //        {
        //           Console.WriteLine(p.Name);                   
        //        }
        //    }
        //    return person;
        //}
    }
}