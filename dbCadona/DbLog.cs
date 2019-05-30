using System;
using System.IO;
using System.Reflection;

namespace dbCadona
{
    public class DbLog
    {
        public DbLog(string logMessage)
        {
            LogWrite(logMessage);
        }

        public void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(@"C:/dev/logs/log.txt"))
                {
                    AddToLog(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void AddToLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog gerado : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
