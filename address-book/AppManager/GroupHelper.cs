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
    public class GroupHelper : BaseHelper
    {
        private string baseURL;
        public GroupHelper(AppManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Nav.OpenGroupsPage();
            ICollection<IWebElement> list = driver.FindElements(By.CssSelector("span.group"));
            foreach(IWebElement item in list)
            {
                groups.Add(new GroupData(item.Text));
            }

            return groups;
        }

        public void IsGroupExist()
        {
            if (driver.Url == baseURL + "group.php"
               && !IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("a", "b", "c");
                Create(group);
            }
            return;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Nav.OpenGroupsPage();
            NewGroupBtn();
            FillGroupForm(group);
            SubmitNewGroupForm();
            manager.Nav.ReturnToGroupsPage();

            return this;
        }

        public void Edit(int id, GroupData newValue)
        {
            manager.Nav.OpenGroupsPage();
            SelectGroup(id);
            EditGroupBtn();
            FillGroupForm(newValue);
            SubmitEditGroupForm();
            manager.Nav.OpenGroupsPage();
        }

        public void Delete(int id)
        {
            manager.Nav.OpenGroupsPage();
            if (driver.Url == baseURL + "group.php"
                && !IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("a", "b", "c");
                Create(group);
            }
            SelectGroup(id);
            DeleteGroupBtn();
            manager.Nav.ReturnToGroupsPage();
        }

        public GroupHelper NewGroupBtn()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            InputText(By.Name("group_name"), group.Name);
            InputText(By.Name("group_header"), group.Header);
            InputText(By.Name("group_footer"), group.Footer);

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

        public GroupHelper DeleteGroupBtn()
        {
            driver.FindElement(By.Name("delete")).Click();

            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();

            return this;
        }

        public GroupHelper EditGroupBtn()
        {
            driver.FindElement(By.Name("edit")).Click();

            return this;
        }
    }
}
