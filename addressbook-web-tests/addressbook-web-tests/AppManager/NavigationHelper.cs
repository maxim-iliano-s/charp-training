using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class NavigationHelper : BaseHelper
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manger, string baseURL) 
            : base(manger)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        /*public void GotoGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }*/
    }
}