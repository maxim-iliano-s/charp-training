using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading.Tasks;





namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
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

            List<ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Create(contact);

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("") {};

            List<ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Create(contact);

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);

        }

        [Test]
        public void DisplayContactName()
        {

            //List<ContactData> contacts = new List<ContactData>();
            //List<ContactData> oldContact = app.Contacts.GetContactsList();
           // app.Contacts.Create();
            app.Contacts.DisplayContact();
            

        }
    }
}