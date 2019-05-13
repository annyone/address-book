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
    public class NavHelper : BaseHelper
    {
        private string baseURL;

        public NavHelper(AppManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);

        }

        public void OpenGroupsPage()
        {
            if(driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
