using CodeInject.NPC;
using CodeInject.Skills;
using Hook_test_lib;
using Reloaded.Hooks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CodeInject.GameMethods;
using static Reloaded.Memory.Sources.MemoryExtensions;

namespace CodeInject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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



        private void button3_Click(object sender, EventArgs e)
        {
       
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


        private void button1_Click_1(object sender, EventArgs e)
        {
            FileName.oryginalnaFunkcja();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FileName.hook();
          //  GameMethods.AttachHook();
        }
    }
}
