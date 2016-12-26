using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data
{
    public class SearchQuery
    {
        DBReadWrite dbReadWrite;
        DataTable dataTable;
        static SearchQuery instance;
        string query, subQuery;

        private SearchQuery()
        {
            dbReadWrite = DBReadWrite.getInstance();
        }

        public static SearchQuery getInstance()
        {
            if (instance == null)
                instance = new SearchQuery();

            return instance;
        }

        public string getCompanyName(int companyId)
        {
            query = "select company_name from company_info where company_id="+companyId;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable.Rows[0]["company_name"].ToString();
        }

        public string getRecruiterName(int recruiterId)
        {
            query = "select user_name from user_info where user_id="+recruiterId;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable.Rows[0]["user_name"].ToString();
        }

        public List<string> getSkillList(int jobId)
        {
            List<string> skillList = new List<string>();

            query = "select skill from user_skill where job_id="+jobId;
            dataTable = dbReadWrite.selectQuery(query);

            for(byte i=0; i<dataTable.Rows.Count; i++)
            {
                skillList.Add(dataTable.Rows[i]["skill"].ToString());
            }

            return skillList;
        }

        public DataTable search(string jobTitle, double minimumSalary, double maximumSalary, bool jobType, string companyName,string location,List<string> skills)
        {
            subQuery = "(select company_id from company_info where company_name ='"+ companyName +"')";
            query = "select * from job_info where job_title='" + jobTitle + "' and company_id =" + subQuery + " and location = '" + location + "' and minimum_salary >= " + minimumSalary + " and maximum_salary <= " + maximumSalary + " and job_type = " + jobType;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
    }
}
