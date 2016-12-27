using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class ProfileInteractionsQuery
    {
        DBReadWrite dbReadWrite = DBReadWrite.getInstance();
        DataTable dataTable;
        static ProfileInteractionsQuery instance;
        string query;

        private ProfileInteractionsQuery()
        {

        }

        public static ProfileInteractionsQuery getInstace()
        {
            if (instance == null)
                instance = new ProfileInteractionsQuery();
            return instance;
        }

        public void AddSectionQuery(int userid, byte exptype, string title, string entity, DateTime sttime, DateTime edtime, string details)
        {
            query = "INSERT INTO  user_experience (user_id, exp_type, title, entity, start_time, end_time, details) VALUES (" + userid + ", " + exptype + ", '" + title + "','" + entity + "', '" + sttime.ToString("yyyy-MM-dd") + "', '" + edtime.ToString("yyyy-MM-dd") + "', '" + details + "')";
            dbReadWrite.insertQuery(query);
        }

        public void AddVacancyQuery(string title, int empid, int userid, string location, DateTime posttime, DateTime deadline, Double minsalary, Double maxsalary, string jobtype, string details)
        {
            query = "INSERT INTO job_info (job_title, company_id, recruiter_id, location, posted_time, dead_line, minimum_salary, maximum_salary, job_type, details) VALUES ('" + title + "', " + empid + ", " + userid + ", '" + location + "', '" + posttime.ToString("yyyy-MM-dd") + "', '" + deadline.ToString("yyyy-MM-dd") + "', " + minsalary + ", " + maxsalary + ", '" + jobtype + "', '" + details + "')";
            dbReadWrite.insertQuery(query);
        }

        public int getCompanyId(string companyName)
        {
            query = "select company_id from company_info where company_name ='" + companyName.Trim() + "'";
            dataTable = dbReadWrite.selectQuery(query);

            return Convert.ToInt32(dataTable.Rows[0]["company_id"]);
        }

        public DataTable getUserExperience(int userId)
        {
            query = "select * from user_experience where user_id="+userId +" order by exp_type";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getVacancy(int userId)
        {
            query = "select * from job_info where recruiter_id=" + userId + " and dead_line >='" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by dead_line";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
    }
}
