using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows;

namespace HospitalDemo.Modelos
{

    //Clase base para la coneccion de la base de datos, se pasa una referencia de este a cada Modelo de Datos
    //de la carpeta modelos.
    public class dbcon
    {
        public OleDbConnection conexcion { get; private set; }

        //Verifica si el archivo access esta en su lugar, y si se puede establecer conexcion exitosamente.
        public bool Inicializar()
        {
            var actual = Environment.CurrentDirectory;
            var dblocation = Path.Combine(actual, "db/db.accdb");
            if (!File.Exists(dblocation))
            {
                MessageBox.Show("No se encontro la base de datos en los archivos", "ERROR FATAL", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            conexcion = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dblocation}");

            try
            {
                conexcion.Open();
                conexcion.Close();
            }catch(OleDbException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

    }
}
