using NUnit.Framework;
using PhoneBookTestApp;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    public class PhoneBookTest
    {
        

        [Test]
        public void getAllPerson()
        {
            DatabaseUtil.initializeDatabase();

            PhoneBook testPhoneBook = new PhoneBook();

            testPhoneBook.GetAll();

            Assert.IsNotNull(testPhoneBook); 
        }

        [Test]
        public void findPerson()
        {
            DatabaseUtil.initializeDatabase();

            PhoneBook testPhoneBook = new PhoneBook();

            testPhoneBook.FindPerson("David", "Jhonson");
            
            Assert.IsNotNull(testPhoneBook);
        }
    }

    // ReSharper restore InconsistentNaming 
}