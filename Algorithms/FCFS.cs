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
        private void DrawGanttChart(Panel panel2, Process process)
        {
            Graphics g = panel2.CreateGraphics();
            //g.Clear(panel2.BackColor);
            int unitWidth = 14; // Mỗi đơn vị thời gian = 20 pixel
            int height = 80;
            int y = panel2.Height / 4;
            int spacing = 1;
                    // Chọn màu theo ID (tuỳ chỉnh)
            Color color = Color.Red;
            if (process.ID == 2) color = Color.DarkGray;
            if (process.ID == 3) color = Color.Orange;
            if (process.ID == 4) color = Color.BlueViolet;
            if (process.ID == 5) color = Color.Green;
            if(process.ID == 1000) color = Color.White;

            // Vẽ ID tiến trình
            Brush brush = new SolidBrush(color);
            Rectangle rect = new Rectangle(xGant, y, unitWidth, height);
            g.FillRectangle(brush, rect);
            g.DrawString("1" , panel2.Font, Brushes.Black, xGant + 2, y + 30);
            xGant += unitWidth + spacing;
            
        }
        private void DrawReadyList(Panel panel7, Process process, string text)
        {
            //g.Clear(panel2.BackColor);
            int unitWidth = 30; // Mỗi đơn vị thời gian = 20 pixel
            int height = 50;
            int y = panel7.Height / 3;
            int spacing = 1;
            // Chọn màu theo ID (tuỳ chỉnh)
            Color color = Color.Red;
            if (process.ID == 2) color = Color.DarkGray;
            if (process.ID == 3) color = Color.Orange;
            if (process.ID == 4) color = Color.BlueViolet;
            if (process.ID == 5) color = Color.Green;

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
             Panel panel7)
        {
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
                   DrawReadyList(panel7, sorted[j], sorted[j].BurstTime.ToString());
                }
                if (currentTime < process.ArrivalTime)
                {
                    for (int j = currentTime; j < process.ArrivalTime; j++)
                    {
                        Process EmptyCpu = new Process();
                        EmptyCpu.ID = 1000;
                        DrawGanttChart(panel2, EmptyCpu);
                        await Task.Delay(1000); // mô phỏng 1s thực tế
                        currentTime++;
                    }
                    i -= 1;
                    xReady = 50;
                    panel7.Invalidate();
                    continue;
                }
               
                    //currentTime = process.ArrivalTime;

                process.StartTime = currentTime;
                process.WaitTime = currentTime - process.ArrivalTime;

                // Chạy theo đơn vị thời gian
                for (int j = 0; j < process.BurstTime; j++)
                {
                    DrawGanttChart(panel2, process);
                    await Task.Delay(1000); // mô phỏng 1s thực tế

                    currentTime++;
                }
                if(!(i < sorted.Count - 1 && currentTime < sorted[i + 1].ArrivalTime))
                {
                    panel7.Invalidate();
                }
                xReady = 50;
                //MessageBox.Show($"chạy xong tiến trình ${process.ID}");
                process.FinishTime = currentTime;
                process.TurnaroundTime = process.FinishTime - process.ArrivalTime;
                process.IsCompleted = true;
            }

            double avgWaitTime = sorted.Average(p => p.WaitTime);
            double avgTurnaroundTime = sorted.Average(p => p.TurnaroundTime);

            return (sorted, avgWaitTime, avgTurnaroundTime);
        }
    }
}
