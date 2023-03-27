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


namespace CodeInject
{
    public partial class Form1 : Form
    {
        PacketParserCommander PacketCommander = new PacketParserCommander();
        private  System.Timers.Timer recivePacketTimer;

        private  void SetTimer()
        {
            // Create a timer with a two second interval.
            recivePacketTimer = new System.Timers.Timer(10);
            // Hook up the Elapsed event for the timer. 
            recivePacketTimer.Elapsed += OnPacketChangeTick;
            recivePacketTimer.AutoReset = true;
            recivePacketTimer.Enabled = true;
        }

        private  void OnPacketChangeTick(Object source, ElapsedEventArgs e)
        {
            PacketCommander.ChechIfNewPacketArrived();
            lPacketCount.Text = PacketCommander.PacketList.Count.ToString();
            label1.Text = GameMethods.GetInt64(GameMethods.GetBaseAdress() + (ulong)0x0112FE60, new short[] { 0x00, 0x00, 0x28, 0x08, 0x2d8 }).ToString("X");
        }

        public Form1()
        {
            InitializeComponent();
            PacketCommander.NewPacketArrived += AddNewPacketToList;
            SetTimer();
        }

        public struct PACKETDATASTRUCTURE
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }


        protected override void WndProc(ref Message m)
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

                MessageBox.Show(hexString);
                for (int i = 0; i < byteArray.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                }

                GameMethods.SendPacket(byteArray);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hexString = textBox1.Text;
            byte[] byteArray = new byte[hexString.Length / 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            GameMethods.SendPacket(byteArray);
            //  GameMethods.SendPacket(new byte[] { 0x08, 0x00, 0x98, 0x07, 0xD1, 0x58, 0x95, 0x80, 0xD6 });
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PacketCommander.Record = !PacketCommander.Record;
        }


        private void AddNewPacketToList(object parent, EventArgs e)
        {
            if (PacketCommander.Record == true)
            {
                PacketArgs packet = (PacketArgs)e;
                string packetBytesToString = "";
                for (int i = 0; i < packet.Packet.PacketSize; i++)
                    packetBytesToString += packet.Packet.Packet[i].ToString("X2") + " ";

                listBox1.Items.Add(packetBytesToString);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("asdsad");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;


            richTextBox1.Text = listBox1.SelectedItem.ToString();
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.LastIndexOf(' '));

            string[] bytesFromText = richTextBox1.Text.Split(' ');
            richTextBox2.Text = "";
            foreach (string singlebyte in bytesFromText)
            {
                if (singlebyte != "" && singlebyte != " ")
                {
                    byte _byte = byte.Parse(singlebyte, System.Globalization.NumberStyles.HexNumber);

                    if(_byte == 0x00 || _byte == 0x0D || _byte == 0x0A)
                    {
                        richTextBox2.Text += ". ";
                    }else
                    {
                        richTextBox2.Text += Convert.ToChar(_byte) + " ";
                    }
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

 
    }
}
