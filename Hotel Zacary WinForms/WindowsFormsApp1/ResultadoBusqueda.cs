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
    public partial class ResultadoBusqueda : Form
    {
        OleDbConnection cn;
        int total;
        public ResultadoBusqueda(OleDbConnection dbcn)
        {
            InitializeComponent();
            cn = dbcn;
        }
        public void AsignarValores(string cliente,string fecha, string duracion, string acomp, int[] simples, int[] matri, int[] tripl,bool check)
        {
            clientLabel.Text += cliente;
            acompLabel.Text += acomp;
            fechalabel.Text += fecha;
            duracion_label.Text += " " +duracion;
            
        }
        public void HabNesesarias(int simples,int p_s, int matrimoniales, int p_m, int triples, int p_t) {
            SimpleLabel.Text += " " + simples + " (" + (simples * p_s) + ")";
            MatrimonialLabel.Text += " " + matrimoniales + " (" + (matrimoniales * p_m) + ")";
            TripleLabel.Text += " " + triples + " (" + (triples * p_t) + ")";
            total = (simples * p_s) + (matrimoniales * p_m) + (triples * p_t);
            label6.Text += " " + total + " Bs";
        }
        private void modfButtom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AplicarButtom_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = cn.CreateCommand();
            string sqlqury = @"INSERT INTO Reservaciones (n_hbt, fecha_rcv,d_rcvs, adul_acomp, ninos_acomp, cdl_rcvdo, cumplidar, total_pagar) VALUES ();";
            MessageBox.Show(sqlqury);
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
            this.Close();
        }
    }
}
