using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Venta_de_Huevos.Clases;
using Venta_de_Huevos.FormulariosModal;

namespace Venta_de_Huevos.Formularios
{
    public partial class Form_Ventas : Form
    {
        public Form_Ventas()
        {
            InitializeComponent();
       
        }

        public DataTable llenar_grid()
        {
            ConexionBDAle.Conectar();
            DataTable dt = new DataTable();
            String Consulta = "SELECT * FROM Ventas";
            SqlCommand cmd = new SqlCommand(Consulta, ConexionBDAle.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        private void Form_Ventas_Load(object sender, EventArgs e)
        {
            dtgVentas.DataSource = llenar_grid();
        }

        private void dtgVentas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgVentas.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dtgVentas.SelectedCells[0].RowIndex;

                    txtCodigo.Text = dtgVentas.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    txtCodigoCliente.Text = dtgVentas.Rows[selectedRowIndex].Cells[1].Value.ToString();
                    txtNombreCliente.Text = dtgVentas.Rows[selectedRowIndex].Cells[2].Value.ToString();
                    txtTipoCliente.Text = dtgVentas.Rows[selectedRowIndex].Cells[3].Value.ToString();
                    txtFecha.Text = dtgVentas.Rows[selectedRowIndex].Cells[4].Value.ToString();
                    txtCodigoProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[5].Value.ToString();
                    txtDetalleProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[6].Value.ToString();
                    txtCantidadProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[7].Value.ToString();
                    txtPrecioCartonProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[8].Value.ToString();
                    txtPrecioVentaProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[9].Value.ToString();
                    txtPrecioUnitarioProducto.Text = dtgVentas.Rows[selectedRowIndex].Cells[10].Value.ToString();
                    txtEstadoVenta.Text = dtgVentas.Rows[selectedRowIndex].Cells[11].Value.ToString();
                    txtMontoPagado.Text = dtgVentas.Rows[selectedRowIndex].Cells[12].Value.ToString();
                    lbMontoTotal.Text = dtgVentas.Rows[selectedRowIndex].Cells[13].Value.ToString();
                    txtGanancia.Text = dtgVentas.Rows[selectedRowIndex].Cells[14].Value.ToString();



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
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtFecha.Clear();
            txtCodigoProducto.Clear();
            txtDetalleProducto.Clear();
            txtCantidadProducto.Clear();
            txtPrecioVentaProducto.Clear();
            txtPrecioUnitarioProducto.Clear();
            txtMontoPagado.Clear();
            txtGanancia.Clear();
            txtPrecioCartonProducto.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            /*decimal precio = decimal.Parse(txtPrecioVentaProducto.Text);
            decimal precioCompra = decimal.Parse(txtPrecioUnitarioProducto.Text);
            int cantidad = int.Parse(txtCantidadProducto.Text);
            decimal Ganancia = precio - precioCompra * cantidad  ;




            ConexionBDAle.Conectar();
            string Insertar = "INSERT INTO Ventas ( ClienteID, NombreCliente, Fecha, ProductoID, Detalle, Cantidad, PrecioVenta, PrecioUnitario, EstadoVenta, MontoPagado, MontoTotal, Ganancia)VALUES( @ClienteID, @NombreCliente, @Fecha, @ProductoID, @Detalle, @Cantidad, @PrecioVenta, @PrecioUnitario, @EstadoVenta, @MontoPagado, @MontoTotal, @Ganancia)";
            SqlCommand cmd2 = new SqlCommand(Insertar, ConexionBDAle.Conectar());
            cmd2.Parameters.AddWithValue("@ClienteID", txtCodigoCliente.Text);
            cmd2.Parameters.AddWithValue("@NombreCliente", txtNombreCliente.Text);
            cmd2.Parameters.AddWithValue("@Fecha", txtFecha.Text);
            cmd2.Parameters.AddWithValue("@ProductoID", txtCodigoProducto.Text);
            cmd2.Parameters.AddWithValue("@Detalle", txtDetalleProducto.Text);
            cmd2.Parameters.AddWithValue("@Cantidad", txtCantidadProducto.Text);
            cmd2.Parameters.AddWithValue("@PrecioVenta", decimal.Parse(txtPrecioVentaProducto.Text));
            cmd2.Parameters.AddWithValue("@PrecioUnitario", decimal.Parse(txtPrecioUnitarioProducto.Text));
            cmd2.Parameters.AddWithValue("@EstadoVenta", txtEstadoVenta.Text);
            cmd2.Parameters.AddWithValue("@MontoPagado", decimal.Parse(txtMontoPagado.Text));
            cmd2.Parameters.AddWithValue("@MontoTotal", lbMontoTotal.Text);
            cmd2.Parameters.AddWithValue("@Ganancia", Ganancia);


            cmd2.ExecuteNonQuery();
            dtgVentas.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtFecha.Clear();
            txtCodigoProducto.Clear();
            txtDetalleProducto.Clear();
            txtCantidadProducto.Clear();
            txtPrecioVentaProducto.Clear();
            txtPrecioUnitarioProducto.Clear();
            txtEstadoVenta.Clear();
            txtMontoPagado.Clear();
       
            txtGanancia.Clear();*/

            // Declaración de variables
            decimal precioCarton;
            decimal precioVenta;
            decimal precioUnitario;
            int cantidad;
            decimal ganancia;

            // Conversión segura de los datos de entrada con TryParse
            if (!decimal.TryParse(txtPrecioUnitarioProducto.Text, out precioUnitario))
            {
                MessageBox.Show("El precio unitario ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtPrecioCartonProducto.Text, out precioCarton))
            {
                MessageBox.Show("El precio de carton ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrecioVentaProducto.Text, out precioVenta))
            {
                MessageBox.Show("El precio de venta ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCantidadProducto.Text, out cantidad))
            {
                MessageBox.Show("La cantidad ingresada es inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cálculo de la ganancia
            ganancia = (precioCarton - precioVenta) * cantidad;

            // Conectar a la base de datos
            SqlConnection conexion = ConexionBDAle.Conectar();

            try
            {
                // Conversión segura para MontoPagado
                decimal montoPagado;
                if (!decimal.TryParse(txtMontoPagado.Text, out montoPagado))
                {
                    MessageBox.Show("El monto pagado ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Conversión segura para MontoTotal
                decimal montoTotal;
                if (!decimal.TryParse(lbMontoTotal.Text, out montoTotal))
                {
                    MessageBox.Show("El monto total ingresado es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Preparar la consulta SQL para la inserción
                string insertar = "INSERT INTO Ventas (ClienteID, NombreCliente, TipoCliente, Fecha, ProductoID, Detalle, Cantidad, PrecioCarton, PrecioVenta, PrecioUnitario, EstadoVenta, MontoPagado, MontoTotal, Ganancia) " +
                                  "VALUES (@ClienteID, @NombreCliente, @TipoCliente,  @Fecha, @ProductoID, @Detalle, @Cantidad, @PrecioCarton, @PrecioVenta, @PrecioUnitario, @EstadoVenta, @MontoPagado, @MontoTotal, @Ganancia)";

                SqlCommand cmd2 = new SqlCommand(insertar, conexion);

                // Agregar parámetros a la consulta SQL
                cmd2.Parameters.AddWithValue("@ClienteID", txtCodigoCliente.Text);
                cmd2.Parameters.AddWithValue("@NombreCliente", txtNombreCliente.Text);
                cmd2.Parameters.AddWithValue("@TipoCliente", txtTipoCliente.Text);
                cmd2.Parameters.AddWithValue("@Fecha", DateTime.Parse(txtFecha.Text));  // Convertir la fecha correctamente
                cmd2.Parameters.AddWithValue("@ProductoID", txtCodigoProducto.Text);
                cmd2.Parameters.AddWithValue("@Detalle", txtDetalleProducto.Text);
                cmd2.Parameters.AddWithValue("@Cantidad", cantidad);  // Ya convertido a entero
                cmd2.Parameters.AddWithValue("@PrecioCarton", precioCarton);
                cmd2.Parameters.AddWithValue("@PrecioVenta", precioVenta);  // Ya convertido a decimal
                cmd2.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);  // Ya convertido a decimal
                cmd2.Parameters.AddWithValue("@EstadoVenta", txtEstadoVenta.Text);
                cmd2.Parameters.AddWithValue("@MontoPagado", montoPagado);  // Ya convertido a decimal
                cmd2.Parameters.AddWithValue("@MontoTotal", montoTotal);  // Ya convertido a decimal
                cmd2.Parameters.AddWithValue("@Ganancia", ganancia);  // Ya calculada

                // Ejecutar el comando SQL
                cmd2.ExecuteNonQuery();

                // Actualizar el DataGridView
                dtgVentas.DataSource = llenar_grid();

                // Limpiar los campos del formulario
                txtCodigo.Clear();
                txtCodigoCliente.Clear();
                txtNombreCliente.Clear();
                txtTipoCliente.Clear();
                txtFecha.Clear();
                txtCodigoProducto.Clear();
                txtDetalleProducto.Clear();
                txtCantidadProducto.Clear();
                txtPrecioVentaProducto.Clear();
                txtPrecioUnitarioProducto.Clear();
                txtMontoPagado.Clear();
                txtGanancia.Clear();
                txtPrecioCartonProducto.Clear();
                
            }
            catch (Exception ex)
            {
                // Manejar errores de la base de datos
                MessageBox.Show("Ocurrió un error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }












        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string actualizar = "UPDATE Ventas SET  ClienteID=@ClienteID, NombreCliente=@NombreCliente, Fecha=@Fecha, ProductoID=@ProductoID, Detalle=@Detalle, Cantidad=@Cantidad, PrecioCarton=@PrecioCarton, PrecioVenta=@PrecioVenta, PrecioUnitario=@PrecioUnitario, EstadoVenta=@EstadoVenta, MontoPagado=@MontoPagado, MontoTotal=@MontoTotal, Ganancia=@Ganancia WHERE VentaID=@VentaID";
            SqlCommand cmd3 = new SqlCommand(actualizar, ConexionBDAle.Conectar());
            cmd3.Parameters.AddWithValue("@VentaID", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@ClienteID", txtCodigoCliente.Text);
            cmd3.Parameters.AddWithValue("@NombreCliente", txtNombreCliente.Text);
            cmd3.Parameters.AddWithValue("@Fecha", txtFecha.Text);
            cmd3.Parameters.AddWithValue("@ProductoID", txtCodigoProducto.Text);
            cmd3.Parameters.AddWithValue("@Detalle", txtDetalleProducto.Text);
            cmd3.Parameters.AddWithValue("@Cantidad", txtCantidadProducto.Text);
            cmd3.Parameters.AddWithValue("@PrecioCarton", txtPrecioCartonProducto.Text);
            cmd3.Parameters.AddWithValue("@PrecioVenta", txtPrecioVentaProducto.Text);
            cmd3.Parameters.AddWithValue("@PrecioUnitario", txtPrecioUnitarioProducto.Text);
            cmd3.Parameters.AddWithValue("@EstadoVenta", txtEstadoVenta.Text);
            cmd3.Parameters.AddWithValue("@MontoPagado", txtMontoPagado.Text);
            cmd3.Parameters.AddWithValue("@MontoTotal", lbMontoTotal.Text);
            cmd3.Parameters.AddWithValue("@Ganancia", txtGanancia.Text);

            cmd3.ExecuteNonQuery();
            dtgVentas.DataSource = llenar_grid();
            txtCodigo.Clear();
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtFecha.Clear();
            txtCodigoProducto.Clear();
            txtDetalleProducto.Clear();
            txtCantidadProducto.Clear();
            txtPrecioVentaProducto.Clear();
            txtPrecioUnitarioProducto.Clear();
            txtMontoPagado.Clear();
            txtTipoCliente.Clear();
            txtGanancia.Clear();
            txtPrecioCartonProducto.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionBDAle.Conectar();
            string eliminar = "DELETE FROM Ventas WHERE VentaID = @VentaID";
            SqlCommand cmd4 = new SqlCommand(eliminar, ConexionBDAle.Conectar());
            cmd4.Parameters.AddWithValue("@VentaID", txtCodigo.Text);

            cmd4.ExecuteNonQuery();
            dtgVentas.DataSource = llenar_grid();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Asignar directamente el texto al campo txtProveedorID
                    txtCodigoCliente.Text = modal.CodigoSeleccionado.ToString();
                    txtNombreCliente.Text = modal.NombreSeleccionado;
                    txtTipoCliente.Text = modal.TipoClienteSeleccionado;
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Asignar directamente el texto al campo txtProveedorID
                    txtCodigoProducto.Text = modal.CodigoSeleccionado.ToString();
                    txtDetalleProducto.Text = modal.DetalleSeleccionado;
                    txtPrecioCartonProducto.Text = modal.PrecioCartonProductoSeleccionado.ToString();
                    txtPrecioUnitarioProducto.Text = modal.PrecioUnidadProductoSeleccionado.ToString();
                }
            }
        }

        private void txtCantidadProducto_TextChanged(object sender, EventArgs e)
        {

            /* // Inicializar la variable de texto para mostrar el resultado
             lbMontoTotal.Text = "";

             // Comprobar si los campos de cantidad o precio de venta están vacíos
             if (string.IsNullOrWhiteSpace(txtCantidadProducto.Text))
             {
                 MessageBox.Show("Por favor, ingrese la cantidad.", "Entrada requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
             else if (string.IsNullOrWhiteSpace(txtPrecioVentaProducto.Text))
             {
                 MessageBox.Show("Por favor, ingrese el precio de venta.", "Entrada requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             try
             {
                 // Convertir las entradas de texto a los tipos numéricos correspondientes
                 decimal precioVenta = decimal.Parse(txtPrecioVentaProducto.Text);
                 int cantidad = int.Parse(txtCantidadProducto.Text);

                 // Calcular el monto total
                 decimal MontoTotal = precioVenta * cantidad;

                 // Mostrar el resultado en el label
                 lbMontoTotal.Text = Convert.ToString(MontoTotal); // Usa formato moneda si es necesario


             }
             catch (FormatException)
             {
                 // Mostrar un mensaje de error si las entradas no son válidas numéricamente
                 MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/



            // Inicializar el texto del label de monto total



            //-------------------------------------------------------------------------------------------------------------------------------------

            /*lbMontoTotal.Text = "";

            // Variables para almacenar la conversión
            decimal precioVenta;
            int cantidad;

            // Validar que los campos no estén vacíos y que contengan valores numéricos válidos
            if (string.IsNullOrWhiteSpace(txtCantidadProducto.Text))
            {
                Console.WriteLine("Por favor, ingrese la cantidad.", "Entrada requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioVentaProducto.Text))
            {
                Console.WriteLine("Por favor, ingrese el precio de venta.", "Entrada requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar convertir las entradas a los tipos numéricos correctos
            if (!decimal.TryParse(txtPrecioVentaProducto.Text, out precioVenta))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para el precio de venta.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCantidadProducto.Text, out cantidad))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la cantidad.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el monto total
            decimal montoTotal = precioVenta * cantidad;

            // Mostrar el resultado en el label, con formato de moneda si es necesario
            lbMontoTotal.Text = Convert.ToString(montoTotal); // C2 es para mostrar formato de moneda



        }*/

            // Limpiar el texto del label de monto total
            lbMontoTotal.Text = "";

            // Variables para almacenar los valores de entrada
            decimal precioVenta;
            int cantidad;

            // Verificar si el campo de cantidad está vacío
            if (string.IsNullOrWhiteSpace(txtCantidadProducto.Text))
            {
                lbMontoTotal.Text = "0";
                return;
            }

            // Verificar si el campo de precio de venta está vacío
            if (string.IsNullOrWhiteSpace(txtPrecioVentaProducto.Text))
            {
                lbMontoTotal.Text = "0";
                return;
            }

            // Intentar convertir el precio de venta a decimal
            if (!decimal.TryParse(txtPrecioVentaProducto.Text, out precioVenta))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para el precio de venta.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Intentar convertir la cantidad a entero
            if (!int.TryParse(txtCantidadProducto.Text, out cantidad))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la cantidad.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el monto total
            decimal montoTotal = precioVenta * cantidad;

            // Mostrar el monto total en el label con formato de moneda (opcional)
            lbMontoTotal.Text = Convert.ToString(montoTotal); // "C2" para formato de moneda con dos decimales
        }

        private void txtPrecioCartonProducto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

