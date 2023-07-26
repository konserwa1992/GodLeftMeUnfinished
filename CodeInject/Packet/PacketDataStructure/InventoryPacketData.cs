using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    internal class InventoryPacketData : IPacket
    {
        public string Description { get; set; }
        public PacketTypes PacketType { get; set; } = PacketTypes.InComing;
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

        public InventoryPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public Inventory GetInventory()
        {
            return new Inventory().Load(Packet);
        }

    }
}
