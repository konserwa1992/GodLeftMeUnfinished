using CodeInject;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Reloaded.Hooks.Definitions.X64;

namespace RoseHackDLL
{
    public class Class1
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();

        [DllExport]
        public static unsafe void IMain(string msg)
        {
            /*string hexString = "07008207D15801";
            byte[] byteArray = new byte[hexString.Length / 2];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            fixed (byte* pointer = byteArray)
            {
                IntPtr p = new IntPtr(pointer);
                GameMethods.SendPacketToServer((short*)p.ToPointer());
            }*/
            MessageBox.Show("Injected");
            FileName.hook();
        }



        public static unsafe class FileName
        {
            [Function(CallingConventions.Microsoft)]
            [FunctionHookOptions(PreferRelativeJump = true,SearchInModules =true,VerifyJumpTargetsModule =true)]
            public delegate void funcDef();


            public static IFunction<funcDef> funkcyjka;
            public static IHook<funcDef> degiafe;

            // [Function(CallingConventions.Microsoft)]
            public static funcDef oryginalFun;


            public unsafe static void hook()
            {
                oryginalFun = oryginalnaFunkcja;

                funkcyjka = ReloadedHooks.Instance.CreateFunction<funcDef>(oryginalFun.Method.MethodHandle.GetFunctionPointer().ToInt64());


                degiafe = ReloadedHooks.Instance.CreateHook<funcDef>(typeof(FileName), nameof(Hook), funkcyjka.Address);
                degiafe.Activate();


            }

            public unsafe static void oryginalnaFunkcja()
            {
                MessageBox.Show("Oryginal");
            }

            public unsafe static void Hook()
            {
                MessageBox.Show("hooked");
            }
        }
    }
}