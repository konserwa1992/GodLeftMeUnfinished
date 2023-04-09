using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Packet
{
    public enum PacketTypes
    {
        InComing,OutComing
    }

    public interface IPacket
    {
        string Description { get; set; }
        PacketTypes PacketType { get; set; }
        byte[] Packet { get; set; }
        short PacketSize { get; set; }
    }
}
