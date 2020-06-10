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
    public partial class Form2 : Form
    {
        public Form2()
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
            button1.Size = new Size(this.Width-pictureBox1.Width-7, 30);
            button1.Location = new Point(this.Width - button1.Width-7, 0);

            label1.Location = new Point(this.Width - button1.Width - 7, this.Height / 2 - label1.Height - 5);
            label2.Location = new Point(this.Width - button1.Width - 7, this.Height / 2 + label2.Height + 5);
            label1.Text = "0";
            label2.Text = "0";
            start();
        }

        Bitmap bmp;
        Graphics graph;
        SolidBrush Brush;

        int schet1=0;
        int schet2=0;
        int x, y, radius = 0;

        private void start()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            Random rand = new Random();
            Random rand2 = new Random();

            x = (rand.Next() % (pictureBox1.Width)) + (rand2.Next() % 20);
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

            Brush = new SolidBrush(Color.White);
            graph.FillEllipse(Brush, x-(radius/2), y-(radius/2), radius, radius);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X > x - radius/2 && e.Location.X < x + radius/2 && e.Location.Y < y + radius/2 && e.Location.Y > y - radius/2)
            {
                start();

                schet1++;
                label1.Text = schet1.ToString();
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

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            this.Hide();
        }
    }
}
