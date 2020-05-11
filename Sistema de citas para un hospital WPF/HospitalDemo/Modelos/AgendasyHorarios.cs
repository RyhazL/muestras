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
    public class Horarios
    {
        public string _horarios = "";
        public int n_citas = 10;
        public bool error = false;

        public string dbstring {
            set {
                if (value == "vacio")
                    _horarios = string.Empty;
                else
                    _horarios = value;
                /*
                _horarios = "";
                var data = value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if(data.Length != 2)
                {
                    error = true;
                }
                else
                {
                    if (!int.TryParse(data[1],out n_citas)){ error = true; }
                    else
                    {
                        _horarios = data[0];
                    }
                }
                */
            }
            get {
                if (_horarios == string.Empty)
                    return "vacio";
                else
                    return _horarios;
            }
        }

        public enum ErroKind { Separador, HoraMinuto, LogicaHM , Dospuntos}
        public ErroKind elerror;

        public string Asignar {
            set {
                error = false;
                if(value == string.Empty)
                {
                    _horarios = "";
                    return;
                }
                var data = value.Split(new string[] { ",",">" }, StringSplitOptions.RemoveEmptyEntries);
                if(((data.Length % 2) == 1))
                {
                    error = true;
                    elerror = ErroKind.Separador;
                    return;
                }
                /*
                foreach(var hora in data)
                {
                    var datos = hora.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    int h, m;
                    if(!int.TryParse(datos[0], out h))
                    {
                        error = true;
                        elerror = ErroKind.HoraMinuto;
                        return;
                    }
                    if(!int.TryParse(datos[1], out m))
                    {
                        error = true;
                        elerror = ErroKind.HoraMinuto;
                        return;
                    }

                    if(( 0 < h) || ( h > 24))
                    {
                        error = true;
                        elerror = ErroKind.HoraMinuto;
                        return;
                    }
                    if ((0 < m) || (h > 60))
                    {
                        error = true;
                        elerror = ErroKind.HoraMinuto;
                        return;
                    }
                }
                */
                TimeSpan ts1 = new TimeSpan();
                TimeSpan ts2 = new TimeSpan();
                bool s = false;

                foreach (var item in data)
                {

                    if (item.IndexOf(":") == -1)
                    {
                        error = true;
                        elerror = ErroKind.Dospuntos;
                        return;
                    }
                    if (!s)
                    {
                        if (!TimeSpan.TryParse(item, out ts1))
                        {
                            error = true;
                            elerror = ErroKind.HoraMinuto;
                            return;
                        }
                        s = true;
                    }
                    else
                    {
                        if (!TimeSpan.TryParse(item, out ts2))
                        {
                            error = true;
                            elerror = ErroKind.HoraMinuto;
                            return;
                        }
                        s = false;
                        var t = ts2.Subtract(ts1);
                        if(t.TotalMinutes < 0)
                        {
                            error = true;
                            elerror = ErroKind.LogicaHM;
                            return;
                        }
                    }
                }
                if (!error)
                    _horarios = value.Replace(" ",string.Empty);
                
            }
        }

        public string Mostrar {
            get {
                if (error)
                    return $"ERROR {TraducirError()}";
                if(_horarios == string.Empty)
                {
                    return "No Trabaja Hoy";
                }
                string r = "";
                var hs = _horarios.Split(new string[] { ",",">" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= (hs.Length/2); i++)
                {
                    r += i > 0 ? " , " : "";
                    r += "De " + TimeSpan.Parse(hs[0 + i]).ToString(@"hh\:mm") + " a " + TimeSpan.Parse(hs[1 + i]).ToString(@"hh\:mm");
                    i++;
                }
                return r;
            }
        }
        public string MostrarCorta
        {
            get
            {
                if (error)
                    return $"ERROR {TraducirError()}";
                if (_horarios == string.Empty)
                {
                    return "No Trabaja Hoy";
                }
                string r = "";
                var hs = _horarios.Split(new string[] { ",", ">" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= (hs.Length / 2); i++)
                {
                    r += i > 0 ? " , " : "";
                    r += TimeSpan.Parse(hs[0 + i]).ToString(@"hh\:mm") + "-" + TimeSpan.Parse(hs[1 + i]).ToString(@"hh\:mm");
                    i++;
                }
                return r;
            }
        }

        public string TraducirError()
        {
            string e = "";
            switch (elerror)
            {
                case ErroKind.HoraMinuto:
                    e = "(Los horarios deben segir el formato HH:MM, HH comprende 00 a 23 y MM 00 a 59)";
                    break;
                case ErroKind.Separador:
                    e = "(Usa el separador '>' y la ',' para separara los datos ejem=( HoraInico1 > HoraFinal1, HoraInico1 > HoraFinal1) )";
                    break;
                case ErroKind.LogicaHM:
                    e = "(la Hora inicial no puede ser mayor a la final)";
                    break;
                case ErroKind.Dospuntos:
                    e = "(Hacen falta los dos puntos ':' en algun horario)";
                    break;
            }
            return e;
        }

        public bool Disponibilidad
        {
            get
            {
                bool dispo = false;
                if (_horarios == string.Empty)
                    return dispo;

                var data = _horarios.Split(new string[] { ",", ">" }, StringSplitOptions.RemoveEmptyEntries);
                TimeSpan ts1 = new TimeSpan();
                TimeSpan ts2 = new TimeSpan();
                bool s = false;

                foreach (var item in data)
                {
                    if (!s)
                    {
                        ts1 = TimeSpan.Parse(item);
                        s = true;
                    }
                    else
                    {
                        ts2 = TimeSpan.Parse(item);
                        s = false;
                        var mydt = DateTime.Now;
                        var time = mydt.TimeOfDay;
                        if((TimeSpan.Compare(time,ts1) >= 0)&&(TimeSpan.Compare(time, ts2) <= 0))
                        {
                            dispo = true;
                        }

                    }
                }
                return dispo;
            }
        }

    }

    public class AgendaHoraria
    {
        public int id = 0;
        public string nombre;
        public Horarios[] horarios;
        bool existe = false;


        public AgendaHoraria()
        {
            id = 0;
            nombre = "";
            horarios = new Horarios[7];
            for (int i = 0; i < horarios.Length; i++)
            {
                horarios[i] = new Horarios();
            }
        }

        public void Cargar(dbcon db)
        {
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM AgendaSemanal WHERE id={id}";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            existe = correcto;
            if (correcto)
            {
                while (result.Read())
                {
                    nombre = result.GetString(1);
                    horarios[0].dbstring = result.GetString(2);
                    horarios[1].dbstring = result.GetString(3);
                    horarios[2].dbstring = result.GetString(4);
                    horarios[3].dbstring = result.GetString(5);
                    horarios[4].dbstring = result.GetString(6);
                    horarios[5].dbstring = result.GetString(7);
                    horarios[6].dbstring = result.GetString(8);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
        }

        public bool Actualizar(dbcon db)
        {
            bool correcto = false;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"Update AgendaSemanal SET nombre=?,lunes=?,martes=?,miercoles=?" +
                $",jueves=?,viernes=?,sabado=?,domingo=? WHERE id={id}";
            cmd.Parameters.Add("nombre", OleDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("lunes", OleDbType.VarChar).Value = horarios[0].dbstring;
            cmd.Parameters.Add("martes", OleDbType.VarChar).Value = horarios[1].dbstring;
            cmd.Parameters.Add("miercoles", OleDbType.VarChar).Value = horarios[2].dbstring;
            cmd.Parameters.Add("jueves", OleDbType.VarChar).Value = horarios[3].dbstring;
            cmd.Parameters.Add("viernes", OleDbType.VarChar).Value = horarios[4].dbstring;
            cmd.Parameters.Add("sabado", OleDbType.VarChar).Value = horarios[5].dbstring;
            cmd.Parameters.Add("domingo", OleDbType.VarChar).Value = horarios[6].dbstring;
            if (cmd.ExecuteNonQuery()> 0) { correcto = true; }
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }
        public bool Insertar(dbcon db)
        {
            bool correcto = false;
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"INSERT INTO AgendaSemanal(nombre,lunes,martes,miercoles,jueves,viernes,sabado,domingo) " +
                $"VALUES(?,?,?,?,?,?,?,?)";
            cmd.Parameters.Add("nombre", OleDbType.VarChar).Value = nombre;
            cmd.Parameters.Add("lunes", OleDbType.VarChar).Value = horarios[0].dbstring;
            cmd.Parameters.Add("martes", OleDbType.VarChar).Value = horarios[1].dbstring;
            cmd.Parameters.Add("miercoles", OleDbType.VarChar).Value = horarios[2].dbstring;
            cmd.Parameters.Add("jueves", OleDbType.VarChar).Value = horarios[3].dbstring;
            cmd.Parameters.Add("viernes", OleDbType.VarChar).Value = horarios[4].dbstring;
            cmd.Parameters.Add("sabado", OleDbType.VarChar).Value = horarios[5].dbstring;
            cmd.Parameters.Add("domingo", OleDbType.VarChar).Value = horarios[6].dbstring;
            if (cmd.ExecuteNonQuery() > 0) { correcto = true; }
            cmd.CommandText = "SELECT @@IDENTITY";
            id = (int)cmd.ExecuteScalar();
            db.conexcion.Close();
            cmd.Dispose();
            return correcto;
        }

        public static List<AgendaHoraria> CargarTodos(dbcon db)
        {
            List<AgendaHoraria> list = new List<AgendaHoraria>();
            db.conexcion.Open();
            var cmd = new OleDbCommand();
            cmd.Connection = db.conexcion;
            cmd.CommandText = $"SELECT * FROM AgendaSemanal";
            var result = cmd.ExecuteReader();
            bool correcto = result.HasRows;
            if (correcto)
            {
                while (result.Read())
                {
                    var a = new AgendaHoraria();
                    a.id = result.GetInt32(0);
                    a.nombre = result.GetString(1);
                    a.horarios[0].dbstring = result.GetString(2);
                    a.horarios[1].dbstring = result.GetString(3);
                    a.horarios[2].dbstring = result.GetString(4);
                    a.horarios[3].dbstring = result.GetString(5);
                    a.horarios[4].dbstring = result.GetString(6);
                    a.horarios[5].dbstring = result.GetString(7);
                    a.horarios[6].dbstring = result.GetString(8);
                    list.Add(a);
                }
            }
            db.conexcion.Close();
            cmd.Dispose();
            return list;
        }

        public override string ToString()
        {
            return $"{nombre} (Lun[{horarios[0].MostrarCorta}]Mar[{horarios[1].MostrarCorta}]Mie[{horarios[2].MostrarCorta}]" +
                $"Jue[{horarios[3].MostrarCorta}]Vie[{horarios[4].MostrarCorta}]Sab[{horarios[5].MostrarCorta}]Dom[{horarios[6].MostrarCorta}])";
        }
    }

}
