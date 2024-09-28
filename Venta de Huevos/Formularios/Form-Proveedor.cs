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

namespace Venta_de_Huevos.Formularios
{
    public partial class Form_Proveedor : Form
    {
        public Form_Proveedor()
        {
            InitializeComponent();
        }

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT * FROM Proveedor";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        private void Form_Proveedor_Load(object sender, EventArgs e)
        {
            dtgProveedor.DataSource = llenar_grid();
        }

        private void dtgProveedor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgProveedor.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dtgProveedor.SelectedCells[0].RowIndex;

                    txtCodigo.Text = dtgProveedor.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtNombre.Text = dtgProveedor.Rows[selectedRowIndex].Cells[1].Value.ToString();
                    txtDireccion.Text = dtgProveedor.Rows[selectedRowIndex].Cells[2].Value.ToString();


                }
            }
            catch
            {
                // Manejar la excepción apropiadamente, por ejemplo, mostrar un mensaje de error.
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string Insertar = "INSERT INTO Proveedor ( Nombre, Direccion)VALUES( @Nombre, @Direccion)";
            SqlCommand cmd2 = new SqlCommand(Insertar, ConexionBDAle.Conectar());
            cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

            cmd2.ExecuteNonQuery();
            dtgProveedor.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string actualizar = "UPDATE Proveedor SET  Nombre=@Nombre, Direccion=@Direccion  WHERE ProveedorID=@ProveedorID";
            SqlCommand cmd3 = new SqlCommand(actualizar, ConexionBDAle.Conectar());
            cmd3.Parameters.AddWithValue("@ProveedorID", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd3.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

            cmd3.ExecuteNonQuery();
            dtgProveedor.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string eliminar = "DELETE FROM Proveedor WHERE ProveedorID = @ProveedorID";
            SqlCommand cmd4 = new SqlCommand(eliminar, ConexionBDAle.Conectar());
            cmd4.Parameters.AddWithValue("@ProveedorID", txtCodigo.Text);

            cmd4.ExecuteNonQuery();
            dtgProveedor.DataSource = llenar_grid();
        }
    }
}
