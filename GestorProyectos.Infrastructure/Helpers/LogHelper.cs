using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Infrastructure.Helpers
{
    public class LogHelper
    {
        private static string UrlLog = "Logs";
        static string LogDate = DateTime.Now.ToString("dd-MM-yyyy");
        static string LogTime = DateTime.Now.ToString("hh:mm:ss");

        public static void Write(string ClassName, int Line, string user, string Mensaje)
        {
            string Path = UrlLog + "/" + LogDate;
            string LogFile = ($@"{Path}\Logs {LogDate}.txt");

            Directory.CreateDirectory(Path);
            using (StreamWriter w = new StreamWriter(LogFile, true))
            {
                w.WriteLine(LogTime + $" Error en la clase: ({ClassName}) en Linea: ({Line}) por el Usuario: ({user}) ===> " + Mensaje);
                w.Flush();
                w.Close();
            }
        }

        private string dateFile()
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string dateFile = sYear + sMonth + sDay;
            return dateFile;
        }

        public static void Write(string ClassName, string user, Exception ex)
        {
            string Path = UrlLog;
            string LogFile = ($@"{Path}\Logs {LogDate}.txt");
            string Mensaje = ex.Message;
            int Line = 0;
            int.TryParse(ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), out Line);
            Directory.CreateDirectory(Path);
            using (StreamWriter w = new StreamWriter(LogFile, true))
            {
                w.WriteLine(LogTime + $" Error en la clase: ({ClassName}) en Linea: ({Line}) por el Usuario: ({user}) ===> " + Mensaje);
                w.Flush();
                w.Close();
            }
        }
    }
}