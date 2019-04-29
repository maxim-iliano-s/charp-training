using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("nnnn", "xxxx")
            {
                Address = "Aweert, Assd st., 2/3",
                Email = "asdf@sdfg.org",
                Home = "+79095556633"
            };
            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData() {};
            app.Contacts.Create();
        }
    }
}