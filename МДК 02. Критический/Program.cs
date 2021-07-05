using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace МДК_02.Критический
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(File.AppendText("LogOFCrit.txt")));
            Debug.AutoFlush = true;

            oKrit krit = new oKrit();
            krit.Reshenie();



        }
    }
}
