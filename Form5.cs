using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aimtrain
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.Text = "";

            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Height = resolution.Height / 5 * 3;
            this.Width = resolution.Width / 5 * 3;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();

            pictureBox1.Size = new Size(this.Width - 70, this.Height);
            pictureBox1.Location = new Point(0, 0);
            button1.Size = new Size(this.Width - pictureBox1.Width - 7, 30);
            button1.Location = new Point(this.Width - button1.Width - 7, 0);

            label1.Location = new Point(this.Width - button1.Width - 7, this.Height / 2 - label1.Height - 5);
            label2.Location = new Point(this.Width - button1.Width - 7, this.Height / 2 + label2.Height + 5);
            label1.Text = "0";
            label2.Text = "0";
        }

        Bitmap bmp;
        Graphics graph;
        SolidBrush Brush;

        List<Point> coords = new List<Point>();
        List<int> rad = new List<int>();

        int schet1 = 0;
        int schet2 = 0;
        int x, y, radius = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            Brush = new SolidBrush(Color.White);

            Random rand = new Random();
            Random rand2 = new Random();

            x = (rand.Next() % (pictureBox1.Width)) + (rand.Next() % 20);
            y = (rand2.Next() % (pictureBox1.Height)) + (rand.Next() % 20);

            bool ch = true;
            while (ch)
            {
                radius = rand.Next() % 20;
                if (radius >= 5)
                    ch = false;
            }

            if (x > pictureBox1.Width - radius)
                x = pictureBox1.Width - radius;
            if (x < radius)
                x = radius;
            if (y > pictureBox1.Height - radius)
                y = pictureBox1.Height - radius;
            if (y < radius)
                y = radius;

            int sk = 0;
            foreach (Point a in coords)
            {
                sk++;
            }
            if (sk == 1000)
            {
                coords.RemoveAt(0);
                rad.RemoveAt(0);
            }

            coords.Add(new Point() { X = x, Y = y });
            rad.Add(radius);
            sk = 0;
            foreach (Point a in coords)
            {
                graph.FillEllipse(Brush, a.X - (rad[sk] / 2), a.Y - (rad[sk] / 2), rad[sk], rad[sk]);
                sk++;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int sk2 = 0;
            bool target = false;
            foreach (Point a in coords)
            {
                if (e.Location.X > a.X - rad[sk2] / 2 && e.Location.X < a.X + rad[sk2] / 2 && e.Location.Y < a.Y + rad[sk2] / 2 && e.Location.Y > a.Y - rad[sk2] / 2)
                {
                    coords.RemoveAt(sk2);
                    rad.RemoveAt(sk2);

                    schet1++;
                    label1.Text = schet1.ToString();
                    target = true;
                    break;
                }
                sk2++;
            }
            if (target)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graph = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                Brush = new SolidBrush(Color.White);

                sk2 = 0;
                foreach (Point a in coords)
                {
                    graph.FillEllipse(Brush, a.X - (rad[sk2] / 2), a.Y - (rad[sk2] / 2), rad[sk2], rad[sk2]);
                    sk2++;
                }
            }
            else
            {
                schet2++;
                label2.Text = schet2.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            schet1 = 0;
            schet2 = 0;
            label1.Text = "0";
            label2.Text = "0";

            coords.Clear();
            rad.Clear();
            timer1.Stop();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            this.Hide();
        }
    }
}
