﻿using System;
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
        private readonly string baseURL;
        public ContactHelper(AppManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public ContactData GetContactInfoFromForm(int index)
        {
            manager.Nav.OpenHomePage();
            EditContactBtn(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Address = address,
                Homephone = homePhone,
                Mobilephone = mobilePhone,
                Workphone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetDetailsContactInfoFromForm(int index)
        {
            manager.Nav.OpenHomePage();
            EditContactBtn(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Address = address,
                Homephone = homePhone,
                Mobilephone = mobilePhone,
                Workphone = workPhone,
                Fax = fax, 
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            manager.Nav.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };

        }

        public ContactData GetContactInfoFromDetails(int index)
        {
            manager.Nav.OpenHomePage();
            DetailsContactBtn(index);
            string text = driver.FindElement(By.Id("content")).Text;
            return new ContactData(text);
        }

        internal void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Nav.OpenHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            AddContactToGroupBtn();
        }

        internal void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Nav.OpenHomePage();
            SelectGroup(group.Name);
            SelectContact(contact.Id);
            DeleteContactFromGroupBtn();
        }

        private void SelectGroup(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void DeleteContactFromGroupBtn()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void AddContactToGroupBtn()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
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

        public void IsAbleToAddInGroup(List<GroupData> groupContactList)
        {
            List<GroupData> allGroups = GroupData.GetAllFromDB();

            if (allGroups.Count.Equals(groupContactList.Count))
            {
                ContactData contact = new ContactData("firstname", "lastname");
                Create(contact);
            }
        }

        public void IsAddedInGroup(ContactData contact, List<ContactData> groupList, GroupData group)
        {
            if(groupList.Count == 0)
            {
                AddContactToGroup(contact, group);
            }
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

        public void Edit(ContactData contact, ContactData newValue)
        {
            EditContactBtn(contact.Id);
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

        public ContactHelper Delete(ContactData contact)
        {
            manager.Nav.OpenHomePage();
            SelectContact(contact.Id);
            DeleteContactBtn();
            driver.SwitchTo().Alert().Accept();
            manager.Nav.OpenHomePage();

            return this;
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
            InputText(By.Name("address"), contact.Address);
            InputText(By.Name("home"), contact.Homephone);
            InputText(By.Name("mobile"), contact.Mobilephone);
            InputText(By.Name("work"), contact.Workphone);
            InputText(By.Name("fax"), contact.Fax);
            InputText(By.Name("email"), contact.Email1);
            InputText(By.Name("email2"), contact.Email2);
            InputText(By.Name("email3"), contact.Email3);
            return this;
        }

        public int GetNumberOfResults()
        {
            manager.Nav.OpenHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;

            return Int32.Parse(text);
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

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();

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

        public ContactHelper EditContactBtn(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
            return this;
        }

        public ContactHelper DetailsContactBtn(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();

            return this;
        }
    }
}
