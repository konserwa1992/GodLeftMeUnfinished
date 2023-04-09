using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.Packet_Events
{
    public class PacketArgs : EventArgs
    {
        public IPacket Packet { get; set; }
    }

    class PacketEvents
    {
        public EventHandler NewPacketArrived;
    }
}
