using CodeInject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ISpace
{
    public class IClass
    {
        public static int IMain(string args)
        {

            Form1 form = new Form1();
            form.ShowDialog();

            return 0;
        }

        [DllImport("kernel32")]
        static extern bool AllocConsole();

        [DllImport("ClrBootstrap.dll")]
        static extern int AttackTarget(uint skill, uint monsterIndex);
    }
}
