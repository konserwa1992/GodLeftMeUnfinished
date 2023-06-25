using CodeInject.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    class MonsterDeadPacketData : IPacket
    {
        /// <summary>
        /// Możliwe że B3 i b6 mogą odpowiadać za zabijanie jeszcze
        /// Monster dead packet
        /// 0E 00 - Size
        /// 9B - OPcode ?
        /// 07 D1 58 - CONST
        /// 19 17 00 00 88 13 
        /// 24 68 - NPC ID

        /// </summary>
        public string Description { get; set; } = "Monster dead packet structure";
        public PacketTypes PacketType { get; set; } = PacketTypes.InComing;
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

        public List<INPC> GetNCPsData()
        {
            List<INPC> Monsters2Delete = new List<INPC>();
            int monsterIdCount = (PacketSize - 6) / 2;


            for (int indexID = 0; indexID < monsterIdCount; indexID++)
            {
                Monsters2Delete.Add(new Monster(BitConverter.ToUInt16(Packet, (indexID * 2) + 6)));
            }

            return Monsters2Delete; ;
        }

        public MonsterDeadPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public INPC GetNCPData()
        {
            return new Monster(BitConverter.ToUInt16(Packet, 12));
        }
    }
}
