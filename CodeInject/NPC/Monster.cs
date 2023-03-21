using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.NPC
{
    class Monster : INPC
    {
        public int ID { get; set; }
        public Vector2 Position { get; set; }
        public int NPCModelNameID { get; set; }

        public Monster(int id)
        {
            ID = id;
        }

        public void Update()
        {
            ulong ListAdresEntryRDI = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C83B8);

            ulong NpcEntryPointer = ListAdresEntryRDI + (ulong)(ID * 8) + 0x22078;

            ulong NpcEntryAdress = GameMethods.GetInt64(NpcEntryPointer);

            if (GameMethods.GetInt32(NpcEntryAdress + 0x1C)!=ID)
            {
                throw new Exception("Incorrect npc information adress, structure is incorrect");
            }

            Position = new Vector2(GameMethods.GetFloat(NpcEntryAdress + 0x10), GameMethods.GetFloat(NpcEntryAdress + 0x14));
            NPCModelNameID = GameMethods.GetInt32(NpcEntryAdress + 0x58);//I belive is somekind of Monster model type



            /*trose.exe + E68D3 - 48 8B 8C C7 78200200 - mov rcx,[rdi+rax * 8 + 00022078]
             * 
             */

        }
    }
}
