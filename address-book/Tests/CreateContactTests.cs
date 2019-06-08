using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;

namespace address_book_tests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
      /*  public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), (GenerateRandomString(10)))
                {
                    Address = GenerateRandomString(15),
                    Homephone = Convert.ToString(rnd.Next(00000, 29999)),
                    Mobilephone = Convert.ToString(rnd.Next(30000, 59999)),
                    Workphone = Convert.ToString(rnd.Next(60000, 79999)),
                    Fax = Convert.ToString(rnd.Next(80000, 99999)),
                    Email1 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                    Email2 = GenerateRandomString(5) + "@" + GenerateRandomString(5),
                    Email3 = GenerateRandomString(5) + "@" + GenerateRandomString(5)
                });
            }

            return contacts;
        }
        */
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contact.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void CreateContactTest(ContactData contact)
        {
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