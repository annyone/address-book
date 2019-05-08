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
            navHelper.OpenHomePage();
            userHelper.LogIn(new UserData("admin", "secret"));
            navHelper.OpenGroupsPage();
            groupHelper.NewGroupForm();
            groupHelper.FillNewGroupForm(new GroupData("a", "b", "c"));
            groupHelper.SubmitNewGroupForm();
            navHelper.OpenGroupsPage();
            userHelper.LogOut();
        }        
    }
}
