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
    public partial class Form_Compra : Form
    {
        public Form_Compra()
        {
            InitializeComponent();
        }

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT * FROM Compra";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }



        private void Form_Compra_Load(object sender, EventArgs e)
        {
            dtgCompra.DataSource = llenar_grid();
        }

        private void dtgCompra_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgCompra.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dtgCompra.SelectedCells[0].RowIndex;

                    txtCodigo.Text = dtgCompra.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtFechaCompra.Text = dtgCompra.Rows[selectedRowIndex].Cells[1].Value.ToString();
                    txtCodigoProveedor.Text = dtgCompra.Rows[selectedRowIndex].Cells[2].Value.ToString();
                    txtCantidad.Text = dtgCompra.Rows[selectedRowIndex].Cells[3].Value.ToString();
                   

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
            txtFechaCompra.Clear();
            txtCodigoProveedor.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string Insertar = "INSERT INTO Compra ( FechaCompra, precioCompra, ProveedorID, Cantidad)VALUES( @FechaCompra, @precioCompra, @ProveedorID, @Cantidad)";
            SqlCommand cmd2 = new SqlCommand(Insertar, ConexionBDAle.Conectar());
            cmd2.Parameters.AddWithValue("@FechaCompra", txtFechaCompra.Text);
            cmd2.Parameters.AddWithValue("@ProveedorID", txtCodigoProveedor.Text);
            cmd2.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd2.Parameters.AddWithValue("@precioCompra", txtPrecioCompra.Text);


            cmd2.ExecuteNonQuery();
            dtgCompra.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtFechaCompra.Clear();
            txtCodigoProveedor.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string actualizar = "UPDATE Compra SET   FechaCompra=@FechaCompra, precioCompra=@precioCompra, ProveedorID=@ProveedorID, Cantidad=@Cantidad  WHERE CompraID=@CompraID";
            SqlCommand cmd3 = new SqlCommand(actualizar, ConexionBDAle.Conectar());
            cmd3.Parameters.AddWithValue("@CompraID", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@FechaCompra", txtFechaCompra.Text);
            cmd3.Parameters.AddWithValue("@ProveedorID", txtCodigoProveedor.Text);
            cmd3.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd3.Parameters.AddWithValue("@precioCompra", txtPrecioCompra.Text);

            cmd3.ExecuteNonQuery();
            dtgCompra.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtFechaCompra.Clear();
            txtCodigoProveedor.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string eliminar = "DELETE FROM Compra WHERE CompraID = @CompraID";
            SqlCommand cmd4 = new SqlCommand(eliminar, ConexionBDAle.Conectar());
            cmd4.Parameters.AddWithValue("@CompraID", txtCodigo.Text);

            cmd4.ExecuteNonQuery();
            dtgCompra.DataSource = llenar_grid();
        }

        private void dtgCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
