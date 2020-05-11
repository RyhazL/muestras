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
    /// Lógica de interacción para RegistrosCitasPage.xaml
    /// </summary>
    public partial class RegistrosCitasPage : Page
    {
        CitasList ListaCitas;
        PersonalCollecion personal;
        int b_tip = -1;
        int b_est = -1;
        int b_personal = -1;
        Cita actual;
        bool listTabChange = false;
        dbcon db;
        List<AgendaHoraria> agendas;
        AgendaHoraria agenda_actual;


        public RegistrosCitasPage(dbcon con)
        {
            db = con;
            agendas = AgendaHoraria.CargarTodos(db);
            ListaCitas = new CitasList(con);
            InitializeComponent();
            citasListBox.ItemsSource = ListaCitas;
            personal = new PersonalCollecion(con);
            personalComboBox.ItemsSource = personal;
            personal.Reload(true);
            personalComboBox.SelectedIndex = personal.Count - 1;
            datosStack.Visibility = Visibility.Collapsed;
            editEstadoComboBox.IsEnabled = false;
        }

        public void AgendaUpdate(bool visible, int personal_id)
        {
            if (!visible)
            {
                disponib_panel.Visibility = Visibility.Collapsed;
                return;
            }
            disponib_panel.Visibility = Visibility.Visible;
            agendas.ForEach(delegate (AgendaHoraria a)
            {
                if (a.id == personal_id)
                {
                    agenda_actual = a;
                }
            });
            int index;

            //day of the weak comienza en cero, el comingo y no el lunes, asi que para corregir, esta este codigo.
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                index = 6;
            else
                index = (int)DateTime.Now.DayOfWeek - 1;

            var disponibilidad = agenda_actual.horarios[index].Disponibilidad;
            var horadetrabajo = agenda_actual.horarios[index].Mostrar;
            DispLabel.Text = disponibilidad ? "DISPONIBLE" : "NO DISPONIBLE";
            horarioText.Text = horadetrabajo;
            if (disponibilidad) { DispColor.Background = Brushes.Green; }
            else { DispColor.Background = Brushes.Red; }

        }

        private void PersonalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select_p = (Personal)personalComboBox.SelectedItem;
            if (select_p != null)
            {
                b_personal = select_p.id;
            }

            ListaCitas.Reload(DateTime.Now, b_personal , b_est, b_tip);
        }

        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int inx = tipoComboBox.SelectedIndex;
            if (inx >= 2)
                b_tip = -1;
            else
                b_tip = inx;
            ListaCitas.Reload(DateTime.Now, b_personal, b_est, b_tip);
        }

        private void EstadoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int inx = estadoComboBox.SelectedIndex;
            if (inx >= 5)
                b_est = -1;
            else
                b_est = inx;
            ListaCitas.Reload(DateTime.Now, b_personal, b_est, b_tip);
        }

        private void CitasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actual = (Cita)citasListBox.SelectedItem;
            if(actual == null)
            {
                pasienteDetallesBtn.IsEnabled = false;
                datosStack.Visibility = Visibility.Collapsed;
                editEstadoComboBox.IsEnabled = false;
                AgendaUpdate(false, 0);
                return;
            }
            else
            {
                pasienteDetallesBtn.IsEnabled = true;
                datosStack.Visibility = Visibility.Visible;
                editEstadoComboBox.IsEnabled = true;
                fcitaTexBlock.Text = actual.fecha_cita.ToString("dd/MM/yyyy");
                finggresoTexBlock.Text = actual.fecha_ingreso.ToString("dd/MM/yyyy");
                personal.ToList().ForEach(delegate (Personal person)
                {
                    int i = 0;
                    if (person.id == actual.personal_id)
                    {
                        persnTexBlock.Text = person.ToString();
                        AgendaUpdate(true, person.agenda_actual);
                    }
                    i++;
                });
            }
            listTabChange = true;
            editEstadoComboBox.SelectedIndex = (int)actual.estado;
        }

        private void EditEstadoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listTabChange)
            {
                listTabChange = false;
                return;
            }
            int select = editEstadoComboBox.SelectedIndex;
            actual.CambiarEstado((EstadoCita)select);
            ListaCitas.Reload(DateTime.Now, b_personal, b_est, b_tip);
            listTabChange = true;
            editEstadoComboBox.SelectedIndex = -1;

        }

        private void PasienteDetallesBtn_Click(object sender, RoutedEventArgs e)
        {
            var pasVen = new PacienteVentana(db, AccionModo.Editar ,actual.paciente_id);
            pasVen.ShowDialog();
        }

        private void EditCitaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCitaBtn_Click(object sender, RoutedEventArgs e)
        {
            var addCita = new AgregarCita(db);
            addCita.ShowDialog();
            if (addCita.needreload)
            {
                ListaCitas.Reload(DateTime.Now, b_personal, b_est, b_tip);
            }
        }

        private void AddEmergenciaCitaBtn_Click(object sender, RoutedEventArgs e)
        {
            var addCita = new AgregarCitaEmergencia(db);
            addCita.ShowDialog();
            if (addCita.needreload)
            {
                ListaCitas.Reload(DateTime.Now, b_personal, b_est, b_tip);
            }
        }
    }
}
