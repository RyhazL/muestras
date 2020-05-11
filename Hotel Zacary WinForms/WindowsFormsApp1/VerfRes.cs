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
    public partial class VerfRes : Form
    {
        OleDbConnection cn;
        ResultadoForm r;
        public VerfRes(OleDbConnection coneccion)
        {
            InitializeComponent();
            cn = coneccion;
        }
        //Accion del Botom Verificar del formulario "Verificar Reservacion"
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = cn.CreateCommand(); //comando con el que "pediremos la informacion a la base de datos" escrito abajo.
            string sqlqury = @"SELECT * FROM Reservaciones WHERE cdl_rcvdor=" + cedulabox.Text + @" AND n_fact="+ nfactura.Text + ";";
            comand.CommandText = sqlqury; //se lo pasamos a la "coneccion"
            try
            {
                cn.Open(); // abrimos la coneccion
                OleDbDataReader result = comand.ExecuteReader(); //leemos la informacion y la guardamos en el OleDBReader
                if (!result.HasRows) {  //si no se encontraron resultados decir "No se encontraron resultados"
                    MessageBox.Show("No se encontraron resultados...");
                    cn.Close();  //SIEMPRE HAY QUE CERRAR LA CONECCION
                    return;
                }
                r = new ResultadoForm(cn);  //El formulario que muestra la informacion
                result.Read();
                string fecha = result.GetValue(1).ToString();
                string duracion = result.GetValue(2).ToString() + " Dias";
                string acomp_a = result.GetValue(4).ToString();
                string acomp_n = result.GetValue(5).ToString();
                string h = result.GetValue(0).ToString();
                string n_fact = result.GetValue(3).ToString();
                bool cumplida = result.GetBoolean(7);
                r.AsignarValores(fecha,duracion,acomp_a,acomp_n,h,n_fact, cumplida); //aqui asignamos la informacion al formlario que los muestra
                while (result.Read())
                {
                    r.MultiHabitacion(result.GetValue(0).ToString()); //cuando se reservo mas de una habitacion se pasa por aqui.
                }
                cn.Close(); //SIEMPRE HAY QUE CERRAR LA CONECCION
                r.ShowDialog();
                this.Close();
            }
            catch (Exception excp) {
                MessageBox.Show(excp.Message);
            }
            
        }
    }
}
