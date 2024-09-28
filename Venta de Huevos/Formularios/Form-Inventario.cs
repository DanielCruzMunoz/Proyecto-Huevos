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
    public partial class Form_Inventario : Form
    {
        public Form_Inventario()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------------Metodo para llenar el date gray view-----------

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT * FROM Inventario";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        private void Form_Inventario_Load(object sender, EventArgs e)
        {
            dtgInventario.DataSource = llenar_grid();
        }





        //--------------------------------------------------------Metodo para utilizar el boton Nuevo.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtExistenciaHuevos.Clear();
            txtTipo.Clear();
            txtPrecioVenta.Clear();
        }


        //-------------------------------------------------------------------------Metodo para utilizar el Boton Agregar.


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string Insertar = "INSERT INTO Inventario ( Detalle, PrecioVenta, ExistenciaHuevos)VALUES( @Detalle, @PrecioVenta, @ExistenciaHuevos)";
            SqlCommand cmd2 = new SqlCommand(Insertar, ConexionBDAle.Conectar());
            cmd2.Parameters.AddWithValue("@Detalle", txtTipo.Text);
            cmd2.Parameters.AddWithValue("@PrecioVenta", txtPrecioVenta.Text);
            cmd2.Parameters.AddWithValue("@ExistenciaHuevos", txtExistenciaHuevos.Text);


            cmd2.ExecuteNonQuery();
            dtgInventario.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtExistenciaHuevos.Clear();
            txtTipo.Clear();
            txtPrecioVenta.Clear();
        }



        //-------------------------------------------------------------------------Metodo para utilizar el Boton Actualizar.

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string actualizar = "UPDATE Inventario SET  Detalle=@Detalle, PrecioVenta=@PrecioVenta, ExistenciaHuevos=@ExistenciaHuevos WHERE ProductoID=@ProductoID";
            SqlCommand cmd3 = new SqlCommand(actualizar, ConexionBDAle.Conectar());
            cmd3.Parameters.AddWithValue("@ProductoID", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@Detalle", txtTipo.Text);
            cmd3.Parameters.AddWithValue("@PrecioVenta", txtPrecioVenta.Text);
            cmd3.Parameters.AddWithValue("@ExistenciaHuevos", txtExistenciaHuevos.Text);

            cmd3.ExecuteNonQuery();
            dtgInventario.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtExistenciaHuevos.Clear();
            txtTipo.Clear();
            txtPrecioVenta.Clear();
        }


        //--------------------------------------------------------------------Metodo para Utilizar el Boton Eliminar.


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string eliminar = "DELETE FROM Inventario WHERE ProductoID = @ProductoID";
            SqlCommand cmd4 = new SqlCommand(eliminar, ConexionBDAle.Conectar());
            cmd4.Parameters.AddWithValue("@ProductoID", txtCodigo.Text);

            cmd4.ExecuteNonQuery();
            dtgInventario.DataSource = llenar_grid();
        }


        //------------------------------------------------------------Metodo para asimilar las colunas de la tabla clientes de la base de datos-------------------------

        private void dtgInventario_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgInventario.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dtgInventario.SelectedCells[0].RowIndex;

                    txtCodigo.Text = dtgInventario.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtTipo.Text = dtgInventario.Rows[selectedRowIndex].Cells[1].Value.ToString();
                    txtPrecioVenta.Text = dtgInventario.Rows[selectedRowIndex].Cells[2].Value.ToString();
                    txtExistenciaHuevos.Text = dtgInventario.Rows[selectedRowIndex].Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                
                
                 MessageBox.Show("Algo fallo" + ex);
                throw;
                
                // Manejar la excepción apropiadamente, por ejemplo, mostrar un mensaje de error.
            }
        }
    }
}
