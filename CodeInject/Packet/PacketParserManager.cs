using CodeInject.NPC;
using CodeInject.Packet.Packet_Events;
using CodeInject.Packet.PacketDataStructure;
using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                case 0x9B : //NPC/ monster dead
                    {

                        MonsterDeadPacketData disappeardMonster = new MonsterDeadPacketData(packet.Packet.Packet);

                        List<INPC> MonstersToRemove = disappeardMonster.GetNCPsData();

                        foreach (INPC monster in MonstersToRemove)
                        {
                            INPC toDelete = npcList.FirstOrDefault(x => x.ID == monster.ID);
                            if (toDelete != null)
                            {
                                npcList.Remove(toDelete);
                            }
                        }

                        break;
                    }
                case 0x94: //NPC/ monster disappear pack
                    {
                        MonsterDisappearPacketData disappeardMonster = new MonsterDisappearPacketData(packet.Packet.Packet);

                        List<INPC> MonstersToRemove = disappeardMonster.GetNCPsData();

                        foreach (INPC monster in MonstersToRemove)
                        {
                            INPC toDelete = npcList.FirstOrDefault(x => x.ID == monster.ID);
                            if (toDelete != null)
                            {
                                npcList.Remove(toDelete);
                            }
                        }
                        break;
                    }

                case 0x97: //Move packet
                    {
                        MonsterMovePacketData movingMonster = new MonsterMovePacketData(packet.Packet.Packet);
                        INPC newMonsterDestination = movingMonster.GetNCPsData();
                        INPC toMove = npcList.FirstOrDefault(x => x.ID == newMonsterDestination.ID);

                        if(toMove != null) 
                        toMove.Position = movingMonster.GetNCPsData().Position;

                        break;
                    }



               /* case 0x16: //Inventory
                    {
                        PlayerCharacter.PlayerInventory = new Inventory().Load(packet.Packet.Packet);// = new InventoryPacketData(packet.Packet.Packet).GetInventory();
                        break;
                    }*/
            }


            if(BitConverter.ToInt16(packet.Packet.Packet,2)== 1814)
            {
                PlayerCharacter.PlayerInventory = PlayerCharacter.PlayerInventory.Load(packet.Packet.Packet);
            }

            if (BitConverter.ToInt16(packet.Packet.Packet, 0) == 0x14 && BitConverter.ToInt16(packet.Packet.Packet, 2) == 1955)
            {
                ItemUsedPacketData buffStart = new ItemUsedPacketData(packet.Packet.Packet);

                buffStart.GetPotionBuff().Item.Count--;
            }

            if (BitConverter.ToInt16(packet.Packet.Packet, 2) == 1974)
            {
                MonsterKilledByOtherPlayerPacketData killedMob = new MonsterKilledByOtherPlayerPacketData(packet.Packet.Packet);

                if (BitConverter.ToUInt16(packet.Packet.Packet, 21)>=16) {
                    npcList.Remove(npcList.FirstOrDefault(x => x.ID == killedMob.GetNPCID()));
                }
            }

            if (BitConverter.ToInt16(packet.Packet.Packet, 2) == 1945)
            {
               HostileMonsterPacketData hostileMonster = new HostileMonsterPacketData(packet.Packet.Packet);
                // PacketParserManager.Instance.npcList.FirstOrDefault(x=>x.ID==hostileMonster.GetHostileMonsterID()).isHostile=true;
                 ushort s = hostileMonster.GetHostileMonsterID();
            
                 INPC npc = PacketParserManager.Instance.npcList.FirstOrDefault(x => x.ID == hostileMonster.GetHostileMonsterID());
                if (npc != null)
                {
                       npc.isHostile = true;  
                }

                if (BitConverter.ToUInt16(packet.Packet.Packet, 14) >= 16)
                {
                    npcList.Remove(npcList.FirstOrDefault(x => x.ID == BitConverter.ToUInt16(hostileMonster.Packet,8)));
                }

                /*  BuffEndPacketData buffEnd = new BuffEndPacketData(packet.Packet.Packet);
                  PlayerCharacter.PlayerInventory.Items.FirstOrDefault(x => x.GameItemID == buffEnd.GetPotionBuffToTurnOff()).
                  PlayerCharacter.PotionInUse.PotionInUseList.Remove(PlayerCharacter.PotionInUse.PotionInUseList.FirstOrDefault(x => x.ID == buffEnd.GetPotionBuffToTurnOff()));*/
                //  MessageBox.Show($"END {buffEnd.GetPotionBuffToTurnOff()}");
            }
        }
    }
}
