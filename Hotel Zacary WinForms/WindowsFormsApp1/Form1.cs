using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        OleDbConnection dbConnection = new OleDbConnection();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            string local = @"\Data\ZACARYDataBase.accdb";
            string db = Environment.CurrentDirectory + local;
            dbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+db+";";
            try
            {
                dbConnection.Open();
                MessageBox.Show("Base de Datos Conectada");
                dbConnection.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DisponibBoton_Click(object sender, EventArgs e)
        {
            var f = new IntroducirCedula(dbConnection);
            f.ShowDialog();
        }

        private void ReservacionBoton_Click(object sender, EventArgs e)
        {
            var vr = new VerfRes(dbConnection);
            vr.ShowDialog();
        }

        private void MainFormSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
