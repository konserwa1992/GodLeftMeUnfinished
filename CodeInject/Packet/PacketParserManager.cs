using CodeInject.NPC;
using CodeInject.Packet.Packet_Events;
using CodeInject.Packet.PacketDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet
{



    class  PacketParserManager:PacketEvents
    {
        public List<IPacket> PacketList { get; private set; } = new List<IPacket>();
        public static PacketParserManager Instance { get; private set; } = new PacketParserManager();
        public bool Record = false;


        public List<INPC> npcList = new List<INPC>();

        public PacketParserManager()
        {
            base.NewPacketArrived += RecivedNewPacketRecord;
        }


        public void Add(IPacket packet)
        {
            PacketList.Add(packet);
      
        }

        public void RecivedNewPacketRecord(object obj, EventArgs packet)
        {
            if (Record == true)
              Add(((PacketArgs)packet).Packet);

            PacketReciveParse(obj, packet);
        }



        public void PacketReciveParse(object obj, EventArgs arg)
        {
            PacketArgs packet = (PacketArgs)arg;

            //OPcode
            switch(packet.Packet.Packet[2])
            {
                case 0x92: //New NPC/Player spawn
                    {
                        npcList.Add(new SpawnMonsterPacketData(packet.Packet.Packet).GetNCPData());
                        break;
                    }
                case 0x9B: //NPC/ monster disappear
                    {
                        MonsterDeadPacketData deadMonster = new MonsterDeadPacketData(packet.Packet.Packet);
                        INPC toDelete=  npcList.FirstOrDefault(x => x.ID == deadMonster.GetNCPData().ID);
                        if (toDelete != null) {
                            npcList.Remove(toDelete); 
                        }
                        break;
                    }
            }
        }
    }
}
