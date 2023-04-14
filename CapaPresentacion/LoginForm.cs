using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaNegocio.CN_Productos;

namespace CapaPresentacion
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }




        private void BtnSalirLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }






        public string GenerateHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }









        public void Login()
        {


            //// Muestra la barra de progreso y establece su valor en 0
            //progressBar1.Visible = true;
            //progressBar1.Value = 0;

            //// Realiza la consulta en la base de datos
            //using (var dbContext = new MyDbContext())
            //{
            //    var usuario = dbContext.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtIniciaSesionUsuario.Text);
            //    if (usuario != null && usuario.Password == GenerateHash(TxtIniciaSesionContraseña.Text))
            //    {
            //        // Actualiza el valor de la barra de progreso a 100 y muestra el mensaje de éxito
            //        progressBar1.Value = 100;
            //        MessageBox.Show("Inicio Sesion");

            //        IndexForm indexForm = new IndexForm();
            //        indexForm.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        // Actualiza el valor de la barra de progreso a 100 y muestra el mensaje de error
            //        progressBar1.Value = 100;
            //        MessageBox.Show("Error al Iniciar Sesión");
            //    }
            //}

            //// Oculta la barra de progreso
            //progressBar1.Visible = false;




            // Muestra la barra de progreso y establece su valor en 0
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            // Realiza la consulta en la base de datos
            using (var dbContext = new MyDbContext())
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtIniciaSesionUsuario.Text);
                if (usuario != null && usuario.Password == GenerateHash(TxtIniciaSesionContraseña.Text))
                {
                    Sesion.NombreDeUsuario = usuario.NombreDeUsuario;
                    // Verifica si el usuario tiene permiso de acceso al formulario correspondiente
                    var permiso = dbContext.Permisos.FirstOrDefault(p => p.IdUsuario == usuario.Id && p.formulario == "IndexForm");
                    if (permiso != null && permiso.permiso)
                    {
                        // Actualiza el valor de la barra de progreso a 100 y muestra el mensaje de éxito
                        progressBar1.Value = 100;
                        MessageBox.Show("Inicio Sesion");

                        IndexForm indexForm = new IndexForm();
                        indexForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Actualiza el valor de la barra de progreso a 100 y muestra el mensaje de error
                        progressBar1.Value = 100;
                        MessageBox.Show("No tiene permiso de acceso a este formulario");
                    }
                }
                else
                {
                    // Actualiza el valor de la barra de progreso a 100 y muestra el mensaje de error
                    progressBar1.Value = 100;
                    MessageBox.Show("Error al Iniciar Sesión");
                }
            }

            // Oculta la barra de progreso
            progressBar1.Visible = false;







        }



        public class MyDbContext : DbContext
        {
            public MyDbContext() : base("Data Source=192.168.1.4;Initial Catalog=Identity;User Id=sa;Password=Passw0rd..;")
            {
            }

            public bool TienePermisoDeAcceso(int usuarioId, string formulario)
            {
                var permiso = Permisos.FirstOrDefault(p => p.IdUsuario == usuarioId && p.formulario == formulario);
                return permiso != null && permiso.permiso;
            }

            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Permisos_Formularios> Permisos { get; set; }
        }
    




        public class Usuario
        {
            public int Id { get; set; }
            public string NombreDeUsuario { get; set; }
            public string Password { get; set; }
        }


        public class Permisos_Formularios
        {
            [Key]
            public int IdUsuario { get; set; }

            public string formulario { get; set; }

            public bool permiso { get; set; }
        }







        private void btnIniciaLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    
    }
}
