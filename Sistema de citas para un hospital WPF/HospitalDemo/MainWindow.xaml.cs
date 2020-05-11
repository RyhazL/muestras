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
using HospitalDemo.Paginas;
using HospitalDemo.Ventanas;

namespace HospitalDemo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //estado de session actual de la aplicacion.
        public Session session;
        Page registroPage;
        Page ConfPage;
        dbcon db;

        public MainWindow()
        {
            InitializeComponent();
            var con = new dbcon();
            if (!con.Inicializar())
            {
                Close();
            }
            session = new Session(con);
            db = con;

            session.sessionCambio += CambioDeSession;
            /*var loginpage = new Login(session);
            var confPage = new ConfiguracionPage();
            */
            registroPage = new RegistrosCitasPage(con);
            ConfPage = new ConfiguracionPage(con,session);
            CambioDeSession(session, EventArgs.Empty);

        }

        private void CambioDeSession(object sender, EventArgs e)
        {
            var ss = (Session)sender;
            registrBtn.IsEnabled = ss._auth;
            confBtn.IsEnabled = ss._auth;
            usernamePanel.Text = ss.alias == string.Empty ? "INICIA SESSION" : ss.alias.ToUpper();
            cerrarSessionBnt.Visibility = ss._auth ? Visibility.Visible : Visibility.Hidden;
            if (ss._auth){
                mainFrame.Navigate(registroPage);
            }
            else{
                mainFrame.Navigate(new Login(session));
            }
        }

        private void cerrarSessionClick(object sender, RoutedEventArgs e)
        {
            session.Cerrar();
        }

        private void RegistrBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RegistrosCitasPage(db));
        }

        private void ConfBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ConfiguracionPage(db, session));
        }
    }
}
