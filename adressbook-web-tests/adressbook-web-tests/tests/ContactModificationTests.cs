﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int index = 0;
            PropertiesContact newData = new PropertiesContact("Dilya3", "Shafigullina3");

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 0) && (!app.Contacts.IsExist(index)))
            {
                app.Contacts.Create(new PropertiesContact("AutoCreated", "AutoCreated"));
            }

            //Если правим контакт, которого нет, то тест должен провалиться
            Assert.IsTrue(app.Contacts.IsExist(index));

            List<PropertiesContact> oldContacts = PropertiesContact.GetAll();
            PropertiesContact oldData = oldContacts[index];
            app.Contacts.Modify(oldData, newData);

            List<PropertiesContact> newContacts = PropertiesContact.GetAll();

            oldContacts[index].Firstname = newData.Firstname;
            oldContacts[index].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            //Допонительная проверка по id
            foreach (PropertiesContact contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.IsTrue(newData.Equals(contact));
                    //Assert.AreEqual(newData.Firstname, contact.Firstname);
                    //Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}