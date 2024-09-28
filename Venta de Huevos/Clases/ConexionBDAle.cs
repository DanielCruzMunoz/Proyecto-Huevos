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
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("server= DANNYPC\\SQLEXPRESS; database= Huevos; integrated security= true");
            cn.Open();
            return cn;

           
        }

    }
}
