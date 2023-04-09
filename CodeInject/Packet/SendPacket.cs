using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet
{
    class SendPacket : IPacket
    {
        public string Description { get; set; }
        public PacketTypes PacketType { get; set; } = PacketTypes.OutComing;
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

        public SendPacket()
        {

        }

        public SendPacket(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }
    }
}
