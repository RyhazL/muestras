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
using System.Windows.Shapes;
using HospitalDemo.Modelos;
using HospitalDemo.Ventanas;
using System.Collections.ObjectModel;

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para AgregarCita.xaml
    /// </summary>
    public partial class AgregarCita : Window
    {
        dbcon db;
        PersonalCollecion personal;
        ObservableCollection<Paciente> pacientes;
        Cita citanueva;
        public bool needreload = false;

        public AgregarCita(dbcon con)
        {
            InitializeComponent();
            db = con;
            personal = new PersonalCollecion(db);
            personal.Reload();
            registroSelectCombo.ItemsSource = personal;
            pacientes = FiltroPasientes.Cargar(db);
            pacienteComboBox.ItemsSource = pacientes;
            citanueva = new Cita(db);
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if((registroSelectCombo.SelectedIndex > -1)&&(pacienteComboBox.SelectedIndex > -1))
            {
                citanueva.fecha_cita = citaDatePicker.SelectedDate.HasValue ? citaDatePicker.SelectedDate.Value : DateTime.Now;
                citanueva.estado = EstadoCita.Pendiente;
                citanueva.tipo = TipoCita.Previa;
                citanueva.paciente_id = ((Paciente)pacienteComboBox.SelectedItem).id;
                citanueva.personal_id = ((Personal)registroSelectCombo.SelectedItem).id;
                citanueva.fecha_ingreso = DateTime.Now;
                var v = citanueva.Ingresar();
                if (v.Value)
                {
                    MessageBox.Show("Cita añadida...");
                    needreload = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Debes asignar tanto como el Personal como el Paciente a atender.");
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
