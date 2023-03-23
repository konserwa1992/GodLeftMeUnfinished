using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInject.Skills
{
    interface ISkill
    {
        int ID { get; set; }
        float CoolDown { get; set; }
        float Name { get; set; }
    }
}
