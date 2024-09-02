using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Venta_de_Huevos.Clases
{
    internal class ConexionBDAle
    {
        //--------------------------------------Cadena de conexion de la base de datos de alejandro----------------------------->
        string cadena2 = "server= ; database= ; integrated security= true";
        public SqlConnection conectarBDAle = new SqlConnection();
        public ConexionBDAle()
        {
            conectarBDAle.ConnectionString = cadena2;
        }

        //-----------------------------------Metodo para abrir la conexion de la base de datos--------------------------------->
        public void abrir()
        {
            try
            {
                conectarBDAle.Open();
                Console.WriteLine("Conexion abierta");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al conectar a la base de datos" + ex);
            }
        }

        public void Cerrar()
        { 
            conectarBDAle.Close();
            Console.WriteLine();
        }
            

            
    }
}
