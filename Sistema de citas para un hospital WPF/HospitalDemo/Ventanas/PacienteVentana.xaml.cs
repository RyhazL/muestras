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
using System.Data.OleDb;

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PacienteVentana.xaml
    /// </summary>
    public partial class PacienteVentana : Window
    {
        public dbcon db;
        public ObservableCollection<Paciente> registros;
        public Paciente P;

        private AccionModo _modo;
        public bool listo = false;

        public AccionModo Modo {
            get { return _modo;  }
            private set
            {
                if(value == AccionModo.Insertar)
                {
                    _modo = value;
                    r_select_stack.Visibility = Visibility.Collapsed;
                    this.Height -= 40;
                    save_btn.Content = "Guardar";
                    Title = "Ingresar Nuevo Paciente";
                }
                else if(value == AccionModo.Editar)
                {
                    _modo = value;
                    save_btn.Content = "Guardar Cambios";
                    registros = FiltroPasientes.Cargar(db);
                    registroSelectCombo.ItemsSource = registros;
                    Title = "Editar Registro de Paciente";
                }
                else if (value == AccionModo.Eliminar)
                {
                    _modo = value;
                    edit_stack.Visibility = Visibility.Collapsed;
                    this.Height = 200;
                    save_btn.Content = "Eliminar";
                    save_btn.IsEnabled = false;
                    registros = FiltroPasientes.Cargar(db);
                    registroSelectCombo.ItemsSource = registros;
                    Title = "Elimina un registro de Paciente";
                }
            }
        }

        public PacienteVentana(dbcon con, AccionModo accion ,int id = 0)
        {
            InitializeComponent();
            db = con;
            P = new Paciente(con);
            if (id > 0)
            {
                Modo = AccionModo.Editar;
                P.id = id;
                if (P.Cargar())
                {
                    int i = 0;
                    registros.ToList().ForEach(delegate (Paciente pac)
                    {
                        if(pac.id == id)
                        {
                            registroSelectCombo.SelectedIndex = i;
                        }
                        i++;
                    });
                    save_btn.Visibility = Visibility.Collapsed;
                    cancel_btn.Visibility = Visibility.Collapsed;
                    registroSelectCombo.IsEnabled = false;
                    Title = "Ver detalles de Paciente.";
                }
            }
            else
            {
                Modo = accion;
            }
            
        }

        private void RegistroSelectCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save_btn.IsEnabled = true;
            P = (Paciente)registroSelectCombo.SelectedItem;
            nombreTextBox.Text = P.nombre;
            apellidoTextBox.Text = P.apellido;
            cedulaTextBox.Text = P.cedula;
            telefonoTextBox.Text = P.telefono;
            direcTextBox.Text = P.direccion;
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_modo == AccionModo.Insertar)
            {
                P.nombre = nombreTextBox.Text;
                P.apellido = apellidoTextBox.Text;
                P.cedula = cedulaTextBox.Text;
                P.telefono = telefonoTextBox.Text;
                P.direccion = direcTextBox.Text;
                var v = P.Ingresar();
                if (!v.Value)
                {
                    MessageBox.Show("Ya se encuentra en la Base de datos");
                }
                else
                {
                    listo = true;
                    MessageBox.Show("Paciente Ingresado!");
                    Close();
                }
            }
            else if (_modo == AccionModo.Editar)
            {
                P.nombre = nombreTextBox.Text;
                P.apellido = apellidoTextBox.Text;
                P.cedula = cedulaTextBox.Text;
                P.telefono = telefonoTextBox.Text;
                P.direccion = direcTextBox.Text;
                var v = P.Actualizar();
                if (!v)
                {
                    MessageBox.Show("No se pudo Guardar los Cambios");
                }
                else
                {
                    listo = true;
                    MessageBox.Show("Cambios Guardados");
                    Close();
                }
            }
            else if (_modo == AccionModo.Eliminar)
            {

                var opcion = MessageBox.Show("¿Seguro que quieres Eliminar a este Paciente?", "¿Seguro?", MessageBoxButton.YesNo);
                if(opcion == MessageBoxResult.Yes)
                {
                    var v = P.Eliminar();
                    if (!v)
                    {
                        MessageBox.Show("No se pudo Eliminar");
                    }
                    else
                    {
                        listo = true;
                        MessageBox.Show("Eliminado!");
                        Close();
                    }
                }
            }
        }
    }
    public enum AccionModo { Editar, Insertar, Eliminar }
}
