namespace WindowsFormsApp1
{
    partial class ResultadoBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.habLabel = new System.Windows.Forms.Label();
            this.acompLabel = new System.Windows.Forms.Label();
            this.duracion_label = new System.Windows.Forms.Label();
            this.fechalabel = new System.Windows.Forms.Label();
            this.SimpleLabel = new System.Windows.Forms.Label();
            this.MatrimonialLabel = new System.Windows.Forms.Label();
            this.TripleLabel = new System.Windows.Forms.Label();
            this.AplicarButtom = new System.Windows.Forms.Button();
            this.clientLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // habLabel
            // 
            this.habLabel.AutoSize = true;
            this.habLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.habLabel.Location = new System.Drawing.Point(12, 174);
            this.habLabel.Name = "habLabel";
            this.habLabel.Size = new System.Drawing.Size(299, 29);
            this.habLabel.TabIndex = 15;
            this.habLabel.Text = "Habitaciones Disponibles: ";
            // 
            // acompLabel
            // 
            this.acompLabel.AutoSize = true;
            this.acompLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.acompLabel.Location = new System.Drawing.Point(12, 131);
            this.acompLabel.Name = "acompLabel";
            this.acompLabel.Size = new System.Drawing.Size(184, 29);
            this.acompLabel.TabIndex = 14;
            this.acompLabel.Text = "Acompañantes: ";
            // 
            // duracion_label
            // 
            this.duracion_label.AutoSize = true;
            this.duracion_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.duracion_label.Location = new System.Drawing.Point(12, 87);
            this.duracion_label.Name = "duracion_label";
            this.duracion_label.Size = new System.Drawing.Size(326, 29);
            this.duracion_label.TabIndex = 13;
            this.duracion_label.Text = "Duracion de la Reservacion:  ";
            // 
            // fechalabel
            // 
            this.fechalabel.AutoSize = true;
            this.fechalabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.fechalabel.Location = new System.Drawing.Point(12, 47);
            this.fechalabel.Name = "fechalabel";
            this.fechalabel.Size = new System.Drawing.Size(272, 29);
            this.fechalabel.TabIndex = 12;
            this.fechalabel.Text = "Fecha de Reservacion:  ";
            // 
            // SimpleLabel
            // 
            this.SimpleLabel.AutoSize = true;
            this.SimpleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.SimpleLabel.Location = new System.Drawing.Point(40, 203);
            this.SimpleLabel.Name = "SimpleLabel";
            this.SimpleLabel.Size = new System.Drawing.Size(109, 29);
            this.SimpleLabel.TabIndex = 18;
            this.SimpleLabel.Text = "- Simple:";
            // 
            // MatrimonialLabel
            // 
            this.MatrimonialLabel.AutoSize = true;
            this.MatrimonialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.MatrimonialLabel.Location = new System.Drawing.Point(40, 232);
            this.MatrimonialLabel.Name = "MatrimonialLabel";
            this.MatrimonialLabel.Size = new System.Drawing.Size(158, 29);
            this.MatrimonialLabel.TabIndex = 19;
            this.MatrimonialLabel.Text = "- Matrimonial:";
            // 
            // TripleLabel
            // 
            this.TripleLabel.AutoSize = true;
            this.TripleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TripleLabel.Location = new System.Drawing.Point(40, 261);
            this.TripleLabel.Name = "TripleLabel";
            this.TripleLabel.Size = new System.Drawing.Size(97, 29);
            this.TripleLabel.TabIndex = 20;
            this.TripleLabel.Text = "- Triple:";
            // 
            // AplicarButtom
            // 
            this.AplicarButtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AplicarButtom.Location = new System.Drawing.Point(279, 370);
            this.AplicarButtom.Name = "AplicarButtom";
            this.AplicarButtom.Size = new System.Drawing.Size(206, 42);
            this.AplicarButtom.TabIndex = 21;
            this.AplicarButtom.Text = "Aplicar Reservacion";
            this.AplicarButtom.UseVisualStyleBackColor = true;
            this.AplicarButtom.Click += new System.EventHandler(this.AplicarButtom_Click);
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.clientLabel.Location = new System.Drawing.Point(12, 9);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(101, 29);
            this.clientLabel.TabIndex = 23;
            this.clientLabel.Text = "Cliente: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label6.Location = new System.Drawing.Point(12, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Total a Pagar:  ";
            // 
            // ResultadoBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 424);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.AplicarButtom);
            this.Controls.Add(this.TripleLabel);
            this.Controls.Add(this.MatrimonialLabel);
            this.Controls.Add(this.SimpleLabel);
            this.Controls.Add(this.habLabel);
            this.Controls.Add(this.acompLabel);
            this.Controls.Add(this.duracion_label);
            this.Controls.Add(this.fechalabel);
            this.Name = "ResultadoBusqueda";
            this.Text = "ResultadoBusqueda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label habLabel;
        private System.Windows.Forms.Label acompLabel;
        private System.Windows.Forms.Label duracion_label;
        private System.Windows.Forms.Label fechalabel;
        private System.Windows.Forms.Label SimpleLabel;
        private System.Windows.Forms.Label MatrimonialLabel;
        private System.Windows.Forms.Label TripleLabel;
        private System.Windows.Forms.Button AplicarButtom;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.Label label6;
    }
}