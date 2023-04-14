using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Windows.Media.Imaging;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace CapaPresentacion
{
    public partial class InventoryAssignmentForm : Form
    {
        public InventoryAssignmentForm()
        {
            InitializeComponent();

            //MostrarAsignaciones();
            LLENARCOMBOPC();
            LLENARCOMBOUSUARIOS();
            LlenarComboFirma1();
            MostrarAsignaciones();

        }
        //contexto

        public class MyDbContextAsignarPC : DbContext
        {
            public MyDbContextAsignarPC() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }


            public DbSet<DISPAUSU> ASIGNARUsuariosDATOS { get; set; }
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
            // public int ID_DIS { get; set; }

            // [Index(IsUnique = true)]
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






        public class MyDbContextUsuarios : DbContext
        {
            public MyDbContextUsuarios() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }

            public DbSet<USUARIOS_PC> UsuariosDATOS { get; set; }
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

            public byte[] Firma { get; set; }

            public bool Entrega { get; set; }
            public byte[] ActaEntregaPDF { get; set; }
            public byte[] ActaDevolucionPDF { get; set; }

            public DateTime? FECHA_CREACION { get; set; }
            public DateTime? FECHA_ACTA_ENTREGA { get; set; }
            public DateTime? FECHA_ACTA_DEVOLUCION { get; set; }



        }








        public class MyDbContextActaData : DbContext
        {
            public MyDbContextActaData() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }


            public DbSet<ActaData> EscribirEnActaPDFDetalle { get; set; }
        }



        public class ActaData
        {
            [Key]
            public int ID_DIS { get; set; }
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


















        public void MostrarAsignaciones()
        {
            using (var connection = new SqlConnection("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;"))
            {
                connection.Open();

                using (var command = new SqlCommand("SP_MOSTRAR_ASIGNACION_PC", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewAsignaciones.DataSource = dataTable;
                    }
                }
            }


            //using (var db = new MyDbContextUsuarios())
            //{
            //    var ContextoUsuarios = db.Database.SqlQuery<DISPAUSU>("SP_MOSTRAR_ASIGNACION_PC").ToList();
            //    dataGridViewAsignaciones.DataSource = ContextoUsuarios;
            //    dataGridViewAsignaciones.DefaultCellStyle.BackColor = Color.LightBlue;
            //}

        }




        public void LLENARCOMBOPC()
        {

            using (var db = new MyDbContextTI())
            {
                var dispositivos = db.TIDATOS.Select(d => d.COD_PC).ToList();

                comboBox1.DataSource = dispositivos;
            }



        }



        public void LLENARCOMBOUSUARIOS()
        {

            using (var db = new MyDbContextUsuarios())
            {
                var usuarios = db.UsuariosDATOS.ToList();
                var nombres_codigos = usuarios.Select(d => d.COD_USUARIO + " " + d.NOMBRES).ToList();
                comboBox2.DataSource = nombres_codigos;
                comboBox2.DisplayMember = "nombres_codigos";
                // comboBox2.ValueMember = "COD_USUARIO";
            }

        }



        public void LlenarComboFirma1()
        {

            using (var db = new MyDbContextUsuarios())
            {
                // Filtrar los usuarios donde Entrega es igual a true
                var usuarios = db.UsuariosDATOS.Where(u => u.Entrega == true).ToList();

                // Combinar los códigos y nombres de usuario
                var nombres_codigos = usuarios.Select(d => d.COD_USUARIO + " " + d.NOMBRES).ToList();

                // Asignar los resultados filtrados al ComboBox
                comboBox3.DataSource = nombres_codigos;
                comboBox3.DisplayMember = "nombres_codigos";
                // comboBox2.ValueMember = "COD_USUARIO";
            }


        }




        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void dataGridViewAsignaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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



        // ACTAS DE ENTREGA
        public void GenerarPDFAsigacion(string _cod_pc, string _cod_usuario) {







            //EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC = 'CETINB02'

            // Crear una lista para almacenar los datos del acta
            List<ActaData> datosActa = new List<ActaData>();

            using (var context = new MyDbContextActaData())
            {
                // Llamar al procedimiento almacenado y obtener los datos del acta
                var query = context.Database.SqlQuery<ActaData>("EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC = @cod_pc", new SqlParameter("@cod_pc", _cod_pc));

                // Agregar los datos del acta a la lista
                datosActa = query.ToList();
            }



            string cod_pc_seleccionado = comboBox3.SelectedValue.ToString();

            string comboBox3Text = comboBox3.Text;
            string[] words = comboBox3Text.Split(' '); // Divide el texto en palabras usando espacio como separador
            string cod_usuario_seleccionado = words[0]; // Obtiene la primera palabra del texto, que es COD_USUARIO

            List<USUARIOS_PC> datosAutorizadosEntrega = new List<USUARIOS_PC>();

            using (var context = new MyDbContextUsuarios())
            {
                // Filtrar los usuarios autorizados a firmar (donde Entrega es igual a true y COD_USUARIO es igual al valor seleccionado)
                datosAutorizadosEntrega = context.UsuariosDATOS
                    .Where(u => u.Entrega == true && u.COD_USUARIO == cod_usuario_seleccionado)
                    .ToList();
            }






            List<USUARIOS_PC> datosUSUARIOS = new List<USUARIOS_PC>();

            using (var context = new MyDbContextUsuarios())
            {
                using (SqlConnection connection = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("EXEC MostrarFirmaUsuarios @_COD_USUARIO = @_cod_usuario", connection))
                    {
                        command.Parameters.AddWithValue("@_cod_usuario", _cod_usuario);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datosUSUARIOS.Add(new USUARIOS_PC
                                {
                                    COD_USUARIO = reader["COD_USUARIO"].ToString(),
                                    NOMBRES = reader["NOMBRES"].ToString(),
                                    APELLIDOS = reader["APELLIDOS"].ToString(),
                                    AREA = reader["AREA"].ToString(),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    Firma = (byte[])reader["Firma"]
                                });
                            }
                        }
                    }
                }
            }




            // Crear el documento PDF y la página
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            // Obtener el objeto XGraphics para dibujar en la página
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Crear la fuente y el formato para el texto
            XFont fontTitulo = new XFont("Arial", 20, XFontStyle.Bold);
            XFont fontNormal = new XFont("Arial", 12, XFontStyle.Regular);
            XStringFormat formatTitulo = new XStringFormat();
            formatTitulo.Alignment = XStringAlignment.Center;
            XStringFormat formatNormal = new XStringFormat();
            formatNormal.Alignment = XStringAlignment.Near;


            //Crear logo


            string imgFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\IMG");



            // Crea un objeto XImage a partir del archivo de imagen del logo
            //XImage logo = XImage.FromFile(@"C:\JP\cuadratura\CapaPresentacion\IMG\LogoActa.png");
            XImage logo = XImage.FromFile(Path.Combine(imgFolder, "LogoActa.png"));


            // Dibuja el logo en la página
            gfx.DrawImage(logo, 50, 50, 110, 100);


            // Agregar el título de la acta
            string titulo = "ACTA DE ENTREGA DE EQUIPOS";
            gfx.DrawString(titulo, fontTitulo, XBrushes.Black,
                new XRect(50, 150, page.Width - 100, fontTitulo.Height), formatTitulo);



            // Agregar la información del equipo entregado
            string TextoInicial = "En la siguiente acta se listan los equipos que se entregaran con fecha de " + DateTime.Today.ToString("dd/MM/yyyy") + ",";
            string TextoSegundo = "el usuario se hace responsable del estado de estos y además se compromete";
            string TextoTercero = "a mantener el área de trabajo limpia para no afectar el funcionamiento de los equipos.";

            string EquipoEntregado;
            string NumeroSerie;
            string Aarea;
            string Tipo;
            string Procesador;
            int RAM;
            string TipoDisco;
            int CapacidadDisco;
            string SistemaOperativo;
            string Modelo;
            string MacLan;
            string MacWifi;
            DateTime? Fecha_asignacion;

            gfx.DrawString(TextoInicial, fontNormal, XBrushes.Black,
                new XRect(50, 200, page.Width - 100, fontNormal.Height), formatNormal);

            gfx.DrawString(TextoSegundo, fontNormal, XBrushes.Black,
                new XRect(50, 220, page.Width - 100, fontNormal.Height), formatNormal);

            gfx.DrawString(TextoTercero, fontNormal, XBrushes.Black,
                new XRect(50, 240, page.Width - 100, fontNormal.Height), formatNormal);


            // Agregar la información del equipo entregado
            if (datosActa.Count > 0)
            {
                // Utilizar los valores de las propiedades de datosActa para llenar el acta
                var equipo = datosActa[0];
                EquipoEntregado = equipo.COD_PC;
                NumeroSerie = equipo.SERIAL;

                Tipo = equipo.TIPO;
                Procesador = equipo.PROCESADOR;
                RAM = equipo.RAM;
                TipoDisco = equipo.TIPO_DISCO;
                CapacidadDisco = equipo.CAPACIDAD_DISCO;
                SistemaOperativo = equipo.SISTEMA_OPERATIVO;
                Modelo = equipo.MODELO;
                MacLan = equipo.MAC_LAN;
                MacWifi = equipo.MAC_WIFI;
                Fecha_asignacion = equipo.FECHA_ASIGNACION;


                // Crear fuentes
                XFont fontBold = new XFont("Arial", 12, XFontStyle.Bold);

                // Dibujar texto con etiquetas y variables en negrita
                gfx.DrawString("Equipo entregado: ", fontNormal, XBrushes.Black,
                    new XRect(50, 300, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(EquipoEntregado, fontBold, XBrushes.Black,
                    new XRect(160, 300, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Número de serie: ", fontNormal, XBrushes.Black,
                    new XRect(50, 320, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(NumeroSerie, fontBold, XBrushes.Black,
                    new XRect(155, 320, page.Width - 100, fontNormal.Height), formatNormal);



                gfx.DrawString("Tipo: ", fontNormal, XBrushes.Black,
                    new XRect(50, 360, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Tipo, fontBold, XBrushes.Black,
                    new XRect(85, 360, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Procesador: ", fontNormal, XBrushes.Black,
                    new XRect(50, 380, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Procesador, fontBold, XBrushes.Black,
                    new XRect(140, 380, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("RAM (GB): ", fontNormal, XBrushes.Black,
                    new XRect(50, 400, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(RAM.ToString(), fontBold, XBrushes.Black,
                    new XRect(130, 400, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Tipo Disco: ", fontNormal, XBrushes.Black,
                    new XRect(50, 420, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(TipoDisco, fontBold, XBrushes.Black,
                    new XRect(130, 420, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Capacidad Disco (GB): ", fontNormal, XBrushes.Black,
                    new XRect(50, 440, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(CapacidadDisco.ToString(), fontBold, XBrushes.Black,
                    new XRect(200, 440, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Sistema Operativo: ", fontNormal, XBrushes.Black,
                    new XRect(50, 460, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(SistemaOperativo, fontBold, XBrushes.Black,
                    new XRect(185, 460, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Modelo: ", fontNormal, XBrushes.Black,
      new XRect(50, 480, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Modelo, fontBold, XBrushes.Black,
                    new XRect(110, 480, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("MAC LAN: ", fontNormal, XBrushes.Black,
                    new XRect(50, 500, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(MacLan, fontBold, XBrushes.Black,
                    new XRect(120, 500, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("MAC WiFi: ", fontNormal, XBrushes.Black,
                    new XRect(50, 520, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(MacWifi, fontBold, XBrushes.Black,
                    new XRect(130, 520, page.Width - 100, fontNormal.Height), formatNormal);



            }
            else
            {
                MessageBox.Show("No se encontró información del equipo seleccionado.");
            }


            string NombreEntrega;
            string ApellidosEntrega;
            string AreaEntrega;
            byte[] firma;

            // Variables de posición para la primera y segunda firma
            double firmaX = 15;
            double firmaWidth = page.Width / 2 - 80;
            double firmaY = 660;
            double firmaHeight = 80;


            // Agrego las variables para la firma
            if (datosAutorizadosEntrega.Count > 0)
            {
                var firmaUsuAUTORIZADO = datosAutorizadosEntrega[0];

                NombreEntrega = firmaUsuAUTORIZADO.NOMBRES;
                ApellidosEntrega = firmaUsuAUTORIZADO.APELLIDOS;
                AreaEntrega = firmaUsuAUTORIZADO.AREA;
                firma = firmaUsuAUTORIZADO.Firma;

                try
                {

                    // Agregar la sección de firmas
                    XRect firmaResponsableRect1 = new XRect(60, 640, page.Width / 1 - 100, 130);
                    gfx.DrawString("Entrega: ", fontNormal, XBrushes.Black,
                    new XRect(firmaResponsableRect1.Left, firmaResponsableRect1.Top - fontNormal.Height, firmaResponsableRect1.Width, fontNormal.Height), formatNormal);

                    using (MemoryStream firmaStream = new MemoryStream(firma))
                    {
                        // Calcular el ancho de los textos del nombre y del área
                        XSize nombreSize = gfx.MeasureString(NombreEntrega + " " + ApellidosEntrega, fontNormal);
                        XSize areaSize = gfx.MeasureString(AreaEntrega, fontNormal);

                        // Ajustar la posición de la imagen de la firma según el nombre
                        double firmaCenterX = firmaResponsableRect1.Left + (nombreSize.Width - firmaWidth) / 2;

                        XImage firmaImage = XImage.FromStream(firmaStream);
                        gfx.DrawImage(firmaImage, firmaCenterX, firmaY, firmaWidth, firmaHeight);

                        // Agregar la sección de firmas para la primera firma
                        XRect firmaResponsableArea = new XRect(firmaResponsableRect1.Left, 720, nombreSize.Width, fontNormal.Height);
                        gfx.DrawString(NombreEntrega + " " + ApellidosEntrega, fontNormal, XBrushes.Black,
                            new XRect(firmaResponsableArea.Left, firmaResponsableArea.Top - fontNormal.Height, firmaResponsableArea.Width, firmaResponsableArea.Height), formatNormal);

                        // Calcular la posición de inicio X para centrar el área de entrega de acuerdo al nombre de entrega
                        double areaX = firmaResponsableArea.Left + (nombreSize.Width - areaSize.Width) / 2;

                        // Agregar la sección de firmas para la primera firma
                        XRect firmaResponsableArea_area = new XRect(areaX, 740, areaSize.Width, fontNormal.Height);
                        gfx.DrawString(AreaEntrega, fontNormal, XBrushes.Black,
                            new XRect(firmaResponsableArea_area.Left, firmaResponsableArea_area.Top - fontNormal.Height, firmaResponsableArea_area.Width, firmaResponsableArea_area.Height), formatNormal);
                    }



                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar y dibujar la Firma: " + ex.Message);
                }




            }
            else
            {
                MessageBox.Show("No se encontró Firma del Usuario que entrega.");
            }


            // Configurar la posición, el ancho y el alto de la segunda firma por separado
            double firma2X = firmaX + firmaWidth + 30;
            double firma2Y = 660;
            double firma2Width = page.Width / 2 - 80;
            double firma2Height = 80;
            string NombreRecibe;
            string ApellidosRecibe;
            string AreaRecibe;

            // Agrego las variables para la firma
            if (datosUSUARIOS.Count > 0)
            {
                var firmaUsu = datosUSUARIOS[0];

                firma = firmaUsu.Firma;
                NombreRecibe = firmaUsu.NOMBRES;
                ApellidosRecibe = firmaUsu.APELLIDOS;
                AreaRecibe = firmaUsu.AREA;

                try
                {
                    // Agregar la sección de firmas
                    XRect firmaResponsableRect = new XRect(350, 640, page.Width / 1 - 100, 130);
                    gfx.DrawString("Recibe:", fontNormal, XBrushes.Black,
                    new XRect(firmaResponsableRect.Left, firmaResponsableRect.Top - fontNormal.Height, firmaResponsableRect.Width, fontNormal.Height), formatNormal);

                    using (MemoryStream firma2Stream = new MemoryStream(firma))
                    {
                        // Calcular el ancho de los textos del nombre y del área
                        XSize nombreSize = gfx.MeasureString(NombreRecibe + " " + ApellidosRecibe, fontNormal);
                        XSize areaSize = gfx.MeasureString(AreaRecibe, fontNormal);

                        // Ajustar la posición de la imagen de la firma según el nombre
                        double firma2CenterX = firmaResponsableRect.Left + (nombreSize.Width - firma2Width) / 2;

                        XImage firma2Image = XImage.FromStream(firma2Stream);
                        gfx.DrawImage(firma2Image, firma2CenterX, firma2Y, firma2Width, firma2Height);

                        // Agregar la sección de firmas para la segunda firma
                        XRect firma2ResponsableArea2 = new XRect(firmaResponsableRect.Left, 705, nombreSize.Width, fontNormal.Height);
                        gfx.DrawString(NombreRecibe + " " + ApellidosRecibe, fontNormal, XBrushes.Black,
                            new XRect(firma2ResponsableArea2.Left, firma2ResponsableArea2.Top, firma2ResponsableArea2.Width, firma2ResponsableArea2.Height), formatNormal);

                        // Calcular la posición de inicio X para centrar el área de recibe de acuerdo al nombre de recibe
                        double areaX = firma2ResponsableArea2.Left + (nombreSize.Width - areaSize.Width) / 2;

                        // Agregar la sección de firmas para la segunda firma
                        XRect firma2ResponsableArea2Area = new XRect(areaX, 724, areaSize.Width, fontNormal.Height);
                        gfx.DrawString(AreaRecibe, fontNormal, XBrushes.Black,
                            new XRect(firma2ResponsableArea2Area.Left, firma2ResponsableArea2Area.Top, firma2ResponsableArea2Area.Width, firma2ResponsableArea2Area.Height), formatNormal);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar y dibujar la segunda Firma: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encontró Firma del Usuario que recibe.");
            }








            // termino el pdf




            // Pedir al usuario que seleccione una ubicación para guardar el PDF
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento como";
            saveFileDialog1.ShowDialog();

            // Si se selecciona una ubicación y se hace clic en "Guardar", guardar el PDF allí
            if (saveFileDialog1.FileName != "")
            {
                // Guardar el PDF
                document.Save(saveFileDialog1.FileName);

                // Leer el archivo PDF y convertirlo a un arreglo de bytes
                byte[] pdfBytes;
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    pdfBytes = new byte[fs.Length];
                    fs.Read(pdfBytes, 0, (int)fs.Length);
                }

                // Insertar los datos en la base de datos
                string connectionString = "Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User ID=sa;Password=Passw0rd..;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string codusuario = _cod_usuario;
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE USUARIOS_PC SET ActaEntregaPDF = @PDFData, FECHA_ACTA_ENTREGA = @FechaEntrega WHERE COD_USUARIO = @CodUsuario", connection);
                    SqlParameter pdfDataParam = new SqlParameter("@PDFData", SqlDbType.VarBinary, -1);
                    pdfDataParam.Value = pdfBytes;
                    command.Parameters.Add(pdfDataParam);
                    command.Parameters.AddWithValue("@CodUsuario", codusuario);

                    // Agregar el parámetro para la fecha de entrega y establecer su valor a la fecha y hora actual
                    SqlParameter fechaEntregaParam = new SqlParameter("@FechaEntrega", SqlDbType.DateTime);
                    fechaEntregaParam.Value = DateTime.Now;
                    command.Parameters.Add(fechaEntregaParam);

                    command.ExecuteNonQuery();
                }


                // Abrir el PDF en el visor de PDF predeterminado en el sistema
                Process.Start(saveFileDialog1.FileName);

                // Liberar los recursos
                document.Close();
            }



        }




        // ACTAS DE devolucion
        public void GenerarPDFDevolucion(string _cod_pc, string _cod_usuario)
        {



            //EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC = 'CETINB02'

            // Crear una lista para almacenar los datos del acta
            List<ActaData> datosActa = new List<ActaData>();

            using (var context = new MyDbContextActaData())
            {
                // Llamar al procedimiento almacenado y obtener los datos del acta
                var query = context.Database.SqlQuery<ActaData>("EXEC SP_MOSTRAR_COMPUTADOR_ASIGNADO @_COD_PC = @cod_pc", new SqlParameter("@cod_pc", _cod_pc));

                // Agregar los datos del acta a la lista
                datosActa = query.ToList();
            }



            string cod_pc_seleccionado = comboBox3.SelectedValue.ToString();

            string comboBox3Text = comboBox3.Text;
            string[] words = comboBox3Text.Split(' '); // Divide el texto en palabras usando espacio como separador
            string cod_usuario_seleccionado = words[0]; // Obtiene la primera palabra del texto, que es COD_USUARIO

            List<USUARIOS_PC> datosAutorizadosEntrega = new List<USUARIOS_PC>();

            using (var context = new MyDbContextUsuarios())
            {
                // Filtrar los usuarios autorizados a firmar (donde Entrega es igual a true y COD_USUARIO es igual al valor seleccionado)
                datosAutorizadosEntrega = context.UsuariosDATOS
                    .Where(u => u.Entrega == true && u.COD_USUARIO == cod_usuario_seleccionado)
                    .ToList();
            }






            List<USUARIOS_PC> datosUSUARIOS = new List<USUARIOS_PC>();

            using (var context = new MyDbContextUsuarios())
            {
                using (SqlConnection connection = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("EXEC MostrarFirmaUsuarios @_COD_USUARIO = @_cod_usuario", connection))
                    {
                        command.Parameters.AddWithValue("@_cod_usuario", _cod_usuario);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                datosUSUARIOS.Add(new USUARIOS_PC
                                {
                                    COD_USUARIO = reader["COD_USUARIO"].ToString(),
                                    NOMBRES = reader["NOMBRES"].ToString(),
                                    APELLIDOS = reader["APELLIDOS"].ToString(),
                                    AREA = reader["AREA"].ToString(),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    Firma = (byte[])reader["Firma"]
                                });
                            }
                        }
                    }
                }
            }




            // Crear el documento PDF y la página
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            // Obtener el objeto XGraphics para dibujar en la página
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Crear la fuente y el formato para el texto
            XFont fontTitulo = new XFont("Arial", 20, XFontStyle.Bold);
            XFont fontNormal = new XFont("Arial", 12, XFontStyle.Regular);
            XStringFormat formatTitulo = new XStringFormat();
            formatTitulo.Alignment = XStringAlignment.Center;
            XStringFormat formatNormal = new XStringFormat();
            formatNormal.Alignment = XStringAlignment.Near;


            //Crear logo


            string imgFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\IMG");



            // Crea un objeto XImage a partir del archivo de imagen del logo
            //XImage logo = XImage.FromFile(@"C:\JP\cuadratura\CapaPresentacion\IMG\LogoActa.png");
            XImage logo = XImage.FromFile(Path.Combine(imgFolder, "LogoActa.png"));


            // Dibuja el logo en la página
            gfx.DrawImage(logo, 50, 50, 110, 100);


            // Agregar el título de la acta
            string titulo = "ACTA DE DEVOLUCIÓN DE EQUIPOS";
            gfx.DrawString(titulo, fontTitulo, XBrushes.Black,
                new XRect(50, 150, page.Width - 100, fontTitulo.Height), formatTitulo);



            // Agregar la información del equipo entregado
            string TextoInicial = "En la siguiente acta se listan los equipos que se reciben como devolucion.";
            string TextoSegundo = "con fecha de " + DateTime.Today.ToString("dd/MM/yyyy") + ",";
            //  string TextoTercero = "a mantener el área de trabajo limpia para no afectar el funcionamiento de los equipos.";

            string EquipoEntregado;
            string NumeroSerie;
            string Aarea;
            string Tipo;
            string Procesador;
            int RAM;
            string TipoDisco;
            int CapacidadDisco;
            string SistemaOperativo;
            string Modelo;
            string MacLan;
            string MacWifi;
            DateTime? Fecha_asignacion;

            gfx.DrawString(TextoInicial, fontNormal, XBrushes.Black,
                new XRect(50, 200, page.Width - 100, fontNormal.Height), formatNormal);

            gfx.DrawString(TextoSegundo, fontNormal, XBrushes.Black,
                new XRect(50, 220, page.Width - 100, fontNormal.Height), formatNormal);

            //gfx.DrawString(TextoTercero, fontNormal, XBrushes.Black,
            //    new XRect(50, 240, page.Width - 100, fontNormal.Height), formatNormal);


            // Agregar la información del equipo entregado
            if (datosActa.Count > 0)
            {
                // Utilizar los valores de las propiedades de datosActa para llenar el acta
                var equipo = datosActa[0];
                EquipoEntregado = equipo.COD_PC;
                NumeroSerie = equipo.SERIAL;

                Tipo = equipo.TIPO;
                Procesador = equipo.PROCESADOR;
                RAM = equipo.RAM;
                TipoDisco = equipo.TIPO_DISCO;
                CapacidadDisco = equipo.CAPACIDAD_DISCO;
                SistemaOperativo = equipo.SISTEMA_OPERATIVO;
                Modelo = equipo.MODELO;
                MacLan = equipo.MAC_LAN;
                MacWifi = equipo.MAC_WIFI;
                Fecha_asignacion = equipo.FECHA_ASIGNACION;


                // Crear fuentes
                XFont fontBold = new XFont("Arial", 12, XFontStyle.Bold);

                // Dibujar texto con etiquetas y variables en negrita
                gfx.DrawString("Equipo entregado: ", fontNormal, XBrushes.Black,
                    new XRect(50, 300, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(EquipoEntregado, fontBold, XBrushes.Black,
                    new XRect(160, 300, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Número de serie: ", fontNormal, XBrushes.Black,
                    new XRect(50, 320, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(NumeroSerie, fontBold, XBrushes.Black,
                    new XRect(155, 320, page.Width - 100, fontNormal.Height), formatNormal);



                gfx.DrawString("Tipo: ", fontNormal, XBrushes.Black,
                    new XRect(50, 360, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Tipo, fontBold, XBrushes.Black,
                    new XRect(85, 360, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Procesador: ", fontNormal, XBrushes.Black,
                    new XRect(50, 380, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Procesador, fontBold, XBrushes.Black,
                    new XRect(140, 380, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("RAM (GB): ", fontNormal, XBrushes.Black,
                    new XRect(50, 400, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(RAM.ToString(), fontBold, XBrushes.Black,
                    new XRect(130, 400, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Tipo Disco: ", fontNormal, XBrushes.Black,
                    new XRect(50, 420, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(TipoDisco, fontBold, XBrushes.Black,
                    new XRect(130, 420, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Capacidad Disco (GB): ", fontNormal, XBrushes.Black,
                    new XRect(50, 440, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(CapacidadDisco.ToString(), fontBold, XBrushes.Black,
                    new XRect(200, 440, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Sistema Operativo: ", fontNormal, XBrushes.Black,
                    new XRect(50, 460, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(SistemaOperativo, fontBold, XBrushes.Black,
                    new XRect(185, 460, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("Modelo: ", fontNormal, XBrushes.Black,
      new XRect(50, 480, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(Modelo, fontBold, XBrushes.Black,
                    new XRect(110, 480, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("MAC LAN: ", fontNormal, XBrushes.Black,
                    new XRect(50, 500, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(MacLan, fontBold, XBrushes.Black,
                    new XRect(120, 500, page.Width - 100, fontNormal.Height), formatNormal);

                gfx.DrawString("MAC WiFi: ", fontNormal, XBrushes.Black,
                    new XRect(50, 520, page.Width - 100, fontNormal.Height), formatNormal);
                gfx.DrawString(MacWifi, fontBold, XBrushes.Black,
                    new XRect(130, 520, page.Width - 100, fontNormal.Height), formatNormal);



            }
            else
            {
                MessageBox.Show("No se encontró información del equipo seleccionado.");
            }


            string NombreEntrega;
            string ApellidosEntrega;
            string AreaEntrega;
            byte[] firma;

            // Variables de posición para la primera y segunda firma
            double firmaX = 15;
            double firmaWidth = page.Width / 2 - 80;
            double firmaY = 660;
            double firmaHeight = 80;


            // Agrego las variables para la firma
            if (datosAutorizadosEntrega.Count > 0)
            {
                var firmaUsuAUTORIZADO = datosAutorizadosEntrega[0];

                NombreEntrega = firmaUsuAUTORIZADO.NOMBRES;
                ApellidosEntrega = firmaUsuAUTORIZADO.APELLIDOS;
                AreaEntrega = firmaUsuAUTORIZADO.AREA;
                firma = firmaUsuAUTORIZADO.Firma;

                try
                {

                    // Agregar la sección de firmas
                    XRect firmaResponsableRect1 = new XRect(60, 640, page.Width / 1 - 100, 130);
                    gfx.DrawString("Recibe: ", fontNormal, XBrushes.Black,
                    new XRect(firmaResponsableRect1.Left, firmaResponsableRect1.Top - fontNormal.Height, firmaResponsableRect1.Width, fontNormal.Height), formatNormal);

                    using (MemoryStream firmaStream = new MemoryStream(firma))
                    {
                        // Calcular el ancho de los textos del nombre y del área
                        XSize nombreSize = gfx.MeasureString(NombreEntrega + " " + ApellidosEntrega, fontNormal);
                        XSize areaSize = gfx.MeasureString(AreaEntrega, fontNormal);

                        // Ajustar la posición de la imagen de la firma según el nombre
                        double firmaCenterX = firmaResponsableRect1.Left + (nombreSize.Width - firmaWidth) / 2;

                        XImage firmaImage = XImage.FromStream(firmaStream);
                        gfx.DrawImage(firmaImage, firmaCenterX, firmaY, firmaWidth, firmaHeight);

                        // Agregar la sección de firmas para la primera firma
                        XRect firmaResponsableArea = new XRect(firmaResponsableRect1.Left, 720, nombreSize.Width, fontNormal.Height);
                        gfx.DrawString(NombreEntrega + " " + ApellidosEntrega, fontNormal, XBrushes.Black,
                            new XRect(firmaResponsableArea.Left, firmaResponsableArea.Top - fontNormal.Height, firmaResponsableArea.Width, firmaResponsableArea.Height), formatNormal);

                        // Calcular la posición de inicio X para centrar el área de entrega de acuerdo al nombre de entrega
                        double areaX = firmaResponsableArea.Left + (nombreSize.Width - areaSize.Width) / 2;

                        // Agregar la sección de firmas para la primera firma
                        XRect firmaResponsableArea_area = new XRect(areaX, 740, areaSize.Width, fontNormal.Height);
                        gfx.DrawString(AreaEntrega, fontNormal, XBrushes.Black,
                            new XRect(firmaResponsableArea_area.Left, firmaResponsableArea_area.Top - fontNormal.Height, firmaResponsableArea_area.Width, firmaResponsableArea_area.Height), formatNormal);
                    }



                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar y dibujar la Firma: " + ex.Message);
                }




            }
            else
            {
                MessageBox.Show("No se encontró Firma del Usuario que entrega.");
            }


            // Configurar la posición, el ancho y el alto de la segunda firma por separado
            double firma2X = firmaX + firmaWidth + 30;
            double firma2Y = 660;
            double firma2Width = page.Width / 2 - 80;
            double firma2Height = 80;
            string NombreRecibe;
            string ApellidosRecibe;
            string AreaRecibe;

            // Agrego las variables para la firma
            if (datosUSUARIOS.Count > 0)
            {
                var firmaUsu = datosUSUARIOS[0];

                firma = firmaUsu.Firma;
                NombreRecibe = firmaUsu.NOMBRES;
                ApellidosRecibe = firmaUsu.APELLIDOS;
                AreaRecibe = firmaUsu.AREA;

                try
                {
                    // Agregar la sección de firmas
                    XRect firmaResponsableRect = new XRect(350, 640, page.Width / 1 - 100, 130);
                    gfx.DrawString("Entrega: ", fontNormal, XBrushes.Black,
                    new XRect(firmaResponsableRect.Left, firmaResponsableRect.Top - fontNormal.Height, firmaResponsableRect.Width, fontNormal.Height), formatNormal);

                    using (MemoryStream firma2Stream = new MemoryStream(firma))
                    {
                        // Calcular el ancho de los textos del nombre y del área
                        XSize nombreSize = gfx.MeasureString(NombreRecibe + " " + ApellidosRecibe, fontNormal);
                        XSize areaSize = gfx.MeasureString(AreaRecibe, fontNormal);

                        // Ajustar la posición de la imagen de la firma según el nombre
                        double firma2CenterX = firmaResponsableRect.Left + (nombreSize.Width - firma2Width) / 2;

                        XImage firma2Image = XImage.FromStream(firma2Stream);
                        gfx.DrawImage(firma2Image, firma2CenterX, firma2Y, firma2Width, firma2Height);

                        // Agregar la sección de firmas para la segunda firma
                        XRect firma2ResponsableArea2 = new XRect(firmaResponsableRect.Left, 705, nombreSize.Width, fontNormal.Height);
                        gfx.DrawString(NombreRecibe + " " + ApellidosRecibe, fontNormal, XBrushes.Black,
                            new XRect(firma2ResponsableArea2.Left, firma2ResponsableArea2.Top, firma2ResponsableArea2.Width, firma2ResponsableArea2.Height), formatNormal);

                        // Calcular la posición de inicio X para centrar el área de recibe de acuerdo al nombre de recibe
                        double areaX = firma2ResponsableArea2.Left + (nombreSize.Width - areaSize.Width) / 2;

                        // Agregar la sección de firmas para la segunda firma
                        XRect firma2ResponsableArea2Area = new XRect(areaX, 724, areaSize.Width, fontNormal.Height);
                        gfx.DrawString(AreaRecibe, fontNormal, XBrushes.Black,
                            new XRect(firma2ResponsableArea2Area.Left, firma2ResponsableArea2Area.Top, firma2ResponsableArea2Area.Width, firma2ResponsableArea2Area.Height), formatNormal);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar y dibujar la segunda Firma: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encontró Firma del Usuario que recibe.");
            }








            // termino el pdf




            // Pedir al usuario que seleccione una ubicación para guardar el PDF
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivos PDF|*.pdf";
            saveFileDialog1.Title = "Guardar documento como";
            saveFileDialog1.ShowDialog();

            // Si se selecciona una ubicación y se hace clic en "Guardar", guardar el PDF allí
            if (saveFileDialog1.FileName != "")
            {
                // Guardar el PDF
                document.Save(saveFileDialog1.FileName);

                // Leer el archivo PDF y convertirlo a un arreglo de bytes
                byte[] pdfBytes;
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    pdfBytes = new byte[fs.Length];
                    fs.Read(pdfBytes, 0, (int)fs.Length);
                }

                // Insertar los datos en la base de datos
                string connectionString = "Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User ID=sa;Password=Passw0rd..;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string codusuario = _cod_usuario;
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE USUARIOS_PC SET ActaDevolucionPDF = @PDFData, FECHA_ACTA_DEVOLUCION = @FechaDevolucion WHERE COD_USUARIO = @CodUsuario", connection);
                    SqlParameter pdfDataParam = new SqlParameter("@PDFData", SqlDbType.VarBinary, -1);
                    pdfDataParam.Value = pdfBytes;
                    command.Parameters.Add(pdfDataParam);
                    command.Parameters.AddWithValue("@CodUsuario", codusuario);

                    // Agregar el parámetro para la fecha de devolución y establecer su valor a la fecha y hora actual
                    SqlParameter fechaDevolucionParam = new SqlParameter("@FechaDevolucion", SqlDbType.DateTime);
                    fechaDevolucionParam.Value = DateTime.Now;
                    command.Parameters.Add(fechaDevolucionParam);

                    command.ExecuteNonQuery();
                }

                // Abrir el PDF en el visor de PDF predeterminado en el sistema
                Process.Start(saveFileDialog1.FileName);

                // Liberar los recursos
                document.Close();
            }



        }






        public void DescargarPDF(string cod_usuario)
        {

            using (var context = new MyDbContextUsuarios())
            {
                // Buscar el registro con el ID especificado
                var registro = context.UsuariosDATOS.FirstOrDefault(r => r.COD_USUARIO == cod_usuario);


                if (registro != null && registro.ActaEntregaPDF != null)
                {
                    // Crear un cuadro de diálogo para guardar el archivo PDF
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    saveFileDialog1.FileName = "acta.pdf";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // Guardar el archivo PDF en la ubicación seleccionada por el usuario
                        System.IO.File.WriteAllBytes(saveFileDialog1.FileName, registro.ActaEntregaPDF);

                        // Abrir el archivo PDF con el programa predeterminado del sistema para archivos PDF
                        Process.Start(saveFileDialog1.FileName);
                    }
                }
                else
                {
                    // Si no se encuentra el registro o el campo ActaPDF es nulo, mostrar un mensaje de error
                    MessageBox.Show("No se ha Asignado un Acta de Entrega a este usuario:");
                }
            }

        }




        public void EnviarCorreoENTREGA(string correoDestinatario, string cod_usuario, string nombreUsuarioSeleccionado, string cod_pc)
        {

            try
            {



                // Configurar el cliente SMTP
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply@cerasus.cl", "Cerasus/2023..");

                // Configurar el correo electrónico
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply@cerasus.cl");
                mail.To.Add(correoDestinatario);
                mail.CC.Add("eduardo.allende@giddingsfruit.com");
                mail.CC.Add("john.parra@giddingsfruit.com");
                mail.CC.Add("mario.perez@giddingsfruit.com");
                mail.Subject = "Acta de entrega";
                mail.Body = "Adjunto al correo está el acta de entrega.";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;



                byte[] pdfBytes = null;


                using (var context = new MyDbContextUsuarios())
                {
                    // Buscar el PDF en la tabla DISPAUSU según el código de usuario seleccionado
                    var Usu = context.UsuariosDATOS.FirstOrDefault(d => d.COD_USUARIO == cod_usuario);
                    if (Usu != null)
                    {
                        pdfBytes = Usu.ActaEntregaPDF;


                    }




                }

                // Asegúrese de que se encontró un archivo PDF válido
                if (pdfBytes != null && pdfBytes.Length > 0)
                {
                    try
                    {
                        // Construye el nombre del archivo
                        string nombreArchivo = $"Acta de entrega {cod_usuario} {nombreUsuarioSeleccionado}.pdf";


                        // Adjuntar el archivo PDF
                        using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
                        {
                            Attachment pdfAttachment = new Attachment(pdfStream, nombreArchivo, "application/pdf");
                            mail.Attachments.Add(pdfAttachment);

                            // Enviar correo electrónico
                            client.Send(mail); // Agrega esta línea
                            MessageBox.Show("Correo electrónico enviado correctamente.");
                            Console.WriteLine("Correo electrónico enviado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                        Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo PDF correspondiente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
            }
        }






        public void EnviarCorreoDEVOLUCION(string correoDestinatario, string cod_usuario, string nombreUsuarioSeleccionado, string cod_pc)
        {


            try
            {



                // Configurar el cliente SMTP
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply@cerasus.cl", "Cerasus/2023..");

                // Configurar el correo electrónico
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply@cerasus.cl");
                mail.To.Add(correoDestinatario);
                mail.CC.Add("eduardo.allende@giddingsfruit.com");
                mail.CC.Add("john.parra@giddingsfruit.com");
                mail.CC.Add("mario.perez@giddingsfruit.com");
                mail.Subject = "Acta de devolución";
                mail.Body = "Adjunto al correo está el acta de devolución.";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;



                byte[] pdfBytes = null;


                using (var context = new MyDbContextUsuarios())
                {
                    // Buscar el PDF en la tabla USUARIOS_PC según el código de usuario seleccionado
                    var Usu = context.UsuariosDATOS.FirstOrDefault(d => d.COD_USUARIO == cod_usuario);
                    if (Usu != null)
                    {
                        pdfBytes = Usu.ActaDevolucionPDF;


                    }




                }

                // Asegúrese de que se encontró un archivo PDF válido
                if (pdfBytes != null && pdfBytes.Length > 0)
                {
                    try
                    {
                        // Construye el nombre del archivo
                        string nombreArchivo = $"Acta de devolución {cod_usuario} {nombreUsuarioSeleccionado}.pdf";


                        // Adjuntar el archivo PDF
                        using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
                        {
                            Attachment pdfAttachment = new Attachment(pdfStream, nombreArchivo, "application/pdf");
                            mail.Attachments.Add(pdfAttachment);

                            // Enviar correo electrónico
                            client.Send(mail); // Agrega esta línea
                            MessageBox.Show("Correo electrónico enviado correctamente.");
                            Console.WriteLine("Correo electrónico enviado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                        Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo PDF correspondiente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
            }
        }




        public void EnviarCorreoENTREGA_CARGADA(string correoDestinatario, string cod_usuario, string nombreUsuarioSeleccionado, string cod_pc)
        {

            try
            {



                // Configurar el cliente SMTP
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply@cerasus.cl", "Cerasus/2023..");

                // Configurar el correo electrónico
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("noreply@cerasus.cl");
                mail.To.Add(correoDestinatario);
                mail.CC.Add("eduardo.allende@giddingsfruit.com");
                mail.CC.Add("john.parra@giddingsfruit.com");
                mail.CC.Add("mario.perez@giddingsfruit.com");
                mail.Subject = "Acta de entrega";
                mail.Body = "Adjunto al correo está el acta de entrega, este acta ya estaba hecha, ahora esta cargada en sistema.";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;



                byte[] pdfBytes = null;


                using (var context = new MyDbContextUsuarios())
                {
                    // Buscar el PDF en la tabla DISPAUSU según el código de usuario seleccionado
                    var Usu = context.UsuariosDATOS.FirstOrDefault(d => d.COD_USUARIO == cod_usuario);
                    if (Usu != null)
                    {
                        pdfBytes = Usu.ActaEntregaPDF;


                    }




                }

                // Asegúrese de que se encontró un archivo PDF válido
                if (pdfBytes != null && pdfBytes.Length > 0)
                {
                    try
                    {
                        // Construye el nombre del archivo
                        string nombreArchivo = $"Acta de entrega {cod_usuario} {nombreUsuarioSeleccionado}.pdf";


                        // Adjuntar el archivo PDF
                        using (MemoryStream pdfStream = new MemoryStream(pdfBytes))
                        {
                            Attachment pdfAttachment = new Attachment(pdfStream, nombreArchivo, "application/pdf");
                            mail.Attachments.Add(pdfAttachment);

                            // Enviar correo electrónico
                            client.Send(mail); // Agrega esta línea
                            MessageBox.Show("Correo electrónico enviado correctamente.");
                            Console.WriteLine("Correo electrónico enviado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                        Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo PDF correspondiente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message);
                Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
            }
        }





        public void EnviarCorreoConActaEntrega() {

            // Obtener el valor seleccionado en el ComboBox
            string valorSeleccionado = comboBox2.SelectedItem.ToString();
            string cod_pc = comboBox1.SelectedItem.ToString();

            // Separar el valor basado en el espacio en blanco
            string[] partes = valorSeleccionado.Split(' ');

            // Suponiendo que el código de usuario es la primera parte
            string cod_usuario_seleccionado = partes[0];
            string nombreUsuarioSeleccionado = partes[1];

            string correoDestinatario = cod_usuario_seleccionado;
            string Cod_usario_acta = cod_usuario_seleccionado;

            using (var context = new MyDbContextUsuarios())
            {
                // Buscar el correo electrónico en la tabla USUARIOS_PC según el código de usuario seleccionado
                var usuario = context.UsuariosDATOS.FirstOrDefault(u => u.COD_USUARIO == cod_usuario_seleccionado);
                if (usuario != null)
                {
                    correoDestinatario = usuario.EMAIL; // Asegúrese de que "EMAIL" es el nombre correcto de la propiedad que representa la columna 4 en la tabla USUARIOS_PC
                }
            }

            // Verificar si la dirección de correo electrónico no está vacía antes de llamar al método EnviarCorreo
            if (!string.IsNullOrEmpty(correoDestinatario))
            {
                EnviarCorreoENTREGA(correoDestinatario, Cod_usario_acta, nombreUsuarioSeleccionado, cod_pc);
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la dirección de correo electrónico del destinatario.");
            }


        }

        public void EnviarCorreoConActaDevolucion() {

            // Obtener el valor seleccionado en el ComboBox
            string valorSeleccionado = comboBox2.SelectedItem.ToString();
            string cod_pc = comboBox1.SelectedItem.ToString();

            // Separar el valor basado en el espacio en blanco
            string[] partes = valorSeleccionado.Split(' ');

            // Suponiendo que el código de usuario es la primera parte
            string cod_usuario_seleccionado = partes[0];
            string nombreUsuarioSeleccionado = partes[1];

            string correoDestinatario = cod_usuario_seleccionado;
            string Cod_usario_acta = cod_usuario_seleccionado;

            using (var context = new MyDbContextUsuarios())
            {
                // Buscar el correo electrónico en la tabla USUARIOS_PC según el código de usuario seleccionado
                var usuario = context.UsuariosDATOS.FirstOrDefault(u => u.COD_USUARIO == cod_usuario_seleccionado);
                if (usuario != null)
                {
                    correoDestinatario = usuario.EMAIL; // Asegúrese de que "EMAIL" es el nombre correcto de la propiedad que representa la columna 4 en la tabla USUARIOS_PC
                }
            }

            // Verificar si la dirección de correo electrónico no está vacía antes de llamar al método EnviarCorreo
            if (!string.IsNullOrEmpty(correoDestinatario))
            {
                EnviarCorreoDEVOLUCION(correoDestinatario, Cod_usario_acta, nombreUsuarioSeleccionado, cod_pc);
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la dirección de correo electrónico del destinatario.");
            }


        }




        public void EnviarCorreoConActaEntregaCARGADA()
        {

            // Obtener el valor seleccionado en el ComboBox
            string valorSeleccionado = comboBox2.SelectedItem.ToString();
            string cod_pc = comboBox1.SelectedItem.ToString();

            // Separar el valor basado en el espacio en blanco
            string[] partes = valorSeleccionado.Split(' ');

            // Suponiendo que el código de usuario es la primera parte
            string cod_usuario_seleccionado = partes[0];
            string nombreUsuarioSeleccionado = partes[1];

            string correoDestinatario = cod_usuario_seleccionado;
            string Cod_usario_acta = cod_usuario_seleccionado;

            using (var context = new MyDbContextUsuarios())
            {
                // Buscar el correo electrónico en la tabla USUARIOS_PC según el código de usuario seleccionado
                var usuario = context.UsuariosDATOS.FirstOrDefault(u => u.COD_USUARIO == cod_usuario_seleccionado);
                if (usuario != null)
                {
                    correoDestinatario = usuario.EMAIL; // Asegúrese de que "EMAIL" es el nombre correcto de la propiedad que representa la columna 4 en la tabla USUARIOS_PC
                }
            }

            // Verificar si la dirección de correo electrónico no está vacía antes de llamar al método EnviarCorreo
            if (!string.IsNullOrEmpty(correoDestinatario))
            {
                EnviarCorreoENTREGA_CARGADA(correoDestinatario, Cod_usario_acta, nombreUsuarioSeleccionado, cod_pc);
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la dirección de correo electrónico del destinatario.");
            }


        }





        private void Btn_Enviar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            // bloque que guarda la asignacion
            try
            {
                using (var context = new MyDbContextAsignarPC())
                {
                    // Configurar el valor mínimo y máximo del progressBar1
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 7;

                    progressBar1.Value = 1; // Actualizar el valor del progressBar1

                    // El resto del código original aquí ...



                    // Obtener el código de usuario seleccionado en el ComboBox
                    string usuarioSeleccionado = comboBox2.SelectedItem.ToString();
                    string[] partes = usuarioSeleccionado.Split(' '); // Dividir el texto en partes separadas por espacios en blanco
                    string cod_usuario = partes[0]; // El código de usuario sería la primera parte del texto resultante

                    // Obtener la PC seleccionada en el ComboBox
                    string pcSeleccionado = comboBox1.SelectedItem.ToString();

                    //// Verificar si el usuario ya tiene un PC asignado
                    //bool usuarioConPC = context.ASIGNARUsuariosDATOS.Any(a => a.COD_USUARIO == cod_usuario);

                    //if (usuarioConPC)
                    //{
                    //    MessageBox.Show("El usuario ya tiene un PC asignado.");
                    //}
                    //else
                    //{


                    // Verificar si ya existe un registro con el mismo código de PC
                    bool pcExistente = context.ASIGNARUsuariosDATOS.Any(a => a.COD_PC == pcSeleccionado);



                    if (pcExistente)
                    {
                        MessageBox.Show("El código de Computador ya ha sido asignado a un usuario. Verifique e intente nuevamente.");
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        progressBar1.Value = 2; // Actualizar el valor del progressBar1

                        // Obtener el último número de acta registrado
                        int ultimoActa = context.ASIGNARUsuariosDATOS.Max(a => (int?)a.NUM_ACTA) ?? 0;

                        // Incrementar el número de acta en 1 para el nuevo registro
                        int nuevoActa = ultimoActa + 1;

                        // Crear un nuevo registro en la tabla DISPAUSU
                        var nuevoRegistro = new DISPAUSU
                        {
                            COD_PC = pcSeleccionado,
                            COD_USUARIO = cod_usuario,
                            NUM_ACTA = nuevoActa,
                            ENVIADO = 1,
                            ASIGNADO = 1,
                            FECHA_ASIGNACION = DateTime.Now
                        };

                        // Agregar el nuevo registro al contexto y guardar los cambios en la base de datos
                        context.ASIGNARUsuariosDATOS.Add(nuevoRegistro);
                        context.SaveChanges();

                        progressBar1.Value = 3; // avanzo con la barra de progreso

                        ShowSignatureDialog();

                        progressBar1.Value = 4; // avanzo con el progreso de la barra

                        MostrarAsignaciones();

                        progressBar1.Value = 5;




                        MessageBox.Show("Registro guardado exitosamente."); // Mostrar mensaje de éxito

                        string cod_pc = comboBox1.SelectedValue.ToString();
                        //string _cod_usuario = comboBox2.SelectedValue.ToString();
                        GenerarPDFAsigacion(cod_pc, cod_usuario);

                        progressBar1.Value = 6;


                        //Envío el correo a la bandeja de entrada del usuario y estec correo esta registrado en la tabla Usuarios
                        EnviarCorreoConActaEntrega();

                        progressBar1.Value = 7;
                        if (progressBar1.Value == 7)
                        {

                            LblProgreso.Text = "Última Asignación Completa: " + cod_pc;
                        }
                    }

                }
                //}
            }
            catch (DbUpdateException ex)
            {

                MessageBox.Show("Ocurrió un error al guardar el registro: " + ex.Message);
            }






        }








        private void BtnPDF_Click(object sender, EventArgs e)
        {


            //


        }

        private void BtnDevolucion_Click(object sender, EventArgs e)
        {


            try
            {
                using (var context = new MyDbContextAsignarPC())
                {
                    // Configurar el valor mínimo y máximo del progressBar1
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 7;

                    progressBar1.Value = 1; // Actualizar el valor del progressBar1


                    // ...

                    // Obtener el código de usuario seleccionado en el ComboBox
                    string usuarioSeleccionado = comboBox2.SelectedItem.ToString();
                    string[] partes = usuarioSeleccionado.Split(' '); // Dividir el texto en partes separadas por espacios en blanco
                    string cod_usuario = partes[0]; // El código de usuario sería la primera parte del texto resultante

                    // Obtener la PC seleccionada en el ComboBox
                    string pcSeleccionado = comboBox1.SelectedItem.ToString();

                    // Buscar el registro en la tabla ASIGNARUsuariosDATOS usando el código de usuario y PC seleccionados
                    var registro = context.ASIGNARUsuariosDATOS.FirstOrDefault(a => a.COD_USUARIO == cod_usuario && a.COD_PC == pcSeleccionado);

                    if (registro != null)
                    {
                        // Eliminar el registro encontrado
                        context.ASIGNARUsuariosDATOS.Remove(registro);
                        // Guardar los cambios en la base de datos
                        context.SaveChanges();

                        // Actualizar el UI
                        progressBar1.Value = 3;
                        ShowSignatureDialog();
                        progressBar1.Value = 4;
                        MostrarAsignaciones();
                        progressBar1.Value = 5;

                        GenerarPDFDevolucion(pcSeleccionado, cod_usuario);
                        progressBar1.Value = 6;

                        //Envío el correo a la bandeja de entrada del usuario y estec correo esta registrado en la tabla Usuarios
                        EnviarCorreoConActaDevolucion();


                        progressBar1.Value = 7;
                        if (progressBar1.Value == 7)
                        {
                            LblProgreso.Text = "Eliminado Correctamente: " + pcSeleccionado;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un registro con el código de usuario y PC seleccionados.");
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Ocurrió un error al realizar la devolucion del equipo: " + ex.Message);
            }





        }

        private void BtnDescargarActa_Click(object sender, EventArgs e)
        {


            string cod_pc = comboBox1.SelectedValue.ToString();
            DescargarPDF(cod_pc);
        }


        public class SignatureData
        {
            public byte[] SignatureBytes { get; set; }
        }
        private void ShowSignatureDialog()
        {
            using (var signatureForm = new SignatureForm())
            {
                if (signatureForm.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Guardando y mostrando la firma...");

                    Bitmap signatureImage = signatureForm.Signature;

                    MemoryStream signatureStream = new MemoryStream();
                    signatureImage.Save(signatureStream, ImageFormat.Png);
                    byte[] signatureBytes = signatureStream.ToArray();

                    SignatureData signatureData = new SignatureData();
                    signatureData.SignatureBytes = signatureBytes;

                    // Muestra la firma en el PictureBox
                    signaturePictureBox.Image = signatureImage;
                    signaturePictureBox.Refresh();


                    // Extrae el código de usuario del ComboBox2
                    string selectedItem = comboBox2.SelectedItem.ToString();
                    string[] parts = selectedItem.Split(' ');
                    string cod_usuario = parts[0].Trim();

                    // Guarda la firma en la base de datos
                    SaveSignatureToDatabase(cod_usuario, signatureData.SignatureBytes);


                }
            }
        }


        private void SaveSignatureToDatabase(string cod_usuario, byte[] signatureBytes)
        {

            string connectionString = "Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE USUARIOS_PC SET Firma = @Firma WHERE COD_USUARIO = @cod_usuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Firma", signatureBytes);
                    command.Parameters.AddWithValue("@cod_usuario", cod_usuario);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void BtnFirmar_Click(object sender, EventArgs e)
        {
            ShowSignatureDialog();
        }

        private void BtnDescargarFirma_Click(object sender, EventArgs e)
        {



            if (signaturePictureBox.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Guardar firma como imagen";
                saveFileDialog.FileName = "firma.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    signaturePictureBox.Image.Save(fileName, ImageFormat.Png);
                    MessageBox.Show("Firma guardada exitosamente en: " + fileName, "Guardar Firma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay una firma para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }




        private void BtnCargarActa_Click(object sender, EventArgs e)
        {

            // bloque que CREA una asignacion y guarda un PDF con CARGA
            try
            {
                using (var context = new MyDbContextAsignarPC())
                {
                    // Configurar el valor mínimo y máximo del progressBar1
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 7;

                    progressBar1.Value = 1; // Actualizar el valor del progressBar1

                    // El resto del código original aquí ...

                    // Obtener el código de usuario seleccionado en el ComboBox
                    string usuarioSeleccionado = comboBox2.SelectedItem.ToString();
                    string[] partes = usuarioSeleccionado.Split(' '); // Dividir el texto en partes separadas por espacios en blanco
                    string cod_usuario = partes[0]; // El código de usuario sería la primera parte del texto resultante

                    // Obtener la PC seleccionada en el ComboBox
                    string pcSeleccionado = comboBox1.SelectedItem.ToString();

                    // Verificar si ya existe un registro con el mismo código de PC
                    bool pcExistente = context.ASIGNARUsuariosDATOS.Any(a => a.COD_PC == pcSeleccionado);

                    if (pcExistente)
                    {
                        MessageBox.Show("El código de Computador ya ha sido asignado a un usuario. Verifique e intente nuevamente.");
                        progressBar1.Value = 0;
                    }
                    else
                    {
                        progressBar1.Value = 2; // Actualizar el valor del progressBar1

                        // Obtener el último número de acta registrado
                        int ultimoActa = context.ASIGNARUsuariosDATOS.Max(a => (int?)a.NUM_ACTA) ?? 0;

                        // Incrementar el número de acta en 1 para el nuevo registro
                        int nuevoActa = ultimoActa + 1;

                        // Crear un nuevo registro en la tabla DISPAUSU
                        var nuevoRegistro = new DISPAUSU
                        {
                            COD_PC = pcSeleccionado,
                            COD_USUARIO = cod_usuario,
                            NUM_ACTA = nuevoActa,
                            ENVIADO = 1,
                            ASIGNADO = 1,
                            FECHA_ASIGNACION = DateTime.Now
                        };

                        // Agregar el nuevo registro al contexto y guardar los cambios en la base de datos
                        context.ASIGNARUsuariosDATOS.Add(nuevoRegistro);
                        context.SaveChanges();

                        progressBar1.Value = 3; // avanzo con la barra de progreso

                        // ShowSignatureDialog();

                        progressBar1.Value = 4; // avanzo con el progreso de la barra

                        MostrarAsignaciones();

                        progressBar1.Value = 5;

                        MessageBox.Show("Registro guardado exitosamente."); // Mostrar mensaje de éxito

                        string cod_pc = comboBox1.SelectedValue.ToString();

                        byte[] pdfDataCARGA = null; // Declarar la variable aquí

                        // Abrir cuadro de diálogo para seleccionar el archivo PDF
                        DialogResult result = openFileDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string pdfFilePath = openFileDialog.FileName;
                            try
                            {
                                // Leer el archivo PDF y convertirlo en un array de bytes
                                pdfDataCARGA = File.ReadAllBytes(pdfFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al cargar el archivo PDF: " + ex.Message);
                            }
                        }





                        if (pdfDataCARGA != null)
                        {
                            // Después de guardar la asignación, usar un nuevo contexto para actualizar el registro de USUARIOS_PC
                            using (var contextUsuarios = new MyDbContextUsuarios())
                            {
                                var usuario_pc = contextUsuarios.UsuariosDATOS.SingleOrDefault(u => u.COD_USUARIO == cod_usuario);

                                if (usuario_pc != null)
                                {
                                    // Actualizar la columna ActaEntregaPDF y FECHA_ACTA_ENTREGA
                                    usuario_pc.ActaEntregaPDF = pdfDataCARGA;
                                    usuario_pc.FECHA_ACTA_ENTREGA = DateTime.Now;

                                    // Guardar los cambios en la base de datos
                                    contextUsuarios.SaveChanges();

                                    MessageBox.Show("El archivo PDF se cargó y guardó correctamente.");
                                    progressBar1.Value = 6;
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el registro de USUARIOS_PC para el usuario seleccionado.");
                                }
                            }

                            // Envío el correo a la bandeja de entrada del usuario y este correo esta registrado en la tabla Usuarios
                            EnviarCorreoConActaEntregaCARGADA();

                            progressBar1.Value = 7;
                            if (progressBar1.Value == 7)
                            {
                                LblProgreso.Text = "Última Asignación Completa: " + cod_pc;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se cargó ningún archivo PDF. Por favor, seleccione un archivo.");
                        }

                    }
                }
                // llave que cierra el try general
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el bloque de la carga... 'General' " + ex);
            }
            //llave que cierra el boton
        }



        // llaves que cierran la name class
    }
}

