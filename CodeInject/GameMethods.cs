﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject
{
    class GameMethods
    {
        [DllImport("ClrBootstrap.dll")]
        public static extern int AttackTarget(uint skill, uint monsterIndex);

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


        public static int SendPacket(byte[] packet)
        {
            return SendPacketToServer(GetInt64((GetBaseAdress()+ 0x1126948))+ 0x000016D8 +0x320, packet);
        }

    }
}
