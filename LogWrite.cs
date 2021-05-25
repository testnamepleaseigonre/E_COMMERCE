using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


public class LogWrite
{
    private string m_exePath = string.Empty;

    public LogWrite(string logMessage)
    {
        LogWriter(logMessage);
    }

    public void LogWriter(string logMessage)
    {
        m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        try
        {
            using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
            {
                Log(logMessage, w);
            }
        }
        catch
        {

        }
    }

    public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.Write("Log Entry: ");
            txtWriter.WriteLine("{0}", DateTime.Now.ToString());
            txtWriter.WriteLine("{0}", logMessage);
            txtWriter.WriteLine("-------------------------------");
        }
        catch
        {

        }
    }
}