using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto=null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MostrarProdctos();
        }



        private void MostrarDespacho() {

            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarTABLAMIXDESPACHOS(txtBUSCAR_PRODUCTOR.Text);
            dataGridView2.DataSource = objeto.MostrarTABLAPRECIOLIQ(txtBUSCAR_PRODUCTOR.Text);

        }

        private void MostrarDespachoXlote()
        {

            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarTABLAMIXDESPACHOSxLOTE(textBox1.Text);
            

        }

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
            //EDITAR
            if (Editar == true) {

                try
                {
                    objetoCN.EditarProd(txtLOTE.Text, txtCOD_PRO_SEA.Text, txtCOD_PRO_NUEVO.Text, txtCOD_VAR.Text, txtSEMANA.Text, txtCorrelativoMixD.Text, txtCajas.Text);
                    MessageBox.Show("se edito correctamente");
                    MostrarDespacho();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El Productor no existe, por favor verifique si la informacion es correcta.!" + ex);

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtLOTE.Text = dataGridView1.CurrentRow.Cells["LOTE MIXD"].Value.ToString();
                //txtCOD_PRO_NUEVO.Text = dataGridView1.CurrentRow.Cells["PRODUCTOR"].Value.ToString();
                txtCOD_PRO_SEA.Text = dataGridView1.CurrentRow.Cells["PRODUCTOR"].Value.ToString();
                txtCOD_VAR.Text = dataGridView1.CurrentRow.Cells["VARIEDAD"].Value.ToString();
                txtSEMANA.Text = dataGridView1.CurrentRow.Cells["SEMANA"].Value.ToString();
                txtCajas.Text = dataGridView1.CurrentRow.Cells["CAJAS"].Value.ToString();
                txtCorrelativoMixD.Text = dataGridView1.CurrentRow.Cells["CORRELATIVO"].Value.ToString();
                txtCorrelativoP.Text = dataGridView2.CurrentRow.Cells["CORRELATIVO PRECIOLIQ"].Value.ToString();
                //idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
               
                MessageBox.Show("DEBE SELECCIONAR UNA FILA DE LOS DESPACHOS POR FAVOR");
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
         
            //textBox1.Clear();
            //textBox2.Clear();
            //textBox3.Clear();
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

            MostrarDespacho();

            limpiarForm();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string filterField1 = "LOTE MIXD";
            string filterField2 = "LOTE PRELIQ";
            ////  string filterField3 = "CAJAS";

            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox1.Text);

            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField2, textBox1.Text);

            //  //((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField3, textBox1.Text);

            //  //((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField3, textBox1.Text);



            //((DataTable)dataGridView1.DataSource).DefaultView
            //                                   .RowFilter = "LOTE MIXD"+"=" + textBox1.Text;

            //((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "";

            //((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = null;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

                     
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("convert(CAJAS, 'System.String') Like '%{0}%' ", textBox2.Text);
            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("convert(CAJAS, 'System.String') Like '%{0}%' ", textBox2.Text);
                                                                         //string.Format("[{0}] LIKE '%{1}%'", filterField1, textBox2.Text);

         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


            string filterField3 = "ENVASE OP";
            string filterField4 = "ENVASE OP";
            ////  string filterField3 = "CAJAS";

            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField3, textBox3.Text);

            ((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField4, textBox3.Text);





        }
    }
}
