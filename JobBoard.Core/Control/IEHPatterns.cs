using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace JobBoard.Core.Control
{
    public class IEHPatterns
    {
        private static IEHPatterns instance;

        public static string EmailPattern { set; get; }

        private IEHPatterns()
        {
            
        }

        public static IEHPatterns getInstance()
        {
            if (instance == null)
                instance = new IEHPatterns();

            return instance;   
        }

        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool isPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{13})$").Success;
        }
    }
}
