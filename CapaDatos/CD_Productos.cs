using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer_MIXDESPACHO;
        SqlDataReader leer_PRECIO;
        SqlDataReader leer_COMPARACION;
        SqlDataReader leer_ENVASE;
        SqlDataReader leer_ENVASE_KILOS;
       
       
        DataTable tabla1 = new DataTable();
        DataTable tabla2 = new DataTable();
        DataTable tabla3 = new DataTable();
        DataTable tabla4 = new DataTable();//E 
        DataTable tabla5 = new DataTable();//E K

        
        SqlCommand comando1 = new SqlCommand();
        SqlCommand comando2 = new SqlCommand();
        SqlCommand comando3 = new SqlCommand();// update mix d
        SqlCommand comando4 = new SqlCommand(); //COMPARACION
        SqlCommand comando5 = new SqlCommand(); //update precio liq
        SqlCommand comando6 = new SqlCommand(); //ENVASE
        SqlCommand comando7 = new SqlCommand(); //ENVASE-KILOS




        //CALCULAR
        public DataTable Mostrar_ENVASE()
        {

            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "MostrarProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //leer = comando.ExecuteReader();
            //tabla.Load(leer);
            //conexion.CerrarConexion();
            //return tabla; 


            comando6.Connection = conexion.AbrirConexion();
            comando6.CommandText = "SPENVASE";
            comando6.CommandType = CommandType.StoredProcedure;
           // comando6.Parameters.AddWithValue("@_COD_ENVOP", COD_ENVOP);
            leer_ENVASE = comando6.ExecuteReader();
            tabla4.Load(leer_ENVASE);
            conexion.CerrarConexion();
            return tabla4;





        }
        
        public DataTable Mostrar_ENVASE_KILOS(string COD_ENVOP)
        {

            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "MostrarProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //leer = comando.ExecuteReader();
            //tabla.Load(leer);
            //conexion.CerrarConexion();
            //return tabla; 


            comando7.Connection = conexion.AbrirConexion();
            comando7.CommandText = "SPCALCULARCAJAS";
            comando7.CommandType = CommandType.StoredProcedure;
            comando7.Parameters.AddWithValue("@_COD_ENVOP", COD_ENVOP);
            leer_ENVASE_KILOS = comando7.ExecuteReader();
            tabla5.Load(leer_ENVASE_KILOS);
            conexion.CerrarConexion();
            return tabla5;





        }







        public DataTable Mostrar_MIXDESPACHOS(string COD_PRO) {

            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "MostrarProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //leer = comando.ExecuteReader();
            //tabla.Load(leer);
            //conexion.CerrarConexion();
            //return tabla; 


            comando1.Connection = conexion.AbrirConexion();
            comando1.CommandText = "SPCONSULTAMIXDESPACHOS";
            comando1.CommandType = CommandType.StoredProcedure;
            comando1.Parameters.AddWithValue("@_COD_PRO", COD_PRO);
            leer_MIXDESPACHO = comando1.ExecuteReader();
            tabla1.Load(leer_MIXDESPACHO);
            conexion.CerrarConexion();
            return tabla1;





        }

        public DataTable Mostrar_PRECIOLIQ(string COD_PRO_)
        {

            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "MostrarProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //leer = comando.ExecuteReader();
            //tabla.Load(leer);
            //conexion.CerrarConexion();
            //return tabla; 
            comando2.Connection = conexion.AbrirConexion();
            comando2.CommandText = "SPCONSULTAPRECIOLIQ";
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@_COD_PRO", COD_PRO_);
            leer_PRECIO = comando2.ExecuteReader();
            tabla2.Load(leer_PRECIO);
            conexion.CerrarConexion();
            return tabla2;

        }


        public DataTable Mostrar_Validar(string COD_PRO_, string LOTE_)
        {

            comando4.Connection = conexion.AbrirConexion();
            comando4.CommandText = "SPCOMPARARTEST";
            comando4.CommandType = CommandType.StoredProcedure;
            comando4.Parameters.AddWithValue("@_PRODUCTOR", COD_PRO_);
            comando4.Parameters.AddWithValue("@_LOTE", LOTE_);
            leer_COMPARACION = comando4.ExecuteReader();
            tabla3.Load(leer_COMPARACION);
            conexion.CerrarConexion();
            return tabla3;


        }


        //public DataTable Mostrar_MIXDESPACHOSxLOTE(string _LOTE)
        //{

        //    //comando.Connection = conexion.AbrirConexion();
        //    //comando.CommandText = "MostrarProductos";
        //    //comando.CommandType = CommandType.StoredProcedure;
        //    //leer = comando.ExecuteReader();
        //    //tabla.Load(leer);
        //    //conexion.CerrarConexion();
        //    //return tabla; 


        //    comando3.Connection = conexion.AbrirConexion();
        //    comando3.CommandText = "SPBUSCADORxLOTE";
        //    comando3.CommandType = CommandType.StoredProcedure;
        //    comando3.Parameters.AddWithValue("@_LOTE", _LOTE);
        //    leer_MIXDESPACHOxLOTE = comando3.ExecuteReader();
        //    tabla2.Load(leer_MIXDESPACHOxLOTE);
        //    conexion.CerrarConexion();
        //    return tabla2;


        //}

        //public void Insertar(string nombre,string desc,string marca,double precio, int stock ) {
        //    //PROCEDIMNIENTO

        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "InsetarProductos";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@nombre",nombre);
        //    comando.Parameters.AddWithValue("@descrip",desc);
        //    comando.Parameters.AddWithValue("@Marca",marca);
        //    comando.Parameters.AddWithValue("@precio",precio);
        //    comando.Parameters.AddWithValue("@stock",precio);

        //    comando.ExecuteNonQuery();

        //    comando.Parameters.Clear();

        //}



        //public void Eliminar(int id) {
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "EliminarProducto";
        //    comando.CommandType = CommandType.StoredProcedure;

        //    comando.Parameters.AddWithValue("@idpro",id);

        //    comando.ExecuteNonQuery();

        //    comando.Parameters.Clear();
        //}




        public void Editar(string LOTE, string DONDE_COD_PRO, string SETEAR_COD_PRO, string COD_VAR, string SEMANA, string CORRELATIVO, string CAJAS)
        {

            comando3.Connection = conexion.AbrirConexion();
            comando3.CommandText = "SPCUADRATURAMIXD";
            comando3.CommandType = CommandType.StoredProcedure;
            comando3.Parameters.AddWithValue("@_LOTE", LOTE);
            comando3.Parameters.AddWithValue("@_DONDE_COD_PRO", DONDE_COD_PRO);
            comando3.Parameters.AddWithValue("@_SETEAR_COD_PRO", SETEAR_COD_PRO);
            comando3.Parameters.AddWithValue("@_COD_VAR", COD_VAR);
            comando3.Parameters.AddWithValue("@_SEMANA", SEMANA);
            comando3.Parameters.AddWithValue("@_CORRELATIVO", CORRELATIVO);
            comando3.Parameters.AddWithValue("@_CAJAS", CAJAS);
            //comando.Parameters.AddWithValue("@",id);

            comando3.ExecuteNonQuery();

            comando3.Parameters.Clear();  
        }


        public void Editar_PrecioLiq(string LOTE_LIQ, string DONDE_COD_PRO_LIQ, string SETEAR_COD_PRO_LIQ, string COD_VAR_LIQ, string CAJAS_LIQ, string CORRELATIVO_LIQ)
        {

            comando5.Connection = conexion.AbrirConexion();
            comando5.CommandText = "SPCUADRATURAPRECIOLIQ";
            comando5.CommandType = CommandType.StoredProcedure;
            comando5.Parameters.AddWithValue("@_LOTE", LOTE_LIQ);
            comando5.Parameters.AddWithValue("@_DONDE_COD_PRO", DONDE_COD_PRO_LIQ);
            comando5.Parameters.AddWithValue("@_SETEAR_COD_PRO", SETEAR_COD_PRO_LIQ);
            comando5.Parameters.AddWithValue("@_COD_VAR", COD_VAR_LIQ);
            comando5.Parameters.AddWithValue("@_CAJAS", CAJAS_LIQ);
            comando5.Parameters.AddWithValue("@_IDPRECIOLIQ", CORRELATIVO_LIQ);

            comando5.ExecuteNonQuery();

            comando5.Parameters.Clear();
        }




    }
}
