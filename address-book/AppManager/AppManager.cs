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
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected UserHelper userHelper;
        protected NavHelper navHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public AppManager()
        {
            userHelper = new UserHelper(driver);
            navHelper = new NavHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public UserHelper User
        {
            get
            {
                return userHelper;
            }
        }

        public NavHelper Nav
        {
            get
            {
                return navHelper;
            }
        }

        public GroupHelper Gpoups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

    }
}
