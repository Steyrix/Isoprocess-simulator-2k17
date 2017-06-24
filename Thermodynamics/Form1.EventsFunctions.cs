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
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int x = pictureBox3.Location.X, y = pictureBox3.Location.Y;

            //Макс. высота поршня
            double maxHeight = pictureBox1.Location.Y - pictureBox3.Height;

            //Объем на один тик ползунка
            double referenceValue = ((pictureBox1.Height * pictureBox1.Width) - (pictureBox3.Height * pictureBox3.Width)) / trackBar2.TickFrequency;

            //Новая расчётная высота поршня
            double newHeight = (trackBar2.Value - vvalue) * referenceValue / pictureBox1.Width;

            if (y - newHeight < maxHeight)
                pictureBox3.Location = new Point(x, (int)maxHeight);

            else if (y - newHeight > pictureBox1.Height + pictureBox1.Location.Y)
                pictureBox3.Location = new Point(x, pictureBox1.Height + pictureBox1.Location.Y - pictureBox3.Height);

            else
                pictureBox3.Location = new Point(x, (int)(y - newHeight));

            if (trackBar2.Value == 0)
                pictureBox3.Location = new Point(x, pictureBox1.Height + pictureBox1.Location.Y - pictureBox3.Height);

            vvalue = trackBar2.Value;

            textBox1.Text = Convert.ToString(trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(trackBar3.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(trackBar1.Value);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {

                if (radioButton1.Checked)
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
            textBox4.Text = Convert.ToString(trackBar4.Value);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton3.Checked)
            {

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
            textBox5.Text = Convert.ToString(trackBar5.Value);

        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (radioButton2.Checked || radioButton3.Checked)
            {

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
            textBox7.Text = Convert.ToString(trackBar6.Value); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V1 = Convert.ToDouble(textBox1.Text);
            P1 = Convert.ToDouble(textBox2.Text);
            T1 = Convert.ToDouble(textBox3.Text);
            V2 = Convert.ToDouble(textBox4.Text);
            P2 = Convert.ToDouble(textBox5.Text);
            T2 = Convert.ToDouble(textBox7.Text);

                if (radioButton1.Checked) //Изотермический процесс
                {

                        P = P1 * (float)V1 / (float)V2;
                        if (P == P1)
                            P = P2;

                        V = P1 * (float)V1 / (float)P2;
                        if (V == V1)
                            V = V2;

                        if (V >= 120 && (P2 < P1))
                            MessageBox.Show("Дальнейшее увеличение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (V <= 10 && (P2 > P1))
                            MessageBox.Show("Дальнейшее уменьшение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        {

                            if (V1 == V2 && P1 == P2)
                            {
                                T = T1;
                                V = V1;
                                P = P1;
                            }
                            textBox4.Text = Convert.ToString(Math.Round(V, 2));
                            textBox5.Text = Convert.ToString(Math.Round(P, 2));

                            if (V > trackBar2.Maximum)
                                trackBar2.Value = trackBar2.Maximum;
                            else
                                trackBar2.Value = (int)V;
                            if (P > trackBar3.Maximum)
                                trackBar3.Value = trackBar3.Maximum;
                            else if (P < trackBar3.Minimum)
                                trackBar3.Value = trackBar3.Minimum;
                            else
                                trackBar3.Value = (int)P;

                            V1 = V;
                            P1 = P;

                            trackBar4.Enabled = true;
                            textBox4.Enabled = true;

                            trackBar5.Enabled = true;
                            textBox5.Enabled = true;

                        }
                    trackBar5.Enabled = true;
                    textBox5.Enabled = true;
                    trackBar4.Enabled = true;
                    textBox4.Enabled = true;
            }

                if (radioButton2.Checked) //Изобарный процесс
                {
                    
                        T = T1 * (float)V2 / (float)V1;
                        if (T == T1)
                            T = T2;
                        V = V1 * (float)T2 / (float)T1;
                        if (V == V1)
                            V = V2;

                        if (V >= 120 && (T2 > T1))
                            MessageBox.Show("Дальнейшее увеличение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (V <= 10 && (T2 < T1))
                            MessageBox.Show("Дальнейшее уменьшение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        else
                        {
                            if (T1 == T2 && V1 == V2)
                            {
                                T = T1;
                                V = V1;
                                P = P1;
                            }
                            textBox4.Text = Convert.ToString(Math.Round(V, 2));
                            textBox7.Text = Convert.ToString(Math.Round(T, 2));
                            if (V > trackBar2.Maximum)
                                trackBar2.Value = trackBar2.Maximum;
                            else
                                trackBar2.Value = (int)V;

                            if (T > trackBar1.Maximum)
                                trackBar1.Value = trackBar1.Maximum;
                            else if (T < trackBar1.Minimum)
                                trackBar1.Value = trackBar1.Minimum;
                            else
                                trackBar1.Value = (int)T;
                            V1 = V;
                            T1 = T;

                            trackBar4.Enabled = true;
                            textBox4.Enabled = true;

                            trackBar6.Enabled = true;
                            textBox7.Enabled = true;
                        }

                        trackBar4.Enabled = true;
                        textBox4.Enabled = true;
                        trackBar6.Enabled = true;
                        textBox7.Enabled = true;
            }

                if (radioButton3.Checked) //Изохорный процесс
                {

                        T = T1 * (float)P2 / (float)P1;
                        if (T == T1)
                            T = T2;
                        P = P1 * (float)T2 / (float)T1;
                        if (P == P1)
                            P = P2;

                        if (V >= 120 && (T2 > T1))
                            MessageBox.Show("Дальнейшее увеличение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (V <= 10 && (T2 < T1))
                            MessageBox.Show("Дальнейшее уменьшение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        {

                            if (T1 == T2 && P1 == P2)
                            {
                                T = T1;
                                V = V1;
                                P = P1;
                            }
                            textBox5.Text = Convert.ToString(Math.Round(P, 2));
                            textBox7.Text = Convert.ToString(Math.Round(T, 2));

                            if (T > trackBar1.Maximum)
                                trackBar1.Value = trackBar1.Maximum;
                            else if (T < trackBar1.Minimum)
                                trackBar1.Value = trackBar1.Minimum;
                            else
                                trackBar1.Value = (int)T;

                            if (P > trackBar3.Maximum)
                                trackBar3.Value = trackBar3.Maximum;
                            else if (P < trackBar3.Minimum)
                                trackBar3.Value = trackBar3.Minimum;
                            else
                                trackBar3.Value = (int)P;


                            trackBar5.Enabled = true;
                            textBox5.Enabled = true;

                            trackBar6.Enabled = true;
                            textBox7.Enabled = true;

                            P1 = P;
                            T1 = T;
                        }

                    trackBar5.Enabled = true;
                    textBox5.Enabled = true;
                    trackBar6.Enabled = true;
                    textBox7.Enabled = true;
                }

                if (radioButton4.Checked) //Адиабатический процесс
                {
                    
                    adiab = double.Parse(textBox6.Text, CultureInfo.InvariantCulture);

                    P = P1 * Math.Pow(V1 / V2, adiab); //P2
                    if (P == P1)
                        P = P2;
                    V = Math.Pow(P1 * Math.Pow(V1, adiab) / P2, 1f / adiab);
                    if (V == V1)
                        V = V2;
                    T = T1 * Math.Pow(V1 / V2, adiab - 1);
                    if (T == T1)
                        T = T2;


                    if (V >= 120 && (T2 < T1 || P2 < P1))
                        MessageBox.Show("Дальнейшее увеличение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else if (V <= 10 && (T2 > T1 || P1 > P2))
                        MessageBox.Show("Дальнейшее уменьшение объема невозможно", "Процесс нельзя произвести", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    else
                    {
                        textBox4.Text = Convert.ToString(Math.Round(V, 2));
                        textBox5.Text = Convert.ToString(Math.Round(P, 2));
                        textBox7.Text = Convert.ToString(Math.Round(T, 2));
                        if (T > trackBar1.Maximum)
                            trackBar1.Value = trackBar1.Maximum;
                        else if (T < trackBar1.Minimum)
                            trackBar1.Value = trackBar1.Minimum;
                        else
                            trackBar1.Value = (int)T;

                        if (V > trackBar2.Maximum)
                            trackBar2.Value = trackBar2.Maximum;
                        else
                            trackBar2.Value = (int)V;

                        if (P > trackBar3.Maximum)
                            trackBar3.Value = trackBar3.Maximum;
                        else if (P < trackBar3.Minimum)
                            trackBar3.Value = trackBar3.Minimum;
                        else
                            trackBar3.Value = (int)P;

                        P1 = P;
                        T1 = T;
                        V1 = V;
                    }
                }

            
        }

    }
}
