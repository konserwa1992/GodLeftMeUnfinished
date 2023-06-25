using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.NPC
{
   public interface INPC
    {
        ushort ID { get; set; }
        Vector3 Position { get; set; }
        ushort NPCModelNameID { get; set; }
    }
}
