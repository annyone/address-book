﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            app.Contacts.IsContactExist();
            app.Groups.IsGroupExist();

            GroupData group = GroupData.GetAllFromDB()[0];
            ContactData contact = ContactData.GetAllFromDB()[0];
            List<ContactData> oldList = group.GetContacts();
            List<GroupData> allGroups = contact.GetGroups();
            app.Contacts.IsAbleToAddInGroup(allGroups);

            contact = ContactData.GetAllFromDB().Except(group.GetContacts()).First();
            
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
