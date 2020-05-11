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
    public partial class ResDisHabForm : Form
    {
        OleDbConnection cn;
        public bool listo;
        string m_cedula;
        string nombrecompleto;
        int p_s;
        int p_m;
        int p_t;

        public ResDisHabForm(OleDbConnection coneccion, string cedula)
        {
            InitializeComponent();
            cn = coneccion;
            OleDbCommand comand = cn.CreateCommand();
            string sqlqury = @"SELECT Cedula FROM Clientes WHERE Cedula=" + cedula + ";";
            comand.CommandText = sqlqury;
            cn.Open();
            OleDbDataReader result = comand.ExecuteReader();
            var rg = new RegistroClienteForm(cn, cedula);
            if (!result.HasRows)
            {
                cn.Close();
                rg.ShowDialog();
                listo = rg.registrado;
                return;
            }
            cn.Close();
            listo = true;
            m_cedula = cedula;
        }

        private void Verificar_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = cn.CreateCommand();

            string sqlnombre = @"SELECT Nombre,Apellido FROM Clientes WHERE Cedula=" + m_cedula + ";";
            comand.CommandText = sqlnombre;
            cn.Open();
            OleDbDataReader res = comand.ExecuteReader();
            res.Read();
            nombrecompleto = " " + res.GetValue(0).ToString() + " " + res.GetValue(1).ToString() + " (" + m_cedula + ")";
            cn.Close();
            bool[] habitacionesOcupadas = new bool[50];
            DateTime fechainicial = monthCalendar1.SelectionStart;
            if (solicitadocheck.Checked)
                fechainicial = monthCalendar1.TodayDate;
            DateTime fechafinal = fechainicial.AddHours((int)numericduracion.Value);
            string fi = fechainicial.ToString("dd'/'MM'/'yyyy");
            string ff = fechafinal.ToString("dd'/'MM'/'yyyy");
            string sqlqury = @"SELECT n_hbt FROM Reservaciones WHERE fecha_rcv BETWEEN #" + fi + "# AND #" + ff + "#";
            comand.CommandText = sqlqury;
            cn.Open();
            OleDbDataReader result = comand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    habitacionesOcupadas[result.GetInt32(0)] = true;
                }
            }
            cn.Close();
            List<int> DispSimple = new List<int>();
            List<int> DispMatri = new List<int>();
            List<int> DispTriple = new List<int>();
            for (int i = 0; i < habitacionesOcupadas.Length; i++)
            {
                if (!habitacionesOcupadas[i])
                {
                    if (i < 10)
                        DispSimple.Add(i);
                    if (i >= 10 && i < 25)
                        DispMatri.Add(i);
                    if (i >= 25)
                        DispTriple.Add(i);
                }

            }
            string sqlprecios = @"SELECT cod_tipo,Precio FROM Tipo_Habitacion;";
            comand.CommandText = sqlprecios;
            cn.Open();
            OleDbDataReader resprec = comand.ExecuteReader();
           
            while (resprec.Read()) {
                if (resprec.GetInt32(0) == 0)
                    p_s = resprec.GetInt32(1);
                if (resprec.GetInt32(0) == 1)
                    p_m = resprec.GetInt32(1);
                if (resprec.GetInt32(0) == 2)
                    p_t = resprec.GetInt32(1);
            }
            cn.Close();
            if (DispSimple.Count < numericSimples.Value)
            { MessageBox.Show("Solo quedan " + DispSimple.Count + " habitaciones simples disponibles para esas fechas"); return; }
            else if (DispMatri.Count < numericMatrimonial.Value)
            { MessageBox.Show("Solo quedan " + DispSimple.Count + " habitaciones matrimoniales disponibles para esas fechas"); return; }
            else if (DispTriple.Count < numericTriples.Value)
            { MessageBox.Show("Solo quedan " + DispSimple.Count + " habitaciones triples disponibles para esas fechas"); return; }

            string acomp = "Adultos (" + numericAdultos.Value + "), Niños (" + numericNinos.Value + ")";
            var r = new ResultadoBusqueda(cn);
            r.AsignarValores(nombrecompleto, fi, numericduracion.Value + " Dias", acomp, DispSimple.ToArray(), DispMatri.ToArray(), DispTriple.ToArray(), solicitadocheck.Checked);
            r.HabNesesarias((int)numericSimples.Value,p_s, (int)numericMatrimonial.Value,p_m, (int)numericTriples.Value,p_t);
            r.ShowDialog();
        }

        private void solicitadocheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cheak = (CheckBox)sender;
            if (((CheckBox)sender).Checked)
                monthCalendar1.Enabled = false;
            else
                monthCalendar1.Enabled = true;
        }
    }
}
