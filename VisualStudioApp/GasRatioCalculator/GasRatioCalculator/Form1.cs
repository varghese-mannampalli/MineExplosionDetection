using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasRatioCalculator
{
    public partial class Form1 : Form
    {
        Point[] pts = new Point[1000];
        int grcount = 0;
        //tempcount to keep track of x axis
        //int tempcount = 0;

        public Form1()
        {
            InitializeComponent();
            //BackColor = Color.Snow;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            double o2, n2, co2, h2, ch4, co,c2h4;
            double graham,young,coco2, jtr,chr;
            int flag = 0;
            
            if (Double.TryParse(textBox1.Text, out o2) && Double.TryParse(textBox2.Text, out n2) && Double.TryParse(textBox3.Text, out co2)
                && Double.TryParse(textBox4.Text, out co) && Double.TryParse(textBox5.Text, out ch4)
                && Double.TryParse(textBox6.Text, out h2))
            {
                graham = (100 * co / (0.265 * n2 - o2));
                textBox7.Text = "" + graham;
                young = (100 * co2 / (0.265 * n2 - o2));
                textBox8.Text = "" + young;
                coco2 = 100*co / co2;
                textBox9.Text = "" + coco2;
                jtr = (co2 + 0.75 * co - 0.25 * h2) / (0.265 * n2 - o2);
                textBox10.Text = "" + jtr;

                if (graham <= 0.4)
                {
                    textBox11.Text = "normal";
                }
                else
                if (graham <= 0.5)
                {
                    textBox11.Text = "checkup required";
                }
                else
                    if (graham <= 1)
                {
                    textBox11.Text = "heating";
                }
                else
                        if (graham <= 2)
                {
                    textBox11.Text = "serious heating";
                }
                else
                if (graham <= 7)
                    textBox11.Text = "FIRE with certainty";
                else
                {
                    textBox11.Text = "BLAZING FIRE";
                    flag = 1;
                }
                if (young <= 25)
                    textBox13.Text = "superficial heating";
                else
                    if (young <= 50)
                {
                    textBox13.Text = "FIRE present";
                }
                else
                {
                    textBox13.Text = "INTENSE FIRE";
                    flag = 1;
                }
                if (coco2 <= 2)
                {
                    textBox14.Text = "normal";
                }
                else
                    if (coco2 <= 13)
                {
                    textBox14.Text = "ACTIVE FIRE";
                }
                else
                {
                    textBox14.Text = "BLAZING FIRE";
                    flag = 1;
                }
                if (jtr <= 0.4)
                {
                    textBox15.Text = "Indicative of no fire";
                }
                else
                    if (jtr <= 0.5)
                {
                    textBox15.Text = "Indicative of methane fire";
                }
                else
                    if (jtr <= 1)
                {
                    textBox15.Text = "Indicative of coal/oil/conveyor fire";
                }
                else
                {
                    textBox15.Text = "Indicative of timber fire";
                    flag = 1;
                }
                if (flag == 1)
                {
                    //MessageBox.Show("DANGER!");
                    //BackColor = Color.DarkRed;
                }
                //C/H Ratio
                if (Double.TryParse(textBox17.Text, out c2h4))
                {
                    chr = 3 * (co2 + co + ch4 + 2 * c2h4) / (0.2468 * n2 - o2 - co2 - 0.5 * h2 + ch4 + c2h4 + h2 - co);
                    textBox12.Text = "" + chr;
                    if(chr<=5)
                    {
                        textBox18.Text = "Superficial heating";
                    }
                    else
                    {
                        if(chr<=20)
                        {
                            textBox18.Text = "ACTIVE FIRE";
                        }
                        else
                        {
                            textBox18.Text = "BLAZING FIRE";
                        }
                    }
                }
                else
                {
                    textBox12.Text = "Cannot be calculated";
                    textBox18.Text = "-";
                }
                //explosibility1
                int explos = 5;
                double pt = ch4 + co + h2;

                double ch4low = 5;
                double colow = 12.5;
                double h2low = 4;
                double ch4high = 14;
                double cohigh = 74.2;
                double h2high = 74.2;
                double ch4nose = 5.9;
                double conose = 13.8;
                double h2nose = 4.3;
                double ch4np = 6.07;
                double conp = 4.13;
                double h2np = 16.59;

                
                double Llow = pt / (ch4 / ch4low + co / colow + h2 / h2low);
                double Lhigh = pt / (ch4 / ch4high + co / cohigh + h2 / h2high);
                double Lnose = pt / (ch4 / ch4nose + co / conose + h2 / h2nose);
                double Nex = Lnose / pt * (ch4np * ch4 + conp * co + h2np * h2);

                double Oxnose = 0.2093 * (100 - Nex - Lnose);

                //total combustible at extinctive point
                double Le = 20.93 * Lnose / (20.93 - Oxnose);
                //oxygen at lower limit
                double Ob = -20.93 * Llow / 100 + 20.93;
                //oxygen at upper limit
                double Oc = -20.93 * Lhigh / 100 + 20.93;

                if ((o2 >= 0) && (pt >= 0))
                {
                    if (100 * o2 + 20.93 * pt >= 2093)
                        explos = 4;
                    if (Le * o2 + 20.93 * pt <= Le * 20.93)
                        explos = 0;
                    if ((100 * o2 + 20.93 * pt <= 2093) && (Le * o2 + 20.93 * pt >= Le * 20.93) 
                        && ((Lnose-Llow)*o2+(Ob-Oxnose)*pt<=Ob*Lnose-Ob*Llow-Oxnose*Llow+Ob*Llow))
                        explos = 2;
                    if ((100 * o2 + 20.93 * pt <= 2093) && (Le * o2 + 20.93 * pt >= Le * 20.93)
                       && ((Lnose - Llow) * o2 + (Ob - Oxnose) * pt >= Ob * Lnose - Ob * Llow - Oxnose * Llow + Ob * Llow)
                        &&((Lnose-Lhigh)*o2+(Oc-Oxnose)*pt<=Oc*Lnose-Oc*Lhigh-Oxnose*Lhigh+Oc*Lhigh))
                        explos = 3;
                    if ((100 * o2 + 20.93 * pt <= 2093) && (Le * o2 + 20.93 * pt >= Le * 20.93)
                        && ((Lnose - Llow) * o2 + (Ob - Oxnose) * pt >= Ob * Lnose - Ob * Llow - Oxnose * Llow + Ob * Llow)
                        && ((Lnose - Lhigh) * o2 + (Oc - Oxnose) * pt >= Oc * Lnose - Oc * Lhigh - Oxnose * Lhigh + Oc * Lhigh))
                        explos = 1;
                }

                //double trial = Oc * Lnose - Oc * Lhigh - Oxnose * Lhigh + Oc * Lhigh;
                //if (trial >= 0)
                //    MessageBox.Show("positive");
                //else
                //    MessageBox.Show("negative");


                switch (explos)
                {
                    case 0:
                        textBox16.Text = "Not explosive";
                        break;
                    case 1:
                        textBox16.Text = "Potentially explosive(if air is added)";
                        break;
                    case 2:
                        textBox16.Text = "Potentially explosive(if combustible gas is added)";
                        break;
                    case 3:
                        textBox16.Text = "Explosive";
                        break;
                    case 4:
                        textBox16.Text = "Impossible mixture";
                        break;
                    default:
                        textBox16.Text = "Unidentified";
                        break;
                };

                //for now we're taking the values that we add when we use 'calculate' and graphing them.
                //later we'll use a database for filling in values and graph from there
                // 0 for NE, 1 / 2 for PE and 3 for E, 4 / 5 for impossible mixture
                int grx;
                if (explos == 0)
                {
                    grx = 405;
                }
                else
                {
                    if (explos == 1||explos==2)
                    {
                        grx = 370;
                    }
                    else
                    {
                        if (explos == 3)
                        {
                            grx = 335;
                        }
                        else
                            grx = 310;
                        
                    }

                }

            pts[grcount] = new Point((80+grcount*40),grx);
                grcount++;
                float rectwidth = 5;
                float rectheight = 5;
                //no idea what this does
                for (int i=0;i<grcount;i++)
                {
                    if (i != 0)
                    {
                        this.CreateGraphics().DrawRectangle(new Pen(Brushes.Black, 1), (pts[i].X - 2), (pts[i].Y - 2), rectwidth, rectheight);
                        this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), pts[i - 1], pts[i]);
                    }
                    else
                    {
                        this.CreateGraphics().DrawRectangle(new Pen(Brushes.Black, 1), (pts[i].X - 2), (pts[i].Y - 2), rectwidth, rectheight);
                        this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), pts[i], pts[i]);
                    }
                   
                }
                //Ellicotts extension
                //calculating new x,y with shift of origin
                double xp = Llow - Lnose;
                double yp = Ob - Oxnose;
                double xq = Lhigh - Lnose;
                double yq = Oc - Oxnose;
                double xs = (Oxnose * Lnose) / (20.93 - Oxnose);
                double ys = -1*Oxnose;
                double xx = pt - Lnose;
                double yx = o2 - Oxnose;
                //calculating polar values
                double dtr(double angle)
                {
                    return Math.PI * angle / 180.0;
                }

                double rp = Math.Sqrt(xp * xp + yp * yp);
                double thp = dtr(Math.Atan(yp / xp));
                double rq = Math.Sqrt(xq * xq + yq * yq);
                double thq = dtr(Math.Atan(yq / xq));
                double rs = Math.Sqrt(xs * xs + ys * ys);
                double ths = dtr(Math.Atan(ys / xs));
                double rx = Math.Sqrt(xx * xx + yx * yx);
                double thx = dtr(Math.Atan(yx / xx));
                //calculating rm, thm
                // 0 for NE, 1 / 2 for PE and 3 for E, 4 / 5 for impossible mixture
                double rm, thm, xm, ym;
                if(explos==3)
                {
                    rm = rx;
                    thm = ((thx - thq) / (thx - thq + thp - thx)) * 90;
                }
                else
                {
                    if(explos==1||explos==2)
                    {
                        rm = rx;
                        thm = (((thx - ths) / (thx - ths + thq - thx)) * 90) + 270;
                    }
                    else
                    {
                        if(explos==0)
                        {
                            rm = rx;
                            thm = (((thx - thp) / (thx - thp + ths - thx)) * 180) + 90;
                        }
                        else
                        {
                            rm = 0;
                            thm = 0;
                        }
                    }
                }
                //calculating cartesian values of rm,thm
                xm = rm * Math.Cos(thm);
                ym = rm * Math.Sin(thm);
                textBox19.Text = "" + xm + "," + ym;

                //testing
                //double initials = 1;
                //textBox19.Text = "P:" + Llow + "," + Ob + ".Q:" + Lhigh + "," + Oc + ".S"+ initials + ",0.X:" + pt + "," + o2;
            }
            else
                MessageBox.Show("Fill in proper values");
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void resett_Click(object sender, EventArgs e)
        {
            Button resett = (Button)sender;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            //BackColor = Color.Snow;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
