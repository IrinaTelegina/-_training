using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.AvailabilityOfGroups() == false)
            {
                GroupData group = new GroupData("newGroup");
                group.Header = "111";
                group.Footer = "222";
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = app.Groups.GetGroupList(); //список групп до добавления новой


            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            //Список объектов типа GroupData после добавления новой группы
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups); //сравнение двух списков
        }

    }
}
