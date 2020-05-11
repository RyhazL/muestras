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
    public partial class IntroducirCedula : Form
    {
        OleDbConnection cn;
        public IntroducirCedula(OleDbConnection conection)
        {
            InitializeComponent();
            cn = conection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var v = new ResDisHabForm(cn,cedulabox.Text);
            if(v.listo)
                v.ShowDialog();
            this.Close();
        }
    }
}
