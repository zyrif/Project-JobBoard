using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Data;

namespace JobBoard.Core.Control
{
    public class DBConnectionControl
    {
        public DBConnectionControl()
        {
            DBReadWrite dbReadWrite = new DBReadWrite();
            //dbReadWrite.createConnection();
        }
    }
}
