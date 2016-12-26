using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;

namespace JobBoard.Core
{
    public class User
    {
        static User instance;

        public List<string> skillList = new List<string>();

        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public byte UserType { get; set; }
        public enum UserTypeName : byte
        {
            JobSeeker,
            Employer
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Image Photo { get; set; }
        public bool IsVerified { get; set; }

        //Jobseeker only fields
        public DateTime BirthDay{ get; set; }
        public string Location { get; set; }

        public void setSkill(string skill)
        {
            skillList.Add(skill);
        }

        public List<string> getSkillList()
        {
            return skillList;
        }

        //Recruiter only fields
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }

        public User() { }

        public void addUser(string firstName, string lastName, string email, string phNumber, Image photo, DateTime birthday, string location, List<string> skilllist)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
            this.Photo = photo;
            this.BirthDay = birthday;
            this.Location = location;
            this.skillList = skilllist;
        }

        public void addUser(string firstName, string lastName, string email, string phNumber, Image photo, string jobposition, string companyname)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
            this.Photo = photo;
            this.JobPosition = jobposition;
            this.CompanyName = companyname;
            
        }

        public static User getInstance()
        {
            if (instance == null)
                instance = new User();
            return instance;
        }
    }
}
