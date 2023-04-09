using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Commands
{
    class AttackCommand
    {
        public ushort TargetID;
        public ushort SkillID;

        public unsafe void Execute()
        {
            byte[] packetStartStruct = new byte[] { 0x0A, 0x00, 0xB3, 0x07, 0xD1, 0x58 };
            byte[] target = BitConverter.GetBytes(TargetID);
            byte[] skill = BitConverter.GetBytes(SkillID);



            int length = packetStartStruct.Length + target.Length + skill.Length;
            byte[] result = new byte[length];

            int offset = 0;
            Array.Copy(packetStartStruct, 0, result, offset, packetStartStruct.Length);
            offset += packetStartStruct.Length;
            Array.Copy(target, 0, result, offset, target.Length);
            offset += target.Length;
            Array.Copy(skill, 0, result, offset, skill.Length);



            fixed (byte* pointer = result) 
            {
                GameMethods.SendPacketToServer((short*)pointer);
            }
        }

    }
}
