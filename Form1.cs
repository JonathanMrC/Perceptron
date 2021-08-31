using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        public struct Coords
        {
            public float x, y;
            

            public Coords(float _x, float _y)
            {
                x = _x;
                y = _y;
            }
        }
        Graphics grafico;
        Bitmap btmp;
        float escalaX, escalaY;
        Coords pesos;
        List<Coords> Clase1, Clase2;
        Random r;

        public Form1()
        {   
            InitializeComponent();
            CargarGrafico();
            Clase1 = new List<Coords>();
            Clase2 = new List<Coords>();
            r = new Random(new Random(846213213).Next());
        }

        private void Perceptron_Click(object sender, EventArgs e)
        {
            lblEpoca.Visible = true;
        }

        private void InicializarPesos_Click(object sender, EventArgs e)
        {
            float temp = (float)r.NextDouble() + (float)r.Next(0, 6);
            if (r.Next(0, 2) % 2 != 0
                ) temp = -temp;
            pesos.x = temp;
            temp = (float)r.NextDouble() + (float)r.Next(0, 6);
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesos.y = temp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            int radio = 10;
            Coords p = new Coords((e.X - (picBox.Width >> 1)) / escalaX, ((e.Y / escalaY) - 5) * -1);
            if (e.Button.Equals(MouseButtons.Right))
            {
                Clase1.Add(p);
                grafico.FillRectangle(Brushes.Blue, e.X - radio, e.Y - radio, radio << 1, radio << 1);
            }
            else
            {
                Clase2.Add(p);
                grafico.FillEllipse(Brushes.Red, e.X - radio, e.Y - radio, radio << 1, radio << 1);
            }
            picBox.Refresh();
        }
        
        public void CargarGrafico()
        {
            btmp = new Bitmap(picBox.Width, picBox.Height);
            grafico = Graphics.FromImage(btmp);
            grafico.Clear(Color.White);
            //dibuja el eje
            grafico.DrawLine(new Pen(Color.Black), picBox.Width >> 1, 0, picBox.Width >> 1, picBox.Height);
            grafico.DrawLine(new Pen(Color.Black), 0, picBox.Height >> 1, picBox.Width, picBox.Height >> 1);
            
            picBox.Image = btmp;

            //dibujar la escala
            escalaX = picBox.Width / 10;
            escalaY = picBox.Height / 10;

            for (int i = 0; i < 10; ++i)
            {
                grafico.DrawLine(new Pen(Color.Blue), escalaX * i, (picBox.Height >> 1) -5, escalaX * i, (picBox.Height >> 1)+5);
                grafico.DrawLine(new Pen(Color.Blue), (picBox.Width >> 1)-5, escalaY * i, (picBox.Width >> 1)+5, escalaY * i);
                //dibujar las etiquetas
                grafico.DrawString("" + (i - 5), new Font("Arial", 10), new SolidBrush(Color.Black), escalaX * i, picBox.Height >> 1);
                grafico.DrawString("" + (i - 5)*-1, new Font("Arial", 10), new SolidBrush(Color.Black), picBox.Width >> 1, escalaY * i);
            }
        }
    }
}
