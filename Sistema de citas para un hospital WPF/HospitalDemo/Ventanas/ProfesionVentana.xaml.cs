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
using HospitalDemo.Paginas;
using HospitalDemo.Ventanas;

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para ProfesionVentana.xaml
    /// </summary>
    public partial class ProfesionVentana : Window
    {
        dbcon db;
        ProfesionList profesiones;
        Profesion p;
        bool editmode;

        public ProfesionVentana(dbcon con, bool edit = false)
        {
            InitializeComponent();
            db = con;
            profesiones = new ProfesionList(db);
            profesiones.Cargar();
            preselec.ItemsSource = profesiones;
            editmode = edit;
            if (!editmode)
            {
                p_select_stack.Visibility = Visibility.Collapsed;
                save_btn.Content = "Ingresar";
                Title = "Ingresar Nueva profesion";
                p = new Profesion();
            }
            else
            {
                p_select_stack.Visibility = Visibility.Visible;
                save_btn.IsEnabled = false;
                Title = "Editar Profesion";
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            p.nombre = nombreTextBox.Text;
            p.dimin = diminTextBox.Text;
            p.descipcion = DescripTextBox.Text;
            if (!editmode)
            {
                var v =profesiones.InsertarNueva(p);
                if (v) { MessageBox.Show("Nueva profesion agregada."); Close(); }
                else { MessageBox.Show("ERROR: No se pudo agregar la profesion"); }
            }
            else
            {
                var v = profesiones.Actualizar(p);
                if (v) { MessageBox.Show("Profesion Actualizada."); Close(); }
                else { MessageBox.Show("ERROR: No se pudo actualizar la profesion"); }
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Preselec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = (Profesion)preselec.SelectedItem;
            MessageBox.Show($"Profesion id: {p.id}");
            nombreTextBox.Text = p.nombre;
            diminTextBox.Text = p.dimin;
            DescripTextBox.Text = p.descipcion;
            save_btn.IsEnabled = true;
        }
    }
}
