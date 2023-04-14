using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static CapaPresentacion.CaracteristicasPCForm;
using System.Data.Entity.Infrastructure;

namespace CapaPresentacion
{
    public partial class InventoryTICForm : Form
    {
        public InventoryTICForm()
        {
            InitializeComponent();


       



            Mostrar_DISPOSITIVOSCREADOS();

        }







        public class MyDbContextEliminarPC : DbContext
        {
            public MyDbContextEliminarPC() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }


            public DbSet<DISPAUSU> EliminarPC { get; set; }
        }

        [Table("DISPAUSU")]
        public class DISPAUSU
        {

            [Key]
            public int ID_DISPAUSU { get; set; }
            public string COD_PC { get; set; }
            public string COD_USUARIO { get; set; }
            public int NUM_ACTA { get; set; }
            public int ENVIADO { get; set; }
            public int ASIGNADO { get; set; }

            public DateTime? FECHA_ASIGNACION { get; set; }
            public DateTime? FECHA_DEVOLUCION { get; set; }

            public byte[] ACTA_PDF { get; set; }


        }




        public class MyDbContextUsuarios : DbContext
        {
            public MyDbContextUsuarios() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

            public DbSet<USUARIOS_PC> UsuariosDATOS { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<USUARIOS_PC>().ToTable("USUARIOS_PC");
                base.OnModelCreating(modelBuilder);
            }
        }


        public class USUARIOS_PC
        {

            [Key]
            //  public int ID_USU { get; set; }
            public string COD_USUARIO { get; set; }
            public string NOMBRES { get; set; }
            public string APELLIDOS { get; set; }
            public string AREA { get; set; }
            public string EMAIL { get; set; }




        }



        public class MyDbContextCaracteristicasPC : DbContext
        {
            public MyDbContextCaracteristicasPC() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }
            public DbSet<TIPOPC> MostrarTipoPC { get; set; }
            public DbSet<RAM> MostrarRAM { get; set; }
            public DbSet<PROCESADORES> MostrarPROCESADOR { get; set; }
            public DbSet<TIPOSDISCOS> MostrarTIPODISCO { get; set; }
            public DbSet<SISTEMA_OPERATIVO> MostrarSO { get; set; }
            public DbSet<CAPACIDAD_DISCOS> MostrarCAPACIDAD_DISCOS { get; set; }
        }



        [Table("TIPOPC")]
        public class TIPOPC
        {

            [Key]
            public int ID_Caract_PC { get; set; }
            public string Tipo_PC { get; set; }


        }


        [Table("RAM")]
        public class RAM
        {

            [Key]
            public int ID_RAM { get; set; }
            public int CAPACIDAD_RAM { get; set; }


        }


        [Table("PROCESADORES")]
        public class PROCESADORES
        {

            [Key]
            public int ID_PROC { get; set; }
            public String PROCESADOR { get; set; }


        }

        [Table("TIPOSDISCOS")]
        public class TIPOSDISCOS
        {

            [Key]
            public int ID_TIPDISCO { get; set; }
            public String TIPO_DISCO { get; set; }


        }

        [Table("SISTEMA_OPERATIVO")]
        public class SISTEMA_OPERATIVO
        {

            [Key]
            public int ID_OS { get; set; }
            public String SO { get; set; }


        }
        [Table("CAPACIDAD_DISCOS")]
        public class CAPACIDAD_DISCOS
        {

            [Key]
            public int ID_CAPDISCO { get; set; }
            public int CAPACIDAD_DISCO { get; set; }


        }







        private void BtnEliminarDispositivoTI_Click(object sender, EventArgs e)
        {

            if (dataGridViewDispositivos.SelectedRows.Count > 0) // verifica si hay al menos una fila seleccionada
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar el dispositivo?", "Confirmar eliminación",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string cod_pc = dataGridViewDispositivos.SelectedRows[0].Cells["COD_PC"].Value.ToString();



                    using (var db = new MyDbContextTI())
                    {
                        DISPOSITIVOS dispositivo = db.TIDATOS.Where(d => d.COD_PC == cod_pc).FirstOrDefault();
                        if (dispositivo != null)
                        {
                            // Crear una instancia del contexto MyDbContextEliminarPC
                            using (var eliminarPCContext = new MyDbContextEliminarPC())
                            {
                                // Consulta la tabla 'DISPAUSU' utilizando el contexto MyDbContextEliminarPC
                                var asignaciones = eliminarPCContext.EliminarPC.Where(x => x.COD_PC == dispositivo.COD_PC).ToList();

                                if (asignaciones.Count > 0)
                                {
                                    // Si hay dispositivos asignados, obtén el COD_USUARIO de la primera asignación
                                    var asignacion = asignaciones.First();
                                    string cod_usuario = asignacion.COD_USUARIO;

                                    // Busca la información del usuario utilizando el contexto MyDbContextUsuarios
                                    using (var usuariosContext = new MyDbContextUsuarios())
                                    {
                                        var usuario = usuariosContext.UsuariosDATOS.FirstOrDefault(u => u.COD_USUARIO == cod_usuario);

                                        if (usuario != null)
                                        {
                                            var nombreUsuario = $"{usuario.NOMBRES} {usuario.APELLIDOS}";
                                            MessageBox.Show($"Este dispositivo está asignado a {nombreUsuario}. Verifique y vuelva a intentar.");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Este dispositivo está asignado a un usuario desconocido. Verifique y vuelva a intentar.");
                                        }
                                    }
                                }
                                else
                                {
                                    // Si no hay dispositivos asignados, elimina el usuario
                                    db.TIDATOS.Remove(dispositivo);
                                    db.SaveChanges();
                                    MessageBox.Show("Dispositivo eliminado exitosamente");
                                }
                            }
                        }
                    }




                    Mostrar_DISPOSITIVOSCREADOS();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar", "Seleccionar fila",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }



        public async Task Mostrar_DISPOSITIVOSCREADOS()
        {
           
            using (var db = new MyDbContextTI())
            {
                var datos = await db.Database.SqlQuery<DISPOSITIVOS>("sp_MostrarDispositivos").ToListAsync();
                dataGridViewDispositivos.DataSource = datos;
                dataGridViewDispositivos.DefaultCellStyle.BackColor = Color.LightBlue;
              //  dataGridViewDispositivos.Columns["ID_DIS"].Visible = false;

            }


        }





        public class MyDbContextTI : DbContext
        {
            public MyDbContextTI() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

            public DbSet<DISPOSITIVOS> TIDATOS { get; set; }
        }


        public class DISPOSITIVOS
        {

            [Key]
            public int ID_DIS { get; set; }

            [Index(IsUnique = true)]
            public string COD_PC { get; set; }
            public string SERIAL { get; set; }
            public string TIPO { get; set; }
            public string PROCESADOR { get; set; }
            public int RAM { get; set; }
            public string TIPO_DISCO { get; set; }
            public int CAPACIDAD_DISCO { get; set; }
            public string SISTEMA_OPERATIVO { get; set; }
            public string MODELO { get; set; }
            public string MAC_LAN { get; set; }
            public string MAC_WIFI { get; set; }
            public DateTime? FECHA_CREACION { get; set; }
            public DateTime? FECHA_ASIGNACION { get; set; }
            public DateTime? FECHA_DEVOLUCION { get; set; }

        }

        private void dataGridViewDispositivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.LightCyan;
            }
            else
            {
                e.CellStyle.BackColor = Color.LightSteelBlue;
            }


        }






        public void ObtenerDatosListaTemporal()
        {

            // Crear un nuevo formulario temporal
            Form formTemp = new Form();
            formTemp.Text = "Agregar nuevo dispositivo";

            // Personalizar el tamaño del formulario temporal
            formTemp.StartPosition = FormStartPosition.CenterParent;
            formTemp.Size = new Size(280, 500);
            


                                                            // Crear los TextBox correspondientes a cada propiedad de DatosTI
                                                            TextBox txtCodPc = new TextBox();
                                                          
                                                            TextBox txtSerial = new TextBox();
                                                        
                                                            ComboBox ComboTipo = new ComboBox();
                                                            ComboBox ComboProcesador = new ComboBox();
                                                            ComboBox ComboRam = new ComboBox();
                                                            ComboBox ComboTipoDisco = new ComboBox();
                                                            ComboBox ComboCapacidadDisco = new ComboBox();
                                                            ComboBox ComboSistemaOperativo = new ComboBox();
                                                            TextBox txtModelo = new TextBox();
                                                            TextBox txtMacLan = new TextBox();
                                                            TextBox txtMacWifi = new TextBox();





            //// eventos de textbox para el focus se escriben usando keydown
            /////// y ademas se llama al evento focus del formulario temporal
            formTemp.Load += (sender, e) =>
            {
                txtCodPc.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtSerial.Focus();
                };           

                txtSerial.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboTipo.Focus();
                };

                ComboTipo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboProcesador.Focus();
                };

                ComboProcesador.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboRam.Focus();
                };

                ComboRam.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboTipoDisco.Focus();
                };

                ComboTipoDisco.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboCapacidadDisco.Focus();
                };

                ComboCapacidadDisco.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        ComboSistemaOperativo.Focus();
                };

                ComboSistemaOperativo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtModelo.Focus();
                };

                txtModelo.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtMacLan.Focus();
                };

                txtMacLan.KeyDown += (s, evt) =>
                {
                    if (evt.KeyCode == Keys.Enter)
                        txtMacWifi.Focus();
                };
            };






                                                            // Crear las etiquetas correspondientes para cada TextBox
                                                            Label lblCodPc = new Label();
                                                         
                                                            Label lblSerial = new Label();
                                                       
                                                            Label lblTipo = new Label();
                                                            Label lblProcesador = new Label();
                                                            Label lblRam = new Label();
                                                            Label lblTipoDisco = new Label();
                                                            Label lblCapacidadDisco = new Label();
                                                            Label lblSistemaOperativo = new Label();
                                                            Label lblModelo = new Label();
                                                            Label lblMacLan = new Label();
                                                            Label lblMacWifi = new Label();

                                                            // Agregar los TextBox y las etiquetas al formulario
                                                            formTemp.Controls.Add(lblCodPc);
                                                            formTemp.Controls.Add(txtCodPc);
                                                           
                                                            formTemp.Controls.Add(lblSerial);
                                                            formTemp.Controls.Add(txtSerial);
                                                        
                                                            formTemp.Controls.Add(lblTipo);
                                                            formTemp.Controls.Add(ComboTipo);
                                                            formTemp.Controls.Add(lblProcesador);
                                                            formTemp.Controls.Add(ComboProcesador);
                                                            formTemp.Controls.Add(lblRam);
                                                            formTemp.Controls.Add(ComboRam);
                                                            formTemp.Controls.Add(lblTipoDisco);
                                                            formTemp.Controls.Add(ComboTipoDisco);
                                                            formTemp.Controls.Add(lblCapacidadDisco);
                                                            formTemp.Controls.Add(ComboCapacidadDisco);
                                                            formTemp.Controls.Add(lblSistemaOperativo);
                                                            formTemp.Controls.Add(ComboSistemaOperativo);
                                                            formTemp.Controls.Add(lblModelo);
                                                            formTemp.Controls.Add(txtModelo);
                                                            formTemp.Controls.Add(lblMacLan);
                                                            formTemp.Controls.Add(txtMacLan);
                                                            formTemp.Controls.Add(lblMacWifi);
                                                            formTemp.Controls.Add(txtMacWifi);

                                                            // Establecer el texto de las etiquetas
                                                            lblCodPc.Text = "Código PC:";
                                                          
                                                            lblSerial.Text = "Serial:";
                                                         
                                                            lblTipo.Text = "Tipo:";
                                                            lblProcesador.Text = "Procesador:";
                                                            lblRam.Text = "RAM (GB):";
                                                            lblTipoDisco.Text = "Tipo de disco:";
                                                            lblCapacidadDisco.Text = "Cap. de disco (MB):";
                                                            lblSistemaOperativo.Text = "Sistema Operativo:";
                                                            lblModelo.Text = "Modelo:";
                                                            lblMacLan.Text = "MAC LAN:";
                                                            lblMacWifi.Text = "MAC WIFI:";



                                                                                    // Establecer la posición de las etiquetas y los cuadros de texto
                                                                                    lblCodPc.SetBounds(10, 10, 100, 20);
                                                                                    txtCodPc.SetBounds(lblCodPc.Right + 10, 10, 100, 20);

                                                                                    lblSerial.SetBounds(10, 40, 100, 20);
                                                                                    txtSerial.SetBounds(lblSerial.Right + 10, 40, 100, 20);

                                                                                    lblTipo.SetBounds(10, 70, 100, 20);
                                                                                    ComboTipo.SetBounds(lblTipo.Right + 10, 70, 100, 100);

                                                                                    lblProcesador.SetBounds(10, 100, 100, 20);
                                                                                    ComboProcesador.SetBounds(lblProcesador.Right + 10, 100, 100, 20);

                                                                                    lblRam.SetBounds(10, 130, 100, 20);
                                                                                    ComboRam.SetBounds(lblRam.Right + 10, 130, 100, 20);

                                                                                    lblTipoDisco.SetBounds(10, 160, 100, 20);
                                                                                    ComboTipoDisco.SetBounds(lblTipoDisco.Right + 10, 160, 100, 20);

                                                                                    lblCapacidadDisco.SetBounds(10, 190, 100, 20);
                                                                                    ComboCapacidadDisco.SetBounds(lblCapacidadDisco.Right + 10, 190, 100, 20);

                                                                                    lblSistemaOperativo.SetBounds(10, 220, 100, 20);
                                                                                    ComboSistemaOperativo.SetBounds(lblSistemaOperativo.Right + 10, 220, 100, 20);

                                                                                    lblModelo.SetBounds(10, 250, 100, 20);
                                                                                    txtModelo.SetBounds(lblModelo.Right + 10, 250, 100, 20);

                                                                                    lblMacLan.SetBounds(10, 280, 100, 20);
                                                                                    txtMacLan.SetBounds(lblMacLan.Right + 10, 280, 100, 20);

                                                                                    lblMacWifi.SetBounds(10, 310, 100, 20);
                                                                                    txtMacWifi.SetBounds(lblMacWifi.Right + 10, 310, 100, 20);


            using (var db = new MyDbContextCaracteristicasPC())
            {
                // Obtener los valores de la columna "Tipo_PC" de la tabla "TIPOPC"
                var tipoPc = db.MostrarTipoPC.Select(tp => tp.Tipo_PC).ToList();

                // Asignar los valores al ComboBox ComboTipo
                ComboTipo.DataSource = tipoPc;
            }
            
            using (var db = new MyDbContextCaracteristicasPC())
            {
               
                var procesador = db.MostrarPROCESADOR.Select(tp => tp.PROCESADOR).ToList();

                ComboProcesador.DataSource = procesador;
            }

            using (var db = new MyDbContextCaracteristicasPC())
            {
               
                var ram = db.MostrarRAM.Select(tp => tp.CAPACIDAD_RAM).ToList();

                ComboRam.DataSource = ram;
            }
            
            using (var db = new MyDbContextCaracteristicasPC())
            {
               
                var tipodisco = db.MostrarTIPODISCO.Select(tp => tp.TIPO_DISCO).ToList();

             
                ComboTipoDisco.DataSource = tipodisco;
            }

            using (var db = new MyDbContextCaracteristicasPC())
            {
               
                var capdisco = db.MostrarCAPACIDAD_DISCOS.Select(tp => tp.CAPACIDAD_DISCO).ToList();

                // Asignar los valores al ComboBox ComboTipo
                ComboCapacidadDisco.DataSource = capdisco;
            }
            
            using (var db = new MyDbContextCaracteristicasPC())
            {
               
                var so = db.MostrarSO.Select(tp => tp.SO).ToList();

                // Asignar los valores al ComboBox ComboTipo
                ComboSistemaOperativo.DataSource = so;
            }




            // Suscribirse al evento TextChanged
            txtMacLan.TextChanged += TxtMac_TextChanged;
            txtMacWifi.TextChanged += TxtMac_TextChanged;

            void TxtMac_TextChanged(object sender, EventArgs e)
            {
                TextBox txtMac = sender as TextBox;
                if (txtMac == null) return;

                // Expresión regular para validar una dirección MAC
                string macPattern = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";

                // Verifica si la dirección MAC es válida
                bool isValidMac = Regex.IsMatch(txtMac.Text, macPattern);

                // Cambiar el color de fondo del TextBox según la validez de la dirección MAC
                txtMac.BackColor = isValidMac ? Color.White : Color.LightCoral;
            }



            // Crear un botón gUARDAR 
            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // Agregar el sbotón al formulario
            formTemp.Controls.Add(btnGuardar);

            // Establecer la posición 
            btnGuardar.SetBounds((formTemp.ClientSize.Width - btnGuardar.Width) / 2, 390, 80, 25);

            // Función que se ejecutará cuando se haga clic en el segundo botón
            async void btnGuardar_Click(object sender, EventArgs e)
            {


                // Expresión regular para validar una dirección MAC
                string macPattern = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
                bool isValidMacLan = Regex.IsMatch(txtMacLan.Text, macPattern);
                bool isValidMacWifi = Regex.IsMatch(txtMacWifi.Text, macPattern);

                if (!isValidMacLan || !isValidMacWifi)
                {
                    MessageBox.Show("Corregir las direcciones MAC antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var db = new MyDbContextTI())
                {
                    DISPOSITIVOS dispositivo = new DISPOSITIVOS
                    {
                        COD_PC = txtCodPc.Text,
                        //COD_USUARIO = txtCodUsuario.Text,
                        //NOMBRE_USUARIO = txtNombreUsuario.Text,
                        SERIAL = txtSerial.Text,
                    //    AREA = txtArea.Text,
                        TIPO = ComboTipo.Text,
                        PROCESADOR = ComboProcesador.Text,
                        RAM = int.Parse(ComboRam.Text),
                        TIPO_DISCO = ComboTipoDisco.Text,
                        CAPACIDAD_DISCO = int.Parse(ComboCapacidadDisco.Text),
                        SISTEMA_OPERATIVO = ComboSistemaOperativo.Text,
                        MODELO = txtModelo.Text,
                        MAC_LAN = txtMacLan.Text,
                        MAC_WIFI = txtMacWifi.Text,
                        FECHA_CREACION = DateTime.Now
                    };

                    db.TIDATOS.Add(dispositivo);
                    db.SaveChanges();
                }




                // Mostrar el mensaje al usuario y preguntar si desea limpiar los controles
                var result = MessageBox.Show("Dispositivo registrado con éxito. ¿Desea limpiar los controles?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario selecciona "Sí", limpiar los controles del formulario temporal
                if (result == DialogResult.Yes)
                {
                    foreach (Control control in formTemp.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox textBox = (TextBox)control;
                            textBox.Clear();
                        }
                    }
                }

                // Actualizar la lista de dispositivos
                await Mostrar_DISPOSITIVOSCREADOS();


            }








            // Crear un botón CANCELAR y establecer sus propiedades
            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.DialogResult = DialogResult.OK;

            // Agregar el botón al formulario
            formTemp.Controls.Add(btnCancelar);

            // Establecer la posición del botón
            btnCancelar.SetBounds((formTemp.ClientSize.Width - btnCancelar.Width) / 2, 420, 80, 25);




            ////////////// MOSTRAR EL FORMULARIO TEMPORAL
            formTemp.ShowDialog();










          






        }








      
        private void BtnGrabarDispositivoTI_Click(object sender, EventArgs e)
            {

            ObtenerDatosListaTemporal();
   
            }


        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDispositivos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {



            // Obtener la fila editada
            DataGridViewRow row = dataGridViewDispositivos.Rows[e.RowIndex];

          
            DISPOSITIVOS dispositivo = (DISPOSITIVOS)row.DataBoundItem;

           
            dispositivo.COD_PC = row.Cells["COD_PC"].Value.ToString();
      
            dispositivo.SERIAL = row.Cells["SERIAL"].Value.ToString();
      
            dispositivo.TIPO = row.Cells["TIPO"].Value.ToString();
            dispositivo.PROCESADOR = row.Cells["PROCESADOR"].Value.ToString();
            dispositivo.RAM = int.Parse(row.Cells["RAM"].Value.ToString());
            dispositivo.TIPO_DISCO = row.Cells["TIPO_DISCO"].Value.ToString();
            dispositivo.CAPACIDAD_DISCO = int.Parse(row.Cells["CAPACIDAD_DISCO"].Value.ToString());
            dispositivo.SISTEMA_OPERATIVO = row.Cells["SISTEMA_OPERATIVO"].Value.ToString();
            dispositivo.MODELO = row.Cells["MODELO"].Value.ToString();
            dispositivo.MAC_LAN = row.Cells["MAC_LAN"].Value.ToString();
            dispositivo.MAC_WIFI = row.Cells["MAC_WIFI"].Value.ToString();

            using (var db = new MyDbContextTI())
            {
                   db.Entry(dispositivo).State = EntityState.Modified;
                    db.SaveChanges();
            }



        }

        private void dataGridViewDispositivos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (e.ColumnIndex ==1) // la primera columna es el COD_PC
            {
                DialogResult result = MessageBox.Show("Va a asignar un codigo de PC. ¿Está seguro?", "Exclamación",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // cancela la edición
                }
            }

            if (e.ColumnIndex == 2) 
            {
                DialogResult result = MessageBox.Show("Va a modificar un serial. ¿Está seguro?", "Exclamación",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // cancela la edición
                }
            }




        }
    }
}
