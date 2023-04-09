using CodeInject.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    /// <summary>
    /// Spawn new monster
    /// 
    /// 6B 00 -SIZE
    /// 92 - OPCODe?
    /// 07 D1 58 - CONST 
    /// 5A 5A - ID
    /// 20 7B 05 49 30 64 02 49 20 7B 05 49 30 64 02 49 00 00 00 00 00 00 00 00 00 00 00 00 72 42 BD 00 01 00 00 00 00 00 00 00 00 01 05 02 00 00 05 02 00 00 64 00 00 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 64 00 00 00 00 00 00 00 00 00 00 00 00 00 48 00 00 00 08 00 00 00 00 00 00
    /// </summary>
    public class SpawnMonsterPacketData : IPacket
    {
        public string Description { get; set; } = "Monster Packet Structure";
        public PacketTypes PacketType { get; set; } = PacketTypes.InComing;
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }



        public SpawnMonsterPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public INPC GetNCPData()
        {
            return new Monster(BitConverter.ToUInt16(Packet, 6));
        }
    }
}
