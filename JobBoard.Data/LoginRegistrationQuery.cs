﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class LoginRegistrationQuery
    {
        DBReadWrite dbReadWrite = new DBReadWrite();
        DataTable dataTable;
        string query;

        public bool getUser(string userName, string passWord)
        {
            query = "select * from LoginInfo where username ='" + userName.Trim() + "' and password='" + passWord.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;
            
            return false;
        }

        public bool getUser(string userName)
        {
            query = "select * from login_info where user_name ='" + userName.Trim()+"'";
            dataTable = dbReadWrite.selectQuery(query);

            if (dataTable.Rows.Count == 1)
                return true;

            return false;
        }

        public DataTable getUserInfo(string userName)
        {
            query = "select * from UserDetail where UserName ='" + userName + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
        
        public DataTable getSkill(string userName)
        {
            query = "select * from Skill where UserName ='" + userName+"'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
        
        //Registration Portion
        public void createUser(string userName, string passWord)
        {
            query = "INSERT INTO login_info VALUES ('" + userName + "', '"+ passWord + "')";
            dbReadWrite.insertQuery(query);
        }

        public void writeCommonUserInfo(string userName, string firstName, string lastName, string email, string phoneNumber, byte userType)
        {
            query = "INSERT INTO UserDetail (UserName, FirstName, LastName, Email, Phone, UserType) VALUES('" + userName.Trim() + "','" + firstName.Trim() + "','" + lastName.Trim() + "','" + email.Trim() + "','" + phoneNumber.Trim() + "'," + userType + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeBirthDay(string userName, DateTime birthDay)
        {
            query = "INSERT INTO JobSeeker VALUES('" + userName.Trim() +"'," + birthDay + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeSkill(string userName, string skill)
        {
            query = "INSERT INTO Skill VALUES('" + userName.Trim() + "','" + skill.Trim() + "')";
            dbReadWrite.insertQuery(query);
        }

        public void writeAdditionalEmployerInfo(string userName, string jobPosition, int companyId)
        {
            query = "INSERT INTO EmployerInfo VALUES ('" + userName.Trim() + "','" + jobPosition.Trim() + "'," + companyId + ")";
            dbReadWrite.insertQuery(query);
        }

        public void writeCompanyInfo(string companyName, string address, short countryCode, string phone, string email, string website, byte businessType, int companyId)
        {
            query = "INSERT INTO Company VALUES ('" + companyName.Trim() + "','" + address.Trim() + "','" + countryCode + ",'"+ phone.Trim() + "','" + email.Trim() + "','" + website.Trim() + "'," + businessType + companyId + ")";
            dbReadWrite.insertQuery(query);
        }
    }
}
