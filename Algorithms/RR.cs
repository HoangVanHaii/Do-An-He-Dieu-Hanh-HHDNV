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

        bool running = MainForm.IsRunning;


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
                    Process idle = new Process { ID = 1000 };
                    DrawGanttChart(panel2, idle, 1, true);
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
                    DrawReadyList(panel7, p, p.BurstTime.ToString());
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
                    DrawGanttChart(panel2, currentProcess, (t == executeTime - 1) ? 3 : 0);
                    await Task.Delay(1100 - SpeedTB.Value);

                    CurrentJob.Text = $"JOB {currentProcess.ID}";
                    CurrentTimelabel.Text = $"{currentTime} -> {currentTime + 1}";

                    currentTime++;
                    totalCPU++;

                    // Cập nhật UI realtime có thể thêm nếu muốn
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
            
            return (sorted, totalWaiting / totalProcess, totalTurnaround / totalProcess);
        }




    }
}
