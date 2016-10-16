using AdoNet06.Reportes;
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
    public partial class frmFactura : Form
    {
        int n;
        public frmFactura(int nfact)
        {
            InitializeComponent();
            n = nfact;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            FacturaVenta fac = new FacturaVenta();
            crvFactura.SelectionFormula = "{v_Factura_Venta.IdPedido}="+n;
            crvFactura.ReportSource = fac;
        }
    }
}
