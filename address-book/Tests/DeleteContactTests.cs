using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteContactTests : ContactTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Nav.OpenHomePage();
            app.Contacts.IsContactExist();
            List<ContactData> oldContacts = ContactData.GetAllFromDB();
            ContactData forRemove = oldContacts[0];

            app.Contacts.Delete(forRemove);

            List<ContactData> newContacts = ContactData.GetAllFromDB();
            oldContacts.RemoveAt(0);
            //oldContacts.Sort();
            //newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreEqual(contact.Id, forRemove.Id);
            }
        }
    }
}
