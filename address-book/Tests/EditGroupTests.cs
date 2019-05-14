using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class EditGroupTests : AuthTestBase
    {
        [Test]
        public void EditGroupAllFields()
        {
            GroupData newValue = new GroupData("a1", "b1", "c1");
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            app.Groups.Edit(1, newValue);
        }

        [Test]
        public void EditGroupHeader()
        {
            GroupData newValue = new GroupData("a2", null, null);
            app.Nav.OpenGroupsPage();
            app.Groups.IsGroupExist();
            app.Groups.Edit(1, newValue);
        }
    }
}
