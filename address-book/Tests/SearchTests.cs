using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    class SearchTests : AuthTestBase
    {
        [Test]
        public void CheckNumberOfResultsTest()
        {
            Console.Write(app.Contacts.GetNumberOfResults());
        }
    }
}
