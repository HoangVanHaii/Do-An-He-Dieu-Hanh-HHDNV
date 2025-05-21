using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace CPUSchedulerProject.Algorithms
{
    internal class RR
    {
        int xGant = 50;
        int xReady = 50;
        private void DrawGanttChart(Panel panel2, Process process, int space, bool isEmptyCpu = false)
        {
            Graphics g = panel2.CreateGraphics();
            //g.Clear(panel2.BackColor);
            int unitWidth = 14; // Mỗi đơn vị thời gian = 20 pixel
            int height = 80;
            int y = panel2.Height / 4;
            int spacing = 1;
            // Chọn màu theo ID (tuỳ chỉnh)
            Color color = Color.Red;
            if (process.ID == 2) color = Color.Brown;
            if (process.ID == 3) color = Color.Orange;
            if (process.ID == 4) color = Color.BlueViolet;
            if (process.ID == 5) color = Color.Green;
            if (process.ID == 1000) color = Color.DarkGray;

            // Vẽ ID tiến trình
            Brush brush = new SolidBrush(color);
            Rectangle rect = new Rectangle(xGant, y, unitWidth, height);
            g.FillRectangle(brush, rect);
            if (!isEmptyCpu) g.DrawString(process.ID.ToString(), panel2.Font, Brushes.Black, xGant + 2, y + 30);

            if (isEmptyCpu)
            {
                Pen pen = new Pen(Color.Black, 1);
                int y1 = rect.Top + rect.Height / 4;
                g.DrawLine(pen, rect.Left, y1, rect.Right, y1);
                int y3 = rect.Top + (rect.Height) / 2;
                g.DrawLine(pen, rect.Left, y3, rect.Right, y3);
                int y2 = rect.Top + (rect.Height * 3) / 4;
                g.DrawLine(pen, rect.Left, y2, rect.Right, y2);
            }
            xGant += unitWidth + spacing + space;
        }
        public async Task<(List<Process> Processes, double AvgWaitTime, double AvgTurnaroundTime)> RunAsync(
        List<Process> processes,
        Panel panel2,
        Panel panel7,
        Label CurrentJob,
        Label CurrentTimelabel,
        Label CPUlabel,
        Label WaitingLabel,
        Label TurnaroundLabel,
        DataGridView Jobpool,
        TrackBar SpeedTB,
        int quantum)
            {
                var sorted = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.ID).ToList();
                Queue<Process> readyQueue = new Queue<Process>();
                int currentTime = 0;
                double waiting = 0;
                double turnaround = 0;
                double totalCPU = 0;
                Dictionary<int, int> remainingBurst = sorted.ToDictionary(p => p.ID, p => p.BurstTime);
                int completed = 0;
                int totalProcess = sorted.Count;

                while (completed < totalProcess)
                {
                    // Thêm tiến trình đến vào hàng đợi
                    foreach (var process in sorted)
                    {
                        if (process.ArrivalTime <= currentTime && !process.IsCompleted && !readyQueue.Contains(process))
                            readyQueue.Enqueue(process);
                    }

                    if (readyQueue.Count == 0)
                    {
                        // CPU idle
                        Process idle = new Process { ID = 1000 };
                        DrawGanttChart(panel2, idle, 3, true);
                        await Task.Delay(1100 - SpeedTB.Value);
                        currentTime++;
                        continue;
                    }

                    var currentProcess = readyQueue.Dequeue();

                    int executeTime = Math.Min(quantum, remainingBurst[currentProcess.ID]);

                    // Nếu là lần đầu chạy thì set StartTime
                    if (currentProcess.StartTime == -1)
                    {
                        currentProcess.StartTime = currentTime;
                        Jobpool.Rows[currentProcess.ID - 1].Cells[2].Value = currentTime;
                    }

                    for (int t = 0; t < executeTime; t++)
                    {
                    DrawGanttChart(panel2, currentProcess, (t == executeTime - 1) ? 3 : 0);
                        await Task.Delay(1100 - SpeedTB.Value);

                        CurrentJob.Text = $"JOB {currentProcess.ID}";
                        CurrentTimelabel.Text = $"{currentTime} -> {currentTime + 1}";
                        currentTime++;
                    }

                    remainingBurst[currentProcess.ID] -= executeTime;
                    totalCPU += executeTime;

                    // Nếu chạy xong hoàn toàn
                    if (remainingBurst[currentProcess.ID] == 0)
                    {
                        currentProcess.FinishTime = currentTime;
                        currentProcess.TurnaroundTime = currentProcess.FinishTime - currentProcess.ArrivalTime;
                        currentProcess.WaitTime = currentProcess.TurnaroundTime - currentProcess.BurstTime;
                        currentProcess.IsCompleted = true;

                        Jobpool.Rows[currentProcess.ID - 1].Cells[3].Value = currentProcess.FinishTime;

                        waiting += currentProcess.WaitTime;
                        turnaround += currentProcess.TurnaroundTime;
                        completed++;
                    }
                    else
                    {
                        // Quay lại cuối hàng đợi
                        foreach (var proc in sorted)
                        {
                            if (proc.ArrivalTime <= currentTime && !proc.IsCompleted && !readyQueue.Contains(proc) && proc.ID != currentProcess.ID)
                                readyQueue.Enqueue(proc);
                        }
                        readyQueue.Enqueue(currentProcess);
                    }

                    WaitingLabel.Text = $"{(waiting / totalProcess):F2}";
                    TurnaroundLabel.Text = $"{(turnaround / totalProcess):F2}";
                    CPUlabel.Text = $"{(totalCPU / currentTime * 100):F2}%";
                }

                return (sorted, waiting / totalProcess, turnaround / totalProcess);
            }

    }
}
