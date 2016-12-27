using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Core.Entity;
using JobBoard.Data;
using System.Data;

namespace JobBoard.Core
{
    public class ProfileInteractionsControl
    {
        ProfileInteractionsQuery query = ProfileInteractionsQuery.getInstace();
        SearchQuery searchQuery = SearchQuery.getInstance();
        static ProfileInteractionsControl instance;
        DataTable dataTable = new DataTable();
        List<Experience> experienceList;
        List<Vacancy> vacancyList;

        private ProfileInteractionsControl()
        {

        }

        public static ProfileInteractionsControl getInstance()
        {
            if (instance == null)
                instance = new ProfileInteractionsControl();
            return instance;
        }

        public void AddSection(int userId, Experience exp)
        {
            query.AddSectionQuery(userId, exp.ExpType, exp.Title, exp.Entity, exp.StartTime, exp.EndTime, exp.Details);
        }

        public void AddVacancy(int userId, Vacancy vac)
        {
            int empid = query.getCompanyId(vac.Company);
            query.AddVacancyQuery(vac.JobTitle, empid, userId, vac.Location, vac.PostedTime, vac.DeadLine, vac.MinimumSalary, vac.MaximumSalary, vac.JobType, vac.JobSummary);
        }

        public List<Experience> getExperienceList(int userId)
        {
            experienceList = new List<Experience>();
            Experience experience;
            dataTable = query.getUserExperience(userId);
            for(byte i=0; i<dataTable.Rows.Count; i++)
            {
                experience = new Experience(Convert.ToByte(dataTable.Rows[i]["exp_type"]),
                                            dataTable.Rows[i]["title"].ToString(),
                                            dataTable.Rows[i]["entity"].ToString(),
                                            Convert.ToDateTime(dataTable.Rows[i]["start_time"].ToString()),
                                            Convert.ToDateTime(dataTable.Rows[i]["end_time"].ToString()),
                                            dataTable.Rows[i]["details"].ToString());
                experienceList.Add(experience);
            }

            return experienceList;
        }

        public List<Vacancy> getVacanciesPosted(int jobId)
        {
            dataTable = query.getVacancy(jobId);
            Vacancy vacancy;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                vacancy = new Vacancy(dataTable.Rows[0]["job_title"].ToString(),
                                          searchQuery.getCompanyName(Convert.ToInt32(dataTable.Rows[0]["company_id"])).ToString(),
                                          searchQuery.getRecruiterName(Convert.ToInt32(dataTable.Rows[0]["recruiter_id"])).ToString(),
                                          dataTable.Rows[0]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[0]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[0]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[0]["maximum_salary"].ToString()),
                                          Convert.ToBoolean(dataTable.Rows[0]["job_type"].ToString()),
                                          searchQuery.getSkillList(Convert.ToInt32(dataTable.Rows[0]["job_id"])));

                vacancyList.Add(vacancy);
            }

            return vacancyList;
        }
    }
}
