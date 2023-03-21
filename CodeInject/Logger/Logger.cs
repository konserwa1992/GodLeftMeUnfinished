using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Logger
{
   public class Logger
    {
        private static Logger loggerInstance = new Logger();
        private StreamWriter streamWriter;

        private Logger() {
            streamWriter = new StreamWriter(DateTime.Now.Ticks + ".log", false);
        }

        public static void Log(string log)
        {
            loggerInstance.streamWriter.WriteLine($"{DateTime.Now}: {log}");
        }

    }
}
