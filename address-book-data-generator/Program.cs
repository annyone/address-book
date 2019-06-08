using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using address_book_tests;

namespace address_book_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                if (dataType == "groups")
                {   
                    groups.Add(new GroupData(TestBase.GenerateRandomString(5))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(5)
                    });
                }
                else if (dataType == "contacts")
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(5), TestBase.GenerateRandomString(5))
                    {
                        Address = TestBase.GenerateRandomString(15),
                        Homephone = Convert.ToString(TestBase.rnd.Next(00000, 29999)),
                        Mobilephone = Convert.ToString(TestBase.rnd.Next(30000, 59999)),
                        Workphone = Convert.ToString(TestBase.rnd.Next(60000, 79999)),
                        Fax = Convert.ToString(TestBase.rnd.Next(80000, 99999)),
                        Email1 = TestBase.GenerateRandomString(5) + "@" + TestBase.GenerateRandomString(5),
                        Email2 = TestBase.GenerateRandomString(5) + "@" + TestBase.GenerateRandomString(5),
                        Email3 = TestBase.GenerateRandomString(5) + "@" + TestBase.GenerateRandomString(5)
                    });
                }
                else
                {
                    System.Console.Out.Write("Bad data type:" + dataType);
                }
            }

            if(format == "csv")
            {
                WriteGroupDataToCsvFile(groups, writer);
                WriteContactDataToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                WriteGroupDataToXmlFile(groups, writer);
                WriteContactDataToXmlFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Bad format:" + format);
            }

            writer.Close();
        }

        static  void WriteGroupDataToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},{1},{2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupDataToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteContactDataToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},{1}",
                    contact.Firstname, contact.Lastname));
            }
        }

        static void WriteContactDataToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);

        }
    }
}
