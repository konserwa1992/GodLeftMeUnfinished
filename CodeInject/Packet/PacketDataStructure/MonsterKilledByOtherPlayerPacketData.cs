using CodeInject.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    class MonsterKilledByOtherPlayerPacketData : IPacket
    {
        /// <summary>
        /// opcode B6 07
        /// </summary>
        public string Description { get; set; } = "Monster dead packet structure";
        public PacketTypes PacketType { get; set; } = PacketTypes.InComing;
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

  

        public MonsterKilledByOtherPlayerPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public ushort GetNPCID()
        {
            return BitConverter.ToUInt16(Packet, 6);
        }
    }
}
