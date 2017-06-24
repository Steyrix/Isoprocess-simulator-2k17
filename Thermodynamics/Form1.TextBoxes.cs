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
    partial class Form1
    {
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(textBox1.Text);
            if (val > 120)
            {
                val = 120;
                textBox1.Text = Convert.ToString((int)val);
            }
            trackBar2.Value = (int)val;

            if (radioButton3.Checked)
            {
                textBox4.Text = textBox1.Text;
                trackBar4.Value = trackBar2.Value;
            }

            int x = pictureBox3.Location.X, y = pictureBox3.Location.Y;
            double referenceValue = ((pictureBox1.Height * pictureBox1.Width) - (pictureBox3.Height * pictureBox3.Width))
                / trackBar2.TickFrequency;
            double newHeight = (trackBar2.Value - vvalue) * referenceValue / pictureBox1.Width;
            pictureBox3.Location = new Point(x, y - (int)newHeight);

            vvalue = val;


        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int val = (int)Convert.ToDouble(textBox2.Text);
            if (val > trackBar3.Maximum)
                trackBar3.Value = trackBar3.Maximum;
            else if (val < trackBar3.Minimum)
                trackBar3.Value = trackBar3.Minimum;
            else trackBar3.Value = val;

            if (radioButton2.Checked)
            {
                textBox5.Text = textBox2.Text;
                trackBar5.Value = trackBar3.Value;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int val = (int)Convert.ToDouble(textBox3.Text);
            if (val > trackBar1.Maximum)
                trackBar1.Value = trackBar1.Maximum;
            else if (val < trackBar1.Minimum)
                trackBar1.Value = trackBar1.Minimum;
            else trackBar1.Value = val;

            if (radioButton1.Checked)
            {
                textBox7.Text = textBox3.Text;
                trackBar6.Value = trackBar1.Value;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(textBox4.Text);
            if (val > 120)
            {
                val = 120;
                textBox4.Text = Convert.ToString((int)val);
            }

            trackBar4.Value = (int)val;

            if(radioButton1.Checked)
            {
                trackBar5.Enabled = false;
                textBox5.Enabled = false;
            }
            if (radioButton2.Checked)
            {
                trackBar6.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int val = (int)Convert.ToDouble(textBox5.Text);
            if (val > trackBar5.Maximum)
                trackBar5.Value = trackBar5.Maximum;
            else if (val < trackBar5.Minimum)
                trackBar5.Value = trackBar5.Minimum;
            else trackBar5.Value = val;

            if (radioButton1.Checked)
            {
                trackBar4.Enabled = false;
                textBox4.Enabled = false;
            }
            if (radioButton3.Checked)
            {
                trackBar6.Enabled = false;
                textBox7.Enabled = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int val = (int)Convert.ToDouble(textBox7.Text);
            if (val > trackBar6.Maximum)
                trackBar6.Value = trackBar6.Maximum;
            else if (val < trackBar6.Minimum)
                trackBar6.Value = trackBar6.Minimum;
            else trackBar6.Value = val;

            if (radioButton2.Checked)
            {
                trackBar4.Enabled = false;
                textBox4.Enabled = false;
            }
            if (radioButton3.Checked)
            {
                trackBar5.Enabled = false;
                textBox5.Enabled = false;
            }
        }
    }
}
