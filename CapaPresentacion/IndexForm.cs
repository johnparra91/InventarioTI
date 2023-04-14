using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaPresentacion
{
    public partial class IndexForm : Form
    {

        public IndexForm()
        {
            InitializeComponent();

        }

        private void cuadraturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                var secondaryForm = new Form1();
                secondaryForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
                secondaryForm.Show();

            }
        }
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {



            // Cierra el formulario Index
            this.Close();

            // Crea una nueva instancia del formulario de autenticación y lo muestra
            LoginForm formLogin = new LoginForm();
            formLogin.Show();


        }

        private void inventarioTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AbrirInventoryTIForm = new InventoryTICForm();
            AbrirInventoryTIForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            AbrirInventoryTIForm.Show();




        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryUserForm formuser = new InventoryUserForm();
            formuser.Show();
        }

        private void crearAsignacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            InventoryAssignmentForm formassignment = new InventoryAssignmentForm();
            formassignment.Show();


        }

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var AbrirInventoryTIForm = new InventoryTICForm();
            AbrirInventoryTIForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            AbrirInventoryTIForm.Show();

        }

        private void moverCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var secondaryForm = new Form1();
            secondaryForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            secondaryForm.Show();
        }

        private void creaItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var abrirCaracteristicasForm = new CaracteristicasPCForm();
            abrirCaracteristicasForm.Owner = this; // Establece a MainForm como el propietario de SecondaryForm
            abrirCaracteristicasForm.Show();





        }

        private void creaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                var abrirMantenedorLoginForm = new Form2();
                abrirMantenedorLoginForm.Owner = this;
                abrirMantenedorLoginForm.Show();
            }
            catch (System.ObjectDisposedException ex)
            {
               Console.WriteLine("No tiene autorización para acceder a esta función. Por favor, contacte a su administrador.");
                
            }






        }
    }
}
