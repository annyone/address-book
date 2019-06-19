using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class EditGroupTests : GroupTestBase
    {
        [Test]
        public void EditGroupAllFields()
        {
            GroupData newValue = new GroupData("a1", "b1", "c1");
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Edit(0, newValue);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups[0].Name = newValue.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EditGroupHeader()
        {
            GroupData newValue = new GroupData("a2", null, null);
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Edit(0, newValue);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups[0].Name = newValue.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
