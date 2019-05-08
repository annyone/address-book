using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Nav.OpenHomePage();
            app.User.LogIn(new UserData("admin", "secret"));
            app.Nav.OpenGroupsPage();
            app.Gpoups.SelectGroup(1);
            app.Gpoups.DeleteGroup();
            app.Nav.ReturnToGroupsPage();
        }
    }
}
