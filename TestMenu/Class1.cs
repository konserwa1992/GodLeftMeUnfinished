using System;
using System.Runtime.InteropServices;

namespace TestMenu
{
    public class IClass
    {
        public static int IMain(string args)
        {
            AllocConsole();
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
