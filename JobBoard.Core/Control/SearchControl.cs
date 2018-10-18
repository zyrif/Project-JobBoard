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
        LoginRegistrationControl lrControl = LoginRegistrationControl.getInstance();

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

                postedJob = new Vacancy(dataTable.Rows[i]["job_title"].ToString(),
                                          Convert.ToInt32(dataTable.Rows[i]["job_id"]),

                                          query.getCompanyName(Convert.ToInt32(dataTable.Rows[i]["company_id"])),
                                          User.getInstanceById(Convert.ToInt32(dataTable.Rows[i]["recruiter_id"])),
                                          dataTable.Rows[i]["location"].ToString(),
                                          Convert.ToDateTime(dataTable.Rows[i]["posted_time"].ToString()),
                                          Convert.ToDateTime(dataTable.Rows[i]["dead_line"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["minimum_salary"].ToString()),
                                          Convert.ToDouble(dataTable.Rows[i]["maximum_salary"].ToString()),
                                          jType,
                                          dataTable.Rows[i]["details"].ToString(),
                                          query.getSkillList(Convert.ToInt32(dataTable.Rows[i]["job_id"])));

                
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

        public List<User> candidateSearch(int jobId)
        {
            dataTable = query.getCandidateAppliedInJob(jobId);
            List<User> candidateList = new List<User>();
            for (int i=0; i<dataTable.Rows.Count; i++)
                candidateList.Add(lrControl.GetJobSeekerInfo(query.getCandidateName(Convert.ToInt32(dataTable.Rows[i]["user_id"]))));

            return candidateList;
        }

        public List<User> candidateSearch(List<string> jobSkills, string location)
        {
            List<int> jSkillIdList = new List<int>();                                                   
            List<int> userList = new List<int>();
            List<int> userSkills;

            //initialize required skill id for a job
            foreach(string skill in jobSkills)
            {
                jSkillIdList.Add(query.getSkillIdByName(skill));
            }

            //suggested candidates by nearest location
            dataTable = query.getCandidateByLocation(location);
            for(int i=0; i<dataTable.Rows.Count; i++)
            {
                userList.Add(Convert.ToInt32(dataTable.Rows[i]["user_id"]));
            }
            
            //Compare required skill with users skill
            List< KeyValuePair < int, int>> candidateIdList = new List<KeyValuePair<int, int>>();
            foreach (int user in userList)
            {
                userSkills = query.getSkillListOfCandidates(user);

                int skillMatch = 0;
                foreach (int uSkill in userSkills)
                {
                    foreach(int jSkill in jSkillIdList)
                    {
                        if(uSkill == jSkill)
                        {
                            skillMatch++;
                        }
                    }
                }
                if(skillMatch>0)
                    candidateIdList.Add(new KeyValuePair<int, int>(user,skillMatch));
            }
            
            //sort candidates matching with skills
            candidateIdList.Sort((x, y) => -1* x.Value.CompareTo(y.Value));
            
            List<User> candidateList = new List<User>();
            foreach(KeyValuePair<int,int> candidate in candidateIdList)
            {
                candidateList.Add(lrControl.GetJobSeekerInfo(query.getCandidateName(candidate.Key)));
            }

            return candidateList;
        }

        public List<string> getSkillListByUserId(int userId)
        {
            List<int> skillList = query.getSkillListOfCandidates(userId);
            List<string> skillNameList = new List<string>();
            foreach (int skillId in skillList)
            {
                skillNameList.Add(query.getSkillById(skillId));
            }
            return skillNameList;
        }
    }
}
