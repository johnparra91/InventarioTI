using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.Entity;
using static CapaNegocio.CN_Productos;
using CapaNegocio;
using System.ComponentModel.DataAnnotations;

namespace CapaPresentacion
{
    public partial class Form2 : Form
    {

        CN_Productos objetoCN = new CN_Productos();


        public Form2()
        {
            InitializeComponent();
            ValidarPermisos();
        }



      async public void ValidarPermisos()
        {

            using (var dbContext = new MyDbContextPermisos())
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == Sesion.NombreDeUsuario);
                if (usuario != null && dbContext.TienePermisoDeAcceso(usuario.Id, "Form2"))
                {
                    // El usuario tiene permiso de acceso al formulario
                    // Carga los datos necesarios para el formulario
                }
                else
                {
                    // El usuario no tiene permiso de acceso al formulario
                    MessageBox.Show("No tiene autorización para acceder a esta función. Por favor, contacte a su administrador.", "Error de autorización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
        }



        }


        private void BtnCrea_Click(object sender, EventArgs e)
        {
            CrearUsuario();
        }

        private void BtnActualiza_Click(object sender, EventArgs e)
        {
            CambiarContraseña();
        }

        private void BtnElimina_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }





        private void btnIniciar_Click(object sender, EventArgs e)
        {




            //string connectionString = "Data Source=192.168.1.4;Initial Catalog=Identity;User Id=sa;Password=Passw0rd..;";
            //string query = "SELECT COUNT(*) FROM AspNetUsers WHERE UserName = @usuario AND PasswordHash = @contraseña";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //{
            //    command.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            //    command.Parameters.AddWithValue("@contraseña", txtContraseña.Text);

            //    connection.Open();

            //    int result = (int)command.ExecuteScalar();

            //    if (result > 0)
            //    {
            //        MessageBox.Show("Inicio de sesión exitoso");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Usuario o contraseña incorrectos");
            //    }
            //}













            //string connectionString = "Data Source=192.168.1.4;Initial Catalog=Identity;User Id=sa;Password=Passw0rd..;";
            //string query = "SELECT COUNT(*) FROM AspNetUsers WHERE UserName = @usuario AND PasswordHash = @contraseña";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //{
            //    command.Parameters.AddWithValue("@usuario", txtUsuario.Text);

            //    // calcular el hash de la contraseña ingresada
            //    string contraseñaHash = GetHashString(txtContraseña.Text);
            //    command.Parameters.AddWithValue("@contraseña", contraseñaHash);

            //    connection.Open();

            //    int result = (int)command.ExecuteScalar();

            //    if (result > 0)
            //    {
            //        MessageBox.Show("Inicio de sesión exitoso");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Usuario o contraseña incorrectos");
            //    }
            //}












            using (var dbContext = new MyDbContextPermisos())
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtIniciaSesionUsuario.Text && u.Password == TxtIniciaSesionContraseña.Text);
                if (usuario != null)
                {

                    MessageBox.Show("Inicio Sesion");


                }
                else
                {

                    MessageBox.Show("Error al Iniciar Sesión");

                }
            }










        }





        public class MyDbContextPermisos : DbContext
        {
            public MyDbContextPermisos() : base("Data Source=192.168.1.4;Initial Catalog=Identity;User Id=sa;Password=Passw0rd..;")
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


        public void CrearUsuario()


        {

            using (var db = new MyDbContextPermisos())
            {
            
                                        if (string.IsNullOrEmpty(TxtCreaUsuario.Text))
                                        {
                                            MessageBox.Show("El nombre de usuario es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        if (string.IsNullOrEmpty(TxtCreaContraseña.Text))
                                        {
                                            MessageBox.Show("La contraseña es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                
                // Buscar si ya existe un usuario con el mismo nombre de usuario
                var usuarioExistente = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtCreaUsuario.Text);

                // Si el usuario ya existe, mostrar un mensaje de error y salir del método
                if (usuarioExistente != null)
                {
                    MessageBox.Show("El nombre de usuario ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si el usuario no existe, crear el nuevo usuario
                var nuevoUsuario = new Usuario
                {
                    NombreDeUsuario = TxtCreaUsuario.Text,
                    Password = GenerateHash(TxtCreaContraseña.Text)
                };
                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }









        ///////////////////////////////////////  HASH /////

        //public void CrearUsuario()
        //{
        //    using (var db = new MyDbContext())
        //    {
        //        var nuevoUsuario = new Usuario
        //        {
        //            NombreDeUsuario = TxtCreaUsuario.Text,               //"usuario1",
        //            Password = GenerateHash(TxtCreaContraseña.Text)      // Generar hash de la contraseña
        //        };
        //        db.Usuarios.Add(nuevoUsuario);
        //        db.SaveChanges();
        //    }
        //}









        //public void CrearUsuario()

        //{
        //    using (var db = new MyDbContext())
        //    {
        //        var nuevoUsuario = new Usuario
        //        {
        //            NombreDeUsuario = TxtCreaUsuario.Text,               //"usuario1",
        //            Password = TxtCreaContraseña.Text                                         // "contraseña1"
        //        };
        //        db.Usuarios.Add(nuevoUsuario);
        //        db.SaveChanges();
        //    }
        //}



        public void MostrarUsuarios()
        {

            using (var db = new MyDbContextPermisos())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Id: {usuario.Id}, Nombre de usuario: {usuario.NombreDeUsuario}, Contraseña: {usuario.Password}");
                }
            }





        }























        public void CambiarContraseña()
        {
            using (var db = new MyDbContextPermisos())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtActualizaUsuario.Text);

                if (usuario != null)
                {
                    usuario.Password = GenerateHash(TxtActualizaContraseña.Text);
                    var cambiosRealizados = db.SaveChanges();

                    if (cambiosRealizados > 0)
                    {
                        MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la contraseña. Verifique que la contraseña actual sea correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }











        //public void CambiarContraseña()
        //{

        //    using (var db = new MyDbContext())
        //    {
        //        var usuario = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtActualizaUsuario.Text);                          //"usuario1");
        //        if (usuario != null)
        //        {
        //            usuario.Password = GenerateHash(TxtActualizaContraseña.Text);                                                                                               // "nueva_contraseña";
        //            db.SaveChanges();
        //        }
        //    }

        //}





































        public void EliminarUsuario()
        {
            using (var db = new MyDbContextPermisos())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtEliminaUsuario.Text);

                if (usuario == null)
                {
                    MessageBox.Show("El usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Preguntar al usuario si está seguro de que desea eliminar el registro
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma que desea eliminar el registro
                if (confirmacion == DialogResult.Yes)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();

                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TxtCreaUsuario_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCreaUsuario.Text))
            {
                TxtCreaUsuario.BackColor = Color.White;
            }
            else
            { 
                TxtCreaUsuario.BackColor= Color.Red;
            }
        }

        private void TxtCreaUsuario_Leave(object sender, EventArgs e)
        {
            TxtCreaUsuario.BackColor = Color.White;
        }








        //public void EliminarUsuario()
        //{
        //    // Preguntar al usuario si está seguro de que desea eliminar el registro
        //    var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar el usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    // Si el usuario confirma que desea eliminar el registro
        //    if (confirmacion == DialogResult.Yes)
        //    {
        //        using (var db = new MyDbContext())
        //        {
        //            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtEliminaUsuario.Text);
        //            if (usuario != null)
        //            {
        //                db.Usuarios.Remove(usuario);
        //                db.SaveChanges();

        //                MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //}






        //public void EliminarUsuario()
        //{


        //    using (var db = new MyDbContext())
        //    {
        //        var usuario = db.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == TxtEliminaUsuario.Text);                                                  //"usuario1");
        //        if (usuario != null)
        //        {
        //            db.Usuarios.Remove(usuario);
        //            db.SaveChanges();
        //        }
        //    }

        //}




        //// función para calcular el hash de una cadena utilizando SHA256
        //public static string GetHashString(string text)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(text);
        //    using (SHA256 hash = SHA256Managed.Create())
        //    {
        //        byte[] hashBytes = hash.ComputeHash(bytes);
        //        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        //    }
        //}




    }
}
