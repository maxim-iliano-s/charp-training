using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string email = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string address2 = "";
        private string notes = "";


        public ContactData() {}

        public ContactData(string firstname)
        {
            this.firstname = null;
        }

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public ContactData(string firstname, string lastname, string adress, string email, string mobile)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = adress;
            this.email = email;
            this.mobile = mobile;
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

            if (Firstname == other.Firstname)
                if (Lastname != other.Lastname)
                {
                    return false;
                }
            return false;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname: " + Firstname + " ; Lastname: " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Firstname.CompareTo(other.Firstname) == 0)
                return Lastname.CompareTo(other.Lastname);
            else
                return Firstname.CompareTo(other.Firstname);
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string Homepage { get => homepage; set => homepage = value; }
        public string Bmonth { get => bmonth; set => bmonth = value; }
        public string Bday { get => bday; set => bday = value; }
        public string Byear { get => byear; set => byear = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string Notes { get => notes; set => notes = value; }
        public string Home { get => home; set => home = value; }
        public string Company { get => company; set => company = value; }
        public string Company1 { get => company; set => company = value; }
        public string Title { get => title; set => title = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
    }
}