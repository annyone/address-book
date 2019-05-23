using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Nav.OpenHomePage();
            app.Contacts.IsContactExist();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Delete(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
