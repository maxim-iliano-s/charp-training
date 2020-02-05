using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using System.Windows.Forms;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContact = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);

            MessageBox.Show("In ContactRemovalTest", "AreEqual");
            Assert.AreEqual(oldContact.Count-1, app.Contacts.GetContactCount());

            List<ContactData> newContact = app.Contacts.GetContactsList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();

            MessageBox.Show("In ContactRemovalTest", "AreEqual");
            Assert.AreEqual(oldContact, newContact);
        }
    }
}