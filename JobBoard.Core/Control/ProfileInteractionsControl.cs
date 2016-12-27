using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Core.Entity;
using JobBoard.Data;

namespace JobBoard.Core
{
    public class ProfileInteractionsControl
    {
        ProfileInteractionsQuery query = ProfileInteractionsQuery.getInstace();
        static ProfileInteractionsControl instance;

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


    }
}
