using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class ResultadoForm : Form
    {
        OleDbConnection cn;
        string NumeroFactura;

        //Constructor del Formulario
        public ResultadoForm(OleDbConnection conection)
        {
            InitializeComponent();
            cn = conection;
        }
        //Funcio para pasar la informacion de la base de datos al Formulario.
        public void AsignarValores(string fecha, string duracion, string acomp_a, string acomp_n, string h, string n_fact, bool cumplida) {
            adultosLabel.Text += acomp_a;
            fechalabel.Text += fecha;
            duracion_label.Text += duracion;
            ninosLabel.Text += acomp_n;
            habLabel.Text += h;
            NumeroFactura = n_fact;
            if (cumplida)
            {
                solicitada.Enabled = false;
                solicitada.Text = "YA SOLICITADA";
            }
        }
        public void MultiHabitacion(string habitacion) {
            habLabel.Text += ", " + habitacion;
        }

        private void ResultadoForm_Load(object sender, EventArgs e)
        {

        }

        private void solicitada_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = cn.CreateCommand();
            string sqlqury = @"UPDATE Reservaciones SET cumplida = true WHERE n_fact = " + NumeroFactura + ";";
            comand.CommandText = sqlqury;
            try
            {
                cn.Open();
                comand.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
        }
    }
}
