using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Button Add = (Button)sender;
            double n1;
            double n2;
            if (Double.TryParse(Num1.Text, out n1)&&Double.TryParse(Num2.Text, out n2))
            {
                double solution = n1 + n2;
                Answer.Text = solution;
            }
            else
                Answer.Text = "Enter numbers in the text boxes";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
