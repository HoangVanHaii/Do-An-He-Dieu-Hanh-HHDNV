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
    public class SRTF
    {
        int xGant = 50;
        int xReady = 50;
        bool isEmptyCPU = true;
        Helpers helper = new Helpers();

        public async Task RunSRTFAsync(
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
            int currentTime = 0;
            int completed = 0;
            int n = processes.Count;
            var processList = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.ID).ToList();

            foreach (var p in processList)
            {
                p.RemainingTime = p.BurstTime;
                p.IsCompleted = false;
            }

            Process currentProcess = null;
            int lastProcessID = -1;
            var availableProcesses = processList
                    .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.ID)
                    .ToList();
            while (completed < n)
            {
                int PreviousID = availableProcesses.Any() ? availableProcesses.First().ID : -1;
                availableProcesses = processList
                    .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.ID)
                    .ToList();
                int affterID = availableProcesses.Any() ? availableProcesses.First().ID : -1;

                
                if (availableProcesses.Any())
                {
                    currentProcess = availableProcesses.First();
                    foreach(var process in availableProcesses)
                    {
                        if (process.ArrivalTime <= currentTime &&
                            !process.IsCompleted &&
                            process != currentProcess
                            )
                        {
                            await Task.Delay(5);
                            helper.DrawReadyList(panel7, process, process.RemainingTime.ToString(), ref xReady);
                            lastProcessID = process.ID;
                        }
                    }
                    if (currentProcess.StartTime == -1)
                    {
                        currentProcess.StartTime = currentTime;
                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[2].Value = currentTime;
                    }
                    await Task.Delay(5);
                    isEmptyCPU = false;
                    
                    if (affterID != PreviousID && PreviousID != -1 )
                    {
                        xGant += 3;
                    }
                    helper.DrawGanttChart(panel2, currentProcess, 0, ref xGant, ref isEmptyCPU);
                    CurrentJob.Text = $"JOB {currentProcess.ID}";

                    await Task.Delay(1100 - SpeedTB.Value);
                    currentTime++;
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";
                    currentProcess.RemainingTime--;
                    total++;

                    if (currentProcess.RemainingTime == 0)
                    {
                        currentProcess.IsCompleted = true;
                        currentProcess.FinishTime = currentTime;
                        currentProcess.TurnaroundTime = currentProcess.FinishTime - currentProcess.ArrivalTime;
                        currentProcess.WaitTime = currentProcess.TurnaroundTime - currentProcess.BurstTime;

                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[3].Value = currentProcess.FinishTime;
                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[4].Value = currentProcess.WaitTime;
                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[5].Value = currentProcess.TurnaroundTime;

                        waiting += currentProcess.WaitTime;
                        turnaround += currentProcess.TurnaroundTime;

                        double tmpWait = waiting / n;
                        double tmpTurn = turnaround / n;
                        WaitingLabel.Text = $"{tmpWait:F3}";
                        TurnaroundLabel.Text = $"{tmpTurn:F3}";

                        completed++;
                    }
                    //WaitingLabel.Text = $"{currentProcess.StartTime - currentProcess.ArrivalTime:F3}";
                    double CPU = (total / (double)currentTime) * 100;
                    //CPUlabel.Text = $"{CPU:F2}%";
                    CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                }
                else
                {
                    // Không có tiến trình sẵn sàng => vẽ CPU trống
                    await Task.Delay(20);
                    Process idle = new Process ();
                    idle.ID= 1000;
                    isEmptyCPU = true;
                    helper.DrawGanttChart(panel2, idle, 3, ref xGant ,ref isEmptyCPU);
                    await Task.Delay(1100 - SpeedTB.Value);

                    currentTime++;
                    CurrentJob.Text = "Idle";
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";
                    double CPU = (total / (double)currentTime) * 100;
                    //CPUlabel.Text = $"{CPU:F2}%";
                    CPUlabel.Text = CPU % 1 == 0 ? $"{(int)CPU}%" : $"{CPU:F2}%";
                }
                if (currentProcess != null && currentProcess.RemainingTime == 0) { 
                    panel7.Invalidate();
                }
                xReady = 50;
            }
            double avgWaitTime = processList.Average(p => p.WaitTime);
            double avgTurnaroundTime = processList.Average(p => p.TurnaroundTime);
            return;
        }
    }
}
