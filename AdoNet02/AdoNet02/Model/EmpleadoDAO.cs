using AdoNet02.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet02.DataBase;
using System.Data.SqlClient;

namespace AdoNet02.Model
{
    public class EmpleadoDAO
    {

        public List<EmpleadoDTO> ListaEmpleados()
        {
            List<EmpleadoDTO> lista = new List<EmpleadoDTO>();
            using(var cn=AccesoDB.getConnection())
            {
                var cmd = new SqlCommand("usp_Empleados_Listar",cn);
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmpleadoDTO re = new EmpleadoDTO()
                        {
                            IdEmpleado=Convert.ToInt16(dr["IdEmpleado"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Cargo=dr["Cargo"].ToString()
                        };
                        lista.Add(re);
                    }
                    //cerrar cursor dr
                    dr.Close();
                    cn.Close();
                }
                catch (Exception)
                {                    
                    //throw;
                }
                return lista;
            }
        }
    }
}
