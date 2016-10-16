using Adonet01.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet01.View
{
    public partial class frmProductosxCategoria : Form
    {
        public frmProductosxCategoria()
        {
            InitializeComponent();
        }

        private void frmProductosxCategoria_Load(object sender, EventArgs e)
        {
            cboCategoria.DataSource = new ProductoBLL().ListaCategorias();
            cboCategoria.DisplayMember = "NombreCategoría";
            cboCategoria.ValueMember = "IdCategoría";
            cboCategoria_SelectedIndexChanged(sender,e);
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvProductos.DataSource = new ProductoBLL().ListaProductosxCategoria((int)cboCategoria.SelectedValue);
            }
            catch (Exception)
            {                
               // throw;
            }
        }
    }
}
