using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using AdoNet05.Controller;
using AdoNet05.Entity;

namespace AdoNet05.View
{
    public partial class frmRegistraVentas : Form
    {
        #region Constructor

        public frmRegistraVentas()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables
        private VentaBLL oventa = new VentaBLL();
        private int stock;
        DataSet ds = new DataSet();
        DataTable tbDetalle;
        DataRow drw;
        decimal total = 0;

        #endregion

        #region Metodos

        private void cargaListas()
        {
            // llenar combo de clientes
            cboCliente.DataSource = oventa.ListaClientes();
            cboCliente.DisplayMember = "NombreCompañía";
            cboCliente.ValueMember = "IdCliente";
            //llenar combo de empleados
            cboEmpleado.DataSource = oventa.ListaEmpleados();
            cboEmpleado.DisplayMember = "Empleado";
            cboEmpleado.ValueMember = "IdEmpleado";
            //llenar combo de empleados
            cboProducto.DataSource = oventa.ListaProductos();
            cboProducto.DisplayMember = "NombreProducto";
            cboProducto.ValueMember = "IdProducto";
        }

        private void agregarDetalle()
        {
            if (txtImporte.Text != null)
            {
                drw = tbDetalle.NewRow();
                drw["Codigo"] = txtCodigo.Text;
                drw["Nombre"] = cboProducto.Text;
                drw["Precio"] = txtPrecio.Text;
                drw["Cantidad"] = txtCantidad.Text;
                drw["SubTotal"] = txtImporte.Text;
                tbDetalle.Rows.Add(drw);
                total += decimal.Parse(txtImporte.Text);
                txtTotal.Text = total.ToString("n2");
            }
            else
            {
                MessageBox.Show("Falta datos", "Aviso");
            }
        }

        private void ConfigurarTabla()
        {
            tbDetalle = ds.Tables.Add();
            tbDetalle.Columns.Add("Codigo").Unique = true;
            tbDetalle.Columns.Add("Nombre");
            tbDetalle.Columns.Add("Precio");
            tbDetalle.Columns.Add("Cantidad");
            tbDetalle.Columns.Add("SubTotal");
            dgdDetalle.DataSource = tbDetalle;
        }

        private void NuevaVenta()
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();

        }

        private void quitarItemDetalle()
        {
            if (tbDetalle.Rows.Count > 0)
            {
                total -= decimal.Parse((string)dgdDetalle.Rows[dgdDetalle.CurrentCell.RowIndex].Cells[4].Value);
                txtTotal.Text = total.ToString("n2");
                tbDetalle.Rows.RemoveAt(dgdDetalle.CurrentCell.RowIndex);
            }
            else
            {
                MessageBox.Show("No hay Item para eliminar", "Aviso");
            }
        }

        private void registrarVenta()
        {
            VentaDTO ve = new VentaDTO();
            List<DetalleDTO> lista = new List<DetalleDTO>();
            foreach (DataRow item in tbDetalle.Rows)
            {
                DetalleDTO d = new DetalleDTO();
                d.IdProducto = Int32.Parse(item[0].ToString());
                d.Precio = decimal.Parse(item[2].ToString());
                d.Cantidad = Int32.Parse(item[3].ToString());
                d.Descuento = 0;
                lista.Add(d);
            }
            try
            {
                ve.IdCliente = cboCliente.SelectedValue.ToString();
                ve.IdEmpleado = (int)cboEmpleado.SelectedValue;
                ve.Fecha = DateTime.Parse(txtFecha.Text);
                ve.Monto = decimal.Parse(txtTotal.Text);
                ve.Item = lista;
                if (oventa.RegistrarVenta(ve) > 0)
                {
                    txtNro.Text = ve.IdVenta.ToString();
                    MessageBox.Show("Venta registrada correctamente", "Registrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Eventos
        private void frmRegistraVentas_Load(object sender, EventArgs e)
        {
            cargaListas();
            ConfigurarTabla();
            NuevaVenta();
        }


        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int n = (int)cboProducto.SelectedValue;
                DataTable tb = oventa.DatosProducto(n);
                txtCodigo.Text = tb.Rows[0][0].ToString();
                txtPrecio.Text = tb.Rows[0][1].ToString();
                stock = Int32.Parse(tb.Rows[0][2].ToString());
                txtCantidad.Text = "1";
                txtCantidad.SelectAll();
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text != string.Empty)
                {
                    int cant = Int32.Parse(txtCantidad.Text);
                    if (cant < stock)
                    {
                        decimal pre = decimal.Parse(txtPrecio.Text);
                        decimal subt = pre * cant;
                        txtImporte.Text = subt.ToString("n2");
                    }
                    else
                    {
                        MessageBox.Show("Solo quedan : " + stock + " unidades en stock", "Aviso");
                        txtCantidad.SelectAll();
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    txtImporte.Clear();
                }
            }
            catch (Exception)
            {
                // throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarDetalle();
        }


        private void btnEliminaDetalle_Click(object sender, EventArgs e)
        {
            quitarItemDetalle();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            registrarVenta();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
