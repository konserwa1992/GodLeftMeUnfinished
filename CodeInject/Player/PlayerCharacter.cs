using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Player
{
    unsafe class PlayerCharacter
    {
        public static ushort ID { get; set; }
        public static Vector3 Position { get; set; }
        public static Inventory PlayerInventory { get; set; } =new Inventory();
        public static PotionBuffs PotionInUse { get; set; } =  new PotionBuffs();
        public static int* HP { get; private set; }
        public static int* MaxHP { get; private set; }
        public static int* MP { get; private set; }
        public static int* MaxMP { get; private set; }



        public static void InitHpData()
        {
            HP = (int*)new UIntPtr(GameMethods.GetInt64(GameMethods.GetBaseAdress()+ 0x111AE90) + 0x3AE8).ToPointer();
            MaxHP = (int*)new UIntPtr(GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x111AE90) + 0x3c94).ToPointer();


            MP = (int*)new UIntPtr(GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x111AE90) + 0x3aec).ToPointer();
            MaxMP = (int*)new UIntPtr(GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x111AE90) + 0x3ca0).ToPointer();
        }


        public static void LoadInventory(byte[] packet) {
            PlayerInventory.Load(packet);
        }
    }
}
