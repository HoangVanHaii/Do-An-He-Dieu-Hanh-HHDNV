using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using CPUSchedulerProject;

namespace Algorithms
{
    public class FCFS
    {
        int xGant = 50;
        int xReady = 50;
        bool isEmptyCPU = true;
        Helpers helper = new Helpers();
        
        public async Task RunAsync(
             List<Process> processes,
             Panel panel2,
             Panel panel7,
             Label CurrentJob,
             Label CurrentTimelabel,
             Label CPUlabel,
             Label WaitingLabel,
             Label TurnaroundLabel,
             DataGridView Jobpool,
             TrackBar SpeedTB)
        {
            double total = 0;
            double waiting = 0;
            double turnaround = 0;
            var sorted = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.ID).ToList();
            int currentTime = 0;

            for(int i = 0; i < sorted.Count; i++)
            {
                var process = sorted[i];
                await Task.Delay(5);
                int k = i;
                if(currentTime >= process.ArrivalTime)
                {
                    k += 1;
                }
                for (int j = k ; j < sorted.Count; j++)
                {
                    if(currentTime >= sorted[j].ArrivalTime)
                    {
                        helper.DrawReadyList(panel7, sorted[j], sorted[j].BurstTime.ToString(),ref xReady);
                    }
                }
                if (currentTime < process.ArrivalTime)
                {
                    for (int j = currentTime; j < process.ArrivalTime; j++)
                    {
                        CurrentJob.Text = "Idle";
                        CurrentTimelabel.Text = $"{currentTime}";
                        currentTime++;
                        CurrentTimelabel.Text += $" -> {currentTime}";
                        Process EmptyCpu = new Process();
                        EmptyCpu.ID = 1000;
                        int space = 0;
                        if (j == process.ArrivalTime - 1)
                        {
                            space = 3;
                        }
                        isEmptyCPU = true;
                        helper.DrawGanttChart(panel2, EmptyCpu, space, ref xGant,ref isEmptyCPU);
                        await Task.Delay(1100 - SpeedTB.Value); // mô phỏng 1s thực tế
                        double CPU = ((double)total / currentTime) * 100;
                        CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                    }
                    i -= 1;
                    xReady = 50;
                    panel7.Invalidate();
                    continue;
                }
                process.StartTime = currentTime;
                Jobpool.Rows[i].Cells[2].Value = process.StartTime;
                process.WaitTime = currentTime - process.ArrivalTime;
                waiting += process.WaitTime;

                double tmp = ((double)waiting / sorted.Count);
                WaitingLabel.Text = $"{tmp:F3}";
                CurrentJob.Text = $"JOB {process.ID}";
                // Chạy theo đơn vị thời gian
                for (int j = 0; j < process.BurstTime; j++)
                {
                    CurrentTimelabel.Text = $"{currentTime}";
                    currentTime++;
                    total++;
                    CurrentTimelabel.Text += $" -> {currentTime}";
                    int space = 0;
                    if(j == process.BurstTime - 1)
                    {
                        space = 3;
                    }
                    isEmptyCPU = false;
                    helper.DrawGanttChart(panel2, process, space,ref xGant, ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value); // mô phỏng 

                    double CPU = ((double)total / currentTime) * 100;
                    CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                    for (int t = i + 1; t < sorted.Count; t++)
                    {
                        if (currentTime == sorted[t].ArrivalTime)
                        {
                            helper.DrawReadyList(panel7, sorted[t], sorted[t].BurstTime.ToString(), ref xReady);
                        }
                    }
                }

                if (!(i < sorted.Count - 1 && currentTime < sorted[i + 1].ArrivalTime))
                {
                    panel7.Invalidate();
                }

                xReady = 50;
                //MessageBox.Show($"chạy xong tiến trình ${process.ID}");
                process.FinishTime = currentTime;
                process.TurnaroundTime = process.FinishTime - process.ArrivalTime;
                process.IsCompleted = true;

                Jobpool.Rows[i].Cells[3].Value = process.FinishTime;
                Jobpool.Rows[i].Cells[4].Value = process.WaitTime;
                Jobpool.Rows[i].Cells[5].Value = process.TurnaroundTime;
                turnaround += process.TurnaroundTime;
                double tmpTurn = ((double)turnaround / sorted.Count) ;
                TurnaroundLabel.Text = $"{tmpTurn:F3}";
            }
            double avgWaitTime = sorted.Average(p => p.WaitTime);
            double avgTurnaroundTime = sorted.Average(p => p.TurnaroundTime);
            return;
        }
    }
}
