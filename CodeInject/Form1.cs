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

        public Form1()
        {
            InitializeComponent();
           // = false;
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
                Marshal.Copy(cds.lpData, data, 0, cds.cbData);


                GameMethods.SendPacket(data);
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
            GameMethods.SendPacket(new byte[] { 0x12, 0x00, 0x9A, 0x07, 0xD1, 0x58, 0x00, 0x00, 0xCD, 0x64, 0x03, 0x49, 0xF5, 0x7E, 0x01, 0x49, 0x5E, 0xFE, 0x41, 0x41, 0x41 });
        }
    }
}
