using Reloaded.Injector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InjectorDLL
{
    
    [ExcludeFromCodeCoverage]
    public struct stringParams
    {
        public string A { get; private set; }

        public stringParams(string msg) : this()
        {
            A = msg;
        }
    }

    internal class Program
    {



         delegate int IMain(string msg);
        static unsafe void Main(string[] args)
        {
            Process process = Process.GetProcessesByName("trose")[0];

            Console.WriteLine($"Proces znaleziony PID{process.Id}");

            Injector injector = new Injector(process);

            long DllAdress = injector.Inject("C:\\dev rose\\ClrBootstrap.dll");
            Console.WriteLine($"ClrBootstrap Adress: {DllAdress.ToString("X")}");


            DllAdress = injector.Inject("C:\\dev rose\\RoseHackDLL.dll");
            Console.WriteLine($"RoseHackDLL Adress: {DllAdress.ToString("X")}");


            long adressFunckcjiIMain = injector.GetFunctionAddress("RoseHackDLL.dll", "IMain");
            Console.WriteLine($"IMain: {adressFunckcjiIMain.ToString("X2")}");

            stringParams parames = new stringParams("asaadwsdwdw");
            injector.CallFunction("RoseHackDLL.dll", "IMain", parames);

            Console.ReadKey();
        }
    }
}
