using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests.tests
{
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void GontactRemovealTest()
        {
            if (app.Contacts.AvailabilityOfContacts() == false)
            {
                ContactData contact = new ContactData("Irina", "Telegina");
                app.Contacts.AddNewContact(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
