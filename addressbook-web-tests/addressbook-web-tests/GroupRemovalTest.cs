using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
   
    [Test]
    public void GroupRemovalTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin" , "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            navigationHelper.ReturnToGroupPage();
            //driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}