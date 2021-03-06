﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteGroupTests : GroupTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            GroupData forRemove = oldGroups[0];
            app.Groups.Delete(forRemove);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, forRemove.Id);
            }

        }
    }
}
