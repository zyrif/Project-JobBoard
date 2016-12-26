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
        PostedJob postedJob;
        List<PostedJob> postedJobList;
        SearchQuery query;
        DataTable dataTable;

        public List<PostedJob> search(string jobTitle, double minimumSalary, double maximumSalary, bool jobType, string companyName, string location, List<string> skills)
        {
            dataTable = query.search(jobTitle, minimumSalary, maximumSalary, jobType, companyName, location, skills);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                postedJob = new PostedJob(dataTable.Rows[i]["job_title"].ToString(),
                                          query.getCompanyName(Convert.ToInt32(dataTable.Rows[i]["company_id"])).ToString(),
                                          query.getRecruiterName(Convert.ToInt32(dataTable.Rows[i]["recruiter_id"])).ToString(),
                                          dataTable.Rows[i]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[i]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[i]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["maximum_salary"].ToString()),
                                          Convert.ToBoolean(dataTable.Rows[i]["job_type"].ToString()),
                                          query.getSkillList(Convert.ToInt32(dataTable.Rows[i]["job_id"])));

                postedJobList.Add(postedJob);
            }

            return postedJobList;
        }
    }
}
