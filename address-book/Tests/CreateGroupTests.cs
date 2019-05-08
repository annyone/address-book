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
            GroupData group = new GroupData("a", "b", "c");
            app.Groups.Create(group);
        }

        [Test]
        public void CreateGroupTestWithEmptyFields()
        {
            GroupData group = new GroupData("", "", "");
            app.Groups.Create(group);
        }
    }
}
