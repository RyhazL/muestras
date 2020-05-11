namespace WindowsFormsApp1
{
    partial class ResDisHabForm
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
            this.numericduracion = new System.Windows.Forms.NumericUpDown();
            this.numericDias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericSimples = new System.Windows.Forms.NumericUpDown();
            this.numericMatrimonial = new System.Windows.Forms.NumericUpDown();
            this.numericTriples = new System.Windows.Forms.NumericUpDown();
            this.numericAdultos = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericNinos = new System.Windows.Forms.NumericUpDown();
            this.solicitadocheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericduracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSimples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMatrimonial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTriples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAdultos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNinos)).BeginInit();
            this.SuspendLayout();
            // 
            // numericduracion
            // 
            this.numericduracion.Location = new System.Drawing.Point(300, 208);
            this.numericduracion.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericduracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericduracion.Name = "numericduracion";
            this.numericduracion.Size = new System.Drawing.Size(54, 20);
            this.numericduracion.TabIndex = 0;
            this.numericduracion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericDias
            // 
            this.numericDias.AutoSize = true;
            this.numericDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericDias.Location = new System.Drawing.Point(12, 208);
            this.numericDias.Name = "numericDias";
            this.numericDias.Size = new System.Drawing.Size(159, 20);
            this.numericDias.TabIndex = 1;
            this.numericDias.Text = "Dias de Reservacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(16, 37);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Verificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Verificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "N Habitaciones Simples";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "N Habitaciones Matrimoniales";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "N Habitaciones Triples";
            // 
            // numericSimples
            // 
            this.numericSimples.Location = new System.Drawing.Point(300, 237);
            this.numericSimples.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSimples.Name = "numericSimples";
            this.numericSimples.Size = new System.Drawing.Size(54, 20);
            this.numericSimples.TabIndex = 9;
            // 
            // numericMatrimonial
            // 
            this.numericMatrimonial.Location = new System.Drawing.Point(300, 266);
            this.numericMatrimonial.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericMatrimonial.Name = "numericMatrimonial";
            this.numericMatrimonial.Size = new System.Drawing.Size(54, 20);
            this.numericMatrimonial.TabIndex = 10;
            // 
            // numericTriples
            // 
            this.numericTriples.Location = new System.Drawing.Point(300, 296);
            this.numericTriples.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericTriples.Name = "numericTriples";
            this.numericTriples.Size = new System.Drawing.Size(54, 20);
            this.numericTriples.TabIndex = 11;
            // 
            // numericAdultos
            // 
            this.numericAdultos.Location = new System.Drawing.Point(300, 357);
            this.numericAdultos.Maximum = new decimal(new int[] {
            115,
            0,
            0,
            0});
            this.numericAdultos.Name = "numericAdultos";
            this.numericAdultos.Size = new System.Drawing.Size(54, 20);
            this.numericAdultos.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Acompañantes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "- Adultos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "- Niños";
            // 
            // numericNinos
            // 
            this.numericNinos.Location = new System.Drawing.Point(300, 389);
            this.numericNinos.Maximum = new decimal(new int[] {
            115,
            0,
            0,
            0});
            this.numericNinos.Name = "numericNinos";
            this.numericNinos.Size = new System.Drawing.Size(54, 20);
            this.numericNinos.TabIndex = 18;
            // 
            // solicitadocheck
            // 
            this.solicitadocheck.AutoSize = true;
            this.solicitadocheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solicitadocheck.Location = new System.Drawing.Point(22, 422);
            this.solicitadocheck.Name = "solicitadocheck";
            this.solicitadocheck.Size = new System.Drawing.Size(151, 24);
            this.solicitadocheck.TabIndex = 13;
            this.solicitadocheck.Text = "YA SOLICITADO";
            this.solicitadocheck.UseVisualStyleBackColor = true;
            this.solicitadocheck.CheckedChanged += new System.EventHandler(this.solicitadocheck_CheckedChanged);
            // 
            // ResDisHabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 503);
            this.Controls.Add(this.numericNinos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericAdultos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solicitadocheck);
            this.Controls.Add(this.numericTriples);
            this.Controls.Add(this.numericMatrimonial);
            this.Controls.Add(this.numericSimples);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericDias);
            this.Controls.Add(this.numericduracion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResDisHabForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verificar Disponibilidad";
            ((System.ComponentModel.ISupportInitialize)(this.numericduracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSimples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMatrimonial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTriples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAdultos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNinos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericduracion;
        private System.Windows.Forms.Label numericDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericSimples;
        private System.Windows.Forms.NumericUpDown numericMatrimonial;
        private System.Windows.Forms.NumericUpDown numericTriples;
        private System.Windows.Forms.NumericUpDown numericAdultos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericNinos;
        private System.Windows.Forms.CheckBox solicitadocheck;
    }
}