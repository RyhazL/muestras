using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.OleDb;

namespace HospitalDemo.Modelos
{
    public class Paciente
    {
        public int id;

        public string cedula = string.Empty;
        public string nombre = string.Empty;
        public string apellido = string.Empty;
        public string telefono = string.Empty;
        public string direccion = string.Empty;
        public bool existe;

        public dbcon db;

        public Paciente(dbcon con) { db = con; }
        public Paciente(dbcon con, int identificador)
        {
            db = con;
            id = identificador;
        }

        public override string ToString()
        {
            return $"{nombre} {apellido} [{cedula}]";
        }

        public bool Cargar()
        {
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Paciente WHERE id={id}";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                existe = true;
                while (result.Read())
                {
                    cedula = result.GetString(1);
                    nombre = result.GetString(2);
                    apellido = result.GetString(3);
                    telefono = result.GetString(4);
                    direccion = result.GetString(5);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool? Ingresar()
        {
            var correcto = false;
            var v = Cargar();
            if (v)
            {
                MessageBox.Show("Este Registro de paciente ya se encuentra en la Base de datos.");
                return false;
            }
            id = 0;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO Paciente(cedula,nombre,apellido,telefono,direccion) VALUES(?,?,?,?,?)";
            cmd.Parameters.Add(new OleDbParameter("@cedula", OleDbType.VarChar)).Value = cedula;
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = nombre;
            cmd.Parameters.Add(new OleDbParameter("@apellido", OleDbType.VarChar)).Value = apellido;
            cmd.Parameters.Add(new OleDbParameter("@telefono", OleDbType.VarChar)).Value = telefono;
            cmd.Parameters.Add(new OleDbParameter("@direccion", OleDbType.VarChar)).Value = direccion;

            if (cmd.ExecuteNonQuery() > 0) {
                correcto = true;
                cmd.CommandText = "SELECT @@IDENTITY";
                id = (int)cmd.ExecuteScalar();
            }
            db.conexcion.Close();
            cmd.Dispose();

            return correcto;
        }

        public bool Eliminar()
        {
            var correcto = false;
            var v = Cargar();
            if (!v)
            {
                MessageBox.Show("No puedes eliminar un registro de Paciente que no existe");
                return false;
            }
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"DELETE FROM Paciente WHERE id={id}";
            if (cmd.ExecuteNonQuery() > 0) { correcto = true; existe = false; }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool Actualizar()
        {
            var correcto = false;
            var v = existe;
            if (!v)
            {
                MessageBox.Show("Este Registro de paciente no existe en la base de datos.");
                return false;
            }
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"UPDATE Paciente SET cedula=?,nombre=?,apellido=?,telefono=?,direccion=? WHERE id={id}";
            cmd.Parameters.Add(new OleDbParameter("@cedula", OleDbType.VarChar)).Value = cedula;
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = nombre;
            cmd.Parameters.Add(new OleDbParameter("@apellido", OleDbType.VarChar)).Value = apellido;
            cmd.Parameters.Add(new OleDbParameter("@telefono", OleDbType.VarChar)).Value = telefono;
            cmd.Parameters.Add(new OleDbParameter("@direccion", OleDbType.VarChar)).Value = direccion;

            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            db.conexcion.Close();
            cmd.Dispose();

            return correcto;
        }

    }

    public class FiltroPasientes
    {
        public ObservableCollection<Paciente> resultados;
        public dbcon db;

        public FiltroPasientes(dbcon con)
        {
            db = con;
        }

        public void BuscarPorNombre(string nombre)
        {
            resultados.Clear();
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Paciente WHERE nombre LIKE '{nombre}'";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                while (result.Read())
                {
                    var p = new Paciente(db);
                    p.cedula = result.GetString(1);
                    p.nombre = result.GetString(2);
                    p.apellido = result.GetString(3);
                    p.telefono = result.GetString(4);
                    p.direccion = result.GetString(5);
                    p.existe = true;
                    resultados.Add(p);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
        }
        public static ObservableCollection<Paciente> Cargar(dbcon db)
        {
            var list = new ObservableCollection<Paciente>();

            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Paciente";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                while (result.Read())
                {
                    var p = new Paciente(db);
                    p.id = result.GetInt32(0);
                    p.cedula = result.GetString(1);
                    p.nombre = result.GetString(2);
                    p.apellido = result.GetString(3);
                    p.telefono = result.GetString(4);
                    p.direccion = result.GetString(5);
                    p.existe = true;
                    list.Add(p);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();

            return list;
        }
    }
}
