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

            public Coords(float _b = 1, float _x = 1, float _y = 1)
            {
                b = _b;
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
        Graphics grafico, graficoTemporal;
        Bitmap btmpFondo, btmpTemporal;
        float escalaX, escalaY;
        Coords pesosP, pesosA;
        List<Data> dataset;
        Random r;
        float learningr;
        int radio;
        bool convergeA = false, convergeP = false, pesosGen = false;
        public Form1()
        {   
            InitializeComponent();
            CargarGrafico();
            dataset = new List<Data>();
            r = new Random();
        }
        
         float calc(Coords current) 
        {
            float val = current.b * pesosP.b;
            val += current.x * pesosP.x;
            val += current.y * pesosP.y;
            return val;
        }
        float calcA(Coords current) 
        {
            float val = current.b * pesosA.b;
            val += current.x * pesosA.x;
            val += current.y * pesosA.y;
            return val;
        }

        int classify(Coords current) {
            float cur = calcA(current);
            if(cur < 0) return 0;
            return 1;
        }
  
        float calcError(Data current) {
            float deseada;
            if(current.clase == 1) deseada = (float)0.5;
            else deseada = (float)-0.5;
            return deseada - calcA(current.coord);
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
            pesosP.b += (d.b * (x * learningr));
            pesosP.x += (d.x * x * learningr);
            pesosP.y += (d.y * x * learningr);
        }

        void updateA(Coords d, float x) {
            pesosA.b += (d.b * x * learningr);
            pesosA.x += (d.x * x * learningr);
            pesosA.y += (d.y * x * learningr);
        }

        public float actualizarA() {
            int n = dataset.Count();
            float acum = 0;
            for(int i = 0; i < n; ++i) {

                float x = calcError(dataset[i]);
                acum += x * x;
                if(x != 0) {
                    updateA(dataset[i].coord, (float)x);
                    ActualizarRecta();
                }
            }
            return acum;
        }

        public int actualizar() {
            int n = dataset.Count();
            int acum = 0;
            for(int i = 0; i < n; ++i) {

                int x = error(dataset[i]);
                if(x != 0) {
                    acum += Math.Abs(x);
                    update(dataset[i].coord, (float)x);
                    ActualizarRecta();
                }
            }
            return acum;
        }

        public Coords CoordenadasReales(Coords ans)
        {
            ans.x = (ans.x * escalaX)+(picBox.Width >> 1);
            ans.y = (-ans.y +1)*(escalaY);
            return ans;
        }

        float evalP(float num) {
            float y;
            if(pesosP.y == 0) return 0;
            y = (-pesosP.b - (pesosP.x * num)) / pesosP.y;
            return y;
        }
        float evalA(float num) {
            float y;
            if(pesosA.y == 0) return 0;
            y = (-pesosA.b - (pesosA.x * num)) / pesosA.y;
            return y;
        }

        

        private void AdalineClick(object sender, EventArgs e)
        {
            if (!pesosGen)
            {
                MessageBox.Show("No ha generado los pesos...");
                return;
            }
            lblEpoca.Visible = true;
            int epocas = (int)Epocas.Value;
            learningr = (float)learningR.Value;
            float minError = (float)ErrorDeseado.Value;
            for (int iteracion = 1; iteracion <= epocas; ++iteracion)
            {
                float errores = actualizarA() / (float)dataset.Count;
                Errores.Series["Adaline"].Points.AddXY("Generación: " + iteracion, errores);
                ActualizarRecta();
                lblEpoca.Text = "Época Actual: " + iteracion;
                lblEpoca.Refresh();
                if (errores < minError)
                {
                    MessageBox.Show("Convergio en la iteracion : " + iteracion);
                    convergeA = true;
                    ActualizarRecta();
                    ReShow();
                    return;
                }
                //MessageBox.Show("" + learningr + "pesos " + pesosA.b + " " + pesosA.x + " ");
            }
            MessageBox.Show("No se pudo converger");
        }

        public void ReShow()
        {
            //graficoTemporal.Clear(Color.Transparent);
            foreach(Data objeto in dataset)
            {
                Coords c = CoordenadasReales(objeto.coord);
                if (classify(objeto.coord) == 1)
                    graficoTemporal.DrawRectangle(new Pen(Color.Navy, 3), c.x - radio, c.y - radio, radio << 1, radio << 1);
                else 
                    graficoTemporal.DrawEllipse(new Pen(Color.Pink, 3), c.x - radio, c.y - radio, radio << 1, radio << 1);
            }
            picBox.Refresh();
        }

        private void PerceptronClick(object sender, EventArgs e)
        {
            if (!pesosGen)
            {
                MessageBox.Show("No ha generado los pesos...");
                return;
            }
            lblEpoca.Visible = true;
            int epocas = (int)Epocas.Value;
            learningr = (float)learningR.Value;
            for (int iteracion = 1; iteracion <= epocas; ++iteracion)
            {
                int errores = actualizar();
                //Errores.Series["Perceptron"].Points.AddXY("Generación: " + iteracion, errores);
                ActualizarRecta();
                lblEpoca.Text = "Época Actual: " + iteracion;
                lblEpoca.Refresh();
                if (errores == 0)
                {
                    MessageBox.Show("Convergio en la iteracion : " + iteracion);
                    convergeP = true;
                    ActualizarRecta();
                    return;
                }
            }
            MessageBox.Show("No se pudo converger");
        }

        private void ResetClick(object sender, EventArgs e)
        {
            CargarGrafico();
            pesosGen = false;
            lblEpoca.Visible = false;
            convergeP = false;
            convergeA = false;
            dataset.Clear();
            
            pesosP.x = 1;
            pesosP.y = 1;
            
            pesosA.x = 1;
            pesosA.y = 1;

            //Errores.Series["Perceptron"].Points.Clear();
            Errores.Series["Adaline"].Points.Clear();
        }

        public void ActualizarRecta()
        {
            graficoTemporal.Clear(Color.Transparent);
            RectaA();
            RectaP();
            picBox.Refresh();
        }

        public void RectaP()
        {
            Coords c = CoordenadasReales(new Coords(0, -1, evalP(-1)));
            Coords c2 = CoordenadasReales(new Coords(0, 1, evalP(1)));
            float x1 = c.x, y1 = c.y, x2 = c2.x, y2 = c2.y;
            Pen p = new Pen(Color.Blue);//(Color.FromArgb(255, 192, 128));//el color del boton perceptron;

            if (convergeP)
                grafico.DrawLine(p, x1, y1, x2, y2);
            else graficoTemporal.DrawLine(p, x1, y1, x2, y2);
        }
        public void RectaA()
        {
            Coords c = CoordenadasReales(new Coords(0, -1, evalA(-1)));
            Coords c2 = CoordenadasReales(new Coords(0, 1, evalA(1)));
            float x1 = c.x, y1 = c.y, x2 = c2.x, y2 = c2.y;
            Pen p = new Pen(Color.Orange);//(Color.FromArgb(128, 128, 255));//el color del boton adaline

            if (convergeA)
                grafico.DrawLine(p, x1, y1, x2, y2);
            else graficoTemporal.DrawLine(p, x1, y1, x2, y2);
        }

        private void InicializarPesos_Click(object sender, EventArgs e)
        {
            pesosGen = true;
            float temp = (float)r.NextDouble()/2;
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesosP.x = temp;

            temp = (float)r.NextDouble()/2;
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesosP.y = temp;
            
            temp = (float)r.NextDouble()/2;
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesosA.x = temp;

            temp = (float)r.NextDouble()/2;
            if (r.Next(0, 2) % 2 != 0) temp = -temp;
            pesosA.y = temp;
            
            ActualizarRecta();
        }

        private void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            radio = 10;
            Coords p = new Coords(1, (e.X - (picBox.Width >> 1)) / escalaX, ((e.Y / escalaY) - 1) * -1);
            //MessageBox.Show(""+p.x+", "+p.y);
            if (!convergeA)
            {
                p.b = 1;
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
            }
            else
            {
                if (classify(p)==1)
                {
                    grafico.FillRectangle(Brushes.Blue, e.X - radio, e.Y - radio, radio << 1, radio << 1);
                }
                else
                {
                    grafico.FillEllipse(Brushes.Red, e.X - radio, e.Y - radio, radio << 1, radio << 1);
                }
            }
            picBox.Refresh();
        }

        public void CargarGrafico()
        { 
            //fondo del picturebox
            btmpFondo = new Bitmap(picBox.Width, picBox.Height);
            grafico = Graphics.FromImage(btmpFondo);
            grafico.Clear(Color.White);

            //grafico temporal
            btmpTemporal = new Bitmap(picBox.Width, picBox.Height);
            graficoTemporal = Graphics.FromImage(btmpTemporal);
            graficoTemporal.Clear(Color.Transparent);

            //dibuja el eje
            grafico.DrawLine(new Pen(Color.Black), picBox.Width >> 1, 0, picBox.Width >> 1, picBox.Height);
            grafico.DrawLine(new Pen(Color.Black), 0, picBox.Height >> 1, picBox.Width, picBox.Height >> 1);
            
            //se asigna al fondo
            picBox.BackgroundImage = btmpFondo;
            picBox.Image = btmpTemporal;

            //dibujar la escala
            escalaX = picBox.Width / 2;
            escalaY = picBox.Height / 2;

            for (int i = 0; i < 2; ++i)
            {
                grafico.DrawLine(new Pen(Color.Blue), escalaX * i, (picBox.Height >> 1) -5, escalaX * i, (picBox.Height >> 1)+5);
                grafico.DrawLine(new Pen(Color.Blue), (picBox.Width >> 1)-5, escalaY * i, (picBox.Width >> 1)+5, escalaY * i);
                //dibujar las etiquetas
                grafico.DrawString("" + (i - 1), new Font("Arial", 10), new SolidBrush(Color.Black), escalaX * i, picBox.Height >> 1);
                grafico.DrawString("" + (i - 1)*-1, new Font("Arial", 10), new SolidBrush(Color.Black), picBox.Width >> 1, escalaY * i);
            }
            picBox.Refresh();
        }
    }
}
