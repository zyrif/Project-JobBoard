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

        public DataTable getUserInstance(int id)
        {
            query = "select * from user_info where user_id=" +id;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public int getjobId(string jobTitle, int userId)
        {
            query = "select job_id from job_info where job_title='" + jobTitle + "' and recruiter_id=" + userId;
            dataTable = dbReadWrite.selectQuery(query);

            return Convert.ToInt32(dataTable.Rows[0]["job_id"]);
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

        public string getCandidateName(int candidateId)
        {
            query = "select user_name from user_info where user_id=" + candidateId;
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable.Rows[0]["user_name"].ToString();
        }

        public List<string> getSkillList(int jobId)
        {
            List<string> skillList = new List<string>();
            query = "select skill from skill_list where skill_id in(select skill_id from user_skill where job_id=" + jobId + ")";
            dataTable = dbReadWrite.selectQuery(query);

            for(byte i=0; i<dataTable.Rows.Count; i++)
            {
                skillList.Add(dataTable.Rows[i]["skill"].ToString());
            }
            return skillList;
        }

        public int getSkillIdByName(string skill)
        {
            query = "select skill_id from skill_list where skill='"+skill+"'";
            dataTable = dbReadWrite.selectQuery(query);

            return Convert.ToInt32(dataTable.Rows[0]["skill_id"]);
        }

        public List<int> getSkillListOfCandidates(int candidateId)
        {
            List<int> skillList = new List<int>();

            query = "select skill_id from user_skill where user_id=" + candidateId;
            dataTable = dbReadWrite.selectQuery(query);

            for (byte i = 0; i < dataTable.Rows.Count; i++)
            {
                skillList.Add(Convert.ToInt32(dataTable.Rows[i]["skill_id"]));
            }

            return skillList;
        }

        public string getSkillById(int skillId)
        {
            query = "select skill from skill_list where skill_id=" + skillId;
            return dbReadWrite.selectQuery(query).Rows[0]["skill"].ToString();
        }

        public DataTable search(string jobTitle, string companyName, string location, double minimumSalary, double maximumSalary, bool jobType)
        {
            query = "select * from job_info where ";

            if (jobTitle != "")
                query += "job_title = '" + jobTitle + "' and ";
            if (companyName != "")
            {
                subQuery = "(select company_id from company_info where company_name ='" + companyName + "')";
                query += "company_id =" + subQuery + " and ";
            }
            if (location != "")
                query += "location = '" + location + "' and ";
            if (minimumSalary != 0)
            {
                query += "(minimum_salary <= " + minimumSalary + " and maximum_salary >=" + minimumSalary + ") or (minimum_salary <= " + maximumSalary + " and maximum_salary >=" + maximumSalary + ") and ";
            }
            query += "job_type = " + Convert.ToByte(jobType);

            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getJobTitles()
        {
            query = "select distinct job_title from job_info";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getEmployers()
        {
            query = "select company_name from company_info where company_id in(select distinct company_id from job_info)";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getLocations()
        {
            query = "select distinct location from job_info";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }

        public DataTable getCandidateByLocation(string location)
        {
            query = "select user_id from user_info where location = '"+location+"'";
            dataTable = dbReadWrite.selectQuery(query);

            return dataTable;
        }
    }
}
