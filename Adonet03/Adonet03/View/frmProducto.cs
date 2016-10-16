using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adonet03.Controller;
using Adonet03.Entity;

namespace Adonet03
{
    public partial class frmProducto : Form
    {

        #region Constructor

        public frmProducto()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        void verProductos()
        {
            dgvProducto.DataSource = new ProductoBLL().ProductoListar();
        }
        void cargaCombos()
        {
            cboProveedor.DataSource = new ProductoBLL().ListaProveedores();
            cboProveedor.DisplayMember = "NombreCompañía";
            cboProveedor.ValueMember = "IdProveedor";

            cboCategoria.DataSource = new ProductoBLL().ListaCategorias();
            cboCategoria.DisplayMember = "NombreCategoría";
            cboCategoria.ValueMember = "IdCategoría";
        }

        private void registraproducto()
        {
        ProductoDTO pro=new ProductoDTO();
        pro.Nombre = txtNombre.Text;
            pro.IdProveedor=(int)cboProveedor.SelectedValue;
            pro.IdCategoria = (int)cboCategoria.SelectedValue;
            pro.Precio = decimal.Parse(txtPrecio.Text);
            pro.Stock = (int)numCantidad.Value;
            try
            {
                if (new ProductoBLL().ProductoAdicionar(pro)>0)
                {
                    txtIdproducto.Text = pro.IdProducto.ToString();
                    MessageBox.Show("Producto Registrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al registrar Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizaproducto()
        {
            ProductoDTO pro = new ProductoDTO();
            pro.IdProducto = Int32.Parse(txtIdproducto.Text);
            pro.Nombre = txtNombre.Text;
            pro.IdProveedor = (int)cboProveedor.SelectedValue;
            pro.IdCategoria = (int)cboCategoria.SelectedValue;
            pro.Precio = decimal.Parse(txtPrecio.Text);
            pro.Stock = (int)numCantidad.Value;
            try
            {
                if (new ProductoBLL().ProductoActualiza(pro)>0)
                {

                    MessageBox.Show("Producto Actualizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Actualizar Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaproducto()
        {
            ProductoDTO pro = new ProductoDTO();
            pro.IdProducto = Int32.Parse(txtIdproducto.Text);
            try
            {
                if (new ProductoBLL().ProductoEliminar(pro)>0)
                {

                    MessageBox.Show("Producto Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Eliminar Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void datosProducto()
        {
            int f = dgvProducto.CurrentCell.RowIndex;
            txtIdproducto.Text = dgvProducto.Rows[f].Cells[0].Value.ToString();
            txtNombre.Text = dgvProducto.Rows[f].Cells[1].Value.ToString();
            cboProveedor.SelectedValue = dgvProducto.Rows[f].Cells[2].Value;
            cboCategoria.SelectedValue = dgvProducto.Rows[f].Cells[3].Value;
            txtPrecio.Text = dgvProducto.Rows[f].Cells[4].Value.ToString();
            numCantidad.Value =Int32.Parse(dgvProducto.Rows[f].Cells[5].Value.ToString());
            tabControl1.SelectedIndex = 0;
        }

        #endregion

        #region Eventos

      private void frmProducto_Load(object sender, EventArgs e)
        {
            verProductos();
            cargaCombos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            registraproducto();
            verProductos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizaproducto();
            verProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminaproducto();
            verProductos();
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                datosProducto();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    

        #endregion

   }
}
