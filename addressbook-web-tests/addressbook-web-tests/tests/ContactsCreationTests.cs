using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts
                .CreateContact()
                .NameAndLastname(new ContactData("irina", "telegina"))
                .SubmitContact();
            app.Navigator.ReturnToHomePage();
        }
    }
}
