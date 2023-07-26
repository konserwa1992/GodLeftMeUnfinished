using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodeInject.Player.Inventory;

namespace CodeInject.Player
{
    class PotionBuff
    {
        public short ID { get; set; } = 0;
        public Item Item { get; set; }
    }

    class PotionBuffs
    {
        public List<PotionBuff> PotionInUseList = new List<PotionBuff>();
    }
}
