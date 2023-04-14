using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

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
        
        
        
        public DataTable MostrarTABLAMIXDESPACHOSxLOTE(string _LOTE)
        {

            DataTable tabla2 = new DataTable();
            tabla2 = objetoCD.Mostrar_MIXDESPACHOSxLOTE(_LOTE);
            return tabla2;
        }









        //    public void InsertarPRod ( string nombre,string desc,string marca,string precio, string stock){

        //        objetoCD.Insertar(nombre,desc,marca,Convert.ToDouble(precio),Convert.ToInt32(stock));
        //}

        public void EditarProd(string LOTE, string DONDE_COD_PRO, string SETEAR_COD_PRO, string COD_VAR, string SEMANA, string CORRELATIVO, string CAJAS)
        {
            //objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));

            objetoCD.Editar(LOTE, DONDE_COD_PRO, SETEAR_COD_PRO, COD_VAR, SEMANA, CORRELATIVO, CAJAS);
        }

        //public void EliminarPRod(string id) {

        //    objetoCD.Eliminar(Convert.ToInt32(id));
        //}

    }
}
