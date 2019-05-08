using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class EditGroupTests : TestBase
    {
        [Test]
        public void EditGroupTest()
        {
            GroupData newValue = new GroupData("a1", "b1", "c1");
            app.Groups.Edit(1, newValue);
        }

    }
}
