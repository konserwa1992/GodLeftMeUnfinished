using EasyHook;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Reloaded.Memory.Sources.MemoryExtensions;

namespace Hook_test_lib
{
    public static unsafe class FileName
    {
        //[FunctionHookOptions(PreferRelativeJump = true,SearchInModules =true,VerifyJumpTargetsModule =true)]
        public delegate void funcDef();


        public static IFunction<funcDef> funkcyjka;
        public static IHook<funcDef> degiafe;

        // [Function(CallingConventions.Microsoft)]
        public static funcDef oryginalFun;
        public static funcDef hookFun;


        public unsafe static void hook()
        {
            oryginalFun = oryginalnaFunkcja;
            hookFun = Hook;

            /* funkcyjka = ReloadedHooks.Instance.CreateFunction<funcDef>(oryginalFun.Method.MethodHandle.GetFunctionPointer().ToInt64());


             degiafe = ReloadedHooks.Instance.CreateHook<funcDef>(typeof(FileName), nameof(Hook), funkcyjka.Address);
             degiafe.Activate();*/


            LocalHook hook =
           EasyHook.LocalHook.Create(oryginalFun.Method.MethodHandle.GetFunctionPointer(), hookFun, null);
            hook.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });

            //    var detour = new MethodDetour(oryginalFun.Method, hookFun.Method);
            //    detour.InitialiseDetour();


        }

        public unsafe static void oryginalnaFunkcja()
        {
            MessageBox.Show("Oryginal");
        }

        public unsafe static void Hook()
        {
            MessageBox.Show("Hooked func");
            // degiafe.OriginalFunction();
        }
    }
}
