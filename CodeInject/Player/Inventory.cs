using CodeInject.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Player
{
    public class Inventory
    {
        public byte result;
        public UInt64 Gold;
        public UInt32 ItemsCount;

        public List<Item> Items = new List<Item>();
        public class Item
        {
            public UseItemData ItemInformation;
            public UInt16 Type;
            public UInt32 ObjectModelID;
            public UInt32 Unknow1;
            public UInt32 Unknow2;
            public UInt32 Unknow3;
            public UInt32 Unknow4;
            public UInt64 GameItemID;


            public Byte Unknow5;
            public UInt16 Unknow6;
            public UInt16 Unknow7;
            public UInt16 Unknow8;
            public UInt16 Unknow9;
            public UInt16 Unknow10;
            public Byte Unknow11;
            public Byte Unknow12;
            public UInt16 Unknow13;
            public UInt16 Count;
            public Byte Unknow14;
            public UInt32 InventoryIndex;
            public UInt32 Unknow15;
            public UInt16 Unknow16;
            public Byte Unknow17;
            public Byte Unknow18;
            public UInt32 Unknow19;
            public UInt32 Unknow20;
            public UInt32 Unknow21;
            public UInt32 Unknow22;
        }


        public Inventory Load(byte[] packet)
        {
            this.result = packet[6];
            this.Gold = BitConverter.ToUInt64(packet, 7);
            this.ItemsCount = BitConverter.ToUInt32(packet, 15); //19


            for (int i = 0; i < this.ItemsCount; i++)
            {
                Item currItem = new Item();
                int shift = 19 + i * 76;
                currItem.Type = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.ObjectModelID = BitConverter.ToUInt32(packet, shift);
                if(currItem.Type==0x0a)
                currItem.ItemInformation = GameInfoList.GetUseItemByID((int)currItem.ObjectModelID);
                shift += 4;
                currItem.Unknow1 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow2 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow3 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow4 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.GameItemID = BitConverter.ToUInt64(packet, shift);
                shift += 8;
                currItem.Unknow5 = packet[shift];
                shift += 1;
                currItem.Unknow6 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow7 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow8 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow9 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow10 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow11 = packet[shift];
                shift += 1;
                currItem.Unknow12 = packet[shift];
                shift += 1;
                currItem.Unknow13 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Count = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow14 = packet[shift];
                shift += 1;
                currItem.InventoryIndex = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow15 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow16 = BitConverter.ToUInt16(packet, shift);
                shift += 2;
                currItem.Unknow17 = packet[shift];
                shift += 1;
                currItem.Unknow18 = packet[shift];
                shift += 1;
                currItem.Unknow19 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow20 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow21 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                currItem.Unknow22 = BitConverter.ToUInt32(packet, shift);
                shift += 4;
                Console.WriteLine(shift);
                Items.Add(currItem);
            }
            return this;
        }
    }
}
