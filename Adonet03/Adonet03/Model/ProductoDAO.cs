using Adonet03.Entity;
using Adonet03.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Adonet03.DataBase;

namespace Adonet03.Model
{
    public class ProductoDAO : ICrud<ProductoDTO>
    {
        //constructor
        public ProductoDAO()
        {

        }
        // metodos para la persistencia de datos

        public int create(ProductoDTO o)
        {
            int iResult;
            try
            {
                using (var cn = AccesoDB.getConnection())
                {
                    var cmd = new SqlCommand("usp_Inserta_Producto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", o.Nombre);
                    cmd.Parameters.AddWithValue("@IdProveedor", o.IdProveedor);
                    cmd.Parameters.AddWithValue("@IdCategoria", o.IdCategoria);
                    cmd.Parameters.AddWithValue("@Precio", o.Precio);
                    cmd.Parameters.AddWithValue("@Stock", o.Stock);
                    cmd.Parameters.AddWithValue("@IdProducto", 0).Direction = ParameterDirection.Output;
                    cn.Open();
                    iResult = cmd.ExecuteNonQuery() == 1 ? 1 : 0;
                    cn.Close();
                    o.IdProducto = (Int32)cmd.Parameters["@IdProducto"].Value;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return iResult;
        }// fin

        public int update(ProductoDTO o)
        {
            int iResult;
            try
            {
                using (var cn = AccesoDB.getConnection())
                {
                    var cmd = new SqlCommand("usp_Actualizar_Producto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", o.Nombre);
                    cmd.Parameters.AddWithValue("@IdProveedor", o.IdProveedor);
                    cmd.Parameters.AddWithValue("@IdCategoria", o.IdCategoria);
                    cmd.Parameters.AddWithValue("@Precio", o.Precio);
                    cmd.Parameters.AddWithValue("@Stock", o.Stock);
                    cmd.Parameters.AddWithValue("@IdProducto", o.IdProducto);
                    cn.Open();
                    iResult = cmd.ExecuteNonQuery() == 1 ? 1 : 0;
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return iResult;
        }//fin

        public int delete(ProductoDTO o)
        {
            int iResult;
            try
            {
                using (var cn = AccesoDB.getConnection())
                {
                    var cmd = new SqlCommand("usp_Eliminar_Producto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", o.IdProducto);
                    cn.Open();
                    iResult = cmd.ExecuteNonQuery() == 1 ? 1 : 0;
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return iResult;
        }//fin

        public List<ProductoDTO> readAll()
        {
            List<ProductoDTO> lista = new List<ProductoDTO>();
            try
            {
                using (var cn = AccesoDB.getConnection())
                {
                    var cmd = new SqlCommand("usp_ListaProductos", cn);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ProductoDTO p = new ProductoDTO()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Nombre = dr["NombreProducto"].ToString(),
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoría"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"]),
                            Stock = Convert.ToInt32(dr["UnidadesEnExistencia"])
                        };
                        lista.Add(p);
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }// fin

        public ProductoDTO find(int id)
        {
            ProductoDTO p = null;
            try
            {
                using (var cn = AccesoDB.getConnection())
                {
                    var cmd = new SqlCommand("usp_Producto_Por_Codigo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto",id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                         p = new ProductoDTO()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Nombre = dr["NombreProducto"].ToString(),
                            IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                            IdCategoria = Convert.ToInt32(dr["IdCategoría"]),
                            Precio = Convert.ToDecimal(dr["PrecioUnidad"]),
                            Stock = Convert.ToInt32(dr["UnidadesEnExistencia"])
                        };                       
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return p;
        }// fin

        public DataTable Listar2()
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("usp_ListaCategorias", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }// fin

        public DataTable Listar3()
        {
            using (var cn = AccesoDB.getConnection())
            {
                var dap = new SqlDataAdapter("usp_ListaProveedores", cn);
                var dt = new DataTable();
                dap.Fill(dt);
                return dt;
            }
        }//fin

    }
}
