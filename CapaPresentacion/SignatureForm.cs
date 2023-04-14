using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class SignatureForm : Form
    {


        public Bitmap Signature { get; private set; }
        private Point previousPoint;

        private Bitmap drawingBitmap;


        public SignatureForm()
        {
            InitializeComponent();
            drawingBitmap = new Bitmap(signaturepanel.Width, signaturepanel.Height);
            signaturepanel.BackgroundImage = drawingBitmap;

            signaturepanel.MouseDown += SignaturePanel_MouseDown;
            signaturepanel.MouseMove += SignaturePanel_MouseMove;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;


            // Suscribirse al evento Shown
            this.Shown += SignatureForm_Shown;
            
            // Suscribirse al evento mousemove
            this.MouseMove += new MouseEventHandler(SignatureForm_MouseMove);

        }
        private void CenterCursor()
        {
            int x = this.Location.X + (this.Width / 2);
            int y = this.Location.Y + (this.Height / 2);
            Cursor.Position = new Point(x, y);
        }
        private void SignatureForm_Shown(object sender, EventArgs e)
        {
            CenterCursor();
        }



        private void SignaturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
        }

        private void SignaturePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(Pens.Blue, previousPoint, e.Location);
                }
                signaturepanel.Invalidate(); // Refresca el panel para mostrar los cambios
                previousPoint = e.Location;
            }


            

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Signature = new Bitmap(drawingBitmap);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }





        private void BtnResetFirma_Click(object sender, EventArgs e)
        {



            // Recargue el formulario en lugar de limpiar el panel de firma
            SignatureForm newSignatureForm = new SignatureForm();
            this.Hide();
            if (newSignatureForm.ShowDialog() == DialogResult.OK)
            {
                Signature = newSignatureForm.Signature;
                DialogResult = DialogResult.OK;


            }

        }

        private void SignatureForm_MouseMove(object sender, MouseEventArgs e)
        {

            // Obtén las coordenadas del formulario en la pantalla
            Point formLocation = this.PointToScreen(Point.Empty);

            // Calcula las coordenadas de las esquinas del formulario
            int left = formLocation.X;
            int top = formLocation.Y;
            int right = formLocation.X + this.Width;
            int bottom = formLocation.Y + this.Height;

            // Limita la posición del cursor al área del formulario
            int newX = Math.Max(left, Math.Min(right - 1, Cursor.Position.X));
            int newY = Math.Max(top, Math.Min(bottom - 1, Cursor.Position.Y));

            Cursor.Position = new Point(newX, newY);


        }
    }

}