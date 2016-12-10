using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace JobBoard.Core
{
    class User
    {
        public static User currentUser;
        public enum UserType: byte
        {
            JobSeeker,
            Employer
        }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public User() { }

        public User(string username,string userpass,string firstName,string lastName,string email,string phNumber)
        {
            this.UserName = username;
            this.UserPassword = userpass;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
        }
    }
}
