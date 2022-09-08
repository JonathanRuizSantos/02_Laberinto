namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_Graphics = new System.Windows.Forms.Button();
            this.pB = new System.Windows.Forms.PictureBox();
            this.btSolucion = new System.Windows.Forms.Button();
            this.lbCola = new System.Windows.Forms.ListBox();
            this.lbPila = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Graphics
            // 
            this.bt_Graphics.Location = new System.Drawing.Point(613, 478);
            this.bt_Graphics.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_Graphics.Name = "bt_Graphics";
            this.bt_Graphics.Size = new System.Drawing.Size(131, 36);
            this.bt_Graphics.TabIndex = 0;
            this.bt_Graphics.Text = "Genera Laberinto";
            this.bt_Graphics.UseVisualStyleBackColor = true;
            this.bt_Graphics.Click += new System.EventHandler(this.bt_Graphics_Click);
            // 
            // pB
            // 
            this.pB.Location = new System.Drawing.Point(14, 77);
            this.pB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pB.Name = "pB";
            this.pB.Size = new System.Drawing.Size(583, 580);
            this.pB.TabIndex = 1;
            this.pB.TabStop = false;
            // 
            // btSolucion
            // 
            this.btSolucion.Location = new System.Drawing.Point(750, 478);
            this.btSolucion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSolucion.Name = "btSolucion";
            this.btSolucion.Size = new System.Drawing.Size(133, 36);
            this.btSolucion.TabIndex = 2;
            this.btSolucion.Text = "Solución";
            this.btSolucion.UseVisualStyleBackColor = true;
            this.btSolucion.Click += new System.EventHandler(this.btSolucion_Click);
            // 
            // lbCola
            // 
            this.lbCola.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbCola.FormattingEnabled = true;
            this.lbCola.ItemHeight = 20;
            this.lbCola.Location = new System.Drawing.Point(613, 77);
            this.lbCola.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbCola.Name = "lbCola";
            this.lbCola.Size = new System.Drawing.Size(270, 164);
            this.lbCola.TabIndex = 3;
            // 
            // lbPila
            // 
            this.lbPila.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPila.FormattingEnabled = true;
            this.lbPila.ItemHeight = 20;
            this.lbPila.Location = new System.Drawing.Point(613, 286);
            this.lbPila.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPila.Name = "lbPila";
            this.lbPila.Size = new System.Drawing.Size(270, 164);
            this.lbPila.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(708, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "COLA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(708, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "PILA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(905, 670);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPila);
            this.Controls.Add(this.lbCola);
            this.Controls.Add(this.btSolucion);
            this.Controls.Add(this.pB);
            this.Controls.Add(this.bt_Graphics);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bt_Graphics;
        private PictureBox pB;
        private Button btSolucion;
        private ListBox lbCola;
        private ListBox lbPila;
        private Label label1;
        private Label label2;
    }
}