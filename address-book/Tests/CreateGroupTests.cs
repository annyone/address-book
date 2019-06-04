using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(50)
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateGroupTest()
        {
            GroupData group = new GroupData("a", "b", "c");

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void CreateGroupTestWithBadName()
        {
            GroupData group = new GroupData("a'a", "", "");

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
