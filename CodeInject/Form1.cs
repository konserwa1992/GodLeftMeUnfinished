using CodeInject.NPC;
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
        string selectedMonster = "";
        PlayerCharacter player;
        List<Monster> MonsterList = new List<Monster>();



        public Form1()
        {
            InitializeComponent();
            RefreshMonsters();
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

        public void RefreshMonsters()
        {
            listBox1.Items.Clear();
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
                listBox1.Items.Add(mob.ID.ToString());
                MonsterList.Add(mob);

                MonsterListAdr += 0x4;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;

            button2.Text = timer2.Enabled == true ? "Stop" : "Start";
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            RefreshMonsters();
            if (listBox1.Items == null)
                return;

            bool isAlive = false; 


            for(int i=0;i<listBox1.Items.Count;i++)
            {
                if (listBox1.Items[i].ToString() == selectedMonster)
                {
                    isAlive = true;
                    break;
                }
            }

            if (isAlive)
            {
                Random rand = new Random();
                GameMethods.AttackTarget((uint)rand.Next(0x210, 0x212), uint.Parse(selectedMonster));
            }
            else
            {
                Random skillRandomizer = new Random();
                Monster closestMonster = MonsterList.OrderBy(x => Vector2.Distance(x.Position, player.Position)).FirstOrDefault();
                selectedMonster = closestMonster.ID.ToString();
                GameMethods.AttackTarget((uint)skillRandomizer.Next(0x210, 0x212), uint.Parse(selectedMonster));
            }


            label1.Text = $"{selectedMonster} {isAlive} Distance:{Vector2.Distance(MonsterList.FirstOrDefault(x=>x.ID==int.Parse(selectedMonster)).Position, player.Position)}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monster monster = new Monster(int.Parse(selectedMonster));
            monster.Update();
            MessageBox.Show($"{monster.Position.X} {monster.Position.Y} ");
        }
    }
}
