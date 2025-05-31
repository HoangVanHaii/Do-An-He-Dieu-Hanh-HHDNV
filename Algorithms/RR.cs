using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CPUSchedulerProject.Algorithms
{
    internal class RR
    {
        int xGant = 50;
        int xReady = 50;
        bool isEmptyCPU = true;
        Helpers helper = new Helpers();
        //bool running = MainForm.IsRunning;
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
            System.Windows.Forms.TrackBar SpeedTB,
            int quantum)
        {
            var sorted = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.ID).ToList();
            Queue<Process> readyQueue = new Queue<Process>();
            int currentTime = 0;
            double totalWaiting = 0;
            double totalTurnaround = 0;
            double totalCPU = 0;
            int completed = 0;
            int totalProcess = sorted.Count;

            Dictionary<int, int> remainingBurst = sorted.ToDictionary(p => p.ID, p => p.BurstTime);

            xReady = 50;
            xGant = 50;

            while (completed < totalProcess)
            {
                // Đưa tiến trình mới đến vào hàng đợi ready
                foreach (var process in sorted)
                {
                    if (process.ArrivalTime <= currentTime && !process.IsCompleted && !readyQueue.Contains(process))
                        readyQueue.Enqueue(process);
                }
                panel7.Invalidate();
                await Task.Delay(50);

                if (readyQueue.Count == 0)
                {
                    // CPU idle
                    CurrentJob.Text = "Idle";
                    isEmptyCPU = true;
                    Process idle = new Process { ID = 1000 };
                    helper.DrawGanttChart(panel2, idle, 1,ref xGant, ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value);
                    currentTime++;
                    double tmpTotalCPU1 = (totalCPU / currentTime * 100);
                    CPUlabel.Text = tmpTotalCPU1 % 1 == 0 ? $"{(int)tmpTotalCPU1}%" : $"{tmpTotalCPU1:F2}%";
                    continue;
                }

                var currentProcess = readyQueue.Dequeue();
                xReady = 50;
                foreach (var p in readyQueue)
                {
                    helper.DrawReadyList(panel7, p, p.BurstTime.ToString(), ref xReady);
                    //if (!MainForm.IsRunning)
                    //{
                    //    await Task.Delay(5000);
                    //}
                }
                int executeTime = Math.Min(quantum, remainingBurst[currentProcess.ID]);

                if (currentProcess.StartTime == -1)
                {
                    currentProcess.StartTime = currentTime;
                    Jobpool.Rows[currentProcess.ID - 1].Cells[2].Value = currentTime; // StartTime
                }

                for (int t = 0; t < executeTime; t++)
                {
                    isEmptyCPU = false;
                    helper.DrawGanttChart(panel2, currentProcess,(t == executeTime - 1) ? 3 : 0, ref xGant, ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value);

                    CurrentJob.Text = $"JOB {currentProcess.ID}";
                    CurrentTimelabel.Text = $"{currentTime} -> {currentTime + 1}";

                    currentTime++;
                    totalCPU++;
                }

                remainingBurst[currentProcess.ID] -= executeTime;

                if (remainingBurst[currentProcess.ID] == 0)
                {
                    // Hoàn thành tiến trình
                    currentProcess.FinishTime = currentTime;
                    currentProcess.TurnaroundTime = currentProcess.FinishTime - currentProcess.ArrivalTime;
                    currentProcess.WaitTime = currentProcess.TurnaroundTime - currentProcess.BurstTime;
                    currentProcess.IsCompleted = true;

                    Jobpool.Rows[currentProcess.ID - 1].Cells[3].Value = currentProcess.FinishTime; // FinishTime
                    Jobpool.Rows[currentProcess.ID - 1].Cells[4].Value = currentProcess.WaitTime;
                    Jobpool.Rows[currentProcess.ID - 1].Cells[5].Value = currentProcess.TurnaroundTime;

                    totalWaiting += currentProcess.WaitTime;
                    totalTurnaround += currentProcess.TurnaroundTime;
                    completed++;
                }
                else
                {
                    // Thêm tiến trình mới vào ready queue nếu chưa có
                    foreach (var proc in sorted)
                    {
                        if (proc.ArrivalTime <= currentTime && !proc.IsCompleted && !readyQueue.Contains(proc) && proc.ID != currentProcess.ID)
                        {
                            readyQueue.Enqueue(proc);
                        }
                    }
                    // Đưa currentProcess trở lại cuối hàng đợi
                    readyQueue.Enqueue(currentProcess);
                }

                WaitingLabel.Text = $"{(totalWaiting / totalProcess):F3}";
                TurnaroundLabel.Text = completed > 0 ? $"{(totalTurnaround / completed):F3}" : "0";
                double tmpTotalCPU = (totalCPU / currentTime * 100);

                CPUlabel.Text = tmpTotalCPU % 1 == 0 ? $"{(int)tmpTotalCPU}%" : $"{tmpTotalCPU:F2}%";

            }
            
            return;
        }




    }
}
