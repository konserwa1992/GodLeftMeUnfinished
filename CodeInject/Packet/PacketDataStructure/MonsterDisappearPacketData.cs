using CodeInject.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    /// <summary>
    /// Monster disappear
    /// 08 00 - Size
    /// 94  - OpCode
    /// 07 D1 58 - CONST
    /// C9 38 - ID
    /// 
    /// {0A 00 94 07 D1 58 94 24 BD BC }
    /// </summary>
    class MonsterDisappearPacketData : MonsterDeadPacketData
    {

        public MonsterDisappearPacketData(byte[] rawPacket):base(rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public List<INPC> GetNCPsData()
        {
            List<INPC> Monsters2Delete = new List<INPC>();
            int monsterIdCount = (PacketSize - 6) / 2;


            for(int indexID = 0; indexID < monsterIdCount;indexID++)
            {
                Monsters2Delete.Add(new Monster(BitConverter.ToUInt16(Packet, (indexID*2)+6)));
            }

            return Monsters2Delete; ;
        }
    }
}
