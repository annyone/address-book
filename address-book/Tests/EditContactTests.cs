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
    public class EditContactTests : AuthTestBase
    {
        [Test]
        public void EditContactTest()
        {
            ContactData newValue = new ContactData("firstname000", "lastname000")
            {
                Workaddress = "workaddress000",
                Homephone = "homephone000",
                Mobilephone = "mobilephone000",
                Workphone = "workphone000",
                Fax = "fax000",
                Email1 = "email1000",
                Email2 = "email2000",
                Email3 = "email3000"
            };

            app.Nav.OpenHomePage();
            app.Contacts.IsContactExist();
            app.Contacts.Edit(1, newValue);
        }
    }
}
