using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea16_ListasEnlazadasSimplesOrdenadas
{
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        Inventario miInventario = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToSingle(txtPrecio.Text), Convert.ToInt16(txtCantidad.Text));
            MessageBox.Show(miInventario.agregarProductoOrdenado(miProducto));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.buscarProducto(Convert.ToInt16(txtCodigo.Text)).ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.borrarProducto(Convert.ToInt16(txtCodigo.Text)));
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miInventario.reporte();
        }
    }
}
