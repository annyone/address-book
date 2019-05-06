using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            OpenHomePage();
            LogIn(new UserData("admin", "secret"));
            OpenGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
        }
    }
}
