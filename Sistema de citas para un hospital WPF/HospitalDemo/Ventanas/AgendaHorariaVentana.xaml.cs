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
using HospitalDemo.Paginas;

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para AgendaHorariaVentana.xaml
    /// </summary>
    public partial class AgendaHorariaVentana : Window
    {
        AgendaHoraria agendaActual;
        List<AgendaHoraria> lista;
        dbcon db;
        bool modo;

        public AgendaHorariaVentana(dbcon con, bool e = false)
        {
            InitializeComponent();
            db = con;
            agendaActual = new AgendaHoraria();
            lista = AgendaHoraria.CargarTodos(db);
            selectComboBox.ItemsSource = lista;
            Actualizar();
            modo = e;
            if (modo)
            {
                aceptarBtn.Content = "Guardar Cambios.";
                agenLabel.Text = "Agenda a Modificar: ";
            }
            else
            {
                aceptarBtn.Content = "Guardar Agenda Nueva";
                agenLabel.Text = "Toma otra como referencia: ";
            }
        }

        public void Actualizar()
        {
            nameTextBox.Text = agendaActual.nombre;
            lunesComboBox.Text = agendaActual.horarios[0]._horarios;
            martesComboBox.Text = agendaActual.horarios[1]._horarios;
            miercolesComboBox.Text = agendaActual.horarios[2]._horarios;
            juevesComboBox.Text = agendaActual.horarios[3]._horarios;
            viernesComboBox.Text = agendaActual.horarios[4]._horarios;
            sabadoComboBox.Text = agendaActual.horarios[5]._horarios;
            domingoComboBox.Text = agendaActual.horarios[6]._horarios;

        }

        public void CambioDeTexto(int i,TextBox c, TextBlock t)
        {
            agendaActual.horarios[i].Asignar = c.Text;
            t.Text = agendaActual.horarios[i].Mostrar;
            if (agendaActual.horarios[i].error)
                t.Background = Brushes.Red;
            else
                t.Background = Brushes.Green;
        }

        private void LunesComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(0, lunesComboBox, lunesTextEstado);
        }

        private void MartesComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(1, martesComboBox, martesTextEstado);
        }

        private void MiercolesComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(2, miercolesComboBox, miercolesTextEstado);
        }

        private void JuevesComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(3, juevesComboBox, juevesTextEstado);
        }

        private void ViernesComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(4, viernesComboBox, viernesTextEstado);
        }

        private void SabadoComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(5, sabadoComboBox, sabadoTextEstado);
        }

        private void DomingoComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CambioDeTexto(6, domingoComboBox, domingoTextEstado);
        }

        private void SelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agendaActual = (AgendaHoraria)selectComboBox.SelectedItem;
            Actualizar();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            agendaActual.nombre = nameTextBox.Text;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AceptarBtn_Click(object sender, RoutedEventArgs e)
        {
            bool preparado = true;
            foreach (var h in agendaActual.horarios)
            {
                if (h.error)
                    preparado = false;
            }
            if (!preparado)
            {
                MessageBox.Show("soluciona primero los errores de horario.");
                return;
            }

            if (!modo)
            {
                var ok = agendaActual.Insertar(db);
                if (ok) { MessageBox.Show("Agenda Ingresada exitosamente."); Close(); }
                else { MessageBox.Show("No se pudo ingresar la agenda."); }
            }
            else
            {
                var ok = agendaActual.Actualizar(db);
                if (ok) { MessageBox.Show("Agenda actualizada exitosamente."); Close(); }
                else { MessageBox.Show("No se pudo actualizar la agenda."); }
            }
        }
    }
}
