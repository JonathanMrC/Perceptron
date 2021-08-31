
namespace Perceptron

{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PanelDiv = new System.Windows.Forms.TableLayoutPanel();
            this.panelArriba = new System.Windows.Forms.Panel();
            this.lblEpoca = new System.Windows.Forms.Label();
            this.Perceptron = new System.Windows.Forms.Button();
            this.InicializarPesos = new System.Windows.Forms.Button();
            this.Epocas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.learningR = new System.Windows.Forms.NumericUpDown();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.panelAbajo = new System.Windows.Forms.Panel();
            this.Errores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.PanelDiv.SuspendLayout();
            this.panelArriba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Epocas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.panelAbajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errores)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelDiv
            // 
            this.PanelDiv.ColumnCount = 1;
            this.PanelDiv.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelDiv.Controls.Add(this.panelArriba, 0, 0);
            this.PanelDiv.Controls.Add(this.panelAbajo, 0, 1);
            this.PanelDiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDiv.Location = new System.Drawing.Point(0, 0);
            this.PanelDiv.Name = "PanelDiv";
            this.PanelDiv.RowCount = 2;
            this.PanelDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.PanelDiv.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.PanelDiv.Size = new System.Drawing.Size(1064, 681);
            this.PanelDiv.TabIndex = 0;
            // 
            // panelArriba
            // 
            this.panelArriba.Controls.Add(this.button1);
            this.panelArriba.Controls.Add(this.lblEpoca);
            this.panelArriba.Controls.Add(this.Perceptron);
            this.panelArriba.Controls.Add(this.InicializarPesos);
            this.panelArriba.Controls.Add(this.Epocas);
            this.panelArriba.Controls.Add(this.label2);
            this.panelArriba.Controls.Add(this.label1);
            this.panelArriba.Controls.Add(this.learningR);
            this.panelArriba.Controls.Add(this.picBox);
            this.panelArriba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArriba.Location = new System.Drawing.Point(0, 0);
            this.panelArriba.Margin = new System.Windows.Forms.Padding(0);
            this.panelArriba.Name = "panelArriba";
            this.panelArriba.Size = new System.Drawing.Size(1064, 476);
            this.panelArriba.TabIndex = 0;
            // 
            // lblEpoca
            // 
            this.lblEpoca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpoca.AutoSize = true;
            this.lblEpoca.Location = new System.Drawing.Point(765, 174);
            this.lblEpoca.Name = "lblEpoca";
            this.lblEpoca.Size = new System.Drawing.Size(87, 13);
            this.lblEpoca.TabIndex = 15;
            this.lblEpoca.Text = "Épocas Actual: x";
            this.lblEpoca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEpoca.Visible = false;
            // 
            // Perceptron
            // 
            this.Perceptron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Perceptron.Location = new System.Drawing.Point(866, 137);
            this.Perceptron.Name = "Perceptron";
            this.Perceptron.Size = new System.Drawing.Size(189, 30);
            this.Perceptron.TabIndex = 14;
            this.Perceptron.Text = "Perceptrón";
            this.Perceptron.UseVisualStyleBackColor = true;
            this.Perceptron.Click += new System.EventHandler(this.Perceptron_Click);
            // 
            // InicializarPesos
            // 
            this.InicializarPesos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InicializarPesos.Location = new System.Drawing.Point(866, 91);
            this.InicializarPesos.Name = "InicializarPesos";
            this.InicializarPesos.Size = new System.Drawing.Size(189, 30);
            this.InicializarPesos.TabIndex = 13;
            this.InicializarPesos.Text = "Inicializar pesos";
            this.InicializarPesos.UseVisualStyleBackColor = true;
            this.InicializarPesos.Click += new System.EventHandler(this.InicializarPesos_Click);
            // 
            // Epocas
            // 
            this.Epocas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Epocas.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Epocas.Location = new System.Drawing.Point(961, 49);
            this.Epocas.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Epocas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Epocas.Name = "Epocas";
            this.Epocas.Size = new System.Drawing.Size(94, 20);
            this.Epocas.TabIndex = 12;
            this.Epocas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Epocas.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(866, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Épocas máximas:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(866, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Learning Rate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // learningR
            // 
            this.learningR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.learningR.DecimalPlaces = 1;
            this.learningR.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.learningR.Location = new System.Drawing.Point(961, 9);
            this.learningR.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            this.learningR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.learningR.Name = "learningR";
            this.learningR.Size = new System.Drawing.Size(94, 20);
            this.learningR.TabIndex = 9;
            this.learningR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.learningR.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBox.Location = new System.Drawing.Point(9, 9);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(750, 460);
            this.picBox.TabIndex = 8;
            this.picBox.TabStop = false;
            this.picBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseClick);
            // 
            // panelAbajo
            // 
            this.panelAbajo.Controls.Add(this.Errores);
            this.panelAbajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAbajo.Location = new System.Drawing.Point(0, 476);
            this.panelAbajo.Margin = new System.Windows.Forms.Padding(0);
            this.panelAbajo.Name = "panelAbajo";
            this.panelAbajo.Size = new System.Drawing.Size(1064, 205);
            this.panelAbajo.TabIndex = 1;
            // 
            // Errores
            // 
            chartArea1.Name = "ChartArea1";
            this.Errores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Errores.Legends.Add(legend1);
            this.Errores.Location = new System.Drawing.Point(12, 16);
            this.Errores.Name = "Errores";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Errores";
            this.Errores.Series.Add(series1);
            this.Errores.Size = new System.Drawing.Size(1043, 177);
            this.Errores.TabIndex = 0;
            this.Errores.Text = "Errores";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.PanelDiv);
            this.MaximumSize = new System.Drawing.Size(1080, 720);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perceptrón";
            this.PanelDiv.ResumeLayout(false);
            this.panelArriba.ResumeLayout(false);
            this.panelArriba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Epocas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.panelAbajo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Errores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelDiv;
        private System.Windows.Forms.Panel panelArriba;
        private System.Windows.Forms.Label lblEpoca;
        private System.Windows.Forms.Button Perceptron;
        private System.Windows.Forms.Button InicializarPesos;
        private System.Windows.Forms.NumericUpDown Epocas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown learningR;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel panelAbajo;
        private System.Windows.Forms.DataVisualization.Charting.Chart Errores;
        private System.Windows.Forms.Button button1;
    }
}

