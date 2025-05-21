using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Algorithms
{
    public class SJF
    {
        int xGant = 50;
        int xReady = 50;

        private void DrawGanttChart(Panel panel2, Process process, int space, bool isEmptyCpu = false)
        {
            Graphics g = panel2.CreateGraphics();
            int unitWidth = 14;
            int height = 80;
            int y = panel2.Height / 4;
            int spacing = 1;
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
                int y3 = rect.Top + rect.Height / 2;
                g.DrawLine(pen, rect.Left, y3, rect.Right, y3);
                int y2 = rect.Top + (rect.Height * 3) / 4;
                g.DrawLine(pen, rect.Left, y2, rect.Right, y2);
            }

            xGant += unitWidth + spacing + space;
            

        }

        private void DrawReadyList(Panel panel7, Process process, string text)
        {
            int unitWidth = 30;
            int height = 50;
            int y = panel7.Height / 3;
            int spacing = 1;
            Color color = GetColorByProcessID(process.ID);

            using (Graphics g = panel7.CreateGraphics())
            using (Brush brush = new SolidBrush(color))
            {
                Point p1 = new Point(xReady - spacing, y + height / 2);
                Point p2 = new Point(xReady - spacing - 10, y + height / 2);
                g.DrawLine(Pens.Green, p1, p2);
                Rectangle rect = new Rectangle(xReady, y, unitWidth, height);
                xReady += 15;

                g.DrawLine(Pens.Green, p2, new Point(p2.X + 5, p2.Y - 5));
                g.DrawLine(Pens.Green, p2, new Point(p2.X + 5, p2.Y + 5));

                g.FillRectangle(brush, rect);
                g.DrawString($"P{process.ID}", panel7.Font, Brushes.Black, xReady - 10, y + 15);
            }

            xReady += unitWidth + spacing;
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
                default: return Color.Black;
            }
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
            TrackBar SpeedTB)
        {
            double total = 0, waiting = 0, turnaround = 0;
            int currentTime = 0;
            int completed = 0;
            var readyQueue = new List<Process>();
            var processesCopy = processes.Select(p => new Process
            {
                ID = p.ID,
                ArrivalTime = p.ArrivalTime,
                BurstTime = p.BurstTime
            }).ToList();
            xGant = 50; // Reset vẽ Gantt cho mỗi lượt

            while (completed < processesCopy.Count)
            {
                readyQueue.Clear();
                readyQueue.AddRange(processesCopy.Where(p => p.ArrivalTime <= currentTime && !p.IsCompleted));
                readyQueue = readyQueue.OrderBy(p => p.BurstTime).ThenBy(p => p.ArrivalTime).ThenBy(p => p.ID).ToList();

                if (readyQueue.Count == 0)
                {
                    await Task.Delay(20);
                    Process idle = new Process { ID = 1000 };
                    DrawGanttChart(panel2, idle, 3, true);
                    await Task.Delay(1100 - SpeedTB.Value);
                    currentTime++;
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
                    await Task.Delay(20);
                    DrawGanttChart(panel2, process, i == process.BurstTime - 1 ? 3 : 0);
                    await Task.Delay(1100 - SpeedTB.Value);
                    CurrentTimelabel.Text = $"{currentTime} -> {currentTime + 1}";
                    currentTime++;

                    foreach (var p in processesCopy.Where(p => p.ArrivalTime == currentTime && !p.IsCompleted))
                    {
                        DrawReadyList(panel7, p, p.BurstTime.ToString());
                        await Task.Delay(1100 - SpeedTB.Value);
                    }
                }

                total += process.BurstTime;
                CurrentJob.Text = $"JOB {process.ID}";
                CPUlabel.Text = $"{(total / currentTime * 100):F2}%";

                process.FinishTime = currentTime;
                process.TurnaroundTime = process.FinishTime - process.ArrivalTime;
                turnaround += process.TurnaroundTime;
                TurnaroundLabel.Text = $"{(turnaround / processes.Count):F3}";
                process.IsCompleted = true;
                completed++;

                Jobpool.Rows[index].Cells[3].Value = process.FinishTime;
                xReady = 50;
                panel7.Invalidate();
            }

            double avgWaitTime = processesCopy.Average(p => p.WaitTime);
            double avgTurnaroundTime = processesCopy.Average(p => p.TurnaroundTime);
            return (processesCopy, avgWaitTime, avgTurnaroundTime);
        }
    }
}
