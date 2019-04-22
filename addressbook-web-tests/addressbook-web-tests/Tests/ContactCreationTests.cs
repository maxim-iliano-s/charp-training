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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("nnnn", "xxxx");
            contact.Address = "Aweert, Assd st., 2/3";
            contact.Email = "asdf@sdfg.org";
            contact.Home = "+79095556633";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
        }
    }
}