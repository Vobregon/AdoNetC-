using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Adonet01.DataBase
{
    public class AccesoDB
    {
        public static SqlConnection getConnection()
        {
            SqlConnection cn = new SqlConnection("server=.;database=Neptuno;integrated security=true");
            return cn;
        }
    }
}
