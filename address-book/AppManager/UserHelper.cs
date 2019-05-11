using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace address_book_tests
{
    public class UserHelper : BaseHelper
    {
        public UserHelper (AppManager manager) 
            : base(manager) { }

        public void LogIn(UserData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user))
                {
                    return;
                }
                LogOut();
            }

            InputText(By.Name("user"), user.Username);
            InputText(By.Name("pass"), user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(UserData user)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                    == "(" + user.Username + ")";
        }
    }
}
