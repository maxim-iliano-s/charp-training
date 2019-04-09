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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("nnnn", "xxxx");
            contact.Address = "Aweert, Assd st., 2/3";
            contact.Email = "asdf@sdfg.org";
            contact.Home = "+79095556633";
            FillContactForm(contact);
            SubmitContactCreation();
        }
    }
}