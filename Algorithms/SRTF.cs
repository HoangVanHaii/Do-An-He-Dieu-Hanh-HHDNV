using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Algorithms
{
    public class SRTF
    {
        int xGant = 50;
        int xReady = 50;
        private void DrawGanttChart(Panel panel2, Process process, int space, bool isEmptyCpu = false)
        {
            Graphics g = panel2.CreateGraphics();
            //g.Clear(panel2.BackColor);
            int unitWidth = 14; // Mỗi đơn vị thời gian = 20 pixel
            int height = 80;
            int y = panel2.Height / 4 + 20;
            int spacing = 1;
            // Chọn màu theo ID (tuỳ chỉnh)
            Color color = GetColorByProcessID(process.ID);
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

        public Color GetColorByProcessID(int id)
        {
            switch (id)
            {
                case 1: return Color.Red;
                case 2: return Color.Brown;
                case 3: return Color.Orange;
                case 4: return Color.BlueViolet;
                case 5: return Color.Green;
                case 6: return Color.Yellow;
                case 7: return Color.Purple;
                case 8: return Color.Teal;
                case 9: return Color.Gray;
                case 10: return Color.Pink;
                case 11: return Color.Cyan;
                case 12: return Color.Lime;
                case 13: return Color.Magenta;
                case 14: return Color.DarkBlue;
                case 1000: return Color.DarkGray;
                default: return Color.Black; // mặc định nếu không có ID phù hợp
            }
        }

        private void DrawReadyList(Panel panel7, Process process, string text)
        {
            //g.Clear(panel2.BackColor);
            int unitWidth = 30; // Mỗi đơn vị thời gian = 20 pixel
            int height = 50;
            int y = panel7.Height / 3 + 10;
            int spacing = 1;
            // Chọn màu theo ID (tuỳ chỉnh)
            Color color = GetColorByProcessID(process.ID);

            // Vẽ ID tiến trình
            using (Graphics g = panel7.CreateGraphics())
            using (Brush brush = new SolidBrush(color))
            {
                Point p1 = new Point(xReady - spacing, y + height / 2); // Điểm cuối mũi tên
                Point p2 = new Point(xReady - spacing - 10, y + height / 2); // Điểm đầu mũi tên
                g.DrawLine(Pens.Green, p1, p2); // Vẽ thân mũi tên
                Rectangle rect = new Rectangle(xReady, y, unitWidth, height);
                xReady += 15;

                // Vẽ 2 nhánh của đầu mũi tên
                g.DrawLine(Pens.Green, p2, new Point(p2.X + 5, p2.Y - 5));
                g.DrawLine(Pens.Green, p2, new Point(p2.X + 5, p2.Y + 5));

                g.FillRectangle(brush, rect);
                g.DrawString($"P{process.ID}", panel7.Font, Brushes.Black, xReady - 10, y + 15);
            }

            xReady += unitWidth + spacing;

        }

        public async Task<(List<Process> Processes, double AvgWaitTime, double AvgTurnaroundTime)> RunSRTFAsync(
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

            while (completed < n)
            {
                var availableProcesses = processList
                    .Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.ID)
                    .ToList();

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
                            await Task.Delay(20);
                            DrawReadyList(panel7, process, process.RemainingTime.ToString());
                            lastProcessID = process.ID;
                        }
                    }

                    if (currentProcess.StartTime == -1)
                    {
                        currentProcess.StartTime = currentTime;
                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[2].Value = currentTime;
                    }

                    DrawGanttChart(panel2, currentProcess, currentProcess.RemainingTime == 1 ? 3 : 0);
                    CurrentJob.Text = $"JOB {currentProcess.ID}";

                    await Task.Delay(1100 - SpeedTB.Value);
                    currentTime++;
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";

                    currentProcess.RemainingTime--;

                    if (currentProcess.RemainingTime == 0)
                    {
                        currentProcess.IsCompleted = true;
                        currentProcess.FinishTime = currentTime;
                        currentProcess.TurnaroundTime = currentProcess.FinishTime - currentProcess.ArrivalTime;
                        currentProcess.WaitTime = currentProcess.TurnaroundTime - currentProcess.BurstTime;
                        total += currentProcess.BurstTime;

                        Jobpool.Rows[processList.IndexOf(currentProcess)].Cells[3].Value = currentProcess.FinishTime;

                        waiting += currentProcess.WaitTime;
                        turnaround += currentProcess.TurnaroundTime;

                        double tmpWait = waiting / n;
                        double tmpTurn = turnaround / n;
                        WaitingLabel.Text = $"{tmpWait:F3}";
                        TurnaroundLabel.Text = $"{tmpTurn:F3}";

                        completed++;
                    }

                    double CPU = (total / (double)currentTime) * 100;
                    CPUlabel.Text = $"{CPU:F2}%";
                }
                else
                {
                    // Không có tiến trình sẵn sàng => vẽ CPU trống
                    await Task.Delay(20);
                    Process idle = new Process ();
                    idle.ID= 1000;
                    DrawGanttChart(panel2, idle, 3, true);
                    await Task.Delay(1100 - SpeedTB.Value);
                    currentTime++;
                    CurrentTimelabel.Text = $"{currentTime - 1} -> {currentTime}";
                }
                if(currentProcess != null &&currentProcess.RemainingTime == 0) { 
                    panel7.Invalidate();
                }
                xReady = 50;
            }

            double avgWaitTime = processList.Average(p => p.WaitTime);
            double avgTurnaroundTime = processList.Average(p => p.TurnaroundTime);
            return (processList, avgWaitTime, avgTurnaroundTime);
        }


    }
}
