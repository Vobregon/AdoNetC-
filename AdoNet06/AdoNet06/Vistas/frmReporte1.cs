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
    public partial class frmReporte1 : Form
    {
        public frmReporte1()
        {
            InitializeComponent();
        }     
       

        private void frmReporte1_Load(object sender, EventArgs e)
        {
         ListaPrecios f = new ListaPrecios();
         crvPrecios.ReportSource = f;
        }
    }
}
