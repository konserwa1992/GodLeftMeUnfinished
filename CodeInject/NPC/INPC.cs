using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.NPC
{
    interface INPC
    {
        int ID { get; set; }
        Vector3 Position { get; set; }
        int NPCModelNameID { get; set; }
        void Update();
    }
}
