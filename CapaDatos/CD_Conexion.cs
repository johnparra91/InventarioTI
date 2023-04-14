using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
       //private SqlConnection Conexion = new SqlConnection("Server=192.168.1.6;DataBase=test;Integrated Security=true");
        
       
        //Test
       // private SqlConnection Conexion = new SqlConnection("Data Source=192.168.1.6;Initial Catalog=Test;User ID=sa;Password=adminsdt");
       
        //Produccion
       private SqlConnection Conexion = new SqlConnection("Data Source=192.168.1.6;Initial Catalog=erpfrusys;User ID=sa;Password=adminsdt");
     
        
        //  private SqlConnection Conexion = new SqlConnection("Data Source=192.168.1.4;Initial Catalog=erpfrusys ;User ID=sa;Password=Passw0rd..");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
