using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    /// <summary>
    /// OpCode 0xA307 or (short)1955
    /// </summary>
    class ItemUsedPacketData : IPacket
    {
        public string Description { get; set; }
        public PacketTypes PacketType { get; set; }
        public byte[] Packet { get; set; }
        public short PacketSize { get; set ; }

        public ItemUsedPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public PotionBuff GetPotionBuff()
        {
            return new PotionBuff()
            {
                ID = BitConverter.ToInt16(Packet, 7),
                Item = PlayerCharacter.PlayerInventory.Items.First(x => x.GameItemID == BitConverter.ToUInt64(Packet, 12))
            };
        }
    }
}
