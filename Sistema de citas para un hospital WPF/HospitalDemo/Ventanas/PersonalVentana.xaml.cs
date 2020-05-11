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

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PersonalVentana.xaml
    /// </summary>
    public partial class PersonalVentana : Window
    {
        public dbcon db;
        public Personal p;
        public PersonalCollecion personas_activas;
        public ProfesionList profesiones;
        public List<AgendaHoraria> agendas;
        public Modalidad accion;
        public enum Modalidad { Ingresar,Editar,Eliminar};
        public bool ok = false;
        public bool usuario;

        public PersonalVentana(dbcon database,bool sessoinlimit = false)
        {
            InitializeComponent();
            db = database;
            profesiones = new ProfesionList(db);
            agendas = AgendaHoraria.CargarTodos(db);
            usuario = sessoinlimit;
        }

        public bool IngresarNuevo()
        {
            p = new Personal(db);
            p_select_stack.Visibility = Visibility.Collapsed;
            save_btn.Content = "Ingresar";
            accion = Modalidad.Ingresar;
            profesiones.Cargar();
            ProfsComboBox.ItemsSource = profesiones;
            ProfsComboBox.SelectedIndex = 0;
            agendaComboBox.ItemsSource = agendas;
            agendaComboBox.SelectedIndex = 0;
            bool? op = this.ShowDialog();
            return op.Value;

        }

        public bool Editar()
        {
            p = new Personal(db);
            profesiones.Cargar();
            personas_activas = new PersonalCollecion(db);
            personas_activas.Reload();
            PersonalSelectCombo.ItemsSource = personas_activas;
            agendaComboBox.ItemsSource = agendas;
            p_select_stack.Visibility = Visibility.Visible;
            this.Height += 50;
            save_btn.Content = "Guardar Cambios";
            accion = Modalidad.Editar;
            profesiones.Cargar();
            save_btn.IsEnabled = false;
            ProfsComboBox.ItemsSource = profesiones;
            if (usuario)
            {
                nombreTextBox.IsEnabled = false;
                apellidoTextBox.IsEnabled = false;
                ProfsComboBox.IsEnabled = false;
                fechaDatePicker.IsEnabled = false;
            }
            bool? op = this.ShowDialog();
            return op.Value;
        }

        public bool Eliminar()
        {
            p = new Personal(db);
            personas_activas = new PersonalCollecion(db);
            personas_activas.Reload();
            PersonalSelectCombo.ItemsSource = personas_activas;
            p_select_stack.Visibility = Visibility.Visible;
            edit_stack.Visibility = Visibility.Collapsed;
            this.Height = 200;
            save_btn.Content = "Eliminar";
            save_btn.IsEnabled = false;
            
            accion = Modalidad.Eliminar;
            bool? op = this.ShowDialog();
            return op.Value;
        }




        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            if (accion == Modalidad.Editar)
            {
                p.nombre = nombreTextBox.Text;
                p.apellido = apellidoTextBox.Text;
                p.f_ingreso = fechaDatePicker.SelectedDate.GetValueOrDefault();
                if (ProfsComboBox.SelectedIndex > -1)
                {
                    p.prof_id = profesiones[ProfsComboBox.SelectedIndex].id;
                }
                else { p.prof_id = 0; }
                p.agenda_actual = ((AgendaHoraria)agendaComboBox.SelectedItem).id;
                bool correcto = p.Actualizar();
                if (correcto)
                {
                    MessageBox.Show("Informacion Actualizada!", "Correcto!");
                    ok = true;
                    return;
                }
                else { MessageBox.Show("No se pudo Actualizar la Informacion", "Ups!"); }
            }
            else if (accion == Modalidad.Ingresar)
            {
                p.nombre = nombreTextBox.Text;
                p.apellido = apellidoTextBox.Text;
                p.f_ingreso = fechaDatePicker.SelectedDate.HasValue ? fechaDatePicker.SelectedDate.Value : DateTime.Now;
                if (ProfsComboBox.SelectedIndex > -1)
                {
                    p.prof_id = profesiones[ProfsComboBox.SelectedIndex].id;
                }
                else { p.prof_id = 0; }
                p.agenda_actual = ((AgendaHoraria)agendaComboBox.SelectedItem).id;
                bool correcto = p.Ingresar();
                if (correcto)
                {
                    MessageBox.Show("Informacion Ingresada", "Correcto!");
                    ok = true;
                    return;
                }
                else { MessageBox.Show("No se pudo Ingresar la Informacion", "Ups!"); }
            }
            else if(accion == Modalidad.Eliminar)
            {
                p = (Personal)PersonalSelectCombo.SelectedItem;
                if (p == null)
                {
                    MessageBox.Show("selecciona un peronal Valido para Eliminar");
                    return;
                }
                var r = MessageBox.Show($"¿Seguro que desea eliminar el registro personal de {p.nombre} {p.apellido}?", "¿seguro?", MessageBoxButton.YesNo);
                if (r == MessageBoxResult.Yes)
                    ok = p.Eliminar();
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void PersonalSelectCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PersonalSelectCombo.SelectedIndex != -1)
            {
                save_btn.IsEnabled = true;
                p = (Personal)PersonalSelectCombo.SelectedItem;
                nombreTextBox.Text = p.nombre;
                apellidoTextBox.Text = p.apellido;
                int i = 0;
                foreach (var item in profesiones)
                {
                    if(item.id == p.prof_id)
                    {
                        ProfsComboBox.SelectedIndex = i;
                    }
                    i++;
                }
                fechaDatePicker.SelectedDate = p.f_ingreso;
                i = 0;
                foreach (var item in agendas)
                {
                    if(item.id == p.agenda_actual)
                    {
                        agendaComboBox.SelectedIndex = i;
                    }
                    i++;
                }

            }
        }

        private void AgendaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
