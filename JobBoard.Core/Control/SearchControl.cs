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
    class SearchControl
    {
        Vacancy postedJob;
        List<Vacancy> postedJobList;
        SearchQuery query;
        DataTable dataTable;

        public List<Vacancy> search(string jobTitle, double minimumSalary, double maximumSalary, bool jobType, string companyName, string location, List<string> skills)
        {
            dataTable = query.search(jobTitle, minimumSalary, maximumSalary, jobType, companyName, location, skills);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                postedJob = new Vacancy(dataTable.Rows[0]["job_title"].ToString(),
                                          query.getCompanyName(Convert.ToInt32(dataTable.Rows[0]["company_id"])).ToString(),
                                          query.getRecruiterName(Convert.ToInt32(dataTable.Rows[0]["recruiter_id"])).ToString(),
                                          dataTable.Rows[0]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[0]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[0]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["maximum_salary"].ToString()),
                                          Convert.ToBoolean(dataTable.Rows[0]["job_type"].ToString()),
                                          query.getSkillList(Convert.ToInt32(dataTable.Rows[0]["job_id"])));

                postedJobList.Add(postedJob);
            }

            return postedJobList;
        }
    }
}
