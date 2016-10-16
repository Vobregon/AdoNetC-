using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet04.Model;
using System.Data.Objects;


namespace AdoNet04
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
        // crear objeto de la clase dbcontext
        NeptunoEntities dc = new NeptunoEntities();

        void verProductos()
        {
            dgvProducto.DataSource = dc.usp_ListaProductos().ToList();
        }
        void cargaCombos()
        {
            cboProveedor.DataSource = dc.usp_ListaProveedores().ToList();
            cboProveedor.DisplayMember = "NombreCompañía";
            cboProveedor.ValueMember = "IdProveedor";

            cboCategoria.DataSource = dc.usp_ListaCategorias().ToList();
            cboCategoria.DisplayMember = "NombreCategoría";
            cboCategoria.ValueMember = "IdCategoría";
        }

        private void registraproducto()
        {
            usp_ListaProductos_Result pro = new usp_ListaProductos_Result();
            pro.NombreProducto = txtNombre.Text;
            pro.IdProveedor = (int)cboProveedor.SelectedValue;
            pro.IdCategoría = (int)cboCategoria.SelectedValue;
            pro.PrecioUnidad = decimal.Parse(txtPrecio.Text);
            pro.UnidadesEnExistencia = Convert.ToInt16(numCantidad.Value.ToString());
            try
            {
               ObjectParameter IdProducto = new ObjectParameter("IdProducto", typeof(int));
               int x= dc.usp_Inserta_Producto(pro.NombreProducto, pro.IdProveedor, pro.IdCategoría, pro.PrecioUnidad, pro.UnidadesEnExistencia,IdProducto);
               txtIdproducto.Text = IdProducto.Value.ToString();                 
               MessageBox.Show("Producto Registrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);                                                            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizaproducto()
        {
            usp_ListaProductos_Result pro = new usp_ListaProductos_Result();
            pro.IdProducto = Int32.Parse(txtIdproducto.Text);
            pro.NombreProducto = txtNombre.Text;
            pro.IdProveedor = (int)cboProveedor.SelectedValue;
            pro.IdCategoría = (int)cboCategoria.SelectedValue;
            pro.PrecioUnidad = decimal.Parse(txtPrecio.Text);
            pro.UnidadesEnExistencia = Convert.ToInt16(numCantidad.Value.ToString());
            try
            {                
                int x = dc.usp_Actualizar_Producto(pro.NombreProducto, pro.IdProveedor, pro.IdCategoría, pro.PrecioUnidad, pro.UnidadesEnExistencia, pro.IdProducto);
                MessageBox.Show("Producto actualizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaproducto()
        {
            usp_ListaProductos_Result pro = new usp_ListaProductos_Result();
            pro.IdProducto = Int32.Parse(txtIdproducto.Text);            
            try
            {
                int x = dc.usp_Eliminar_Producto(pro.IdProducto);
                MessageBox.Show("Producto eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            numCantidad.Value = Int32.Parse(dgvProducto.Rows[f].Cells[5].Value.ToString());
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
