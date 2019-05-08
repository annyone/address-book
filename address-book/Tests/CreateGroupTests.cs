using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroupTest()
        {
            app.Nav.OpenHomePage();
            app.User.LogIn(new UserData("admin", "secret"));
            app.Nav.OpenGroupsPage();
            app.Gpoups.NewGroupForm();
            app.Gpoups.FillNewGroupForm(new GroupData("a", "b", "c"));
            app.Gpoups.SubmitNewGroupForm();
            app.Nav.OpenGroupsPage();
            app.User.LogOut();
        }        
    }
}
