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
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(AppManager manager)
            : base(manager) { }

        public GroupHelper Create(GroupData group)
        {
            manager.Nav.OpenGroupsPage();
            NewGroupForm();
            FillGroupForm(group);
            SubmitNewGroupForm();
            manager.Nav.OpenGroupsPage();

            return this;
        }

        public GroupHelper Edit(int id, GroupData newValue)
        {
            manager.Nav.OpenGroupsPage();
            SelectGroup(id);
            EditGroupForm();
            FillGroupForm(newValue);
            SubmitEditGroupForm();
            manager.Nav.OpenGroupsPage();

            return this;
        }

        public GroupHelper Delete(int id)
        {
            manager.Nav.OpenGroupsPage();
            SelectGroup(id);
            DeleteGroup();
            manager.Nav.ReturnToGroupsPage();

            return this;
        }

        public GroupHelper NewGroupForm()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);

            return this;
        }

        public GroupHelper SubmitNewGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();

            return this;
        }

        public GroupHelper SubmitEditGroupForm()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();

            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();

            return this;
        }

        public GroupHelper EditGroupForm()
        {
            driver.FindElement(By.Name("edit")).Click();

            return this;
        }
    }
}
