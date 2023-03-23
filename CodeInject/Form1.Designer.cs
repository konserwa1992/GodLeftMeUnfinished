
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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lNpcID = new System.Windows.Forms.Label();
            this.lNpcPosition = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lPlayerID = new System.Windows.Forms.Label();
            this.lPlayerPosition = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lSkillList = new System.Windows.Forms.ListBox();
            this.bRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(524, 447);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(516, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Game Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lNpcID);
            this.groupBox3.Controls.Add(this.lNpcPosition);
            this.groupBox3.Location = new System.Drawing.Point(166, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 125);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NPC/Other Player";
            // 
            // lNpcID
            // 
            this.lNpcID.AutoSize = true;
            this.lNpcID.Location = new System.Drawing.Point(6, 15);
            this.lNpcID.Name = "lNpcID";
            this.lNpcID.Size = new System.Drawing.Size(21, 13);
            this.lNpcID.TabIndex = 1;
            this.lNpcID.Text = "ID:";
            // 
            // lNpcPosition
            // 
            this.lNpcPosition.AutoSize = true;
            this.lNpcPosition.Location = new System.Drawing.Point(6, 44);
            this.lNpcPosition.Name = "lNpcPosition";
            this.lNpcPosition.Size = new System.Drawing.Size(50, 13);
            this.lNpcPosition.TabIndex = 0;
            this.lNpcPosition.Text = "Position: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lPlayerID);
            this.groupBox2.Controls.Add(this.lPlayerPosition);
            this.groupBox2.Location = new System.Drawing.Point(166, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 119);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hero";
            // 
            // lPlayerID
            // 
            this.lPlayerID.AutoSize = true;
            this.lPlayerID.Location = new System.Drawing.Point(6, 16);
            this.lPlayerID.Name = "lPlayerID";
            this.lPlayerID.Size = new System.Drawing.Size(21, 13);
            this.lPlayerID.TabIndex = 2;
            this.lPlayerID.Text = "ID:";
            // 
            // lPlayerPosition
            // 
            this.lPlayerPosition.AutoSize = true;
            this.lPlayerPosition.Location = new System.Drawing.Point(6, 38);
            this.lPlayerPosition.Name = "lPlayerPosition";
            this.lPlayerPosition.Size = new System.Drawing.Size(50, 13);
            this.lPlayerPosition.TabIndex = 0;
            this.lPlayerPosition.Text = "Position: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 250);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actor Lists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 147);
            this.listBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lSkillList);
            this.tabPage2.Controls.Add(this.bRefresh);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(516, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Skills";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lSkillList
            // 
            this.lSkillList.FormattingEnabled = true;
            this.lSkillList.Location = new System.Drawing.Point(6, 6);
            this.lSkillList.Name = "lSkillList";
            this.lSkillList.Size = new System.Drawing.Size(120, 342);
            this.lSkillList.TabIndex = 1;
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(6, 354);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(120, 52);
            this.bRefresh.TabIndex = 0;
            this.bRefresh.Text = "Refresh Skill List";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 460);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lNpcID;
        private System.Windows.Forms.Label lNpcPosition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lPlayerID;
        private System.Windows.Forms.Label lPlayerPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.ListBox lSkillList;
    }
}