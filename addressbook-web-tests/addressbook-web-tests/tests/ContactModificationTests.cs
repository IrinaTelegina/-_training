using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests.tests
{
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.AvailabilityOfContacts() == false)
            {
                ContactData contact = new ContactData("Irina", "Telegina");
                app.Contacts.AddNewContact(contact);
            }
            ContactData newData = new ContactData("Irina123", "Telegina123");
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Modify(0, newData);
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}