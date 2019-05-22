using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Delete(0); // 1
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
