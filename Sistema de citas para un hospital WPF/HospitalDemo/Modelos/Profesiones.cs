using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections.ObjectModel;
using System.Windows;

namespace HospitalDemo.Modelos
{
    public class Profesion
    {
        public int id = 0;
        public string nombre = string.Empty;
        public string dimin = string.Empty;
        public string descipcion = string.Empty;

        public override string ToString()
        {
            return nombre;
        }
    }

    public class ProfesionList : ObservableCollection<Profesion>
    {
        dbcon db;

        public ProfesionList(dbcon con) : base()
        {
            db = con;
        }

        public void Cargar()
        {
            ClearItems();
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Profesion";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            while (result.Read())
            {
                var p = new Profesion();
                p.id = result.GetInt32(0);
                p.nombre = result.GetString(1);
                p.dimin = result.GetString(2);
                p.descipcion = result.GetString(3);
                Add(p);
            }
            db.conexcion.Close();
            cmd.Dispose();
        }

        public bool BuscarPorID(int id, ref Profesion v)
        {
            bool encontrado = false;
            Profesion x = null;
            this.ToList().ForEach(delegate (Profesion p) {
                if (p.id == id)
                {
                    x = p; encontrado = true;
                }
            });
            if (encontrado) v = x;
            return encontrado;
        }
        
        public bool InsertarNueva(Profesion p)
        {
            db.conexcion.Open();
            bool correcto = false;
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO Profesion(nombre,dimin,descripcion) VALUES(?,?,?)";
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = p.nombre;
            cmd.Parameters.Add(new OleDbParameter("@dimin", OleDbType.VarChar)).Value = p.dimin;
            cmd.Parameters.Add(new OleDbParameter("@descipcion", OleDbType.VarChar)).Value = p.descipcion;
            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool Eliminar(int id)
        {
            Profesion v = null;
            this.ToList().ForEach(delegate (Profesion p) {
                if (p.id == id)
                    v = p;
            });
            if(v == null)
            {
                MessageBox.Show("La profesion que buscas eliminar no existe");
                return false;
            }
            else
            {
                var c = false;
                db.conexcion.Open();
                var cmd = new OleDbCommand();
                cmd.Connection = db.conexcion;
                cmd.CommandText = $"DELETE FROM Profesion WHERE id={id}";
                if (cmd.ExecuteNonQuery() > 0) { c = true; MessageBox.Show("La profesion que buscas eliminar no existe"); }
                db.conexcion.Close();
                cmd.Dispose();
                return c;
            }

        }

        public bool Actualizar(Profesion v)
        {
            var existe = false;
            this.ToList().ForEach(delegate (Profesion p) {
                if (p.id == v.id)
                    existe = true;
            });
            if (!existe)
            {
                MessageBox.Show("La profesion que buscas actualizar no existe");
                return false;
            }
            else
            {
                var c = false;
                db.conexcion.Open();
                var cmd = new OleDbCommand();
                cmd.Connection = db.conexcion;
                cmd.CommandText = $"UPDATE Profesion SET nombre=?, dimin=?, descripcion=? WHERE ID = {v.id}";
                cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = v.nombre;
                cmd.Parameters.Add(new OleDbParameter("@dimin", OleDbType.VarChar)).Value = v.dimin;
                cmd.Parameters.Add(new OleDbParameter("@descipcion", OleDbType.VarChar)).Value = v.descipcion;
                if (cmd.ExecuteNonQuery() > 0) { c = true; }
                db.conexcion.Close();
                cmd.Dispose();
                return c;
            }
        }
    }
}
