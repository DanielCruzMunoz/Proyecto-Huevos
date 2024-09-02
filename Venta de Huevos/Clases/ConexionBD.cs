using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Venta_de_Huevos
{
    internal class ConexionBD
    {
        //---------------------------Cadena de conenxion PC Daniel------------------------------------>
        string cadena = "server= DANNYPC\\SQLEXPRESS; database= EmpresaHuevos; integrated security= true";
        public SqlConnection conectarBD = new SqlConnection();
        public ConexionBD()
        {
            conectarBD.ConnectionString = cadena;
        }
        //----------------------------Metodo para abrir la conexion----------------------------------->
        public void abrir()
        {
            try
            {
                conectarBD.Open();
                Console.WriteLine("Conexion Abierta" );
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al abrir BD " + ex.Message);
            }
        }
        //----------------------------Metodo para cerrar la conexion--------------------------------->
        public void cerrar()
        {
            conectarBD.Close();
            Console.WriteLine("Conexion Cerrada");
        }
    }

}

