namespace CPUSchedulerProject {
    partial class MainForm {
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CPUlabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CurrentJobLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.SpeedTB = new System.Windows.Forms.TrackBar();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.AlorithmCombo = new System.Windows.Forms.ComboBox();
            this.numProcess = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.JobPool = new System.Windows.Forms.DataGridView();
            this.Arrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Burst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.TurnaroundLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.WaitingLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTB)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobPool)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(10, 470);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 160);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.gantt_chart__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SeaGreen;
            this.label10.Location = new System.Drawing.Point(45, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "GANTT CHART";
            this.label10.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.pictureBox4);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Location = new System.Drawing.Point(320, 320);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(300, 140);
            this.panel7.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.queue;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(15, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(45, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "READY QUEUE";
            this.label8.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.CPUlabel);
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.CurrentTimeLabel);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.CurrentJobLabel);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(10, 320);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 140);
            this.panel6.TabIndex = 1;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.processor;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(15, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // CPUlabel
            // 
            this.CPUlabel.AutoSize = true;
            this.CPUlabel.BackColor = System.Drawing.Color.Transparent;
            this.CPUlabel.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPUlabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CPUlabel.Location = new System.Drawing.Point(210, 100);
            this.CPUlabel.Name = "CPUlabel";
            this.CPUlabel.Size = new System.Drawing.Size(40, 24);
            this.CPUlabel.TabIndex = 0;
            this.CPUlabel.Text = "0%";
            this.CPUlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CPUlabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(210, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Utilization";
            this.label13.Click += new System.EventHandler(this.label5_Click);
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentTimeLabel.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(108, 100);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(23, 24);
            this.CurrentTimeLabel.TabIndex = 0;
            this.CurrentTimeLabel.Text = "0";
            this.CurrentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentTimeLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(108, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Current Time";
            // 
            // CurrentJobLabel
            // 
            this.CurrentJobLabel.AutoSize = true;
            this.CurrentJobLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentJobLabel.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentJobLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CurrentJobLabel.Location = new System.Drawing.Point(15, 100);
            this.CurrentJobLabel.Name = "CurrentJobLabel";
            this.CurrentJobLabel.Size = new System.Drawing.Size(67, 24);
            this.CurrentJobLabel.TabIndex = 0;
            this.CurrentJobLabel.Text = "Job 0";
            this.CurrentJobLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentJobLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(15, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Current Job";
            this.label11.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(45, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 27);
            this.label7.TabIndex = 0;
            this.label7.Text = "CPU";
            this.label7.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MintCream;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.pictureBox6);
            this.panel4.Controls.Add(this.SpeedTB);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Controls.Add(this.AlorithmCombo);
            this.panel4.Controls.Add(this.numProcess);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 300);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.folder;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(15, 15);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 25);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // SpeedTB
            // 
            this.SpeedTB.BackColor = System.Drawing.Color.Teal;
            this.SpeedTB.LargeChange = 200;
            this.SpeedTB.Location = new System.Drawing.Point(115, 130);
            this.SpeedTB.Maximum = 1000;
            this.SpeedTB.Minimum = 100;
            this.SpeedTB.Name = "SpeedTB";
            this.SpeedTB.Size = new System.Drawing.Size(165, 45);
            this.SpeedTB.TabIndex = 4;
            this.SpeedTB.Value = 550;
            // 
            // comboBox3
            // 
            this.comboBox3.ForeColor = System.Drawing.Color.SteelBlue;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox3.Location = new System.Drawing.Point(115, 189);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(165, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // AlorithmCombo
            // 
            this.AlorithmCombo.ForeColor = System.Drawing.Color.SteelBlue;
            this.AlorithmCombo.FormattingEnabled = true;
            this.AlorithmCombo.Items.AddRange(new object[] {
            "FCFS",
            "SJF",
            "SRTF",
            "RR"});
            this.AlorithmCombo.Location = new System.Drawing.Point(115, 89);
            this.AlorithmCombo.Name = "AlorithmCombo";
            this.AlorithmCombo.Size = new System.Drawing.Size(165, 21);
            this.AlorithmCombo.TabIndex = 3;
            // 
            // numProcess
            // 
            this.numProcess.ForeColor = System.Drawing.Color.SteelBlue;
            this.numProcess.Location = new System.Drawing.Point(115, 50);
            this.numProcess.Name = "numProcess";
            this.numProcess.Size = new System.Drawing.Size(165, 20);
            this.numProcess.TabIndex = 2;
            this.numProcess.TextChanged += new System.EventHandler(this.numProcess_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Gray;
            this.button2.Location = new System.Drawing.Point(180, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Finish";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::CPUSchedulerProject.Properties.Resources.spaceship__2_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(15, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(15, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quantum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(15, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Speed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Algorithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Num of Jobs";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(45, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATA";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MistyRose;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.JobPool);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(320, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(610, 300);
            this.panel5.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.scheduling;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(15, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // JobPool
            // 
            this.JobPool.AllowUserToAddRows = false;
            this.JobPool.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JobPool.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.JobPool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JobPool.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Arrive,
            this.Burst,
            this.Start,
            this.Finish});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.JobPool.DefaultCellStyle = dataGridViewCellStyle2;
            this.JobPool.GridColor = System.Drawing.Color.LightGray;
            this.JobPool.Location = new System.Drawing.Point(15, 50);
            this.JobPool.Name = "JobPool";
            this.JobPool.RowHeadersWidth = 51;
            this.JobPool.RowTemplate.Height = 24;
            this.JobPool.Size = new System.Drawing.Size(575, 230);
            this.JobPool.TabIndex = 1;
            this.JobPool.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Arrive
            // 
            this.Arrive.HeaderText = "Arrive";
            this.Arrive.MinimumWidth = 6;
            this.Arrive.Name = "Arrive";
            this.Arrive.Width = 130;
            // 
            // Burst
            // 
            this.Burst.HeaderText = "Burst";
            this.Burst.MinimumWidth = 6;
            this.Burst.Name = "Burst";
            this.Burst.Width = 130;
            // 
            // Start
            // 
            this.Start.HeaderText = "Start";
            this.Start.MinimumWidth = 6;
            this.Start.Name = "Start";
            this.Start.Width = 131;
            // 
            // Finish
            // 
            this.Finish.HeaderText = "Finish";
            this.Finish.MinimumWidth = 6;
            this.Finish.Name = "Finish";
            this.Finish.Width = 131;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.IndianRed;
            this.label6.Location = new System.Drawing.Point(45, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "JOB POOL";
            this.label6.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Lavender;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.pictureBox5);
            this.panel8.Controls.Add(this.TurnaroundLabel);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Controls.Add(this.WaitingLabel);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(630, 320);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(300, 140);
            this.panel8.TabIndex = 1;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::CPUSchedulerProject.Properties.Resources.stock_exchange;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(15, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // TurnaroundLabel
            // 
            this.TurnaroundLabel.AutoSize = true;
            this.TurnaroundLabel.BackColor = System.Drawing.Color.Transparent;
            this.TurnaroundLabel.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnaroundLabel.ForeColor = System.Drawing.Color.Indigo;
            this.TurnaroundLabel.Location = new System.Drawing.Point(130, 100);
            this.TurnaroundLabel.Name = "TurnaroundLabel";
            this.TurnaroundLabel.Size = new System.Drawing.Size(23, 24);
            this.TurnaroundLabel.TabIndex = 0;
            this.TurnaroundLabel.Text = "0";
            this.TurnaroundLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label14.Location = new System.Drawing.Point(130, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Turnaround";
            this.label14.Click += new System.EventHandler(this.label5_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label15.Location = new System.Drawing.Point(15, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Waiting";
            this.label15.Click += new System.EventHandler(this.label5_Click);
            // 
            // WaitingLabel
            // 
            this.WaitingLabel.AutoSize = true;
            this.WaitingLabel.BackColor = System.Drawing.Color.Transparent;
            this.WaitingLabel.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaitingLabel.ForeColor = System.Drawing.Color.Indigo;
            this.WaitingLabel.Location = new System.Drawing.Point(15, 100);
            this.WaitingLabel.Name = "WaitingLabel";
            this.WaitingLabel.Size = new System.Drawing.Size(23, 24);
            this.WaitingLabel.TabIndex = 0;
            this.WaitingLabel.Text = "0";
            this.WaitingLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumOrchid;
            this.label9.Location = new System.Drawing.Point(45, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 27);
            this.label9.TabIndex = 0;
            this.label9.Text = "AVERAGE";
            this.label9.Click += new System.EventHandler(this.label5_Click);
            // 
            // MainForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CPU Scheduler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTB)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobPool)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label CPUlabel;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label CurrentJobLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TrackBar SpeedTB;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox AlorithmCombo;
        private System.Windows.Forms.TextBox numProcess;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView JobPool;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label TurnaroundLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label WaitingLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Burst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finish;
    }
}