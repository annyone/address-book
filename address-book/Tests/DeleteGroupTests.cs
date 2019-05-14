using System;
using System.Text;
using System.Text.RegularExpressions;
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
            app.Groups.Delete(1); // порядковый номер
        }
    }
}
