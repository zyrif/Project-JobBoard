using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace JobBoard.Core
{
    public class User
    {
        static User instance;

        public List<string> SkillList = new List<string>();

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
        public BitmapImage Photo { get; set; }
        public bool IsVerified { get; set; }

        //Jobseeker only fields
        public DateTime BirthDay{ get; set; }
        public string Location { get; set; }

        public void setSkill(string skill)
        {
            SkillList.Add(skill);
        }

        public List<string> getSkillList()
        {
            return SkillList;
        }

        private void initSkills()
        {

        }

        //Recruiter only fields
        public string JobPosition { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }

        public User() { }

        public void addUser(string firstName, string lastName, string email, string phNumber, BitmapImage photo, DateTime birthday, string location, List<string> skilllist)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
            this.Photo = photo;
            this.BirthDay = birthday;
            this.Location = location;
            this.SkillList = skilllist;
        }

        public void addUser(string firstName, string lastName, string email, string phNumber, BitmapImage photo, string jobposition, string companyname)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
            this.Photo = photo;
            this.JobPosition = jobposition;
            this.CompanyName = companyname;
            
        }

        public void addUser(string firstName, string lastName, string email, string phNumber, BitmapImage photo, string jobposition)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phNumber;
            this.Photo = photo;
            this.JobPosition = jobposition;
        }

        public static User getInstance()
        {
            if (instance == null)
                instance = new User();
            return instance;
        }

        public static User getInstanceById(int userId)
        {
            User recruiter = new User();
            System.Data.DataTable dataTable = Data.SearchQuery.getInstance().getUserInstance(userId);

            recruiter.UserName = dataTable.Rows[0]["user_name"].ToString();
            recruiter.UserId = userId;
            recruiter.UserType = Convert.ToByte(dataTable.Rows[0]["user_type"]);
            recruiter.FirstName = dataTable.Rows[0]["first_name"].ToString();
            recruiter.LastName = dataTable.Rows[0]["last_name"].ToString();
            recruiter.Email = dataTable.Rows[0]["email"].ToString();
            recruiter.PhoneNumber = dataTable.Rows[0]["phone"].ToString();
            recruiter.Location = dataTable.Rows[0]["location"].ToString();

            return recruiter;
        }

        public static void clearInstance()
        {
            instance = null;
        }
    }
}
