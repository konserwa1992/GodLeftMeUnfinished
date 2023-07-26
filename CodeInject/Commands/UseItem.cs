using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Commands
{
    internal class UseItem
    {
        private Inventory.Item item;

        public  UseItem(Inventory.Item item)
        { this.item = item; }


        public unsafe void Execute()
        {
           
            byte[] packetStartStruct = new byte[] { 0x0E ,0x00, 0xA3, 0x07, 0xD1, 0x58 };
            byte[] itemID = BitConverter.GetBytes(this.item.GameItemID);


            int length = packetStartStruct.Length + itemID.Length;
            byte[] result = new byte[length];

            int offset = 0;
            Array.Copy(packetStartStruct, 0, result, offset, packetStartStruct.Length);
            offset += packetStartStruct.Length;
            Array.Copy(itemID, 0, result, offset, itemID.Length);
            offset += itemID.Length;



            fixed (byte* pointer = result)
            {
                GameMethods.SendPacketToServer((short*)pointer);
            }
        }
    }
}
