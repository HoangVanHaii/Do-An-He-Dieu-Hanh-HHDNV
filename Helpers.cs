using System.Drawing;
using System.Windows.Forms;
using Data;

namespace CPUSchedulerProject {
    public class Helpers {
        public  void DrawGanttChart(Panel panel2, Process process, int space, ref int xGant, ref bool isEmptyCpu )
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
        public void DrawReadyList(Panel panel7, Process process, string text, ref int xReady)
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


    }
}