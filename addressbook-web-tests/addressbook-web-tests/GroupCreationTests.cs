using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "ddd"
            };
            FillGroupForm(group);
            SubmitGroupCreation();
            GotoGroupPage();
            Logout();
        }
    }
}