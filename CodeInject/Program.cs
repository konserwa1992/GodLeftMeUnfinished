using CodeInject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NXPorts.Attributes;
using Hook_test_lib;

namespace ISpace
{
    public static class IClass
    {
        static Form1 form;

        //public static int IMain(string args)
        public static int IMain(string msg)
        {
            AllocConsole();
            GameMethods.AttachHook();
            // form = new Form1();
            //   form.ShowDialog();
            return 0;
        }


        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("kernel32")]
        static extern bool AllocConsole();

        [DllImport("ClrBootstrap.dll")]
        static extern int AttackTarget(uint skill, uint monsterIndex);
    }
}
