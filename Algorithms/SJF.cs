using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUSchedulerProject;
using Data;

namespace Algorithms
{
    public class SJF
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
            double total = 0, waiting = 0, turnaround = 0;
            int currentTime = 0;
            int completed = 0;
            var processesCopy = processes.Select(p => new Process
            {
                ID = p.ID,
                ArrivalTime = p.ArrivalTime,
                BurstTime = p.BurstTime
            }).ToList();

            while (completed < processesCopy.Count)
            {
                // Lấy danh sách tiến trình đã đến và chưa hoàn thành
                var readyQueue = processesCopy
                    .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted)
                    .OrderBy(p => p.BurstTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.ID)
                    .ToList();

                if (readyQueue.Count == 0)
                {
                    // CPU idle
                    currentTime++;
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";
                    CurrentJob.Text = "Idle";
                    double CPU = ((double)total / currentTime) * 100;
                    CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                    await Task.Delay(5);
                    isEmptyCPU = true;
                    helper.DrawGanttChart(panel2, new Process { ID = 1000 }, 3, ref xGant, ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value);
                    xReady = 50;
                    panel7.Invalidate();
                    continue;
                }

                var process = readyQueue[0];
                process.StartTime = currentTime;
                process.WaitTime = process.StartTime - process.ArrivalTime;
                waiting += process.WaitTime;

                int index = processes.FindIndex(p => p.ID == process.ID);
                Jobpool.Rows[index].Cells[2].Value = process.StartTime;
                WaitingLabel.Text = $"{(waiting / processes.Count):F3}";

                for (int i = 0; i < process.BurstTime; i++)
                {

                    // Cập nhật danh sách ready *loại bỏ tiến trình đang chạy* trong Ready list
                    var readyToDraw = processesCopy
                        .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted && p.ID != process.ID)
                        .OrderBy(p => p.BurstTime)
                        .ThenBy(p => p.ArrivalTime)
                        .ThenBy(p => p.ID)
                        .ToList();

                    panel7.Invalidate();
                    xReady = 50;
                    foreach (var p in readyToDraw)
                    {
                        await Task.Delay(20);
                        helper.DrawReadyList(panel7, p, p.BurstTime.ToString(), ref xReady);
                    }
                    CurrentJob.Text = $"JOB {process.ID}";
                    currentTime++;
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";
                    total ++;

                    double CPU = ((double)total / currentTime) * 100;
                    CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                    isEmptyCPU = false;

                    await Task.Delay(5);
                    helper.DrawGanttChart(panel2, process, i == process.BurstTime - 1 ? 3 : 0, ref xGant, ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value);
                }

                

                process.FinishTime = currentTime;
                process.TurnaroundTime = process.FinishTime - process.ArrivalTime;
                turnaround += process.TurnaroundTime;
                TurnaroundLabel.Text = $"{(turnaround / processes.Count):F3}";
                process.IsCompleted = true;
                completed++;

                Jobpool.Rows[index].Cells[3].Value = process.FinishTime;
                Jobpool.Rows[index].Cells[4].Value = process.WaitTime;
                Jobpool.Rows[index].Cells[5].Value = process.TurnaroundTime;

                // Cập nhật lại Ready list khi tiến trình kết thúc
                var updatedReadyQueue = processesCopy
                    .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted)
                    .OrderBy(p => p.BurstTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.ID)
                    .ToList();

                panel7.Invalidate();
                xReady = 50;
                foreach (var p in updatedReadyQueue)
                {
                    await Task.Delay(20);
                    helper.DrawReadyList(panel7, p, p.BurstTime.ToString(), ref xReady);
                }
            }

            double avgWaitTime = processesCopy.Average(p => p.WaitTime);
            double avgTurnaroundTime = processesCopy.Average(p => p.TurnaroundTime);
            return;
        }


    }
}
