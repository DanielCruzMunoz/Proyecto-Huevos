using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Venta_de_Huevos.Formularios
{
    public partial class Form_clientes : Form
    {
        public Form_clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //----------------------------Metodo para llamar la cadena de conexion que esta en la clase creada---------------------------------->
            ConexionBD Conecxion = new ConexionBD();
            Conecxion.abrir();
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConexionBD Conecxion = new ConexionBD();
            Conecxion.cerrar();
        }
    }
}
