using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Microsoft.Exchange.WebServices.Data;
using static CapaNegocio.CN_Productos;

namespace CapaPresentacion
{
  
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto=null;
        private bool Editar = false;
        private int variable_comparar;

        

        public Form1()
        {
            InitializeComponent();


            ValidarPermisos();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MostrarProdctos();
            //MostrarENVASE();


       

        }



        public void ValidarPermisos() {

            using (var dbContext = new MyDbContext())
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.NombreDeUsuario == Sesion.NombreDeUsuario);
                if (usuario != null && dbContext.TienePermisoDeAcceso(usuario.Id, "Form1"))
                {
                    // El usuario tiene permiso de acceso al formulario
                    // Carga los datos necesarios para el formulario
                }
                else
                {
                    // El usuario no tiene permiso de acceso al formulario
                    MessageBox.Show("No tiene permiso de acceso a este formulario. Contacte a su administrador");
                    this.Close();
                }
            }



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



        private void MostrarENVASE() {

            CN_Productos objeto = new CN_Productos();
            comboBox_ENVASE.DataSource = objeto.MostrarENVASE();
            comboBox_ENVASE.DisplayMember = "COD_ENVOP";
            comboBox_ENVASE.ValueMember = "COD_ENVOP";

        }
        private void obtenerENVASEKILOS()
        {

            // CN_Productos objeto = new CN_Productos();
            // comboBox_ENVASE.DataSource = objeto.MostrarENVASEKILOS(comboBox_ENVASE.Text);
            //comboBox_ENVASE.DisplayMember = "COD_ENVOP";
            //comboBox_ENVASE.ValueMember = "COD_ENVOP";

            // MessageBox.Show(comboBox_ENVASE.DataSource);

            CN_Productos objeto = new CN_Productos();
            comboBox_ENVASE.DataSource = objeto.MostrarENVASEKILOS(comboBox_ENVASE.Text);
            comboBox_ENVASE.DisplayMember = "PESO_NETO";
            comboBox_ENVASE.ValueMember = "PESO_NETO";

            // Obtener el objeto seleccionado del comboBox_ENVASE
            var selectedItem = comboBox_ENVASE.SelectedItem;

            if (selectedItem != null)
            {
                // Obtener el valor de la propiedad ValueMember del objeto seleccionado
                string envase = Convert.ToString(((DataRowView)selectedItem)[comboBox_ENVASE.ValueMember]);
                float cajas;
                float kilos;

                if (string.IsNullOrEmpty(TxtCalcularKilos.Text))
                {
                    MessageBox.Show("El campo de kilos está vacío");
                    return; // Sale del método sin realizar el cálculo
                }
                kilos = Convert.ToInt32(TxtCalcularKilos.Text);
                //cajas = kilos / float.Parse(envase);
                cajas = kilos / Convert.ToInt32(envase);

                LblCalcular.Text = Convert.ToString(cajas);
                //textBox2.Text = Convert.ToString(cajas);
                textBox2.Text = cajas != null ? Convert.ToString(cajas) : string.Empty;
                //MessageBox.Show("envase: " + envase + " kilos: " + kilos + " CAJAS: " + cajas);
            }








        }

        private void MostrarDespacho()
        {

            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarTABLAMIXDESPACHOS(txtBUSCAR_PRODUCTOR.Text);
            dataGridView2.DataSource = objeto.MostrarTABLAPRECIOLIQ(txtBUSCAR_PRODUCTOR.Text);

            


        }









        private void MostrarValidacion()
        {

            CN_Productos objeto = new CN_Productos();
            dataGridView3.DataSource = objeto.MostrarValidar(txtCOD_PRO_SEA.Text, txtLOTE.Text);



            //

        }
        //private void MostrarDespachoXlote()
        //{

        //    CN_Productos objeto = new CN_Productos();
        //    dataGridView1.DataSource = objeto.MostrarTABLAMIXDESPACHOSxLOTE(textBox1.Text);
            

        //}

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            //if (Editar == false)
            //{
            //    try
            //    {
            //        objetoCN.InsertarPRod(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
            //        MessageBox.Show("se inserto correctamente");
            //        MostrarProdctos();
            //        limpiarForm();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("no se pudo insertar los datos por: " + ex);
            //    }
            //}

            if (string.IsNullOrWhiteSpace(txtCOD_PRO_NUEVO.Text))
            {
                MessageBox.Show("Tiene que escribir un 'Productor Nuevo' para asignar el movimiento.", "Error moviendo cajas a productor nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si llegamos a este punto es porque el campo no está vacío, así que seguimos con la acción que quieras realizar
            // ...



          //  MostrarValidacion();


            string mensaje = "";
            string mensaje1 = "";
            string mensaje2 = "";




            try
            {

                


                // Obtén el número de filas en ambos DataGridViews
                int numRows1 = dataGridView1.Rows.Count;
                int numRows2 = dataGridView2.Rows.Count;


                // Itera a través de cada fila en ambos DataGridViews
                for (int i = 0; i < numRows1; i++)
                {
                    for (int j = 0; j < numRows2; j++)
                    {
                        if (dataGridView1.Rows[i].Cells["CAJAS"].Value != null && dataGridView2.Rows[j].Cells["CAJAS"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() == dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString())
                            {
                                // Si los valores son iguales, toma la decisión requerida.
                                // Por ejemplo, muestra un mensaje de confirmación.

                                //Console.WriteLine("Los campos son iguales en ambas filas.");
                                Console.WriteLine("Solo se puede mover las siguientes cajas de mix despachos: " + dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() + " " + dataGridView1.Rows[i].Cells["CORRELATIVO"].Value.ToString());
                                Console.WriteLine("Solo se puede mover las siguientes cajas de PRECIOLIQ: " + dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString() + " " + dataGridView2.Rows[j].Cells["CORRELATIVO PRECIOLIQ"].Value.ToString());

                                mensaje = "Solo se pueden mover las siguientes cajas :\n";
                                mensaje1 += "Mix Despachos: " + dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() + "\n";
                                mensaje2 += "Precio Liq: " + dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString() + "\n";

                                // MessageBox.Show(mensaje);

                                break;
                            }



                        }

                    }
                }

                // MessageBox.Show(mensaje);


            }
            catch (Exception EX)
            {

                MessageBox.Show("ERROR :" + EX);


            }


            //MessageBox.Show(mensaje + "\n" + mensaje1 + "\n" + mensaje2);



            if (mensaje1.Contains(txtCajas.Text) && mensaje2.Contains(txtCajas.Text))
            {

                MessageBox.Show(mensaje + "\n" + mensaje1 + "\n" + mensaje2);


                //EDITAR
                if (Editar == true)
                {

                    try
                    {
                        objetoCN.EditarProd(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtSEMANA.Text, txtCorrelativoMixD.Text, txtCajas.Text);
                      //  objetoCN.EditarPrecio(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtCajas.Text, txtCorrelativoP.Text);
                                                             
                        MessageBox.Show("Se movieron cajas de productor en Mix Despachos " + txtCOD_PRO_SEA.Text + " a productor " + txtCOD_PRO_NUEVO.Text + " con exito");
                       // MostrarDespacho();
                       // limpiarForm();
                        Editar = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El Productor " + txtCOD_PRO_NUEVO.Text + " no existe.!" + ex);

                    }



                }


                if (Editar == true)
                {

                    try
                    {
                        //objetoCN.EditarProd(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtSEMANA.Text, txtCorrelativoMixD.Text, txtCajas.Text);
                          objetoCN.EditarPrecio(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtCajas.Text, txtCorrelativoP.Text);

                        MessageBox.Show("Se movieron cajas de productor en Precio Liq " + txtCOD_PRO_SEA.Text + " a productor " + txtCOD_PRO_NUEVO.Text + "con exito");
                        MostrarDespacho();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El Productor " + txtCOD_PRO_NUEVO.Text + " no existe.!" + ex);

                    }



                }




                else
            {
                MessageBox.Show("las cajas no se pueden mover");
            }



                limpiarFiltros();







            ////EDITAR
            //if (Editar == true) {

            //    try
            //    {
            //        objetoCN.EditarProd(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtSEMANA.Text, txtCorrelativoMixD.Text, txtCajas.Text);
            //        MessageBox.Show("Se movieron cajas de productor " + txtCOD_PRO_SEA.Text + " a productor " + txtCOD_PRO_NUEVO.Text + "con exito" );
            //        MostrarDespacho();
            //        limpiarForm();
            //        Editar = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("El Productor " + txtCOD_PRO_NUEVO.Text + " no existe.!" );

            //    }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Editar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["LOTE MIXD"].Value.ToString();

                txtLOTE.Text = dataGridView1.CurrentRow.Cells["LOTE MIXD"].Value.ToString();
                    //txtCOD_PRO_NUEVO.Text = dataGridView1.CurrentRow.Cells["PRODUCTOR"].Value.ToString();
                    txtCOD_PRO_SEA.Text = dataGridView1.CurrentRow.Cells["PRODUCTOR"].Value.ToString();
                    txtCOD_VAR.Text = dataGridView1.CurrentRow.Cells["VARIEDAD"].Value.ToString();
                    txtSEMANA.Text = dataGridView1.CurrentRow.Cells["SEMANA"].Value.ToString();
                    txtCajas.Text = dataGridView1.CurrentRow.Cells["CAJAS"].Value.ToString();
                    txtCorrelativoMixD.Text = dataGridView1.CurrentRow.Cells["CORRELATIVO"].Value.ToString();

                                                                    if (dataGridView2.SelectedRows.Count > 0)
                                                                    {
                                                                        txtCorrelativoP.Text = dataGridView2.CurrentRow.Cells["CORRELATIVO PRECIOLIQ"].Value.ToString();
                                                                    }
                                                                    else
                                                                    {

                                                                    }
                
            
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de los despachos, después clic en editar para indicar el productor nuevo al cual se le asignara el movimiento.");

                }



            }

        private void limpiarForm() {
            txtCOD_PRO_SEA.Clear();
            //txtCOD_PRO_NUEVO.Text = "";
            txtCOD_VAR.Clear();
            txtSEMANA.Clear();
            txtLOTE.Clear();
            txtCajas.Clear();
            txtCorrelativoMixD.Clear();
            txtCorrelativoP.Clear();
            dataGridView3.DataSource = "";

            //textBox1.Clear();
            //textBox2.Clear();
            //textBox3.Clear();
        }


        private void limpiarFiltros() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                //objetoCN.EliminarPRod(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarDespacho();
            }
            else
                MessageBox.Show("seleccione una fila por favor");

        }

        private void btnBUSCAR_Click(object sender, EventArgs e)
        {

            toolStripProgressBar1.Value = 50;


            MostrarDespacho();


                        


           


            if (toolStripProgressBar1.Value == 100)
            {
                // Agregar un retraso de un segundo
                Thread.Sleep(1000);

                limpiarForm();
                toolStripStatusLabel1.Text = "Completo";
                toolStripProgressBar1.Value = 0;
            }







        }

        private void txtBUSCAR_PRODUCTOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                MostrarDespacho();

                limpiarForm();


                //aqui codigo
            }
            
        }


        //if ((int)e.KeyChar == (int)Keys.Enter)
        //{
        //aqui codigo
        //}



        //-------------  combinacion de filtros -----------------//3


        private void FilterDataGridView1()
        {
          

                string filterField1 = "LOTE MIXD";
                string filterField2 = "ENVASE OP";
                string filterField3 = "VARIEDAD";
                string filterField4 = "CAJAS";

                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox1.Text);
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter += string.Format(" AND [{0}] LIKE '%{1}%'", filterField2, textBox3.Text);
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter += string.Format(" AND [{0}] LIKE '%{1}%'", filterField3, textBox4.Text);
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter += string.Format(" AND convert([{0}], 'System.String') Like '%{1}%' ", filterField4, textBox2.Text);
              
           
          
          
        }

        private void FilterDataGridView2()
        {

            string filterField1 = "LOTE PRELIQ";
            string filterField2 = "CAJAS";
            string filterField3 = "ENVASE OP";
            string filterField4 = "VARIEDAD";

            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox1.Text);
            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter += string.Format(" AND convert([{0}], 'System.String') Like '%{1}%' ", filterField2, textBox2.Text);
            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter += string.Format(" AND [{0}] LIKE '%{1}%'", filterField3, textBox3.Text);
            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter += string.Format(" AND [{0}] LIKE '%{1}%'", filterField4, textBox4.Text);
            

        }






        // Los siguientes métodos de eventos deben llamar a ApplyFilters() en lugar de establecer la expresión de filtro directamente

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
            FilterDataGridView1();
            FilterDataGridView2();

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BackColor = Color.Yellow;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView1();
            FilterDataGridView2();
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Yellow;
            }
            else
            {
                textBox2.BackColor = Color.White;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView1();
            FilterDataGridView2();
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BackColor = Color.Yellow;
            }
            else
            {
                textBox3.BackColor = Color.White;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView1();
            FilterDataGridView2();
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.BackColor = Color.Yellow;
            }
            else
            {
                textBox4.BackColor = Color.White;
            }
        }








































        //---------------------------- COMENTADO PARA PROBAR EL CODIGO DE COMBINACION DE FILTRO ----------------------------//

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //    string filterField1 = "LOTE MIXD";
        //    string filterField2 = "LOTE PRELIQ";
        //    ////  string filterField3 = "CAJAS";

        //    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox1.Text);

        //    ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField2, textBox1.Text);



        //}

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{


        //    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("convert(CAJAS, 'System.String') Like '%{0}%' ", textBox2.Text);
        //    ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("convert(CAJAS, 'System.String') Like '%{0}%' ", textBox2.Text);
        //    //string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox2.Text);


        //}

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{


        //    string filterField3 = "ENVASE OP";
        //    string filterField4 = "ENVASE OP";
        //    ////  string filterField3 = "CAJAS";

        //    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField3, textBox3.Text);

        //    ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField4, textBox3.Text);

        //}

        //private void textBox4_TextChanged(object sender, EventArgs e)
        //{

        //    string filterField5 = "VARIEDAD";
        //    string filterField6 = "VARIEDAD";
        //    ////  string filterField3 = "CAJAS";

        //    ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField5, textBox4.Text);

        //    ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField6, textBox4.Text);


        //}

        //--------------------------------------------------- FIN COMENTADO PARA PROBAR EL CODIGO DE COMBINACION DE FILTRO --------------------------//



        private void button1_Click(object sender, EventArgs e)
        {

            string mensaje = "";
            string mensaje1 = "";
            string mensaje2 = "";
           



            try
            {

                MostrarValidacion();


                // Obtén el número de filas en ambos DataGridViews
                int numRows1 = dataGridView1.Rows.Count;
                int numRows2 = dataGridView2.Rows.Count;


                // Itera a través de cada fila en ambos DataGridViews
                for (int i = 0; i < numRows1; i++)
                            {
                                for (int j = 0; j < numRows2; j++)
                                {
                                        if (dataGridView1.Rows[i].Cells["CAJAS"].Value != null && dataGridView2.Rows[j].Cells["CAJAS"].Value != null)
                                        {
                                            if (dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() == dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString())
                                            {
                                                // Si los valores son iguales, toma la decisión requerida.
                                                // Por ejemplo, muestra un mensaje de confirmación.
                                
                                                //Console.WriteLine("Los campos son iguales en ambas filas.");
                                                Console.WriteLine("Solo se puede mover las siguientes cajas de mix despachos: " + dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() + " " + dataGridView1.Rows[i].Cells["CORRELATIVO"].Value.ToString());
                                                Console.WriteLine("Solo se puede mover las siguientes cajas de PRECIOLIQ: " + dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString() + " " + dataGridView2.Rows[j].Cells["CORRELATIVO PRECIOLIQ"].Value.ToString());

                                                mensaje = "Solo se pueden mover las siguientes cajas :\n";
                                                mensaje1 += "Mix Despachos: " + dataGridView1.Rows[i].Cells["CAJAS"].Value.ToString() + "\n";
                                                mensaje2 += "Precio Liq: " + dataGridView2.Rows[j].Cells["CAJAS"].Value.ToString() + "\n";
                               
                                               // MessageBox.Show(mensaje);

                                                break;
                                            }

                            

                        }
                      
                    }
                 }

               // MessageBox.Show(mensaje);


            }
            catch (Exception EX)
            {

                MessageBox.Show("ERROR :" + EX);

               
            }


            //MessageBox.Show(mensaje + "\n" + mensaje1 + "\n" + mensaje2);



            if (mensaje1.Contains(txtCajas.Text) && mensaje2.Contains(txtCajas.Text))
            {
        
                MessageBox.Show(mensaje + "\n" + mensaje1 + "\n" + mensaje2);
            }
            else
            {
                MessageBox.Show("las cajas no se pueden mover" + mensaje + "\n" + mensaje1 + "\n" + mensaje2);
            }


        }

       

        private void comboBox_ENVASE_DropDown(object sender, EventArgs e)
        {
            MostrarENVASE();
        }

        private void BtnCalcularCajas_Click(object sender, EventArgs e)
        {

            obtenerENVASEKILOS();


            //int Kilos = 0;
            //int Envase = 0;
            //int Cajas = 0;

            //Kilos = Convert.ToInt32(TxtCalcularKilos.Text);
            //Envase = comboBox_ENVASE.SelectedIndex;
            //Cajas = Kilos * Envase;

            //MessageBox.Show("son :" + Cajas + "  INDICE:" + comboBox_ENVASE.SelectedIndex + " VALOR:" + comboBox_ENVASE.SelectedItem);



            //int suma = 0; // Variable donde se almacenará la suma de los valores
            //int valor;

            //if (comboBox_ENVASE.SelectedValue != null) // Verificar que se haya seleccionado un valor en el ComboBox
            //{
            //    valor = Convert.ToInt32(comboBox_ENVASE.SelectedValue); // Obtener el valor seleccionado y convertirlo a entero
            //    suma += valor; // Sumar el valor a la variable "suma"
            //}

            //MessageBox.Show("La suma es: " + suma); // Mostrar el resultado en un mensaje


            //MessageBox.Show();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();


        }

       
    }
}

