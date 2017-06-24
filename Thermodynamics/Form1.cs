using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace Thermodynamics
{
    public partial class Form1 : Form
    {
        bool f = false;
        double vvalue = 50, adiab,
                    V1 = 50, V2, 
                    P1 = 10000, P2, 
                    T1 = 200, T2, 
                    V, P, T;


        public void timer_Tick(object sender, EventArgs e)
        {
            //"Анимация" горелки
            if (!radioButton4.Checked)
            {
                if (!f)
                {
                    pictureBox2.BackgroundImage = global::Thermodynamics.Properties.Resources.heater2;
                    f = true;
                }
                else
                {
                    pictureBox2.BackgroundImage = global::Thermodynamics.Properties.Resources.heater3;
                    f = false;
                }
            }
            else
            {
                pictureBox2.BackgroundImage = global::Thermodynamics.Properties.Resources.heater_dis;
            }
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Start();

            trackBar1.Minimum = 200;
            trackBar1.Maximum = 2000;
            trackBar1.Value = 200;
            trackBar1.TickFrequency = 100;
            textBox3.Text = Convert.ToString(T1);
            trackBar6.Minimum = 200;
            trackBar6.Maximum = 2000;
            trackBar6.Value = 200;
            trackBar6.TickFrequency = 100;
            textBox7.Text = Convert.ToString(T1);

            trackBar2.Minimum = 0;
            trackBar2.Maximum = 120;
            trackBar2.Value = (int)V1;
            trackBar2.TickFrequency = 120;
            textBox1.Text = Convert.ToString(V1);
            trackBar4.Minimum = 0;
            trackBar4.Maximum = 120;
            trackBar4.Value = (int)V1;
            trackBar4.TickFrequency = 120;
            textBox4.Text = Convert.ToString(V1);

            trackBar3.Minimum = 1000;
            trackBar3.Maximum = 1000000;
            trackBar3.Value = (int)P1;
            trackBar3.TickFrequency = 1000;
            textBox2.Text = Convert.ToString(P1);
            trackBar5.Minimum = 1000;
            trackBar5.Maximum = 1000000;
            trackBar5.Value = (int)P1;
            trackBar5.TickFrequency = 1000;
            textBox5.Text = Convert.ToString(P1);

            int stX = pictureBox3.Location.X, stY = pictureBox3.Location.Y;

            int nY = (int)(V1 * (((pictureBox1.Height * pictureBox1.Width) - (pictureBox3.Height * pictureBox3.Width)) / trackBar2.TickFrequency)
                / pictureBox1.Width);
            pictureBox3.Location = new Point(stX, stY - nY);

            textBox6.Text = "1.4"; adiab = 1.4f;

            label11.Visible = false;
            button1.Enabled = false;
            radioButton5.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!label11.Visible)
            {
                label11.Visible = true;
                button2.Text = "Скрыть информацию";
            }
            else
            {
                label11.Visible = false;
                button2.Text = "Информация о программе";
            }
        }

    }
}
