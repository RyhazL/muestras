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
    public partial class RegistroClienteForm : Form
    {
        OleDbConnection cn;
        public bool registrado;
        public RegistroClienteForm(OleDbConnection coneccion, string Cedula)
        {
            InitializeComponent();
            cn = coneccion;
            cedulabox.Text = Cedula;
        }

        private void donebutton_Click(object sender, EventArgs e)
        {
            OleDbCommand comand = cn.CreateCommand();
            string sqlqury = @"INSERT INTO Clientes (Cedula, Apellido, Nombre, Telefono) VALUES ("+cedulabox.Text+ @", '"+apellidobox.Text+ @"', '"+nombrebox.Text+@"', '"+telefonobox.Text+"');";
            MessageBox.Show(sqlqury);
            comand.CommandText = sqlqury;
            try
            {
                cn.Open();
                comand.ExecuteNonQuery();
                cn.Close();
                registrado = true;
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
            this.Close();
        }
    }
}
