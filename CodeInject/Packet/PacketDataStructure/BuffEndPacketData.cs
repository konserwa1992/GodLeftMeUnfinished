using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet.PacketDataStructure
{
    /// <summary>
    /// B707 or 1975
    /// </summary>
    internal class BuffEndPacketData : IPacket
    {
        public string Description { get; set; }
        public PacketTypes PacketType { get; set; }
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

        public BuffEndPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 6);
            Packet = rawPacket;
        }

        public short GetPotionBuffToTurnOff()
        {
            return BitConverter.ToInt16(Packet, 6);
        }
    }
}
