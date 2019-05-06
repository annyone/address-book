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
            OpenHomePage();
            LogIn(new UserData("admin", "secret"));
            OpenGroupsPage();
            NewGroupForm();
            FillNewGroupForm(new GroupData("a", "b", "c"));
            SubmitNewGroupForm();
            OpenGroupsPage();
            LogOut();
        }        
    }
}
