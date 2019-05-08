using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class EditContactTests : TestBase
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
            app.Contacts.Edit(2, newValue);
        }
    }
}
