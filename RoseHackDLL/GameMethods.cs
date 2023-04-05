using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject
{
    public static class GameMethods
    {
        [DllImport("ClrBootstrap.dll")]
        public static extern int AttackTarget(uint skill, uint monsterIndex);

        [DllImport("C:\\dev rose\\ClrBootstrap.dll")]
        public static extern UInt64 GetBaseAdress();

        [DllImport("ClrBootstrap.dll")]
        public static extern UInt64 GetInt64(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern int GetInt32(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern float GetFloat(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern int SendPacketToServer(UInt64 deviceAddr, byte[] packet);

    



        public static UInt64 GetInt64(UInt64 Adress, short[] offsets)
        {
            UInt64 finalAdress = Adress;

            foreach (short offset in offsets)
            {
                finalAdress = GetInt64(finalAdress)+ (ulong)offset;
            }

            return finalAdress;
        }
        public unsafe delegate void SendFunc(IntPtr a, Int16* packet);
        /*
        [Function(CallingConventions.Microsoft)]
        public unsafe delegate void SendFunc(IntPtr a, Int16* packet);
        public static IFunction<SendFunc> sendFunction;

        private static IHook<SendFunc> _sendPacketFuncHook;


        public unsafe static void AttachHook()
        {
              sendFunction = ReloadedHooks.Instance.CreateFunction<SendFunc>((long)(GameMethods.GetBaseAdress() + 0x268DC));
          
            _sendPacketFuncHook = ReloadedHooks.Instance.CreateHook<SendFunc>(typeof(GameMethods), nameof(PacketSendHook), sendFunction.Address);
            _sendPacketFuncHook.Activate();
        }

        public unsafe static void PacketSendHook(IntPtr a, Int16* packet)
        {
            MessageBox.Show("SEND");
             _sendPacketFuncHook.OriginalFunction(a,packet);
        }
        */

        public unsafe static void SendPacketToServer(Int16* packet)
        {
            GameMethods.SendFunc delegataeSend = (GameMethods.SendFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x268DC)), typeof(GameMethods.SendFunc));
            delegataeSend(new IntPtr((long)GameMethods.GetInt64((GameMethods.GetBaseAdress() + 0x1126948)) + 0x000016D8 + 0x320), packet);
        }
    }
}
