namespace WindowsFormsApp1
{
    partial class ResultadoForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.duracion_label = new System.Windows.Forms.Label();
            this.fechalabel = new System.Windows.Forms.Label();
            this.adultosLabel = new System.Windows.Forms.Label();
            this.ninosLabel = new System.Windows.Forms.Label();
            this.habLabel = new System.Windows.Forms.Label();
            this.solicitada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(25, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Acompañantes:";
            // 
            // duracion_label
            // 
            this.duracion_label.AutoSize = true;
            this.duracion_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.duracion_label.Location = new System.Drawing.Point(25, 69);
            this.duracion_label.Name = "duracion_label";
            this.duracion_label.Size = new System.Drawing.Size(326, 29);
            this.duracion_label.TabIndex = 5;
            this.duracion_label.Text = "Duracion de la Reservacion:  ";
            // 
            // fechalabel
            // 
            this.fechalabel.AutoSize = true;
            this.fechalabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.fechalabel.Location = new System.Drawing.Point(25, 29);
            this.fechalabel.Name = "fechalabel";
            this.fechalabel.Size = new System.Drawing.Size(272, 29);
            this.fechalabel.TabIndex = 4;
            this.fechalabel.Text = "Fecha de Reservacion:  ";
            // 
            // adultosLabel
            // 
            this.adultosLabel.AutoSize = true;
            this.adultosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.adultosLabel.Location = new System.Drawing.Point(209, 113);
            this.adultosLabel.Name = "adultosLabel";
            this.adultosLabel.Size = new System.Drawing.Size(99, 29);
            this.adultosLabel.TabIndex = 8;
            this.adultosLabel.Text = "Adultos ";
            // 
            // ninosLabel
            // 
            this.ninosLabel.AutoSize = true;
            this.ninosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.ninosLabel.Location = new System.Drawing.Point(395, 113);
            this.ninosLabel.Name = "ninosLabel";
            this.ninosLabel.Size = new System.Drawing.Size(82, 29);
            this.ninosLabel.TabIndex = 9;
            this.ninosLabel.Text = "Niños ";
            // 
            // habLabel
            // 
            this.habLabel.AutoSize = true;
            this.habLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.habLabel.Location = new System.Drawing.Point(25, 156);
            this.habLabel.Name = "habLabel";
            this.habLabel.Size = new System.Drawing.Size(165, 29);
            this.habLabel.TabIndex = 11;
            this.habLabel.Text = "Habitaciones: ";
            // 
            // solicitada
            // 
            this.solicitada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.solicitada.Location = new System.Drawing.Point(30, 205);
            this.solicitada.Name = "solicitada";
            this.solicitada.Size = new System.Drawing.Size(196, 39);
            this.solicitada.TabIndex = 12;
            this.solicitada.Text = "Solicitar";
            this.solicitada.UseVisualStyleBackColor = true;
            this.solicitada.Click += new System.EventHandler(this.solicitada_Click);
            // 
            // ResultadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 260);
            this.Controls.Add(this.solicitada);
            this.Controls.Add(this.habLabel);
            this.Controls.Add(this.ninosLabel);
            this.Controls.Add(this.adultosLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.duracion_label);
            this.Controls.Add(this.fechalabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultadoForm";
            this.ShowIcon = false;
            this.Text = "ResultadoForm";
            this.Load += new System.EventHandler(this.ResultadoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label duracion_label;
        private System.Windows.Forms.Label fechalabel;
        private System.Windows.Forms.Label adultosLabel;
        private System.Windows.Forms.Label ninosLabel;
        private System.Windows.Forms.Label habLabel;
        private System.Windows.Forms.Button solicitada;
    }
}