
namespace CodeInject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tOffset = new System.Windows.Forms.TextBox();
            this.cTypeConvert = new System.Windows.Forms.ComboBox();
            this.tTestByteArray = new System.Windows.Forms.TextBox();
            this.lOutPutConvert = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListView();
            this.lPacketCount = new System.Windows.Forms.Label();
            this.lPacketCountLabel = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bSkillListRefresh = new System.Windows.Forms.Button();
            this.lSkillList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lSkillToUse = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bAddSkillToUse = new System.Windows.Forms.Button();
            this.bRemoveSkillToUse = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 757);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tOffset);
            this.tabPage1.Controls.Add(this.cTypeConvert);
            this.tabPage1.Controls.Add(this.tTestByteArray);
            this.tabPage1.Controls.Add(this.lOutPutConvert);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.lPacketCount);
            this.tabPage1.Controls.Add(this.lPacketCountLabel);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(669, 731);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Packets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tOffset
            // 
            this.tOffset.Location = new System.Drawing.Point(609, 35);
            this.tOffset.Name = "tOffset";
            this.tOffset.Size = new System.Drawing.Size(36, 20);
            this.tOffset.TabIndex = 28;
            // 
            // cTypeConvert
            // 
            this.cTypeConvert.FormattingEnabled = true;
            this.cTypeConvert.Items.AddRange(new object[] {
            "Float",
            "Double",
            "Short",
            "Int32"});
            this.cTypeConvert.Location = new System.Drawing.Point(351, 61);
            this.cTypeConvert.Name = "cTypeConvert";
            this.cTypeConvert.Size = new System.Drawing.Size(252, 21);
            this.cTypeConvert.TabIndex = 27;
            // 
            // tTestByteArray
            // 
            this.tTestByteArray.Location = new System.Drawing.Point(351, 35);
            this.tTestByteArray.Name = "tTestByteArray";
            this.tTestByteArray.Size = new System.Drawing.Size(252, 20);
            this.tTestByteArray.TabIndex = 26;
            // 
            // lOutPutConvert
            // 
            this.lOutPutConvert.AutoSize = true;
            this.lOutPutConvert.Location = new System.Drawing.Point(348, 85);
            this.lOutPutConvert.Name = "lOutPutConvert";
            this.lOutPutConvert.Size = new System.Drawing.Size(35, 13);
            this.lOutPutConvert.TabIndex = 25;
            this.lOutPutConvert.Text = "label1";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(351, 101);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(186, 25);
            this.button6.TabIndex = 24;
            this.button6.Text = "Convert";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 128);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(285, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listBox1
            // 
            this.listBox1.FullRowSelect = true;
            this.listBox1.GridLines = true;
            this.listBox1.HideSelection = false;
            this.listBox1.Location = new System.Drawing.Point(8, 163);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(652, 333);
            this.listBox1.TabIndex = 22;
            this.listBox1.UseCompatibleStateImageBehavior = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // lPacketCount
            // 
            this.lPacketCount.AutoSize = true;
            this.lPacketCount.Location = new System.Drawing.Point(645, 147);
            this.lPacketCount.Name = "lPacketCount";
            this.lPacketCount.Size = new System.Drawing.Size(13, 13);
            this.lPacketCount.TabIndex = 21;
            this.lPacketCount.Text = "0";
            // 
            // lPacketCountLabel
            // 
            this.lPacketCountLabel.AutoSize = true;
            this.lPacketCountLabel.Location = new System.Drawing.Point(564, 147);
            this.lPacketCountLabel.Name = "lPacketCountLabel";
            this.lPacketCountLabel.Size = new System.Drawing.Size(75, 13);
            this.lPacketCountLabel.TabIndex = 20;
            this.lPacketCountLabel.Text = "Packet Count:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(336, 502);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(324, 194);
            this.richTextBox2.TabIndex = 19;
            this.richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 502);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(324, 194);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(285, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Record";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 32);
            this.button2.TabIndex = 14;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(669, 731);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Monsters";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 702);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Attack";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 702);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(660, 693);
            this.listBox2.TabIndex = 0;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bRemoveSkillToUse);
            this.tabPage3.Controls.Add(this.bAddSkillToUse);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.lSkillToUse);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.lSkillList);
            this.tabPage3.Controls.Add(this.bSkillListRefresh);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(669, 731);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Skills";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bSkillListRefresh
            // 
            this.bSkillListRefresh.Location = new System.Drawing.Point(7, 699);
            this.bSkillListRefresh.Name = "bSkillListRefresh";
            this.bSkillListRefresh.Size = new System.Drawing.Size(120, 23);
            this.bSkillListRefresh.TabIndex = 0;
            this.bSkillListRefresh.Text = "Refresh";
            this.bSkillListRefresh.UseVisualStyleBackColor = true;
            this.bSkillListRefresh.Click += new System.EventHandler(this.button7_Click);
            // 
            // lSkillList
            // 
            this.lSkillList.FormattingEnabled = true;
            this.lSkillList.Location = new System.Drawing.Point(7, 26);
            this.lSkillList.Name = "lSkillList";
            this.lSkillList.Size = new System.Drawing.Size(120, 303);
            this.lSkillList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Skill";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(669, 731);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Hunt";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lSkillToUse
            // 
            this.lSkillToUse.FormattingEnabled = true;
            this.lSkillToUse.Location = new System.Drawing.Point(157, 26);
            this.lSkillToUse.Name = "lSkillToUse";
            this.lSkillToUse.Size = new System.Drawing.Size(120, 147);
            this.lSkillToUse.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Use";
            // 
            // bAddSkillToUse
            // 
            this.bAddSkillToUse.Location = new System.Drawing.Point(133, 60);
            this.bAddSkillToUse.Name = "bAddSkillToUse";
            this.bAddSkillToUse.Size = new System.Drawing.Size(18, 23);
            this.bAddSkillToUse.TabIndex = 5;
            this.bAddSkillToUse.Text = ">";
            this.bAddSkillToUse.UseVisualStyleBackColor = true;
            this.bAddSkillToUse.Click += new System.EventHandler(this.bAddSkillToUse_Click);
            // 
            // bRemoveSkillToUse
            // 
            this.bRemoveSkillToUse.Location = new System.Drawing.Point(133, 89);
            this.bRemoveSkillToUse.Name = "bRemoveSkillToUse";
            this.bRemoveSkillToUse.Size = new System.Drawing.Size(18, 23);
            this.bRemoveSkillToUse.TabIndex = 6;
            this.bRemoveSkillToUse.Text = "<";
            this.bRemoveSkillToUse.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.bRemoveSkillToUse.UseVisualStyleBackColor = true;
            this.bRemoveSkillToUse.Click += new System.EventHandler(this.bRemoveSkillToUse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 758);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Packet Injector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listBox1;
        private System.Windows.Forms.Label lPacketCount;
        private System.Windows.Forms.Label lPacketCountLabel;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox cTypeConvert;
        private System.Windows.Forms.TextBox tTestByteArray;
        private System.Windows.Forms.Label lOutPutConvert;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox tOffset;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bSkillListRefresh;
        private System.Windows.Forms.ListBox lSkillList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lSkillToUse;
        private System.Windows.Forms.Button bRemoveSkillToUse;
        private System.Windows.Forms.Button bAddSkillToUse;
    }
}