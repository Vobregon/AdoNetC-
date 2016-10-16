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
    public partial class frmProductoTodos : Form
    {
        public frmProductoTodos()
        {
            InitializeComponent();
        }

        private void frmProductoTodos_Load(object sender, EventArgs e)
        {
            dgvProducto.DataSource = new ProductoBLL().ListaProductos().Tables["xxx"];
        }
    }
}
