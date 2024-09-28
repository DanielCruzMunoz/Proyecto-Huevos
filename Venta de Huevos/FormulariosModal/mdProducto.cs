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
    public partial class mdProducto : Form
    {
        public int CodigoSeleccionado { get; private set; }
        public string DetalleSeleccionado { get; private set; }
        public decimal PrecioCartonProductoSeleccionado { get; private set; }
        public decimal PrecioUnidadProductoSeleccionado { get; private set; }
        public mdProducto()
        {
            InitializeComponent();
            dtgProveedorMOD.CellClick += dtgProveedorMOD_CellClick;
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            dtgProveedorMOD.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT ProductoID, Detalle, PrecioCarton, CostoUnidad FROM Inventario";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dtgProveedorMOD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en una celda válida
            if (e.RowIndex >= 0 && e.RowIndex < dtgProveedorMOD.Rows.Count)
            {
                // Obtener los valores de la fila seleccionada
                DataGridViewRow row = dtgProveedorMOD.Rows[e.RowIndex];

                // Asignar los valores a las propiedades del formulario modal
                CodigoSeleccionado = Convert.ToInt32(row.Cells["ProductoID"].Value);
                DetalleSeleccionado = row.Cells["Detalle"].Value.ToString();
                PrecioCartonProductoSeleccionado = Convert.ToDecimal(row.Cells["PrecioCarton"].Value);
                PrecioUnidadProductoSeleccionado = Convert.ToDecimal(row.Cells["CostoUnidad"].Value);



                // Cerrar el formulario modal
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
