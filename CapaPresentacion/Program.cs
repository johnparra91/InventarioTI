using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new LoginForm());     // Produccion
           // Application.Run(new InventoryTICForm());
            //  Application.Run(new Form2());
          // Application.Run(new IndexForm());
                 
            
            // Application.Run(new InventoryAssignmentForm());
           // Application.Run(new CaracteristicasPCForm());
        }
    }
}
