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
            GroupData group = new GroupData("aaa")
            {
                Header = "bbb",
                Footer = "ddd"
            };

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            app.Groups.Create(group);
        }
    }
}