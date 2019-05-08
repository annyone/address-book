using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new AppManager();
            app.Nav.OpenHomePage();
            app.User.LogIn(new UserData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.User.LogOut();
            app.Stop();
        }
    }
}
