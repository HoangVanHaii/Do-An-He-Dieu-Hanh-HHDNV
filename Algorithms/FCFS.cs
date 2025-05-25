using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Algorithms
{
    public class FCFS
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

            // Vẽ ID tiến trình
            Brush brush = new SolidBrush(color);
            Rectangle rect = new Rectangle(xGant, y, unitWidth, height);
            g.FillRectangle(brush, rect);
            if(!isEmptyCpu) g.DrawString(process.ID.ToString(), panel2.Font, Brushes.Black, xGant + 2, y + 30);

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
            xGant += unitWidth + spacing + space ;
        }

        public Color GetColorByProcessID(int id){
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
                Point p1 = new Point(xReady - spacing , y + height / 2); // Điểm cuối mũi tên
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
                await Task.Delay(100);
                int k = i;
                if(currentTime >= process.ArrivalTime)
                {
                    k += 1;
                }
                for (int j = k ; j < sorted.Count; j++)
                {
                    if(currentTime >= sorted[j].ArrivalTime)
                    {
                        DrawReadyList(panel7, sorted[j], sorted[j].BurstTime.ToString());
                    }
                }
                if (currentTime < process.ArrivalTime)
                {
                    bool isEmptyCpu = true;
                    for (int j = currentTime; j < process.ArrivalTime; j++)
                    {
                        Process EmptyCpu = new Process();
                        EmptyCpu.ID = 1000;
                        int space = 0;
                        if (j == process.ArrivalTime - 1)
                        {
                            space = 3;
                        }
                        DrawGanttChart(panel2, EmptyCpu, space, isEmptyCpu);
                        await Task.Delay(1100 - SpeedTB.Value); // mô phỏng 1s thực tế
                        currentTime++;                        
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
                // Chạy theo đơn vị thời gian
                for (int j = 0; j < process.BurstTime; j++)
                {
                    int space = 0;
                    if(j == process.BurstTime - 1)
                    {
                        space = 3;
                    }
                    DrawGanttChart(panel2, process, space);
                    await Task.Delay(1100 - SpeedTB.Value); // mô phỏng 1s thực tế

                    CurrentTimelabel.Text = $"{currentTime}";
                    currentTime++;
                    CurrentTimelabel.Text += $" -> {currentTime}";

                    for (int t = i + 1; t < sorted.Count; t++)
                    {
                        if (currentTime == sorted[t].ArrivalTime)
                        {
                            DrawReadyList(panel7, sorted[t], sorted[t].BurstTime.ToString());
                            await Task.Delay(1100 - SpeedTB.Value);
                        }
                    }
                }
                total += process.BurstTime;
                double CPU = ((double)total / currentTime) * 100;
                CPUlabel.Text = $"{CPU:F2}%"; // hiển thị 2 chữ số thập phân
                CurrentJob.Text = $"JOB {process.ID}";

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
                turnaround += process.TurnaroundTime;
                double tmpTurn = ((double)turnaround / sorted.Count) ;
                TurnaroundLabel.Text = $"{tmpTurn:F3}";
            }
            double avgWaitTime = sorted.Average(p => p.WaitTime);
            double avgTurnaroundTime = sorted.Average(p => p.TurnaroundTime);
            return (sorted, avgWaitTime, avgTurnaroundTime);
        }
    }
}
