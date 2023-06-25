using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.NPC
{
    class PlayerCharacter : INPC
    {
        public ushort ID { get; set; }
        public Vector3 Position { get; set; }
        public ushort NPCModelNameID { get; set; }

        public PlayerCharacter(ushort id)
        {
            ID = id;
        }
    }
}
