using CodeInject.NPC;
using CodeInject.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject
{
    public partial class Form1 : Form
    {
        INPC selectedMonster ;
        PlayerCharacter player;
        List<INPC> MonsterList = new List<INPC>();

        List<ISkill> SkillList = new List<ISkill>();


        public Form1()
        {
            InitializeComponent();
            RefreshMonstersListBox();


            RefreshMonstersList();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerAdrr">First element of NPC list</param>
        void LoadPlayerInformation(ulong playerAdrr)
        {
            if (player == null)
            {
                player = new PlayerCharacter(GameMethods.GetInt32(playerAdrr));
            }
            player.Update();
        }

        public void RefreshMonstersListBox()
        {
            listBox1.Items.Clear();

            ulong MonsterListAdr = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C8410);
            MonsterListAdr = GameMethods.GetInt64(MonsterListAdr + 0x22050);

            MonsterListAdr += 0x4;
            int monsterIndex = 0;

            while ((monsterIndex = GameMethods.GetInt32(MonsterListAdr)) != 0)
            {
                listBox1.Items.Add(GameMethods.GetInt32(MonsterListAdr));
                MonsterListAdr += 0x4;
            }

            label2.Text = $"Monster Count:{MonsterList.Count}";
        }

        public void RefreshMonstersList()
        {
            if (MonsterList.Count > 0)
                MonsterList.RemoveRange(0, MonsterList.Count);

            ulong MonsterListAdr = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C8410);
            MonsterListAdr = GameMethods.GetInt64(MonsterListAdr + 0x22050);
            LoadPlayerInformation(MonsterListAdr);

            MonsterListAdr += 0x4;
            int monsterIndex = 0;

            while ((monsterIndex = GameMethods.GetInt32(MonsterListAdr)) != 0)
            {
                Monster mob = new Monster(GameMethods.GetInt32(MonsterListAdr));
                mob.Update();

                MonsterList.Add(mob);

                MonsterListAdr += 0x4;
            }

            label2.Text = $"NPC Count:{MonsterList.Count}";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
            timer1.Enabled = !timer1.Enabled;


            button2.Text = timer2.Enabled == true ? "Stop" : "Start";

            selectedMonster = null;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (selectedMonster != null)
            {
                Random rand = new Random();
                GameMethods.AttackTarget((uint)rand.Next(0x210, 0x212), (uint)selectedMonster.ID);
            }
            // label1.Text = $"{selectedMonster} {isAlive} Distance:{Vector2.Distance(MonsterList.FirstOrDefault(x=>x.ID==int.Parse(selectedMonster)).Position, player.Position)}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshMonstersListBox();
            RefreshMonstersList();
            if (listBox1.Items == null)
                return;




            bool isAlive = false;

            if (selectedMonster != null)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == selectedMonster.ID.ToString())
                    {
                        isAlive = true;
                        break;
                    }
                }
            }


            if (!isAlive || selectedMonster == null)
            {
                Random skillRandomizer = new Random();
                INPC closestMonster = MonsterList.OrderBy(x => Vector3.Distance(x.Position, player.Position)).FirstOrDefault();
                selectedMonster = closestMonster;
                Logger.Logger.Log($"New Attack Target: {selectedMonster}");
                GameMethods.AttackTarget((uint)skillRandomizer.Next(0x210, 0x212), (uint)selectedMonster.ID);
            }

     

            lPlayerPosition.Text = $"Position: {player.Position.ToString()}";
            lPlayerID.Text = $"Position: {player.ID}";

            lNpcID.Text = $"ID: {selectedMonster.ID}";
            lNpcPosition.Text = $"Position: {selectedMonster.Position}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SkillList.RemoveRange(0, SkillList.Count);
            lSkillList.Items.Clear();


       //     MessageBox.Show((GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C5530, new short[] { 0x57c8 }) + ((ulong)0x211 * 8) + 0x18).ToString("X"));

            //maybe i should start loop form 0x8f 
            for (int i = 0; i < 0x24B; i++)
            {
                UInt64 pSkillAddr = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C5530, new short[] { 0x57c8 }) + ((ulong)i * 8) + 0x18;
                pSkillAddr = GameMethods.GetInt64(pSkillAddr);
                if (pSkillAddr != 0)//check if pointer have any addres
                {
                    AttackSkill _temp = new AttackSkill(GameMethods.GetInt32(pSkillAddr + (ulong)0x38));
                    _temp.CoolDown = GameMethods.GetInt32(pSkillAddr + (ulong)0x30);
                    SkillList.Add(_temp);
                    lSkillList.Items.Add(_temp.ID.ToString("X"));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(((GameMethods.GetBaseAdress() + 0x10CF390) + 0x000016D8 + 0x320).ToString("X"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameMethods.SendPacket(new byte[] { 0x12, 0x00, 0x9A, 0x07, 0xD1, 0x58, 0x00, 0x00, 0xCD, 0x64, 0x03, 0x49, 0xF5, 0x7E, 0x01, 0x49, 0x5E, 0xFE, 0x41, 0x41, 0x41 });
        }
    }
}
