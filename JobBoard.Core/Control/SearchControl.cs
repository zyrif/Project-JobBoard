using JobBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Data;
using System.Data;

namespace JobBoard.Core.Control
{
    public class SearchControl
    {
        Vacancy postedJob;
        List<Vacancy> postedJobList;
        SearchQuery query = SearchQuery.getInstance();
        DataTable dataTable;

        public List<Vacancy> search(string jobTitle, string companyName, string location, string salaryBracket, string jobType)
        {
            double minimumSalary = 0, maximumSalary = 0;
            postedJobList = new List<Vacancy>();
            if (salaryBracket != "")
            {
                string[] salary = salaryBracket.Split('-');
                minimumSalary = Convert.ToDouble(salary[0]);
                maximumSalary = Convert.ToDouble(salary[1]);
            }

            bool jType;
            if (jobType == "Temporary") { jType = false; }
            else { jType = true; }

            dataTable = query.search(jobTitle, companyName, location, minimumSalary, maximumSalary, jType);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                postedJob = new Vacancy(dataTable.Rows[0]["job_title"].ToString(),
                                          query.getCompanyName(Convert.ToInt32(dataTable.Rows[i]["company_id"])),
                                          query.getRecruiterName(Convert.ToInt32(dataTable.Rows[i]["recruiter_id"])),
                                          dataTable.Rows[0]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[0]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[0]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["maximum_salary"].ToString()),
                                          jType,
                                          dataTable.Rows[i]["details"].ToString(),
                                          query.getSkillList(Convert.ToInt32(dataTable.Rows[0]["job_id"])));

                postedJobList.Add(postedJob);
            }

            return postedJobList;
        }

        public List<string> getJobTitleList()
        {
            List<string> list = new List<string>();
            dataTable = query.getJobTitles();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(dataTable.Rows[i]["job_title"].ToString());
            }

            return list;
        }

        public List<string> getEmployerList()
        {
            List<string> list = new List<string>();
            dataTable = query.getEmployers();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(dataTable.Rows[i]["company_name"].ToString());
            }

            return list;
        }

        public List<string> getLocationList()
        {
            List<string> list = new List<string>();
            dataTable = query.getLocations();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                list.Add(dataTable.Rows[i]["location"].ToString());
            }

            return list;
        }
    }
}
