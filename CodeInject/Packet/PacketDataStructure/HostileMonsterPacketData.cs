using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject.Packet.PacketDataStructure
{
    internal class HostileMonsterPacketData : IPacket
    {
        /// <summary>
        /// opcode 99 07
        /// </summary>
        public string Description { get; set; }
        public PacketTypes PacketType { get; set; }
        public byte[] Packet { get; set; }
        public short PacketSize { get; set; }

        public HostileMonsterPacketData(byte[] rawPacket)
        {
            PacketSize = BitConverter.ToInt16(rawPacket, 0);
            Packet = rawPacket;
        }

        public ushort GetHostileMonsterID()
        {
            ushort id= BitConverter.ToUInt16(Packet, 6);

            return id;
        }
    }
}
