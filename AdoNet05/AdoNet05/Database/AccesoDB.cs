using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNet05.Database
{
    public class AccesoDB
    {
        public static SqlConnection getConnection()
        {
            try
            {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["factura"].ConnectionString);
            return cn;
            }
            catch (SqlException ex)
            {                
                throw ex;
            }           
        }
    }
}
