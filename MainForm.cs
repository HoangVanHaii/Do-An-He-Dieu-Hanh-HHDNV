using Algorithms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Data;
using System.Drawing;
using System.Threading.Tasks;
using CPUSchedulerProject.Algorithms;
using System.Threading;

namespace CPUSchedulerProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        List<Process> processList = new List<Process>();
        double avgWaitTime = 0;
        double avgTurnaroundTime = 0;
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            JobPool.Invalidate();
            try
            {
                int rows = int.Parse(numProcess.Text);
                //MessageBox.Show(rows.ToString());
            }
            catch(Exception ex)
            {
                return;
            }
        }
        private void numProcess_TextChanged(object sender, EventArgs e)
        {
            string inp = numProcess.Text;
            try
            {
                JobPool.Rows.Clear();
                int row = int.Parse(inp);
                CurrentJobLabel.Text = "Idle";
                CurrentTimeLabel.Text = "0";
                CPUlabel.Text = "0%";
                WaitingLabel.Text = "0";
                TurnaroundLabel.Text = "0";
                if(row <= 0)
                {
                    System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                    toolTip.Show("Số lượng tiến trình không hợp lệ!!", this, 450, 140, 1500);
                    button1.Enabled = false;
                    return;
                }
                for (int i = 0; i < row; i++)
                {
                    JobPool.Rows.Add();
                    JobPool.Rows[i].Cells[2].Value = "undefined";
                    JobPool.Rows[i].Cells[3].Value = "undefined";
                    JobPool.Rows[i].Cells[4].Value = "undefined";
                    JobPool.Rows[i].Cells[5].Value = "undefined";
                    JobPool.Rows[i].HeaderCell.Value = "P" + (i + 1).ToString();
                }
                JobPool.Columns[2].ReadOnly = true;
                JobPool.Columns[3].ReadOnly = true;
                JobPool.Columns[4].ReadOnly = true;
                JobPool.Columns[5].ReadOnly = true;

                JobPool.Invalidate();
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.Show("Số lượng tiến trình không hợp lệ!!", this, 450, 140, 1500);
                button1.Enabled = false;
                return;
            }
        }
        private void SetUp()
        {
            processList.Clear();
            button1.Enabled = false;
            numProcess.Enabled = false;
            AlorithmCombo.Enabled = false;
            comboBox3.Enabled = false;
            JobPool.Columns[0].ReadOnly = true;
            JobPool.Columns[1].ReadOnly = true;
            WaitingLabel.Text = "0";
            TurnaroundLabel.Text = "0";
            CurrentJobLabel.Text = "Idle";
            CurrentTimeLabel.Text = "0";
            CPUlabel.Text = "0%";
            panel2.Invalidate();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string algorithm = AlorithmCombo.SelectedItem?.ToString();
            SetUp();
       
            try
            {
                int rowCount = int.Parse(numProcess.Text);
                for (int i = 0; i < rowCount; i++)
                {
                    int arrivalTime = int.Parse(JobPool.Rows[i].Cells[0].Value.ToString());
                    int burstTime = int.Parse(JobPool.Rows[i].Cells[1].Value.ToString());

                    Process process = new Process
                    {
                        ID = i + 1,
                        ArrivalTime = arrivalTime,
                        BurstTime = burstTime
                    };

                    processList.Add(process);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dữ liệu đầu vào");
                UndosetUp();
                return;
            }

            if (algorithm == "FCFS" )
            {
                FCFS scheduler = new FCFS();
                await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel,TurnaroundLabel, JobPool, SpeedTB);
            }
            else if(algorithm == "RR")
            {
                string tmpQuantum = comboBox3.Text;
                try
                {
                    int quantum = int.Parse(tmpQuantum);
                    if(quantum <= 0)
                    {
                        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                        toolTip.Show("Giá trị quantum không hợp lệ!!", this, 450, 140, 1500);
                        UndosetUp();
                        return;
                    }
                    RR scheduler = new RR();
                    await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB, quantum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Giá trị Quantum không hợp lệ");
                    UndosetUp();
                    return;
                }
            }
            else if (algorithm == "SRTF")
            {
                SRTF scheduler = new SRTF();
                await scheduler.RunSRTFAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB);
            }
            else if (algorithm == "SJF")
            {
                SJF scheduler = new SJF();
                await scheduler.RunAsync(processList,panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB);
            }
            UndosetUp();
        }
        private void UndosetUp()
        {
            button1.Enabled = true;
            numProcess.Enabled = true;
            AlorithmCombo.Enabled = true;
            comboBox3.Enabled = true;
            JobPool.Columns[0].ReadOnly = false;
            JobPool.Columns[1].ReadOnly = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            AlorithmCombo.SelectedIndex = 0; 
            comboBox3.SelectedIndex = 0;
            button1.Enabled = false;
        }
        private static bool isRunning = true;

        public static bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //isRunning = (isRunning == true) ? false : true;
            //Thread.Sleep(100);
        }

        private void AlorithmCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WaitingLabel.Text = "0";
            TurnaroundLabel.Text = "0";
            CurrentJobLabel.Text = "Idle";
            CurrentTimeLabel.Text = "0";
            CPUlabel.Text = "0%";
            panel2.Invalidate();
            string text = numProcess.Text;
            try
            {
                int row = int.Parse(text);
                for (int i = 0; i < row; i++)
                {
                    JobPool.Rows[i].Cells[2].Value = "undefined";
                    JobPool.Rows[i].Cells[3].Value = "undefined";
                    JobPool.Rows[i].Cells[4].Value = "undefined";
                    JobPool.Rows[i].Cells[5].Value = "undefined";
                    JobPool.Rows[i].HeaderCell.Value = "P" + (i + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                return;
            }

            
        }
    }
}
