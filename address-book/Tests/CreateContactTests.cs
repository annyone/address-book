using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), (GenerateRandomString(10)))
                {
                    Address = GenerateRandomString(100),
                    Homephone = Convert.ToString(rnd.Next(00000,29999)),
                    Mobilephone = Convert.ToString(rnd.Next(30000, 59999)),
                    Workphone = Convert.ToString(rnd.Next(60000, 79999)),
                    Fax = Convert.ToString(rnd.Next(80000, 99999)),
                    Email1 = GenerateRandomString(5)+"@"+GenerateRandomString(5),
                    Email2 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                    Email3 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                });
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContactTest(ContactData contact)
        {
          /*  ContactData contact = new ContactData("firstname", "lastname")
            {
                Address = "workaddress",
                Homephone = "homephone",
                Mobilephone = "mobilephone",
                Workphone = "workphone",
                Fax = "fax",
                Email1 = "email1",
                Email2 = "email2",
                Email3 = "email3"
            };*/

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}