using CodeInject.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    class MonsterMovePacketData : MonsterDeadPacketData
    {

        public MonsterMovePacketData(byte[] rawPacket) : base(rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public INPC GetNCPsData()
        {
            INPC Monsters2Move = new Monster(BitConverter.ToUInt16(Packet,6));
            Monsters2Move.Position = new System.Numerics.Vector3(BitConverter.ToSingle(Packet, 12)/100, BitConverter.ToSingle(Packet, 16) / 100, 0);

            return Monsters2Move;
        }
    }
}
