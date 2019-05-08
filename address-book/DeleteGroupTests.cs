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
            navHelper.OpenHomePage();
            userHelper.LogIn(new UserData("admin", "secret"));
            navHelper.OpenGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.DeleteGroup();
            navHelper.ReturnToGroupsPage();
        }
    }
}
