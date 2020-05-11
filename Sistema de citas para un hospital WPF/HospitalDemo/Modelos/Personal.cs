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
    public class Personal
    {
        private int _id = 0;
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int prof_id { get; set; }
        public DateTime f_ingreso { get; set; }
        public int agenda_actual { get; set; }


        public string prof_nombre = string.Empty;
        public bool existe = false;

        public int id {
            get{ return _id;}
            set{ existe = false; _id = value; }
        }
        public dbcon db;

        public Personal(dbcon con) { db = con; }
        public Personal(dbcon con,int identificador)
        {
            db = con;
            id = identificador;
        }

        public override string ToString()
        {
            return $"{nombre} {apellido} [{prof_nombre}]";
        }

        public bool? Cargar()
        {
            if (db == null)
                return null;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Personal WHERE id={_id}";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                existe = true;
                while (result.Read())
                {
                    nombre = result.GetString(1);
                    apellido = result.GetString(2);
                    prof_id = result.GetInt32(3);
                    f_ingreso = result.GetDateTime(4);
                    agenda_actual = result.GetInt32(5);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool Ingresar()
        {
            var correcto = false;
            var v = Cargar();
            if (!v.HasValue)
            {
                MessageBox.Show("Error no se pudo ingresar a la Base de Datos");
                return false;
            }
            if (v.Value)
            {
                MessageBox.Show("Este Registro ya se encuentra en la Base de datos.");
                return false;
            }
            _id = 0;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO Personal(nombre,apellido,prof_id,f_ingreso,agenda_actual) VALUES(?,?,?,?,?)";
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = nombre;
            cmd.Parameters.Add(new OleDbParameter("@apellido", OleDbType.VarChar)).Value = apellido;
            cmd.Parameters.Add(new OleDbParameter("@prof_id", OleDbType.Integer)).Value = prof_id;
            cmd.Parameters.Add(new OleDbParameter("@f_ingreso", OleDbType.DBTimeStamp)).Value = f_ingreso;
            cmd.Parameters.Add(new OleDbParameter("@agenda_actual", OleDbType.Integer)).Value = agenda_actual;
            
            if (cmd.ExecuteNonQuery() > 0){correcto = true;}

            cmd.CommandText = "SELECT @@IDENTITY";
            _id = (int)cmd.ExecuteScalar();
            db.conexcion.Close();
            cmd.Dispose();

            return correcto;
        }

        public bool Eliminar()
        {
            var correcto = false;
            var v = Cargar();
            if (!v.HasValue)
            {
                MessageBox.Show("Error no se pudo ingresar a la Base de Datos");
                return false;
            }
            if (!v.Value)
            {
                MessageBox.Show($"No puedes eliminar un registro de Personal que no existe [reg: {id}]");
                return false;
            }
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"DELETE FROM Personal WHERE id={_id}";
            if(cmd.ExecuteNonQuery() > 0){ correcto = true; existe = false; }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool Actualizar()
        {
            var correcto = false;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"UPDATE Personal SET nombre=?,apellido=?,prof_id=?,f_ingreso=?,agenda_actual=? WHERE id = {id}";
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = nombre;
            cmd.Parameters.Add(new OleDbParameter("@apellido", OleDbType.VarChar)).Value = apellido;
            cmd.Parameters.Add(new OleDbParameter("@prof_id", OleDbType.Integer)).Value = prof_id;
            cmd.Parameters.Add(new OleDbParameter("@f_ingreso", OleDbType.DBTimeStamp)).Value = f_ingreso;
            cmd.Parameters.Add(new OleDbParameter("@agenda_actual", OleDbType.Integer)).Value = agenda_actual;

            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            db.conexcion.Close();

            return correcto;
        }
    }

    public class PersonalCollecion : ObservableCollection<Personal>
    {
        public dbcon db;

        public PersonalCollecion(dbcon con):base()
        {
            db = con;
        }

        public void Reload(bool placeholder = false)
        {
            ClearItems();
            var profesiones = new ProfesionList(db);
            profesiones.Cargar();
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Personal";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            while (result.Read())
            {
                var p = new Personal(db);
                p.id = result.GetInt32(0);
                p.nombre = result.GetString(1);
                p.apellido = result.GetString(2);
                p.prof_id = result.GetInt32(3);
                p.f_ingreso = result.GetDateTime(4);
                p.agenda_actual = result.GetInt32(5);
                p.existe = true;
                var profesion = new Profesion();
                if(profesiones.BuscarPorID(p.prof_id, ref profesion))
                {
                    p.prof_nombre = profesion.nombre;
                }
                Add(p);
            }
            if (placeholder)
            {
                var placeholder_p = new Personal(db);
                placeholder_p.prof_nombre = "Mostrar Todos";
                placeholder_p.id = -1;
                Add(placeholder_p);
            }
            db.conexcion.Close();
            cmd.Dispose();
        }
    }
}
