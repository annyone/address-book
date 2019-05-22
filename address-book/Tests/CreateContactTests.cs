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
        [Test]
        public void CreateContactTest()
        {
            ContactData contact = new ContactData("firstname", "lastname")
            {
                Workaddress = "workaddress",
                Homephone = "homephone",
                Mobilephone = "mobilephone",
                Workphone = "workphone",
                Fax = "fax",
                Email1 = "email1",
                Email2 = "email2",
                Email3 = "email3"
            };

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