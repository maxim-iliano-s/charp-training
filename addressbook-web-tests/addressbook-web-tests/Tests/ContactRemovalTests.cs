using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContact = app.Contacts.GetContactsList();

            app.Contacts.Remove(1);

            Assert.AreEqual(oldContact.Count -1, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.RemoveAt(1);
            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, newContact);
        }
    }
}