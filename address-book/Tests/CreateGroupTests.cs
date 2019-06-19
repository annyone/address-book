using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace address_book_tests
{
    [TestFixture]
    public class CreateGroupTests : GroupTestBase
    {
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"group.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0], parts[1], parts[2]));
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"group.xml"));

        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"group.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void CreateGroupTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Create(group);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


        [Test]
        public void CreateGroupTestWithBadName()
        {
            GroupData group = new GroupData("a'a", "", "");

            List<GroupData> oldGroups = GroupData.GetAllFromDB();
            app.Groups.Create(group);
            List<GroupData> newGroups = GroupData.GetAllFromDB();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
