using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            app.Contacts.IsContactExist();
            app.Groups.IsGroupExist();

            GroupData group = GroupData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAllFromDB().First();
            app.Contacts.IsAddedInGroup(contact, oldList, group);

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);




        }
    }
}
