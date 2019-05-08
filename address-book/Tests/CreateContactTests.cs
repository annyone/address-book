using System;
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
            app.Nav.OpenHomePage();
            app.User.LogIn(new UserData("admin", "secret"));
            app.Contacts.CreateNewContact();
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
            app.Contacts.FillNewContactForm(contact);
            app.Contacts.SubmitNewContactForm();
            app.Nav.OpenHomePage();
            app.User.LogOut();
        }
    }
}
