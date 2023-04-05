using EasyHook;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject
{
    class GameMethods
    {
        #region MemoryOperations
        [DllImport("ClrBootstrap.dll")]
        public static extern UInt64 GetBaseAdress();

        [DllImport("ClrBootstrap.dll")]
        public static extern UInt64 GetInt64(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern int GetInt32(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern float GetFloat(UInt64 Adress);
        [DllImport("ClrBootstrap.dll")]
        public static extern int SendPacketToServer(UInt64 deviceAddr, byte[] packet);

        [DllImport("ClrBootstrap.dll")]
        public static extern byte GetByte(UInt64 Adress);



        [DllImport("ClrBootstrap.dll")]
        public static extern void GetByteArray(UInt64 adress, byte[] outTable, int size);

        public static UInt64 GetInt64(UInt64 Adress, short[] offsets)
        {
            UInt64 finalAdress = Adress;

            foreach (short offset in offsets)
            {
                finalAdress = GetInt64(finalAdress)+ (ulong)offset;
            }

            return finalAdress;
        }
        #endregion


        #region MemoryHooks
        public unsafe delegate void SendFunc(IntPtr a, Int16* packet);

      //  00007ff7bdc9ec69 int64_t sub_7ff7bdc9ec69(int32_t* arg1, int64_t arg2)
        public unsafe delegate Int64 ReciveFunc(IntPtr a, IntPtr packet);


        public static SendFunc hookSendFunction;
        public static ReciveFunc hookRecivFunction;

        private static IHook<SendFunc> _sendPacketFuncHook;
        private static LocalHook hookSend;
        private static LocalHook hookRecive;

        public unsafe static void AttachHook()
        {
            hookSendFunction = PacketSendHook;
            hookRecivFunction = PacketReciveHook;


            hookSend =
            EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x268DC)), hookSendFunction, null);
            hookSend.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });


            hookRecive =
            EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xEC69)), hookRecivFunction, null);
            hookRecive.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });
        }


        public unsafe static Int64 PacketReciveHook(IntPtr a, IntPtr packet)
        {
            Console.WriteLine($"Size: {GameMethods.GetInt32(((ulong)a.ToInt64() - 0x68) + 0x22)} Packet Recive: {packet.ToInt64().ToString("X")}");

            byte[] PacketData = new byte[GameMethods.GetInt32(((ulong)a.ToInt64() - 0x68) + 0x22)];
            GameMethods.GetByteArray((ulong)packet.ToInt64(), PacketData, PacketData.Length);
            for(int i=0;i<PacketData.Length;i++)
            {
                Console.Write(PacketData[i].ToString("X2")+ " ");
            }
            Console.WriteLine();
          Console.WriteLine("------------------------------------------------------");

            return RecivePacketFromServer(a, packet);
        }
        public unsafe static void PacketSendHook(IntPtr a, Int16* packet)
        {
            SendPacketToServer(packet);
            Console.WriteLine($"Packet Send: {new IntPtr(packet).ToInt64().ToString("X")}");
        }

        public unsafe static Int64 RecivePacketFromServer(IntPtr a, IntPtr packet)
        {
            GameMethods.ReciveFunc delegataeRecive = (GameMethods.ReciveFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xEC69)), typeof(GameMethods.ReciveFunc));
            return delegataeRecive(a, packet);
        }

        public unsafe static void SendPacketToServer(Int16* packet)
        {
            GameMethods.SendFunc delegataeSend = (GameMethods.SendFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x268DC)), typeof(GameMethods.SendFunc));
            delegataeSend(new IntPtr((long)GameMethods.GetInt64((GameMethods.GetBaseAdress() + 0x1126948)) + 0x000016D8 + 0x320), packet);
        }
        #endregion
    }
}
