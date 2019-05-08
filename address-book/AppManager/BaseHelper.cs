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
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected AppManager manager;

        public BaseHelper(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}