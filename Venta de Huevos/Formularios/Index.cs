using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Venta_de_Huevos.Clases;

namespace Venta_de_Huevos.Formularios
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            
        }

        private void Index_Load(object sender, EventArgs e)
        {

            ConexionBDAle.Conectar();
            
            MessageBox.Show("Estas conectado a la base de datos..");

            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.Dock = DockStyle.Fill;
            abrirformularioHijo(new inicio());
        }

        private void abrirformularioHijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();


        }



        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformularioHijo(new Form_clientes());
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformularioHijo(new Form_Inventario());
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformularioHijo(new Form_Proveedor());
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirformularioHijo(new Form_Compra());
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirformularioHijo(new Form_Ventas());
        }
    }
}
