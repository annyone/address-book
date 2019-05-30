using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace address_book_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails, allPhones;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
            return "Firstname=" + Firstname + " Lastname=" + Lastname;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Homephone { get; set; }

        public string Mobilephone { get; set; }

        public string Workphone { get; set; }

        public string Fax { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Homeaddress { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

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
                    return (Clean(Homephone + "\r\n" + Mobilephone + "\r\n" + Workphone)).Trim();
                }

            }

            set
            {
                allPhones = value;
            }
        }

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
                    return (Email1 + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                }
            }

            set
            {
                allEmails = value;
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
    }
}
