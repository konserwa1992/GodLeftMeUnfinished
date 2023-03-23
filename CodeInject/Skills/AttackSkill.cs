using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Skills
{
    class AttackSkill : ISkill
    {
        public int ID { get; set ; }
        public float CoolDown { get; set; }
        public float Name { get; set; }

        public AttackSkill(int id)
        {
            this.ID = id;
        }
    }
}
