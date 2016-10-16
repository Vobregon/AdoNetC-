using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprendiendoEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // crear objeto de la clase dbcontext
        NeptunoEntities dc = new NeptunoEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            //var consulta = from c in dc.Productos where c.NombreProducto.Contains("choco")
            //               select new {c.IdProducto,c.NombreProducto,c.PrecioUnidad,c.UnidadesEnExistencia};
            //dgvProducto.DataSource = consulta.ToList();
            dgvProducto.DataSource = dc.usp_ListaProductos().ToList();

        }
    }
}
