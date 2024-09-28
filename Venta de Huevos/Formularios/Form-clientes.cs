using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Venta_de_Huevos.Clases;


namespace Venta_de_Huevos.Formularios
{
    public partial class Form_clientes : Form
    {
        public Form_clientes()
        {
            InitializeComponent();
       
   
        }

        //---------------------------------------------------------------------------Metodo para llenar el date gray view-----------
        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT * FROM Clientes";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }




        private void Form_clientes_Load(object sender, EventArgs e)
        {
            dtgClientes.DataSource = llenar_grid();
        }




        //------------------------------------------------------------Metodo para asimilar las colunas de la tabla clientes de la base de datos-------------------------

        private void dtgClientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgClientes.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dtgClientes.SelectedCells[0].RowIndex;

                    txtCodigo.Text = dtgClientes.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtNombre.Text = dtgClientes.Rows[selectedRowIndex].Cells[1].Value.ToString();
                    txtApellido.Text = dtgClientes.Rows[selectedRowIndex].Cells[2].Value.ToString();
                    cobTipoCliente.Text = dtgClientes.Rows[selectedRowIndex].Cells[3].Value.ToString();


                }
            }
            catch
            {
                // Manejar la excepción apropiadamente, por ejemplo, mostrar un mensaje de error.
            }


        }

        //--------------------------------------------------------Metodo para utilizar el boton Nuevo.

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
           
        }


        //-------------------------------------------------------------------------Metodo para utilizar el Boton Agregar.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string Insertar = "INSERT INTO Clientes ( Nombre, Apellido, Tipo)VALUES( @Nombre, @Apellido, @Tipo)";
            SqlCommand cmd2 = new SqlCommand(Insertar, ConexionBDAle.Conectar());
            cmd2.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd2.Parameters.AddWithValue("@Tipo", cobTipoCliente.Text);


            cmd2.ExecuteNonQuery();
            dtgClientes.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        //-------------------------------------------------------------------------Metodo para utilizar el Boton Actualizar.
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string actualizar = "UPDATE Clientes SET   Nombre=@Nombre, Apellido=@Apellido, Tipo=@Tipo WHERE ClienteID=@ClienteID";
            SqlCommand cmd3 = new SqlCommand(actualizar, ConexionBDAle.Conectar());
            cmd3.Parameters.AddWithValue("@ClienteID", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd3.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd3.Parameters.AddWithValue("@Tipo", cobTipoCliente.Text);

            cmd3.ExecuteNonQuery();
            dtgClientes.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
           
        }

        //--------------------------------------------------------------------Metodo para Utilizar el Boton Eliminar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ConexionBDAle.Conectar();
            string eliminar = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";
            SqlCommand cmd4 = new SqlCommand(eliminar, ConexionBDAle.Conectar());
            cmd4.Parameters.AddWithValue("@ClienteID", txtCodigo.Text);

            cmd4.ExecuteNonQuery();
            dtgClientes.DataSource = llenar_grid();
        }
    }
}
