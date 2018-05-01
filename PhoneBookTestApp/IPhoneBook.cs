using System;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {        
        void FindPerson(string firstName, string lastName);
        void AddPerson();
        void GetAll();
    }
}