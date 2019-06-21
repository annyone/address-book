using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace address_book_tests
{
    [TestFixture]
    public class EditContactTests : ContactTestBase
    {
        [Test]
        public void EditContactTest()
        {
            ContactData newValue = new ContactData("firstname000", "lastname000");

            app.Nav.OpenHomePage();
            app.Contacts.IsContactExist();
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            app.Contacts.Edit(oldContacts[0], newValue);

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts[0].Lastname = newValue.Lastname;
            oldContacts[0].Firstname = newValue.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
