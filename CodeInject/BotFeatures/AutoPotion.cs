using CodeInject.Commands;
using CodeInject.GameData;
using CodeInject.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject.BotFeatures
{
    class AutoPotion
    {
        public bool AutoHP { get; set; } = true;
        public bool AutoMP { get; set; }

        public float MinHpProcentage { get; set; } = 50.0f;
        public float MinMpProcentage { get; set; } = 50.0f;


        Timer MpPotionWatch { get; set; } = new Timer();
        Timer HpPotionWatch { get; set; } = new Timer();


        public unsafe AutoPotion()
        {
            PlayerCharacter.InitHpData();
            MpPotionWatch.Tick += new EventHandler( delegate
            {
                int mp = *PlayerCharacter.MP;
                int maxmp = *PlayerCharacter.MaxMP;

                if (AutoHP && MinMpProcentage > (((float)mp / (float)maxmp) * 100f))
                {
                    Inventory.Item utemToUse = PlayerCharacter.PlayerInventory.Items.FirstOrDefault(x => x.ItemInformation != null && x.ItemInformation.UseName.ToUpper().Contains("HP"));
                    UseItem useItem = new UseItem(utemToUse);
                    useItem.Execute();
                    MpPotionWatch.Interval = 21000;
                }
                else
                {
                    MpPotionWatch.Stop();
                }
            });


            HpPotionWatch.Tick += new EventHandler(delegate
            {
                int hp = *PlayerCharacter.HP;
                int maxhp = *PlayerCharacter.MaxHP;

                if (AutoHP && MinHpProcentage > (((float)hp / (float)maxhp) * 100f))
                {
                    Inventory.Item utemToUse = PlayerCharacter.PlayerInventory.Items.FirstOrDefault(x => x.ItemInformation != null && x.ItemInformation.UseName.ToUpper().Contains("MP"));
                    UseItem useItem = new UseItem(utemToUse);
                    useItem.Execute();

                    HpPotionWatch.Interval = 21000;
                }
                else
                {
                    HpPotionWatch.Stop();
                }
            });
        }

        public unsafe void Update()
        {
            PlayerCharacter.InitHpData();
            int hp = *PlayerCharacter.HP;
            int maxhp = *PlayerCharacter.MaxHP;
            int mp = *PlayerCharacter.MP;
            int maxmp = *PlayerCharacter.MaxMP;

            if (AutoHP && MinHpProcentage > (((float)hp / (float)maxhp) * 100f))
            {

                if (HpPotionWatch.Enabled == false)
                {
                    HpPotionWatch.Interval = 1;
                    HpPotionWatch.Start();
                }
            }

            if (AutoHP && MinMpProcentage > (((float)mp / (float)maxmp) * 100f))
            {
                if (MpPotionWatch.Enabled == false)
                {
                    MpPotionWatch.Interval = 1;
                    MpPotionWatch.Start();
                }
            }
        }
    }
}
