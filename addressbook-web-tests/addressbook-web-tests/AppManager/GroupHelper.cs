using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }


        internal int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCahce = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCahce == null)
            {
                groupCahce = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCahce.Add(new GroupData(element.Text));
                }
            }
            
            return new List<GroupData>(groupCahce);
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            ++index;
            manager.Navigator.GoToGroupsPage();
            IsGroupPresent_1(index);
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        
        public GroupHelper Remove(int index)
        {
            ++index;
            manager.Navigator.GoToGroupsPage();
            IsGroupPresent_1(index);
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper IsGroupPresent_1(int index)
        {
            int groupCount = driver.FindElements(By.Name("selected[]")).Count();
            if (index > groupCount)
            {
                for (int i = 1; i <= index; i++)
                {
                    GroupData group = new GroupData("")
                    {
                        Header = "",
                        Footer = ""
                    };
                    Create(group);
                }
                manager.Navigator.GoToGroupsPage();
            }
            return this;
        }
        /*public ContactHelper CountPresentContact(int v)
        {
            int contactCount = driver.FindElements(By.Name("selected[]")).Count();
            if (v > contactCount)
            {
                for (int i = 1; i <= v; i++)
                {
                    ContactData cont = new ContactData() { };
                    Create();
                    //return this;
                }
                manager.Navigator.GoToHomePage();
            }
            return this;
        }*/

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
                        
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCahce = null;
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCahce = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCahce = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}