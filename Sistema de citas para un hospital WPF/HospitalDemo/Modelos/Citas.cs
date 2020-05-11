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
    public class Cita
    {
        public int id { get; set; }
        public int personal_id { get; set; }
        public int paciente_id { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_cita { get; set; }
        public TipoCita tipo { get; set; }
        public EstadoCita estado { get; set; }

        
        public string PascienteName
        {
            get
            {
                var p = new Paciente(db, paciente_id);
                if (p.Cargar())
                {
                    return $"[{p.cedula}] {p.nombre}, {p.apellido}";
                }
                return "No existe";
            }
        }
        public string TipoColor
        {
            get
            {
                if (tipo == TipoCita.Emergencia)
                    return "#FF9B0000";
                else if (tipo == TipoCita.Previa)
                    return "#FF0059B2";
                return "";
            }
        }
        public string EstadoColor
        {
            get
            {
                if (estado == EstadoCita.Cancelada)
                    return "Red";
                else if (estado == EstadoCita.EnCurso)
                    return "Green";
                else if (estado == EstadoCita.Finalizada)
                    return "Green";
                else if (estado == EstadoCita.Pendiente)
                    return "Yellow";
                else if (estado == EstadoCita.Perdida)
                    return "Red";
                return "White";
            }
        }
        public string CitaFechaEnDias
        {
            get
            {
                var t = fecha_cita.Subtract(DateTime.Today).Days;
                if (t > 1)
                    return $"En {t} Dias";
                else if (t == 1)
                    return "Mañana.";
                else if (t == 0)
                    return "Hoy";
                else if (t == -1)
                    return "Ayer";
                else if (t < -1)
                    return $"Hace {t + (t * -2)} Dias";
                return "";
                //return fecha_cita.ToString("dd/MM/yyyy");
            }
        }

        public dbcon db;

        public Cita(dbcon con) { db = con; }
        public Cita(dbcon con, int identificador)
        {
            db = con;
            id = identificador;
        }
        

        public bool? Cargar()
        {
            if (db == null)
                return null;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Citas WHERE id={id}";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                while (result.Read())
                {
                    personal_id = result.GetInt32(1);
                    paciente_id = result.GetInt32(2);
                    fecha_ingreso = result.GetDateTime(3);
                    fecha_cita = result.GetDateTime(4);
                    tipo = (TipoCita)result.GetInt32(5);
                    estado = (EstadoCita)result.GetInt32(6);
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
            id = 0;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO Citas(personal_id,paciente_id,fecha_ingreso,fecha_cita,tipo,estado) VALUES(?,?,?,?,?,?)";
            cmd.Parameters.Add(new OleDbParameter("@personal_id", OleDbType.Integer)).Value = personal_id;
            cmd.Parameters.Add(new OleDbParameter("@paciente_id", OleDbType.Integer)).Value = paciente_id;
            cmd.Parameters.Add(new OleDbParameter("@fecha_ingreso", OleDbType.DBDate)).Value = DateTime.Now;
            cmd.Parameters.Add(new OleDbParameter("@fecha_cita", OleDbType.DBDate)).Value = fecha_cita;
            cmd.Parameters.Add(new OleDbParameter("@tipo", OleDbType.Integer)).Value = (int)tipo;
            cmd.Parameters.Add(new OleDbParameter("@estado", OleDbType.Integer)).Value = (int)estado;

            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }

            cmd.CommandText = "SELECT @@IDENTITY";
            id = (int)cmd.ExecuteScalar();
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
                MessageBox.Show("No puedes eliminar un registro de Cita que no existe");
                return false;
            }
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"DELETE FROM Citas WHERE id={id}";
            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public bool CambiarEstado(EstadoCita e)
        {
            var correcto = false;
            estado = e;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"UPDATE Citas SET estado=? WHERE id = {id}";
            cmd.Parameters.Add(new OleDbParameter("@nombre", OleDbType.VarChar)).Value = (int)estado;

            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            db.conexcion.Close();
            return correcto;
        }
    }

    public enum TipoCita { Previa, Emergencia }
    public enum EstadoCita { Pendiente, Finalizada, Perdida, Cancelada, EnCurso }

    public class CitasList : ObservableCollection<Cita>
    {
        public dbcon db;

        public CitasList(dbcon con):base()
        {
            db = con;
            //Reload();
        }
        /*
        public void Reload()
        {
            ClearItems();
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Citas";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            while (result.Read())
            {
                var p = new Cita(db);
                p.id = result.GetInt32(0);
                p.personal_id = result.GetInt32(1);
                p.paciente_id = result.GetInt32(2);
                p.fecha_ingreso = result.GetDateTime(3);
                p.fecha_cita = result.GetDateTime(4);
                p.tipo = (TipoCita)result.GetInt32(5);
                p.estado = (EstadoCita)result.GetInt32(6);
                Add(p);
            }
            db.conexcion.Close();
            cmd.Dispose();
        }
        */

        //reload carga todo amenos que le metas parametros de busqueda.
        public void Reload(DateTime f_cita,int p_id = -1, int est = -1,int tip = -1)
        {
            Clear();
            bool busqueda = p_id >= 0 || est >= 0 || tip >= 0;
            string id_str = p_id >= 0 ? $" personal_id={p_id}" : string.Empty;
            string est_str = est >= 0 ? $" estado={est}" : string.Empty;
            string tip_str = tip >= 0 ? $" tipo={tip}" : string.Empty;
            int init = 0;
            string w_str = string.Empty;
            if (busqueda)
            {
                w_str = " WHERE";
                if (id_str != string.Empty)
                {
                    w_str += init == 0 ? id_str : " AND" + id_str;
                    init++;
                }
                if (est_str != string.Empty)
                {
                    w_str += init == 0 ? est_str : " AND" + est_str;
                    init++;
                }
                if (tip_str != string.Empty)
                {
                    w_str += init == 0 ? tip_str : " AND" + tip_str;
                    init++;
                }
            }

            //MessageBox.Show(w_str);
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM Citas" + w_str;
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            while (result.Read())
            {
                var p = new Cita(db);
                p.id = result.GetInt32(0);
                p.personal_id = result.GetInt32(1);
                p.paciente_id = result.GetInt32(2);
                p.fecha_ingreso = result.GetDateTime(3);
                p.fecha_cita = result.GetDateTime(4);
                p.tipo = (TipoCita)result.GetInt32(5);
                p.estado = (EstadoCita)result.GetInt32(6);
                Add(p);
            }
            db.conexcion.Close();
            cmd.Dispose();
        }
    }
}
