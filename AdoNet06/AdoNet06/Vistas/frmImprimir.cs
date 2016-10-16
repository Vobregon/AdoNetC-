using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet06.Vistas
{
    public partial class frmImprimir : Form
    {
        public frmImprimir()
        {
            InitializeComponent();
        }

         int nro;

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            nro = Int32.Parse(txtNro.Text);
            frmFactura f = new frmFactura(nro);
            f.ShowDialog();
        }
    }
}
