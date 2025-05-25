using Algorithms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Data;
using System.Drawing;
using System.Threading.Tasks;
using CPUSchedulerProject.Algorithms;

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
                    JobPool.Rows[i].Cells[2].Value = 0;
                    JobPool.Rows[i].Cells[3].Value = 0;
                    JobPool.Rows[i].HeaderCell.Value = "P" + (i + 1).ToString();
                }
                JobPool.Columns[2].ReadOnly = true;
                JobPool.Columns[3].ReadOnly = true;

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
        private async void button1_Click(object sender, EventArgs e)
        {
            string algorithm = AlorithmCombo.SelectedItem?.ToString();
            processList.Clear();
            button1.Enabled = false;
            numProcess.Enabled = false;
            AlorithmCombo.Enabled = false;
            comboBox3.Enabled = false;
            JobPool.Columns[0].ReadOnly = true;
            JobPool.Columns[1].ReadOnly = true;
            panel2.Invalidate();
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
                return;
            }
            if (algorithm == "FCFS")
            {
                FCFS scheduler = new FCFS();
                var (tmp, avgWait, avgTurnaround) = await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel,TurnaroundLabel, JobPool, SpeedTB);
            }
            else if(algorithm == "RR")
            {
                string tmpQuantum = comboBox3.Text;
                try
                {
                    int quantum = int.Parse(tmpQuantum);
                    RR scheduler = new RR();
                    var (tmp, avgWait, avgTurnaround) = await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB, quantum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Giá trị Quantum không hợp lệ");
                    return;
                }
               
            }
            else if (algorithm == "SRTF")
            {
                SRTF scheduler = new SRTF();
                var (tmp, avgWait, avgTurnaround) = await scheduler.RunSRTFAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB);
            }
            else if (algorithm == "SJF")
            {
                SJF scheduler = new SJF();
                var (tmp, avgWait, avgTurnaround) = await scheduler.RunAsync(
                    processList,
                    panel2,
                    panel7,
                    CurrentJobLabel,
                    CurrentTimeLabel,
                    CPUlabel,
                    WaitingLabel,
                    TurnaroundLabel,
                    JobPool,
                    SpeedTB
                );
            }
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
    }
}
