using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Profile
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public Profile() { }

        public Profile(Gender gender, int age, string emailAddress, string phoneNo)
        {
            Gender = gender;
            Age = age;
            ContactInfo = new ContactInfo
            {
                EmailAddress = emailAddress,
                PhoneNo = phoneNo
            };
        }
    }

    public class ContactInfo
    {
        public string EmailAddress { get; set; }

        public string PhoneNo { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }


}
