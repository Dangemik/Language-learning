using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obiektowe
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String oper = "";
        bool oper_press = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (oper_press))
            {
                result.Clear();
            }
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            oper = b.Text;
            value = Double.Parse(result.Text);
            oper_press = true;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            switch (oper)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
            }
            oper_press = false;
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }
    }
}
