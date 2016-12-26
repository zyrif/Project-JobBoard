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
        string query, subQuery;

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


    }
}
