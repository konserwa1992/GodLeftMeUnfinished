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
        public int ID { get; set; }
        public Vector3 Position { get; set; }
        public int NPCModelNameID { get; set; }

        public PlayerCharacter(int id)
        {
            ID = id;
        }

        public void Update()
        {
            /*trose.exe + E68D3 - 48 8B 8C C7 78200200 - mov rcx,[rdi+rax * 8 + 00022078]*/
            ulong ListAdresEntryRDI = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C83B8);
            ulong NpcEntryPointer = ListAdresEntryRDI + (ulong)(ID * 8) + 0x22078;
            ulong NpcEntryAdress = GameMethods.GetInt64(NpcEntryPointer);
            Position = new Vector3(GameMethods.GetFloat(NpcEntryAdress + 0x10), GameMethods.GetFloat(NpcEntryAdress + 0x14), GameMethods.GetFloat(NpcEntryAdress + 0x18));
        }
    }
}
