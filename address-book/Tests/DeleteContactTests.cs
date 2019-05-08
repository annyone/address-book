using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.Delete(1);
        }
    }
}
