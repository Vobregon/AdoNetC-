using AdoNet05.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet05.Entity;
using System.Data;
using AdoNet05.Database;
using System.Data.SqlClient;

namespace AdoNet05.Model
{
    public class VentaDAO : IVenta
    {
        // constructor
        public VentaDAO()
        { 
        }
        // metodos para la persitencia

        public int registrar(VentaDTO o)
        {
            int iresult;
           SqlConnection cn = AccesoDB.getConnection();
            try
            {
                // grabar venta             
                SqlCommand cmd1 = new SqlCommand("usp_Registra_Venta", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@IdVenta", 0).Direction = ParameterDirection.Output;
                cmd1.Parameters.AddWithValue("@IdCliente", o.IdCliente);
                cmd1.Parameters.AddWithValue("@IdEmpleado", o.IdEmpleado);
                cmd1.Parameters.AddWithValue("@Fecha", o.Fecha);
                cmd1.Parameters.AddWithValue("@Monto", o.Monto);
                cn.Open();
                iresult = cmd1.ExecuteNonQuery() == 1 ? 1 : 0;
                o.IdVenta = (int)cmd1.Parameters["@IdVenta"].Value;
                // grabar detalle
                SqlCommand cmd2 = new SqlCommand("usp_Registra_Detalle", cn);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlCommand cmd3 = new SqlCommand("usp_Actualiza_Stock", cn);
                cmd3.CommandType = CommandType.StoredProcedure;
                foreach (DetalleDTO item in o.Item)
                {
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@IdVenta", o.IdVenta);
                    cmd2.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    cmd2.Parameters.AddWithValue("@Precio", item.Precio);
                    cmd2.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmd2.Parameters.AddWithValue("@Descuento", item.Descuento);
                    cmd2.ExecuteNonQuery();
                    // actualizar stock de producto
                    cmd3.Parameters.Clear();
                    cmd3.Parameters.AddWithValue("@IdProducto", item.IdProducto);
                    cmd3.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                    cmd3.ExecuteNonQuery();
                }                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
            cn.Close();
            }
            return iresult;
        }

        public DataTable lista1() // lista clientes
        { 
            using(var cn=AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select IdCliente,NombreCompañía from Clientes order by NombreCompañía", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }//fin

        public DataTable lista2() // lista empleado
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select IdEmpleado,Empleado=Apellidos+' '+nombre from Empleados order by Empleado", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }//fin

        public DataTable lista3() // lista de producto
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("select IdProducto,NombreProducto from Productos order by NombreProducto", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }//fin

        public DataTable lista4(int id)
        {
            DataTable dt;
            using(var cn=AccesoDB.getConnection())
            {
                var cmd = new SqlCommand("select IdProducto,PrecioUnidad,UnidadesEnExistencia from Productos where IdProducto=@IdProducto",cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdProducto",id);
                try
                {
                    var dap = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    dap.Fill(dt);
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }                
            }
            return dt;
        }
    }
}
