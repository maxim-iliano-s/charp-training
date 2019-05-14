using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData()
            {
                Firstname = "Aaaaa",
                Lastname = "Sssss",
                Address = "Aweert, Assd st., 2/3"
            };
            
            app.Contacts.ContactModification(1, contact);

        }
    }
}
