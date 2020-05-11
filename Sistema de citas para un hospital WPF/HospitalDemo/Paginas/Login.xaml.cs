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

namespace HospitalDemo.Modelos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Session ssn;
        public Login(Session estado)
        {
            InitializeComponent();
            ssn = estado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!ssn.Iniciar(userInput.Text, passwInput.Password))
            {
                MessageBox.Show("El usuario a la contraseña ingresados no son validos.",
                        "Clave/Usuario Invalida",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
            }
        }
    }
}
