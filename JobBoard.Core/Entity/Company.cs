using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    public class Company
    {
        static Company instance;

        public string Name { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public byte BusinessType { set; get; }
        enum EBusinessType:byte
        {
            Small,
            Medium,
            Large,
            International
        }
        public Company(string name,string address,string country,string phone,string email,string website,byte businessType)
        {
            this.Name = name;
            this.Address = address;
            this.Country = country;
            this.Phone = phone;
            this.Email = email;
            this.Website = website;
            this.BusinessType = businessType;
        }

        public Company(int userId)
        {
            
        }

        public Company()
        {

        }

        public static Company getInstance()
        {
            if (instance == null)
                instance = new Company();

            return instance;
        }

        public static void clearInstance()
        {
            instance = null;
        }


    }
}
