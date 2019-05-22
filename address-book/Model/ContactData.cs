using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname, middlename, lastname, nickname, title, company, workaddress, 
            homephone, mobilephone, workphone, fax, email1, email2, email3, homepage, bday, 
            bmonth, byear, aday, amonth, ayear, homeaddress, phone2, notes;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Workaddress
        {
            get { return workaddress; }
            set { workaddress = value; }
        }
        public string Homephone
        {
            get { return homephone; }
            set { homephone = value; }
        }
        public string Mobilephone
        {
            get { return mobilephone; }
            set { mobilephone = value; }
        }
        public string Workphone
        {
            get { return workphone; }
            set { workphone = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Email1
        {
            get { return email1; }
            set { email1 = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }
        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }
        public string Bday
        {
            get { return bday; }
            set { bday = value; }
        }
        public string Bmonth
        {
            get { return bmonth; }
            set { bmonth = value; }
        }
        public string Byear
        {
            get { return byear; }
            set { byear = value; }
        }
        public string Aday
        {
            get { return aday; }
            set { aday = value; }
        }
        public string Amonth
        {
            get { return amonth; }
            set { amonth = value; }
        }
        public string Ayear
        {
            get { return ayear; }
            set { ayear = value; }
        }
        public string Homeaddress
        {
            get { return homeaddress; }
            set { homeaddress = value; }
        }
        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname)==0)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return 0;
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

            return Firstname == other.Firstname;
        }
    }
}
