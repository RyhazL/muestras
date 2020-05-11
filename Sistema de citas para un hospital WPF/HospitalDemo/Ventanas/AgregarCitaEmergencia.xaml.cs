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
    /// Lógica de interacción para AgregarCitaEmergencia.xaml
    /// </summary>
    public partial class AgregarCitaEmergencia : Window
    {
        dbcon db;
        PersonalCollecion personal;
        Paciente paciente;
        Cita citanueva;
        public bool needreload = false;

        public AgregarCitaEmergencia(dbcon con)
        {
            InitializeComponent();
            db = con;
            personal = new PersonalCollecion(db);
            personal.Reload();
            personalComboBox.ItemsSource = personal;
            paciente = new Paciente(db);
            citanueva = new Cita(db);
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if(personalComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("escoje un personal que atienda la emergencia.");
                return;
            }           
            paciente.nombre = emergenciaTextBox.Text;
            paciente.Ingresar();
            citanueva.fecha_cita = DateTime.Now;
            citanueva.estado = EstadoCita.EnCurso;
            citanueva.tipo = TipoCita.Emergencia;
            citanueva.paciente_id = paciente.id;
            citanueva.personal_id = ((Personal)personalComboBox.SelectedItem).id;
            citanueva.fecha_ingreso = DateTime.Now;
            var v = citanueva.Ingresar();
            if (v.Value)
            {
                MessageBox.Show("Cita de Emergencia añadida...");
                needreload = true;
                Close();
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
