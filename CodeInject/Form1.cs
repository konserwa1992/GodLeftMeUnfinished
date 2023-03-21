using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeInject
{
    public partial class Form1 : Form
    {
        string selectedMonster = "";
        public Form1()
        {
            InitializeComponent();
            RefreshMonsters();
        }


        public void RefreshMonsters()
        {
            listBox1.Items.Clear();
            
            ulong MonsterListAdr = GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x10C8410);
            MonsterListAdr = GameMethods.GetInt64(MonsterListAdr + 0x22050);
            MonsterListAdr += 0x4;
            int monsterIndex = 1;
            while ((monsterIndex = GameMethods.GetInt32(MonsterListAdr)) != 0)
            {
                listBox1.Items.Add(monsterIndex);
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
                Random rand = new Random();
                selectedMonster =  listBox1.Items[rand.Next(0, listBox1.Items.Count - 1)].ToString();
                GameMethods.AttackTarget((uint)rand.Next(0x210, 0x212), uint.Parse(selectedMonster));
            }


            label1.Text = selectedMonster + " "+isAlive;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
