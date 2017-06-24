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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                trackBar6.Enabled = false;
                textBox7.Enabled = false;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                trackBar4.Enabled = true;
                trackBar5.Enabled = true;

                textBox5.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                trackBar6.Enabled = true;
                textBox7.Enabled = true;
            }

            trackBar2.Value = trackBar4.Value;
            trackBar3.Value = trackBar5.Value;
            textBox2.Text = textBox5.Text;
            textBox1.Text = textBox4.Text;

            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                trackBar5.Enabled = false;
                textBox5.Enabled = false;
                trackBar1.Enabled = true;
                trackBar6.Enabled = true;
                trackBar2.Enabled = true;
                trackBar4.Enabled = true;

                textBox7.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                trackBar5.Enabled = true;
                textBox5.Enabled = true;
            }

            trackBar1.Value = trackBar6.Value;
            trackBar2.Value = trackBar4.Value;
            textBox3.Text = textBox7.Text;
            textBox1.Text = textBox4.Text;

            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                trackBar4.Enabled = false;
                textBox4.Enabled = false;
                trackBar1.Enabled = true;
                trackBar6.Enabled = true;
                trackBar3.Enabled = true;
                trackBar5.Enabled = true;

                textBox5.Enabled = true;
                textBox7.Enabled = true;
            }
            else
            {
                trackBar4.Enabled = true;
                textBox4.Enabled = true;
            }

            trackBar1.Value = trackBar6.Value;
            trackBar3.Value = trackBar5.Value;
            textBox3.Text = textBox7.Text;
            textBox2.Text = textBox5.Text;

            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
            trackBar1.Value = trackBar6.Value;
            trackBar3.Value = trackBar5.Value;
            trackBar2.Value = trackBar4.Value;
            textBox2.Text = textBox5.Text;
            textBox1.Text = textBox4.Text;
            textBox3.Text = textBox7.Text;

            if (radioButton4.Checked)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox7.Enabled = true;

                trackBar4.Enabled = true;
                trackBar5.Enabled = true;
                trackBar6.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                button1.Enabled = false;
            else button1.Enabled = true;
        }


    }
}
