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

        // Biến toàn cục
        List<Process> processList = new List<Process>();
        List<Process> resultList = new List<Process>();
        double avgWaitTime = 0;
        double avgTurnaroundTime = 0;

        private void label5_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            JobPool.Invalidate();
            int rows = int.Parse(numProcess.Text);
            MessageBox.Show(rows.ToString());
        }

        private void panel6_Paint(object sender, PaintEventArgs e) { }

        private void numProcess_TextChanged(object sender, EventArgs e)
        {
            string inp = numProcess.Text;
            try
            {
                JobPool.Rows.Clear();
                int row = int.Parse(inp);
                for (int i = 0; i < row; i++)
                {
                    JobPool.Rows.Add();
                    JobPool.Rows[i].Cells[2].Value = 0;
                    JobPool.Rows[i].Cells[3].Value = 0;
                    JobPool.Rows[i].HeaderCell.Value = "P" + (i + 1).ToString();
                }
                JobPool.Columns[0].ReadOnly = false;
                JobPool.Columns[1].ReadOnly = false;
                JobPool.Columns[2].ReadOnly = true;
                JobPool.Columns[3].ReadOnly = true;

                JobPool.Invalidate();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi dữ liệu đầu vào: " + ex.Message);
                return;
            }
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string algorithm = AlorithmCombo.SelectedItem?.ToString();
            processList.Clear();
            resultList.Clear();
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
                MessageBox.Show("Lỗi dữ liệu đầu vào: " + ex.Message);
                return;
            }

            if (algorithm == "FCFS")
            {
                FCFS scheduler = new FCFS();
                var (tmp, avgWait, avgTurnaround) = await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel,TurnaroundLabel, JobPool, SpeedTB);

                //string result = "";
                //foreach (var p in resultList)
                //{
                //    result += $"ID: {p.ID}, Arrival: {p.ArrivalTime}, Burst: {p.BurstTime}, " +
                //              $"Start: {p.StartTime}, Finish: {p.FinishTime}, " +
                //              $"Wait: {p.WaitTime}, Turnaround: {p.TurnaroundTime}\n";
                //}
                //resultList = tmp;
                //await  DrawQueueAsync();
                //await DrawGanttChart();
            }
            else if(algorithm == "RR")
            {
                
                string tmpQuantum = comboBox3.SelectedItem?.ToString();
                int quantum = int.Parse(tmpQuantum);
                RR scheduler = new RR();
                var (tmp, avgWait, avgTurnaround) = await scheduler.RunAsync(processList, panel2, panel7, CurrentJobLabel, CurrentTimeLabel, CPUlabel, WaitingLabel, TurnaroundLabel, JobPool, SpeedTB, quantum );

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

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AlorithmCombo.SelectedIndex = 0; // Chọn thuật toán đầu tiên
            comboBox3.SelectedIndex = 0;
        }
    }
}
