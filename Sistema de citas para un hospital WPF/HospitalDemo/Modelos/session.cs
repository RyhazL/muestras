using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows;

namespace HospitalDemo.Modelos
{
    public class Session
    {
        private dbcon db;
        public bool _auth { get; private set; }
        public UserLevel userlevel { get; private set; }
        public int userid { get; private set; } = 0;
        public string alias { get; private set; } = string.Empty;

        

        public Session(dbcon conexcion)
        {
            db = conexcion;
            _auth = false;
        }

        public bool Iniciar(string u, string p)
        {
            OleDbCommand cmd = new OleDbCommand();
            db.conexcion.Open();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT nivel, id_personal, alias FROM Usuarios WHERE alias='{u}' AND contrasena='{p}'";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                _auth = true;
                while (result.Read())
                {
                    userlevel = (UserLevel)result.GetInt32(0);
                        userid = result.GetInt32(1);
                        alias = result.GetString(2);
                }
            }           
            db.conexcion.Close();
            cmd.Dispose();
            ActivarCambio();
            return _auth;
        }
        public void Cerrar()
        {
            _auth = false;
            alias = string.Empty;
            userid = 0;
            ActivarCambio();
        }

        public void CrearUsuarioNuevo(Usuario p)
        {
            OleDbCommand cmd = new OleDbCommand();
            db.conexcion.Open();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO Usuarios(alias,contrasena,id_personal,nivel) VALUES('{p.nuevo_alias}','{p.password}',{p.user_id},2) ";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Usuario creado exitosamente");
            }
            else
            {
                MessageBox.Show("ERROR: No se pudo modificar usuario.");
            }
            db.conexcion.Close();
            cmd.Dispose();
        }

        public List<Usuario> EnumerarUsuarios()
        {
            var data = new List<Usuario>();
            OleDbCommand cmd = new OleDbCommand();
            db.conexcion.Open();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT alias,contrasena,id_personal FROM Usuarios";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                while (result.Read())
                {
                    var u = new Usuario();
                    u.alias = result.GetString(0);
                    u.password = result.GetString(1);
                    u.user_id = result.GetInt32(2);
                    data.Add(u);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
            return data;
        }

        public void ModificarUsuario(Usuario p)
        {
            OleDbCommand cmd = new OleDbCommand();
            db.conexcion.Open();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"UPDATE Usuarios SET contrasena='{p.password}',alias='{p.nuevo_alias}'," +
                $"id_personal={p.user_id} WHERE alias='{p.alias}'";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show($"Cambios de datos en el usuario {p.nuevo_alias} Guardados exitosamente.");
            }
            else
            {
                MessageBox.Show("ERROR: No se pudo modificar usuario.");
            }
            db.conexcion.Close();
            cmd.Dispose();
        }
        public void EliminarUsuario(Usuario p)
        {
            var r = MessageBox.Show("¿Estas seguro de querer eliminar este usuario? Esta accion es irreversible.", "¿Seguro?", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                db.conexcion.Open();
                cmd.Connection = db.conexcion;
                cmd.CommandText = $"DELETE FROM Usuarios WHERE alias='{p.alias}'";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Usuario Eliminado");
                }
                else
                {
                    MessageBox.Show("ERROR: no se pudo eliminar");
                }
                db.conexcion.Close();
                cmd.Dispose();
            }
        }

        public void CambiarContrasena(string actual, string nueva)
        {
            OleDbCommand cmd = new OleDbCommand();
            db.conexcion.Open();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"UPDATE Usuarios SET contrasena='{nueva}' WHERE alias='{alias}' AND contrasena='{actual}'";
            if(cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Cambio de contraseña exitoso.");
            }
            else
            {
                MessageBox.Show("La contraseña actual es incorecta");
            }
            db.conexcion.Close();
            cmd.Dispose();
        }

        //este evento se llamara cada vez que el estado se la session cambia, para desactivar y cambiar
        //el marco visual cuando se cierre session o se intente aceder de nuevo.
        protected virtual void ActivarCambio()
        {
            sessionCambio?.Invoke(this,EventArgs.Empty);
        }

        public event EventHandler sessionCambio;
    }

    public enum UserLevel { Administrador = 1, Usuario = 2}

    public class Usuario
    {
        public string alias;
        public string password;
        public int user_id;
        public string nuevo_alias;

        public override string ToString()
        {
            return alias;
        }
    }
}
