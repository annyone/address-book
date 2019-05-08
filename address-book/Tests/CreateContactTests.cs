﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class CreateContactTests : TestBase
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

            app.Contacts.Create(contact);
        }
    }
}