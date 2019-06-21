using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using LinqToDB.Mapping;

namespace address_book_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails, allPhones, detailsInfo;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string detailsinfo)
        {
            DetailsInfo = detailsinfo;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if ((Lastname == other.Lastname) && (Firstname == other.Firstname))
            {
                return true;
            }

            return false;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            if (Lastname.CompareTo(other.Lastname) > 0)
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) < 0)
            {
                return -1;
            }

            return 0;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Lastname=" + Lastname + "\r"
                + "Firstname=" + Firstname + "\r"
                + "Address=" + Address + "\r"
                + "Homephone=" + Homephone + "\r"
                + "Mobilephone=" + Mobilephone + "\r"
                + "Workphone=" + Workphone + "\r"
                + "Email1=" + Email1 + "\r"
                + "Email2=" + Email2 + "\r"
                + "Email3=" + Email3;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Homephone { get; set; }

        [Column(Name = "mobile")]
        public string Mobilephone { get; set; }

        [Column(Name = "work")]
        public string Workphone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "address2")]
        public string Homeaddress { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [XmlIgnore, JsonIgnore]
        public string AllPhones
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    allPhones = "";

                    if(Homephone != "")
                    {
                        allPhones += Homephone + "\r\n";
                    }

                    if (Mobilephone != "")
                    {
                        allPhones += Mobilephone + "\r\n";
                    }

                    if (Workphone != "")
                    {
                        allPhones += Workphone + "\r\n";
                    }

                    return (Clean(allPhones)).Trim();
                }

            }

            set
            {
                allPhones = value;
            }
        }

        [XmlIgnore, JsonIgnore]
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    allEmails = "";

                    if (Email1 != "")
                    {
                        allEmails += Email1 + "\r\n";
                    }

                    if (Email2 != "")
                    {
                        allEmails += Email2 + "\r\n";
                    }

                    if (Email3 != "")
                    {
                        allEmails += Email3 + "\r\n";
                    }

                    return (allEmails).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        [XmlIgnore, JsonIgnore]
        public string DetailsInfo
        {
            get
            {
                if (detailsInfo != null)
                {
                    return detailsInfo;
                }
                else
                {
                    detailsInfo = "";

                    if (Firstname != "")
                    {
                        detailsInfo += Firstname + " ";
                    }

                    if (Lastname != "")
                    {
                        detailsInfo += Lastname + "\r\n";
                    }

                    if (Address != "")
                    {
                        detailsInfo += Address + "\r\n\r\n";
                    }

                    if (Homephone !="" )
                    {
                        detailsInfo += "H: " + Clean(Homephone) + "\r\n";
                    }
                    
                    if (Mobilephone != "")
                    {
                        detailsInfo += "M: " + Clean(Mobilephone) + "\r\n";
                    }

                    if (Workphone != "")
                    {
                        detailsInfo += "W: " + Clean(Workphone) + "\r\n";
                    }

                    if (Fax != "")
                    {
                        detailsInfo += "F: " + Clean(Fax) + "\r\n\r\n";
                    }

                    if (Email1 != "")
                    {
                        detailsInfo += Email1 + "\r\n";
                    }

                    if (Email2 != "")
                    {
                        detailsInfo += Email2 + "\r\n";
                    }

                    if (Email3 != "")
                    {
                        detailsInfo += Email3 + "\r\n";
                    }

                    return detailsInfo.Trim();
                }
            }

            set
            {
                detailsInfo = value;
            }
        }

        private string Clean(string phone)
        {
            if(phone == "" || phone == null)
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[ -()]", "");
            }
        }

        public static List<ContactData> GetAllFromDB()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }

        }
    }
}
