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
    public class ContactHelper : BaseHelper
    {
        private string baseURL;
        public ContactHelper(AppManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void IsContactExist()
        {
            if (driver.Url == baseURL
                && !IsElementPresent(By.Name("entry")))
            {
                ContactData contact = new ContactData("firstname", "lastname");
                Create(contact);
            }
            return;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Nav.OpenHomePage();
                ICollection<IWebElement> list = driver.FindElements(By.Name("entry"));
                foreach (IWebElement item in list)
                {
                    contactCache.Add(new ContactData(item.FindElement(By.XPath(".//td[3]")).Text, item.FindElement(By.XPath(".//td[2]")).Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public void Edit(int id, ContactData newValue)
        {
            EditContactBtn(id);
            FillContactForm(newValue);
            SubmitEditContactForm();
            manager.Nav.OpenHomePage();
        }

        public void Delete(int id)
        {
            manager.Nav.OpenHomePage();
            SelectContact(id);
            DeleteContactBtn();
            driver.SwitchTo().Alert().Accept();
            manager.Nav.OpenHomePage();
        }

        public void Create(ContactData contact)
        {
            manager.Nav.OpenHomePage();
            NewContactBtn();
            FillContactForm(contact);
            SubmitNewContactForm();
            manager.Nav.OpenHomePage();
        }

        public ContactHelper NewContactBtn()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            InputText(By.Name("firstname"), contact.Firstname);
            InputText(By.Name("middlename"), contact.Middlename);
            InputText(By.Name("lastname"), contact.Lastname);
            InputText(By.Name("address"), contact.Workaddress);
            InputText(By.Name("home"), contact.Homephone);
            InputText(By.Name("mobile"), contact.Mobilephone);
            InputText(By.Name("work"), contact.Workphone);
            InputText(By.Name("fax"), contact.Fax);
            InputText(By.Name("email"), contact.Email1);
            InputText(By.Name("email2"), contact.Email2);
            InputText(By.Name("email3"), contact.Email3);
            return this;
        }

        public ContactHelper SubmitNewContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitEditContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();

            return this;
        }

        public ContactHelper DeleteContactBtn()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;

            return this;
        }
        public ContactHelper EditContactBtn(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();

            return this;
        }
    }
}
