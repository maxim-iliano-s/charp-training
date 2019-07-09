using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("GroupModificationTest1");

            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroup = app.Groups.GetGroupList();
            app.Groups.Modify(0, newData);

            List<GroupData> newGroup = app.Groups.GetGroupList();
            oldGroup[0].Name = newData.Name;
            oldGroup.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroup, newGroup);
            Console.WriteLine( "{0}", Object.ReferenceEquals(oldGroup, newGroup), "bla bla");

        }
    }
}