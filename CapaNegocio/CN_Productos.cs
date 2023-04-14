using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Runtime.Remoting.Contexts;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();
    
        public DataTable MostrarENVASE() {

            DataTable tabla4 = new DataTable();
            tabla4 = objetoCD.Mostrar_ENVASE();
            return tabla4;
        } 
        public DataTable MostrarENVASEKILOS(string COD_ENVOP) {

            DataTable tabla5 = new DataTable();
            tabla5 = objetoCD.Mostrar_ENVASE_KILOS(COD_ENVOP);
            return tabla5;
        }  
        
        public DataTable MostrarTABLAMIXDESPACHOS(string COD_PRO) {

            DataTable tabla1 = new DataTable();
            tabla1 = objetoCD.Mostrar_MIXDESPACHOS(COD_PRO);
            return tabla1;
        }


        public DataTable MostrarTABLAPRECIOLIQ(string COD_PRO_PRECIO)
        {

            DataTable tabla2 = new DataTable();
            tabla2 = objetoCD.Mostrar_PRECIOLIQ(COD_PRO_PRECIO);
            return tabla2;
        
        }

        public DataTable MostrarValidar(string COD_PRO_Validar, string LOTE_Validar)
        {


            DataTable tabla3 = new DataTable();
            tabla3 = objetoCD.Mostrar_Validar(COD_PRO_Validar, LOTE_Validar);
            return tabla3;


        }



        //public DataTable MostrarTABLAMIXDESPACHOSxLOTE(string _LOTE)
        //{

        //    DataTable tabla2 = new DataTable();
        //    tabla2 = objetoCD.Mostrar_MIXDESPACHOSxLOTE(_LOTE);
        //    return tabla2;
        //}



        //    public void InsertarPRod ( string nombre,string desc,string marca,string precio, string stock){

        //        objetoCD.Insertar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock));
        //}

        public void EditarProd(string LOTE, string DONDE_COD_PRO, string SETEAR_COD_PRO, string COD_VAR, string SEMANA, string CORRELATIVO, string CAJAS)
        {
            //objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));

            objetoCD.Editar(LOTE, DONDE_COD_PRO, SETEAR_COD_PRO, COD_VAR, SEMANA, CORRELATIVO, CAJAS);
        }

        public void EditarPrecio(string LOTE_LIQ, string DONDE_COD_PRO_LIQ, string SETEAR_COD_PRO_LIQ, string COD_VAR_LIQ, string CAJAS_LIQ, string CORRELATIVO_LIQ)
        {
            //objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));

            objetoCD.Editar_PrecioLiq(LOTE_LIQ, DONDE_COD_PRO_LIQ, SETEAR_COD_PRO_LIQ, COD_VAR_LIQ, CAJAS_LIQ, CORRELATIVO_LIQ);
        }


        //public void EliminarPRod(string id) {

        //    objetoCD.Eliminar(Convert.ToInt32(id));
        //}










        public static class Sesion
        {
            public static string NombreDeUsuario { get; set; }
        }

    }
}
