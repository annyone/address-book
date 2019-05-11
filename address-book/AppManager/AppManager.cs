using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";

            userHelper = new UserHelper(this);
            navHelper = new NavHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~AppManager()
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

        public static AppManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Nav.OpenHomePage();
                app.Value = new AppManager();  
            }

            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }             
        }

        public UserHelper User
        {
            get { return userHelper; }
        }

        public NavHelper Nav
        {
            get { return navHelper; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }
    }
}
