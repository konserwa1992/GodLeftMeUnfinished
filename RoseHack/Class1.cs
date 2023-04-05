using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ISpace
{
    public static class IClass
    {

        public static int IMain(string args)
        {
            MessageBox.Show("sadfASD");
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



namespace RoseHack
{
    public class Class1
    {

    }
}