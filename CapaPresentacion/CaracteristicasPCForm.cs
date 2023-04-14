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

namespace CapaPresentacion
{
    public partial class CaracteristicasPCForm : Form
    {
        public CaracteristicasPCForm()
        {
            InitializeComponent();
        }




        public class MyDbContextTipoPC : DbContext
        {
            public MyDbContextTipoPC() : base("Data Source=192.168.1.4;Initial Catalog=ToolsCerasus;User Id=sa;Password=Passw0rd..;")
            {
            }


            public DbSet<TIPOPC> CrearTipoPC { get; set; }
            public DbSet<RAM> CrearRAM { get; set; }
            public DbSet<PROCESADORES> CrearPROCESADOR { get; set; }
            public DbSet<TIPOSDISCOS> CrearTIPODISCO { get; set; }
            public DbSet<SISTEMA_OPERATIVO> CrearSO { get; set; }
            public DbSet<CAPACIDAD_DISCOS> CrearCAPACIDAD_DISCOS { get; set; }
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
            public int  CAPACIDAD_DISCO { get; set; }
           

        }




        private void BtnTipoPC_Click(object sender, EventArgs e)
        {


            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    string tipoPC = TxtTipoPC.Text;
                    var registroExistente = db.CrearTipoPC.FirstOrDefault(tpc => tpc.Tipo_PC == tipoPC);

                    if (registroExistente == null)
                    {
                        TIPOPC crearTIPO = new TIPOPC
                        {
                            Tipo_PC = tipoPC
                        };

                        db.CrearTipoPC.Add(crearTIPO);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void BtnRam_Click(object sender, EventArgs e)
        {



            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    int capacidad_ram = Convert.ToInt32(TxtRam.Text);
                    var registroExistente = db.CrearRAM.FirstOrDefault(tpc => tpc.CAPACIDAD_RAM == capacidad_ram);

                    if (registroExistente == null)
                    {
                        RAM crearRAM = new RAM
                        {
                            CAPACIDAD_RAM = capacidad_ram
                        };

                        db.CrearRAM.Add(crearRAM);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }





        }

        private void BtnCapDisco_Click(object sender, EventArgs e)
        {



            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    int capacidad_disco = Convert.ToInt32(TxtCapDisco.Text);
                    var registroExistente = db.CrearCAPACIDAD_DISCOS.FirstOrDefault(tpc => tpc.CAPACIDAD_DISCO == capacidad_disco);

                    if (registroExistente == null)
                    {
                        CAPACIDAD_DISCOS crearDisco = new CAPACIDAD_DISCOS
                        {
                            CAPACIDAD_DISCO = capacidad_disco
                        };

                        db.CrearCAPACIDAD_DISCOS.Add(crearDisco);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }






        }

        private void BtnProcesador_Click(object sender, EventArgs e)
        {



            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    String procesador = TxtProcesador.Text;
                    var registroExistente = db.CrearPROCESADOR.FirstOrDefault(tpc => tpc.PROCESADOR == procesador);

                    if (registroExistente == null)
                    {
                        PROCESADORES creaProcesador = new PROCESADORES
                        {
                            PROCESADOR = procesador
                        };

                        db.CrearPROCESADOR.Add(creaProcesador);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }





        }

        private void BtnTipoDisco_Click(object sender, EventArgs e)
        {

            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    String tipodisco = TxtTipoDisco.Text;
                    var registroExistente = db.CrearTIPODISCO.FirstOrDefault(tpc => tpc.TIPO_DISCO == tipodisco);

                    if (registroExistente == null)
                    {
                        TIPOSDISCOS creadisco = new TIPOSDISCOS
                        {
                            TIPO_DISCO = tipodisco
                        };

                        db.CrearTIPODISCO.Add(creadisco);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }








        }

        private void BtnSO_Click(object sender, EventArgs e)
        {



            using (var db = new MyDbContextTipoPC())
            {
                try
                {
                    String SistemaOperativo = TxtSO.Text;
                    var registroExistente = db.CrearSO.FirstOrDefault(tpc => tpc.SO == SistemaOperativo);

                    if (registroExistente == null)
                    {
                        SISTEMA_OPERATIVO creaSO = new SISTEMA_OPERATIVO
                        {
                            SO = SistemaOperativo
                        };

                        db.CrearSO.Add(creaSO);
                        db.SaveChanges();

                        MessageBox.Show("Registro creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El registro ya existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el registro. Detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }








        }
    }
}
