namespace WindowsFormsApp1
{
    partial class RegistroClienteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cedulabox = new System.Windows.Forms.TextBox();
            this.nombrebox = new System.Windows.Forms.TextBox();
            this.apellidobox = new System.Windows.Forms.TextBox();
            this.telefonobox = new System.Windows.Forms.TextBox();
            this.donebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cedula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefono:";
            // 
            // cedulabox
            // 
            this.cedulabox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cedulabox.Location = new System.Drawing.Point(164, 28);
            this.cedulabox.MaxLength = 8;
            this.cedulabox.Name = "cedulabox";
            this.cedulabox.Size = new System.Drawing.Size(277, 26);
            this.cedulabox.TabIndex = 4;
            // 
            // nombrebox
            // 
            this.nombrebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nombrebox.Location = new System.Drawing.Point(164, 71);
            this.nombrebox.MaxLength = 32;
            this.nombrebox.Name = "nombrebox";
            this.nombrebox.Size = new System.Drawing.Size(277, 26);
            this.nombrebox.TabIndex = 5;
            // 
            // apellidobox
            // 
            this.apellidobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.apellidobox.Location = new System.Drawing.Point(164, 112);
            this.apellidobox.MaxLength = 32;
            this.apellidobox.Name = "apellidobox";
            this.apellidobox.Size = new System.Drawing.Size(277, 26);
            this.apellidobox.TabIndex = 6;
            // 
            // telefonobox
            // 
            this.telefonobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.telefonobox.Location = new System.Drawing.Point(164, 153);
            this.telefonobox.MaxLength = 11;
            this.telefonobox.Name = "telefonobox";
            this.telefonobox.Size = new System.Drawing.Size(277, 26);
            this.telefonobox.TabIndex = 7;
            // 
            // donebutton
            // 
            this.donebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.donebutton.Location = new System.Drawing.Point(330, 198);
            this.donebutton.Name = "donebutton";
            this.donebutton.Size = new System.Drawing.Size(111, 41);
            this.donebutton.TabIndex = 8;
            this.donebutton.Text = "Listo";
            this.donebutton.UseVisualStyleBackColor = true;
            this.donebutton.Click += new System.EventHandler(this.donebutton_Click);
            // 
            // RegistroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 248);
            this.Controls.Add(this.donebutton);
            this.Controls.Add(this.telefonobox);
            this.Controls.Add(this.apellidobox);
            this.Controls.Add(this.nombrebox);
            this.Controls.Add(this.cedulabox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistroClienteForm";
            this.ShowIcon = false;
            this.Text = "INGRESAR DATOS: Nuevo Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cedulabox;
        private System.Windows.Forms.TextBox nombrebox;
        private System.Windows.Forms.TextBox apellidobox;
        private System.Windows.Forms.TextBox telefonobox;
        private System.Windows.Forms.Button donebutton;
    }
}