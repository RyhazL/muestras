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

namespace HospitalDemo.Ventanas
{
    /// <summary>
    /// Lógica de interacción para UsuariosVentana.xaml
    /// </summary>
    public partial class UsuariosVentana : Window
    {
        public dbcon db;
        Session session;
        PersonalCollecion personal;
        Usuario selec;
        string acc;

        
        public UsuariosVentana(dbcon con,Session s, string accion)
        {
            InitializeComponent();
            db = con;
            session = s;
            preselec.ItemsSource = session.EnumerarUsuarios();
            personal = new PersonalCollecion(db);
            personal.Reload();
            personCombo.ItemsSource = personal;
            selec = new Usuario();
            acc = accion;
            if (accion == "ingresar")
            {
                p_select_stack.Visibility = Visibility.Collapsed;
                save_btn.IsEnabled = false;
                save_btn.Content = "Guardar";
                Height -= 24;
            }
            else if (accion == "editar")
            {
                save_btn.IsEnabled = false;
            }
            else if (accion == "eliminar")
            {
                edit_stack.Visibility = Visibility.Collapsed;
                Height = 180;
                save_btn.Content = "Eliminar";
                save_btn.IsEnabled = false;
            }
        }

        private void Preselec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selec = (Usuario)preselec.SelectedItem;
            if (selec == null)
                return;
            if (selec.alias == "admin")
            {
                MessageBox.Show("No puedes editar ese usuario.");
                selec = null;
                preselec.SelectedIndex = -1;
                return;
            }
            if(acc == "editar" || acc == "eliminar")
            {
                save_btn.IsEnabled = true;
                nombreTextBox.Text = selec.alias;
                passswordTextBox.Text = selec.password;
                int i = 0;
                personal.ToList().ForEach(delegate (Personal per) {
                    if(per.id == selec.user_id)
                    {
                        personCombo.SelectedIndex = i;
                    }
                    i++;
                });
            }
        }

        private void PersonCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save_btn.IsEnabled = true;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (acc == "ingresar")
            {
                selec.nuevo_alias = nombreTextBox.Text;
                var enuso = false;
                session.EnumerarUsuarios().ForEach(delegate (Usuario u) 
                {
                    if(u.alias == selec.nuevo_alias)
                    {
                        MessageBox.Show("Ese alias ya esta en uso, escoje otro...");
                        enuso = true;
                        return;
                    }
                });
                if (enuso) { return; }
                selec.password = passswordTextBox.Text;
                selec.user_id = ((Personal)personCombo.SelectedItem).id;
                session.CrearUsuarioNuevo(selec);
                Close();
            }
            else if (acc == "editar")
            {
                selec.nuevo_alias = nombreTextBox.Text;
                selec.password = passswordTextBox.Text;
                selec.user_id = ((Personal)personCombo.SelectedItem).id;
                session.ModificarUsuario(selec);
                Close();
            }
            else if (acc == "eliminar")
            {
                session.EliminarUsuario(selec);
                Close();
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
