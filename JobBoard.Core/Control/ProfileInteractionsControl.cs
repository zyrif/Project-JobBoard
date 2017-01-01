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

        public void UpdateSection(Experience exp)
        {
            query.UpdateSectionQuery(exp.Title,exp.Entity,exp.StartTime,exp.EndTime,exp.Details,exp.ExperienceId);
        }

        public void AddVacancy(int userId, Vacancy vac)
        {
            int empid = query.getCompanyId(vac.Company);
            query.AddVacancyQuery(vac.JobTitle, empid, userId, vac.Location, vac.PostedTime, vac.DeadLine, vac.MinimumSalary, vac.MaximumSalary, Convert.ToBoolean(vac.JobType), vac.JobSummary);

            int jobId = searchQuery.getjobId(vac.JobTitle, userId);

            foreach(string skill in vac.skillList)
            {
                query.addSkillListForJob(jobId, searchQuery.getSkillIdByName(skill));
            }
        }

        public void UpdateVacancy(Vacancy vac)
        {
            int empid = query.getCompanyId(vac.Company);
            query.UpdateVacancyQuery(vac.JobTitle, empid, vac.Recruiter.UserId, vac.Location, vac.PostedTime, vac.DeadLine, vac.MinimumSalary, vac.MaximumSalary, vac.JobType, vac.JobSummary, vac.getJobId());

            //Delete previous skills
            query.deleteSkillForJob(vac.JobId);
            //Add New skills
            foreach (string s in vac.skillList)
                query.addSkillListForJob(vac.JobId, searchQuery.getSkillIdByName(s));
        }

        public List<Experience> getExperienceList(int userId)
        {
            experienceList = new List<Experience>();
            Experience experience;
            dataTable = query.getUserExperience(userId);
            for(byte i=0; i<dataTable.Rows.Count; i++)
            {
                experience = new Experience(Convert.ToByte(dataTable.Rows[i]["exp_type"]),
                                            Convert.ToInt32(dataTable.Rows[i]["experience_id"]),
                                            dataTable.Rows[i]["title"].ToString(),
                                            dataTable.Rows[i]["entity"].ToString(),
                                            Convert.ToDateTime(dataTable.Rows[i]["start_time"].ToString()),
                                            Convert.ToDateTime(dataTable.Rows[i]["end_time"].ToString()),
                                            dataTable.Rows[i]["details"].ToString());
                experienceList.Add(experience);
            }
            return experienceList;
        }

        public List<Vacancy> getVacanciesPosted(User recruiter)
        {
            dataTable = query.getVacancy(recruiter.UserId);
            vacancyList = new List<Vacancy>();
            Vacancy vacancy;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                bool jType;
                jType = Convert.ToBoolean(dataTable.Rows[i]["job_type"]);

                vacancy = new Vacancy(dataTable.Rows[i]["job_title"].ToString(),
                                          Convert.ToInt32(dataTable.Rows[i]["job_id"]),
                                          searchQuery.getCompanyName(Convert.ToInt32(dataTable.Rows[i]["company_id"])).ToString(),
                                          User.getInstanceById(Convert.ToInt32(dataTable.Rows[i]["recruiter_id"])),
                                          dataTable.Rows[i]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[i]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[i]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["maximum_salary"].ToString()),
                                          jType,
                                          dataTable.Rows[i]["details"].ToString(),
                                          searchQuery.getSkillList(Convert.ToInt32(dataTable.Rows[i]["job_id"])));

                vacancyList.Add(vacancy);
            }
            
            return vacancyList;
        }

        public void DeleteExperience(User user, Experience exp)
        {
            query.DelExp(user.UserId, exp.Title);
        }

        public void DeleteVacancy(User user, Vacancy vacancy)
        {
            query.DelVac(user.UserId, vacancy.JobTitle, vacancy.Location);
        }

        public void LogOut()
        {
            Collections.clearInstance();
            User.clearInstance();
        }

        public void addApplication(Vacancy vacancy, User user)
        {
            query.writeApplication(vacancy.JobId, user.UserId);
        }

        public bool alreadyAddedApplication(Vacancy vacancy, User user)
        {
            dataTable = query.alreadyApplied(vacancy.JobId,user.UserId);
            if (dataTable != null)
                return true;
            else
                return false;
        }
    }
}
