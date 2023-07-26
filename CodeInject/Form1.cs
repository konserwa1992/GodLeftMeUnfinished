using CodeInject.NPC;
using CodeInject.Packet;
using CodeInject.Packet.Packet_Events;
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
using System.Timers;
using CodeInject.Commands;
using System.IO;
using CodeInject.GameData;
using CodeInject.Player;
using System.Diagnostics.Eventing.Reader;
using CodeInject.BotFeatures;
using System.Security.Cryptography;

namespace CodeInject
{
    public partial class Form1 : Form
    {
        AutoPotion autopot;


        public Form1()
        {
            InitializeComponent();
            PacketParserManager.Instance.NewPacketArrived += AddNewPacketToList;
            autopot = new AutoPotion();
        }

        public struct PACKETDATASTRUCTURE
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }


        protected unsafe override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x004A && m.WParam == (IntPtr)0x100) 
            {

                PACKETDATASTRUCTURE cds = (PACKETDATASTRUCTURE)m.GetLParam(typeof(PACKETDATASTRUCTURE));
                byte[] data = new byte[cds.cbData];




                string hexString = "";
                Marshal.Copy(cds.lpData, data, 0, cds.cbData);

                foreach (byte zm in data)
                    hexString += (char)zm;

                /*byte[] byteArray = Enumerable.Range(0, hexString.Length)
                                     .Where(x => x % 2 == 0)
                                     .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                                     .ToArray();*/


                byte[] byteArray = new byte[hexString.Length / 2];

                for (int i = 0; i < byteArray.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }

                fixed (byte* pointer = byteArray)
                {
                    IntPtr p = new IntPtr(pointer);
                    GameMethods.SendPacketToServer((short*)p.ToPointer());
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private unsafe void button2_Click(object sender, EventArgs e)
        {
            string hexString = textBox1.Text;
            byte[] byteArray = new byte[hexString.Length / 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            fixed (byte* pointer = byteArray)
            {
                IntPtr p = new IntPtr(pointer);
                GameMethods.SendPacketToServer((short*)p.ToPointer());
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            PacketParserManager.Instance.Record = !PacketParserManager.Instance.Record;

            if (PacketParserManager.Instance.Record)
            {
                listBox1.Items.Clear();
                PacketParserManager.Instance.PacketList.Clear();
            }
        }


        private void AddNewPacketToList(object parent, EventArgs e)
        {
            if (PacketParserManager.Instance.Record == true)
            {
                lPacketCount.Text = PacketParserManager.Instance.PacketList.Count.ToString();
                PacketArgs packet = (PacketArgs)e;
                string packetBytesToString = "";
                for (int i = 0; i < packet.Packet.PacketSize; i++)
                    packetBytesToString += packet.Packet.Packet[i].ToString("X2") + " ";


                ListViewItem newItem = listBox1.Items.Add(packetBytesToString);

                if (packet.Packet.PacketType == PacketTypes.InComing)
                    newItem.BackColor = Color.CadetBlue;
                else
                    newItem.BackColor = Color.LightGreen;
            }
        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                richTextBox1.Text = listBox1.SelectedItems[0].Text;
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(' '));

                textBox1.Text = richTextBox1.Text.Replace(" ","");

                string[] bytesFromText = richTextBox1.Text.Split(' ');
                richTextBox2.Text = "";
                foreach (string singlebyte in bytesFromText)
                {
                    if (singlebyte != "" && singlebyte != " ")
                    {
                        byte _byte = byte.Parse(singlebyte, System.Globalization.NumberStyles.HexNumber);

                        if (_byte == 0x00 || _byte == 0x0D || _byte == 0x0A)
                        {
                            richTextBox2.Text += ". ";
                        }
                        else
                        {
                            richTextBox2.Text += Convert.ToChar(_byte) + " ";
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach(INPC npc in PacketParserManager.Instance.npcList)
            {
                listBox2.Items.Add(npc.ID);
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter _stream = new StreamWriter(DateTime.Now.Ticks+".txt");

            foreach(var item in listBox1.Items)
            {
                _stream.WriteLine(item.ToString());
            }

            _stream.Flush();
            _stream.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            foreach(var item in PlayerCharacter.PotionInUse.PotionInUseList)
            {
                listBox4.Items.Add(item.Item.ItemInformation.Name);
            }

            listBox2.Items.Clear();

            foreach (INPC npc in PacketParserManager.Instance.npcList)
            {
                listBox2.Items.Add(GameInfoList.GetNameMonsterByID(npc.NPCModelNameID) + " ID:" + npc.ID.ToString() + " POS:"+ npc.Position.ToString() + " Hostile: "+npc.isHostile);
            }


            if(listBox3.Items.Count == 0 && PlayerCharacter.PlayerInventory.Items.Count!=0)
            {
                foreach(Inventory.Item item in PlayerCharacter.PlayerInventory.Items)
                {
                        if(item.Type == 0x0A)
                        listBox3.Items.Add($"{item.Type.ToString("X")} {item.Count} {GameInfoList.GetUseItemByID((int)item.ObjectModelID).Name}");
                    else
                        listBox3.Items.Add($"{item.Type.ToString("X")} {item.Count} {item.ObjectModelID}");
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
     
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // AttackCommand command = new AttackCommand()
            // {
            //     TargetID = PacketParserManager.Instance.npcList[listBox2.SelectedIndex].ID,
            //     SkillID = 0x1
            //  };


            selected = PacketParserManager.Instance.npcList[listBox2.SelectedIndex];
          // command.Execute();
        }

        INPC selected=null;
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            autopot.Update();

       //     PlayerCharacter.Position= new Vector3(GameMethods.GetFloat(GameMethods.GetInt64(GameMethods.GetBaseAdress()+0x111AD80,new short[] { 0x0,0x80,0x20,0x1c4 })),
          //      GameMethods.GetFloat(GameMethods.GetInt64(GameMethods.GetBaseAdress() + 0x111AD80, new short[] { 0x0, 0x80, 0x20, 0x1c4 })+0x4),0);

          //  label3.Text = PlayerCharacter.Position.ToString();


            if (selected != null && PacketParserManager.Instance.npcList.FirstOrDefault(x=>x.ID==selected.ID)!=null)
            {
                AttackCommand command = new AttackCommand()
                {
                    TargetID = selected.ID,
                    SkillID = (ushort)(lSkillList.Items.IndexOf(lSkillToUse.Items[new Random().Next(lSkillToUse.Items.Count)]))
                };

                command.Execute();
            }else
            {
                if (PacketParserManager.Instance.npcList.Count != 0)
                {
                    selected = PacketParserManager.Instance.npcList.OrderBy(x=>Vector3.Distance(x.Position,PlayerCharacter.Position)).FirstOrDefault(x=>x.isHostile==true || 1==1);
                    //  selected = PacketParserManager.Instance.npcList[(new Random().Next(PacketParserManager.Instance.npcList.Count))];
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string packet = tTestByteArray.Text.Replace(" ", "");

            switch(cTypeConvert.SelectedIndex)
            {
                case 0:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToSingle(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }
                case 1:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToDouble(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }
                case 2:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToInt16(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }

                case 3:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToInt32(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }

                case 4:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToUInt32(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }

                case 5:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToUInt64(byteArray, int.Parse(tOffset.Text)).ToString();
                        break;
                    }
                case 6:
                    {

                        byte[] byteArray = new byte[packet.Length / 2];
                        for (int i = 0; i < byteArray.Length; i++)
                        {
                            byteArray[i] = Convert.ToByte(packet.Substring(i * 2, 2), 16);
                        }

                        lOutPutConvert.Text = BitConverter.ToUInt16(byteArray, int.Parse(tOffset.Text)).ToString();

                        lOutPutConvert.Text += " Monster found: " + PacketParserManager.Instance.npcList.Any(x => x.ID == BitConverter.ToUInt16(byteArray, int.Parse(tOffset.Text)));
                        break;
                    }
            }

   
        }

        private unsafe void button7_Click(object sender, EventArgs e)
        {
            lSkillList.Items.Clear();

    
            ulong* adrPtr1 = (ulong*)(new UIntPtr(GameMethods.GetBaseAdress() + 0x1118E90).ToPointer());
            // UIntPtr uIntPtr = new UIntPtr((ulong*)adrPtr1);

            int i = 0;
            while (GameMethods.GetShort(*adrPtr1 + ((ulong)i * 2) + 0x50 + 0xCD0) != 0)
            {
                lSkillList.Items.Add(GameInfoList.GetNameSkillByID(GameMethods.GetShort(*adrPtr1 + ((ulong)i * 2) + 0x50 + 0xCD0)));
                i++;
            }
        }

        private void bAddSkillToUse_Click(object sender, EventArgs e)
        {
            if(lSkillList.SelectedItem != null && !lSkillToUse.Items.Contains(lSkillList.SelectedItem)) lSkillToUse.Items.Add(lSkillList.SelectedItem);
        }

        private void bRemoveSkillToUse_Click(object sender, EventArgs e)
        {
            if (lSkillToUse.SelectedItem != null) lSkillToUse.Items.Remove(lSkillToUse.SelectedItem);
        }

        private void bStartHunt_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
        }

        private void bRemoveRegEx_Click(object sender, EventArgs e)
        {
            string itemToRemove = lIgnoreRegExList.Text;
            GameMethods.IgnorePacketRegexList.Remove(GameMethods.IgnorePacketRegexList.FirstOrDefault(x => x == itemToRemove));
            lIgnoreRegExList.Items.Remove(lIgnoreRegExList.SelectedItem);
        }

        private void bAddRegExIgnore_Click(object sender, EventArgs e)
        {
            lIgnoreRegExList.Items.Add(textBox2.Text);
            GameMethods.IgnorePacketRegexList.Add(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tOffset.Text = (int.Parse(tOffset.Text)+1).ToString();
            button6.PerformClick();
        }

        private unsafe void button7_Click_1(object sender, EventArgs e)
        {
            Inventory.Item utemToUse = PlayerCharacter.PlayerInventory.Items.FirstOrDefault(x => x.ItemInformation != null && x.ItemInformation.UseName.ToUpper().Contains("HP"));
            UseItem useItem = new UseItem(utemToUse);
            useItem.Execute();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Inventory.Item utemToUse = PlayerCharacter.PlayerInventory.Items[listBox3.SelectedIndex];
            UseItem useItem = new UseItem(utemToUse);
            useItem.Execute();
        }
    }
}
