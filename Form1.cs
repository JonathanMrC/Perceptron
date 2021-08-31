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
            public float b, x, y;

            public Coords(float _b, float _x, float _y)
            {
                b = 1;
                x = _x;
                y = _y;
            }
        }
        public struct Data
        {
            public Coords coord;
            public int clase;

            public Data(Coords _coord, int _clase)
            {
                coord = _coord;
                clase = _clase;
            }
        }
        Graphics grafico;
        Bitmap btmp;
        float escalaX, escalaY;
        Coords pesos;
        List<Data> dataset;
        Random r;
        int learningr;

        public Form1()
        {   
            InitializeComponent();
            CargarGrafico();
            dataset = new List<Data>();
            dataset.Add(new Data(new Coords(0,0, 0), 0));
            r = new Random();
        }
        
        private void Perceptron_Click(object sender, EventArgs e)
        {
            lblEpoca.Visible = true;
            int epocas = (int)Epocas.Value;
            learningr = (int)learningR.Value;
            for(int iteracion = 1; iteracion <= epocas; ++iteracion) {
                bool cur = actualizar();
                ActualizarRecta();
                if(cur) {
                    MessageBox.Show("Convergio en la iteracion : " + iteracion);
                    return;
                }
            }
            MessageBox.Show("No se pudo converger");
        }

        float calc(Coords current) 
        {
            float val = current.b * pesos.b;
            val += current.x * pesos.x;
            val += current.y * pesos.y;
            return val;
        }
        
        int step(Coords current) {
            if (calc(current) >= (float)0)
                return 1;
            return 0;
        }

        public int error(Data d)
        {
            return d.clase - step(d.coord);
        }
        
        void update(Coords d, float x) {
            pesos.b += (d.b * x * learningr);
            pesos.x += (d.x * x * learningr);
            pesos.y += (d.y * x * learningr);
        }

        public bool actualizar() {
            int n = dataset.Count();
            bool done = true;
            for(int i = 0; i < n; ++i) {
                int x = error(dataset[i]);
                if(x != 0) {
                    done = false;
                    update(dataset[i].coord, x);
                }
            }
            return done;
        }

        public Coords CoordenadasReales(Coords ans)
        {

            ans.x = (ans.x * escalaX)+(picBox.Width >> 1);
            ans.y = (-ans.y +5)*(escalaY);
            return ans;
        }

        float eval(float num) {
            float y = (pesos.b - (pesos.x * num)) / pesos.y;
            return y;
        }

        public void ActualizarRecta()
        {
            Coords c = CoordenadasReales(new Coords(0,-5, eval(-5)));
            Coords c2 = CoordenadasReales(new Coords(0, 5, eval(5)));
            float x1 = c.x;
            float y1 = c.y;
            float x2 = c2.x;
            float y2 = c2.y;
            
            grafico.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
            
            picBox.Refresh();
            //MessageBox.Show(""+dataset[0].Key.x+", "+dataset[0].Key.y);
        }
        private void InicializarPesos_Click(object sender, EventArgs e)
        {
            float temp = (float)r.NextDouble() + (float)r.Next(0, 6);
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesos.x = (float)0.1;

            temp = (float)r.NextDouble()  + (float)r.Next(0, 6);
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesos.y = (float)0.1;

            dataset[0] = new Data(pesos, -1);
            
             pesos.x = (float)1.1;
               pesos.y = (float)1.1;
            ActualizarRecta();
        }

        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            int radio = 10;
            Coords p = new Coords(1,(e.X - (picBox.Width >> 1)) / escalaX, ((e.Y / escalaY) - 5) * -1);
            p.b = 1;
            MessageBox.Show(""+calc(p));
            if (e.Button.Equals(MouseButtons.Right))
            {
                dataset.Add(new Data(p, 1));
                grafico.FillRectangle(Brushes.Blue, e.X - radio, e.Y - radio, radio << 1, radio << 1);
            }
            else
            {
                dataset.Add(new Data(p, 0));
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
