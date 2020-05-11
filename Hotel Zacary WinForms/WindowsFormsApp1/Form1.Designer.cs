namespace WindowsFormsApp1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DisponibBoton = new System.Windows.Forms.Button();
            this.ReservacionBoton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).BeginInit();
            this.MainFormSplitContainer.Panel2.SuspendLayout();
            this.MainFormSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormSplitContainer
            // 
            this.MainFormSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.MainFormSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainFormSplitContainer.IsSplitterFixed = true;
            this.MainFormSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainFormSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainFormSplitContainer.Name = "MainFormSplitContainer";
            // 
            // MainFormSplitContainer.Panel1
            // 
            this.MainFormSplitContainer.Panel1.AutoScroll = true;
            this.MainFormSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MainFormSplitContainer.Panel1Collapsed = true;
            this.MainFormSplitContainer.Panel1MinSize = 200;
            // 
            // MainFormSplitContainer.Panel2
            // 
            this.MainFormSplitContainer.Panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Zacary_logo;
            this.MainFormSplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MainFormSplitContainer.Panel2.Controls.Add(this.DisponibBoton);
            this.MainFormSplitContainer.Panel2.Controls.Add(this.ReservacionBoton);
            this.MainFormSplitContainer.Size = new System.Drawing.Size(1037, 561);
            this.MainFormSplitContainer.SplitterDistance = 220;
            this.MainFormSplitContainer.SplitterWidth = 1;
            this.MainFormSplitContainer.TabIndex = 0;
            this.MainFormSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MainFormSplitContainer_SplitterMoved);
            // 
            // DisponibBoton
            // 
            this.DisponibBoton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DisponibBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisponibBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DisponibBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.DisponibBoton.Location = new System.Drawing.Point(261, 511);
            this.DisponibBoton.Name = "DisponibBoton";
            this.DisponibBoton.Size = new System.Drawing.Size(234, 38);
            this.DisponibBoton.TabIndex = 2;
            this.DisponibBoton.Text = "Verificacion de Disponibilidad";
            this.DisponibBoton.UseVisualStyleBackColor = true;
            this.DisponibBoton.Click += new System.EventHandler(this.DisponibBoton_Click);
            // 
            // ReservacionBoton
            // 
            this.ReservacionBoton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReservacionBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReservacionBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ReservacionBoton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(150)))), ((int)(((byte)(141)))));
            this.ReservacionBoton.Location = new System.Drawing.Point(14, 511);
            this.ReservacionBoton.Name = "ReservacionBoton";
            this.ReservacionBoton.Size = new System.Drawing.Size(232, 38);
            this.ReservacionBoton.TabIndex = 0;
            this.ReservacionBoton.Text = "Verificar Reservacion";
            this.ReservacionBoton.UseVisualStyleBackColor = true;
            this.ReservacionBoton.Click += new System.EventHandler(this.ReservacionBoton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1037, 561);
            this.Controls.Add(this.MainFormSplitContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZACARY - Administrador de Habitaciones";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainFormSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainFormSplitContainer)).EndInit();
            this.MainFormSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainFormSplitContainer;
        private System.Windows.Forms.Button ReservacionBoton;
        private System.Windows.Forms.Button DisponibBoton;
    }
}

