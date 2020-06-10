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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Height = resolution.Height / 5 * 3;
            this.Width = resolution.Width / 5 * 3;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            button1.Size = new Size(70, 40);
            button2.Size = new Size(70, 40);
            button3.Size = new Size(70, 40);
            button4.Size = new Size(25, 25);
            button5.Size = new Size(70, 40);

            button1.Location = new Point(this.Width / 2 - 35, this.Height / 2 - 40 - 5 - 40 - 10);
            button2.Location = new Point(this.Width / 2 - 35, this.Height / 2 - 40 - 5);
            button3.Location = new Point(this.Width / 2 - 35, this.Height / 2 + 5);
            button4.Location = new Point(this.Width - button4.Width-7, 0);
            button5.Location = new Point(this.Width / 2 - 35, this.Height / 2 + 5 + 40 + 10);

            pictureBox1.Size = new Size(this.Width, this.Height);
            pictureBox1.Location = new Point(0, 0);

            button1.BringToFront();
            button2.BringToFront();
            button3.BringToFront();
            button4.BringToFront();
            button5.BringToFront();

            timer1.Start();
        }

        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form5 form5 = new Form5();

        Bitmap bmp;
        Graphics graph;
        SolidBrush Brush;

        List<Point> coords = new List<Point>();
        List<int> rad = new List<int>();

        List<int> r = new List<int>();
        List<int> g = new List<int>();
        List<int> b = new List<int>();

        int x, y, radius = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.Show();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3.Show();
            form3.timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form4.Show();
            form4.timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form5.Show();
            form5.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;


            Random rand = new Random();
            Random rand2 = new Random();

            Random randr = new Random();
            Random randg = new Random();
            Random randb = new Random();

            x = (rand.Next() % (pictureBox1.Width)) + (rand.Next() % 20);
            y = (rand2.Next() % (pictureBox1.Height)) + (rand.Next() % 20);

            int red = randr.Next() % 255;
            int green = randr.Next() % 255;
            int blue = randr.Next() % 255;
            r.Add(red);
            g.Add(green);
            b.Add(blue);

            bool ch = true;
            while (ch)
            {
                radius = rand.Next() % 30;
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
                Brush = new SolidBrush(Color.FromArgb(r[sk], g[sk], b[sk]));
                graph.FillEllipse(Brush, a.X - (rad[sk] / 2), a.Y - (rad[sk] / 2), rad[sk], rad[sk]);
                sk++;
            }
        }
    }

}
