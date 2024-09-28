using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Venta_de_Huevos.Clases;

namespace Venta_de_Huevos.FormulariosModal
{
    public partial class mdCliente : Form
    {

        public int CodigoSeleccionado { get; private set; }
        public string NombreSeleccionado { get; private set; }
        public string TipoClienteSeleccionado { get; private set; }

        public mdCliente()
        {
            InitializeComponent();
            dtgClientesMOD.CellClick += dtgClientesMOD_CellClick;
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            dtgClientesMOD.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT ClienteID, Nombre, Tipo FROM Clientes";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dtgClientesMOD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en una celda válida
            if (e.RowIndex >= 0 && e.RowIndex < dtgClientesMOD.Rows.Count)
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow row = dtgClientesMOD.Rows[e.RowIndex];

                // Asignar los valores a las propiedades del formulario modal
                CodigoSeleccionado = Convert.ToInt32(row.Cells["ClienteID"].Value);
                NombreSeleccionado = row.Cells["Nombre"].Value.ToString();
                TipoClienteSeleccionado = row.Cells["Tipo"].Value.ToString();


                // Cerrar el formulario modal
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
