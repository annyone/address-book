using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class LogInTests : TestBase
    {
        [Test]
        public void LoginWithValidUser()
        {
            //prepare
            app.User.LogOut();

            //action
            UserData user = new UserData("admin", "secret");
            app.User.LogIn(user);

            //verification
            Assert.IsTrue(app.User.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidUser()
        {
            //prepare
            app.User.LogOut();

            //action
            UserData user = new UserData("admin", "12345");
            app.User.LogIn(user);

            //verification
            Assert.IsFalse(app.User.IsLoggedIn());
        }
    }
}
