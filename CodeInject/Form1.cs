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

namespace CodeInject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PacketParserManager.Instance.NewPacketArrived += AddNewPacketToList;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("asdsad");
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

        private void button4_Click(object sender, EventArgs e)
        {
            AttackCommand command = new AttackCommand()
            {
                TargetID = ushort.Parse(listBox2.SelectedItem.ToString()),
                SkillID = 0x210
            };

            command.Execute();
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
    }
}
