using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Core
{
    class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        enum BusinessType:byte
        {
            Small,
            Medium,
            Large,
            International
        }
        public Company(string name,string address,string country,string phone,string email,string website)
        {
            this.Name = name;
            this.Address = address;
            this.Country = country;
            this.Phone = phone;
            this.Email = email;
            this.Website = website;
        }

    }
}
