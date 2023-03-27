using CodeInject.Packet.Packet_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet
{



    class PacketParserCommander:PacketEvents
    {
        public List<IPacket> PacketList { get; private set; } = new List<IPacket>();
        public bool Record = false;


        public IPacket lastRecivePacket { get; private set; }

        public PacketParserCommander()
        {
            base.NewPacketArrived += RecivedNewPacket;
        }

        public bool IsRecivePacketNew(IPacket packet)
        {
            bool isNew = false;
            if(lastRecivePacket == null || 
               lastRecivePacket.PacketSize != packet.PacketSize || 
               !lastRecivePacket.Packet.SequenceEqual(packet.Packet))
            {
                isNew = true;
            }

            if (isNew == true)
            {
                base.NewPacketArrived(this, new PacketArgs() { Packet = packet });
            }

            return isNew;
        }

        public void Add(IPacket packet)
        {
            PacketList.Add(packet);
          
        }

        public void Add(PacketTypes type,byte[] rawPacket)
        {
            IPacket newPacket;
            if(type == PacketTypes.InComing)
            {
                newPacket = new RecivePacket(rawPacket);
            }
            else
            {
                newPacket = new RecivePacket();
            }
            Add(newPacket);
        }


        public void RecivedNewPacket(object obj, EventArgs packet)
        {
            lastRecivePacket = ((PacketArgs)packet).Packet;
            if (Record == true)
              Add(((PacketArgs)packet).Packet);
        }




        public void ChechIfNewPacketArrived()
        {
            ulong adr = GameMethods.GetInt64(GameMethods.GetInt64(GameMethods.GetBaseAdress() + (ulong)0x0112FE60, new short[] { 0x00, 0x00, 0x28, 0x08, 0x2d8 }));
            byte packetSize = GameMethods.GetByte(adr);

            byte[] packetFromServer = new byte[packetSize];

            GameMethods.GetByteArray(adr, packetFromServer, packetFromServer.Length);

            IPacket recivePacket = new RecivePacket(packetFromServer);
           
            IsRecivePacketNew(recivePacket);
        }

    }
}
