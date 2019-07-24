using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData()
            {
                Firstname = "Aaaaa",
                Lastname = null,
                Address = "Aweert, Assd st., 2/3"
            };

            List<ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.ContactModification(1, contact);

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact[0].Firstname = contact.Firstname;
            oldContact[0].Lastname = contact.Lastname;
            oldContact[0].Address = contact.Address;
                        
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
    }
}