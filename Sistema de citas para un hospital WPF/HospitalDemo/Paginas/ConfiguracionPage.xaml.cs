using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalDemo.Modelos;
using HospitalDemo.Ventanas;

namespace HospitalDemo.Paginas
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionPage.xaml
    /// </summary>
    public partial class ConfiguracionPage : Page
    {
        public Session session;
        public PersonalVentana p_ventana;
        public dbcon db;

        public ConfiguracionPage(dbcon con, Session s)
        {
            InitializeComponent();
            db = con;
            session = s;
            actualUserText.Text = "Usuario: " + session.alias;
            if(session.userlevel != UserLevel.Administrador)
            {
                profesionPanel.Visibility = Visibility.Collapsed;
                eliminarPacienteBtn.IsEnabled = false;
                addPersnalBtn.IsEnabled = false;
                eliminarPersnalBtn.IsEnabled = false;
                usersPanel.Visibility = Visibility.Collapsed;

            }
            session.sessionCambio += CambioSess;
        }

        private void AddPersnalBtn_Click(object sender, RoutedEventArgs e)
        {
            p_ventana = new PersonalVentana(db);
            p_ventana.IngresarNuevo();
        }

        private void EditPersnalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (session.userlevel == UserLevel.Administrador)
                p_ventana = new PersonalVentana(db);
            else
                p_ventana = new PersonalVentana(db,true);
            p_ventana.Editar();
        }

        private void EliminarPersnalBtn_Click(object sender, RoutedEventArgs e)
        {
            p_ventana = new PersonalVentana(db);
            p_ventana.Eliminar();
        }

        private void CambioPassBtn_Click(object sender, RoutedEventArgs e)
        {
            if(newPassBox.Password != renewPassBox.Password)
            {
                MessageBox.Show("La nueva contraseña y la repeticion de la nueva contraseña no Coinciden, vuelve a intentarlo", "ERROR!");
                newPassBox.Clear();
                oldPassBox.Clear();
                renewPassBox.Clear();
                return;
            }
            session.CambiarContrasena(oldPassBox.Password, newPassBox.Password);
            newPassBox.Clear();
            oldPassBox.Clear();
            renewPassBox.Clear();
        }

        private void CambioSess(object sender, EventArgs e)
        {
            actualUserText.Text = "Usuario: " + session.alias;
        }

        private void AddPacienteBtn_Click(object sender, RoutedEventArgs e)
        {
            var vent = new PacienteVentana(db, AccionModo.Insertar);
            vent.ShowDialog();
        }

        private void EditPacienteBtn_Click(object sender, RoutedEventArgs e)
        {
            var vent = new PacienteVentana(db, AccionModo.Editar);
            vent.ShowDialog();
        }

        private void EliminarPacienteBtn_Click(object sender, RoutedEventArgs e)
        {
            var vent = new PacienteVentana(db, AccionModo.Eliminar);
            vent.ShowDialog();
        }

        private void AddAgendaBtn_Click(object sender, RoutedEventArgs e)
        {
            var agnew = new AgendaHorariaVentana(db);
            agnew.ShowDialog();
        }

        private void EditAgendaBtn_Click(object sender, RoutedEventArgs e)
        {
            var agnew = new AgendaHorariaVentana(db,true);
            agnew.ShowDialog();
        }

        private void AddPProfesionBtn_Click(object sender, RoutedEventArgs e)
        {
            var profven = new ProfesionVentana(db);
            profven.ShowDialog();
        }

        private void EditProfesionBtn_Click(object sender, RoutedEventArgs e)
        {
            var profven = new ProfesionVentana(db,true);
            profven.ShowDialog();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            var userVen = new UsuariosVentana(db, session, "ingresar");
            userVen.ShowDialog();
        }

        private void EditusersBtn_Click(object sender, RoutedEventArgs e)
        {
            var userVen = new UsuariosVentana(db, session, "editar");
            userVen.ShowDialog();
        }

        private void EliminauserBtn_Click(object sender, RoutedEventArgs e)
        {
            var userVen = new UsuariosVentana(db, session, "eliminar");
            userVen.ShowDialog();
        }
    }
}
