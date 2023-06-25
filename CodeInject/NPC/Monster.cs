using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeInject.Logger;

namespace CodeInject.NPC
{
    class Monster : INPC
    {
        public ushort ID { get; set; }
        public Vector3 Position { get; set; }
        public ushort NPCModelNameID { get; set; }
         
        public Monster(ushort id)
        {
            ID = id;
        }
    }
}
