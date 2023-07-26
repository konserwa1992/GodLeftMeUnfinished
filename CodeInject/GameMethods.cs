using CodeInject.Packet;
using CodeInject.Packet.Packet_Events;
using EasyHook;
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
using System.Text.RegularExpressions;
using CodeInject.NPC;
using System.Security.Cryptography;


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
        public static extern short GetShort(UInt64 Adress);

        [DllImport("ClrBootstrap.dll")]
        public static extern void GetByteArray(UInt64 adress, byte[] outTable, int size);


        public static UInt64 GetInt64(UInt64 Adress, short[] offsets)
        {
            UInt64 finalAdress = Adress;

            foreach (short offset in offsets)
            {
                finalAdress = GetInt64(finalAdress) + (ulong)offset;
            }

            return finalAdress;
        }
        #endregion


        #region MemoryHooks
        public unsafe delegate void SendFunc(IntPtr a, Int16* packet);

        //  00007ff7bdc9ec69 int64_t sub_7ff7bdc9ec69(int32_t* arg1, int64_t arg2)
        public unsafe delegate Int64 ReciveFunc(IntPtr a, Int16* packet);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public unsafe delegate void* ReciveFunc2(IntPtr arg0, Int32 arg1);


        public static SendFunc hookSendFunction;
        public static ReciveFunc hookRecivFunction;
        public static ReciveFunc2 hookRecivFunction2;

        private static LocalHook hookSend;
        private static LocalHook hookRecive;
        private static LocalHook hookRecive2;

        public static List<byte> IgnoreSendPacketOpCode = new List<byte>() { };

        public static List<string> IgnorePacketRegexList = new List<string>() { };

        /// <summary>
        /// Have to be initialized later after login in
        /// </summary>
        public unsafe static void AttachHookSendHook()
        {
            if (hookSend == null)
            {
                hookSendFunction = PacketSendHook;

                hookSend =
                EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x26B7F)), hookSendFunction, null);
                hookSend.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });
            }

        }

        public unsafe static void AttachHookReciveHook()
        {
            if (hookRecive == null)
            {

                hookRecivFunction = PacketReciveHook;
                hookRecivFunction2 = PacketReciveHook2;


                  hookRecive = //EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x26BCA)), hookRecivFunction2, null);

                  EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xED13)), hookRecivFunction, null);
                  hookRecive.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });


                hookRecive2 =

EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xEA0C)), hookRecivFunction2, null);
                hookRecive.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });


            }
            /*hookRecive =
            EasyHook.LocalHook.Create(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x3B471)), hookRecivFunction2, null);
            hookRecive.ThreadACL.SetExclusiveACL(new int[] { Thread.CurrentThread.ManagedThreadId });*/
        }


        public unsafe static Int64 PacketReciveHook(IntPtr a, Int16* packet)
        {
        //    Console.WriteLine($"Size: {GameMethods.GetInt32(((ulong)a.ToInt64() - 0x68) + 0x22)} Packet Recive:");

            byte[] PacketData = new byte[GameMethods.GetShort((ulong)packet)];

            GameMethods.GetByteArray((ulong)packet, PacketData, PacketData.Length);

            string packetAsAString = "";
            for (int i = 0; i < PacketData.Length; i++)
            {
                Console.Write(PacketData[i].ToString("X2") + " ");
                packetAsAString += PacketData[i].ToString("X2") + " ";
            }


            StreamWriter stringWriter = new StreamWriter("LOGGER.txt", true);
            stringWriter.WriteLine("\n[S=>C]");
            stringWriter.WriteLine(packetAsAString);
            stringWriter.Close();




            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");

            PacketParserManager.Instance.NewPacketArrived(a, new PacketArgs { Packet = new RecivePacket(PacketData) });


            foreach (string regEx in IgnorePacketRegexList) {
                Match match = Regex.Match(packetAsAString, regEx);

                if (match.Success)
                {
                    return 0;
                }
            }


            return RecivePacketFromServer(a, packet);

        }
        public unsafe static void PacketSendHook(IntPtr device, Int16* packet)
        {
            ulong packetAdr = (ulong)(new IntPtr((void*)packet).ToInt64());
            byte[] PacketData = new byte[GameMethods.GetByte(packetAdr)];
            GameMethods.GetByteArray(packetAdr, PacketData, PacketData.Length);

            PacketParserManager.Instance.NewPacketArrived(device, new PacketArgs { Packet = new SendPacket(PacketData) });


            string packetAsAString = "";
            for (int i = 0; i < PacketData.Length; i++)
            {
             //   Console.Write(PacketData[i].ToString("X2") + " ");
                packetAsAString += PacketData[i].ToString("X2") + " ";
            }


            ////    StreamWriter stringWriter = new StreamWriter("LOGGER.txt", true);
            //  stringWriter.WriteLine("\n[C=>S]");
            //   stringWriter.WriteLine(packetAsAString);
            //   stringWriter.Close();


         //   Console.WriteLine();
         //   Console.WriteLine("------------------------------------------------------");

        //    Console.WriteLine($"Packet Send: {new IntPtr(packet).ToInt64().ToString("X")}");


            foreach (string regEx in IgnorePacketRegexList)
            {
                Match match = Regex.Match(packetAsAString, regEx);

                if (match.Success)
                {
                    return;
                }
            }

            SendPacketToServer(device, packet);
        }


        public static unsafe void* PacketReciveHook2(IntPtr arg0, Int32 arg1)
        {


            /* byte[] PacketData = new byte[GameMethods.GetShort((ulong)packet)];

             GameMethods.GetByteArray((ulong)packet, PacketData, PacketData.Length);


             Console.WriteLine($"ARG1: {arg1}\nARG2: {arg2}\nARG3: {arg3}\n");

             string packetAsAString = "";
             for (int i = 0; i < PacketData.Length; i++)
             {
                 Console.Write(PacketData[i].ToString("X2") + " ");
                 packetAsAString += PacketData[i].ToString("X2") + " ";
             }


             Console.WriteLine();*/
             Console.WriteLine("===============================================");
            void* returnVal = RecivePacketFromServer2(arg0, arg1);

         //   Console.WriteLine($"ret: {returnVal} ARG1: {arg1.ToString("X")}\n");
            return returnVal;
        }



        public unsafe static Int64 RecivePacketFromServer(IntPtr a, Int16* packet)
        {

            //3B471
            GameMethods.ReciveFunc delegateRecive = (GameMethods.ReciveFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xED13)), typeof(GameMethods.ReciveFunc));
            return delegateRecive(a, packet);
        }

        public unsafe static void* RecivePacketFromServer2(IntPtr arg0, Int32 arg1)
        {
            GameMethods.ReciveFunc2 delegateRecive = (GameMethods.ReciveFunc2)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xEA0C)), typeof(GameMethods.ReciveFunc2));

             return delegateRecive(arg0, arg1);
        }


        //update:2023.06.30
        public unsafe static void SendPacketToServer(Int16* packet)
        {
            GameMethods.SendFunc delegateSend = (GameMethods.SendFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x26B7F)), typeof(GameMethods.SendFunc));
            delegateSend(new IntPtr((long)GameMethods.GetInt64((GameMethods.GetBaseAdress() + 0x1122EF0)) + 0x000016D8 + 0x00000110), packet);
        }

        public unsafe static void SendPacketToServer(IntPtr device,Int16* packet)
        {
            GameMethods.SendFunc delegateSend = (GameMethods.SendFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0x26B7F)), typeof(GameMethods.SendFunc));
            delegateSend(device, packet);
        }


        public unsafe static void SendPacketToClient(Int16* packet)
        {

            GameMethods.ReciveFunc delegateRecive = (GameMethods.ReciveFunc)Marshal.GetDelegateForFunctionPointer(new IntPtr((long)(GameMethods.GetBaseAdress() + 0xED13)), typeof(GameMethods.ReciveFunc));
            delegateRecive(new IntPtr((long)GameMethods.GetInt64((GameMethods.GetBaseAdress() + 0x1122EF0)) + 0x000016D8 + 0x110 + 0x68), packet);
        }
        #endregion
    }
}
