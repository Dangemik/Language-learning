using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        bool x = true;
        int total = 9;
        int now = 0;
        List<Button> przyciski = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            przyciski.Add(button1);
            przyciski.Add(button2);
            przyciski.Add(button3);
            przyciski.Add(button4);
            przyciski.Add(button5);
            przyciski.Add(button6);
            przyciski.Add(button7);
            przyciski.Add(button8);
            przyciski.Add(button9);

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (now < 9)
            {
                Button b = (Button)sender;
                if (x == true || b.Text == null)
                {
                    b.Text = "X";
                    x = false;
                    now++;
                    b.Enabled = false;
                }
                else if (x == false || b.Text == null)
                {
                    b.Text = "O";
                    x = true;
                    now++;
                    b.Enabled = false;
                }
            }
            if ((button1.Text == "X" && button2.Text == "X" && button3.Text == "X") ||
              (button4.Text == "X" && button5.Text == "X" && button6.Text == "X") ||
              (button7.Text == "X" && button8.Text == "X" && button9.Text == "X") ||
              (button1.Text == "X" && button4.Text == "X" && button7.Text == "X") ||
              (button2.Text == "X" && button5.Text == "X" && button8.Text == "X") ||
              (button3.Text == "X" && button6.Text == "X" && button9.Text == "X") ||
              (button1.Text == "X" && button5.Text == "X" && button9.Text == "X") ||
              (button3.Text == "X" && button5.Text == "X" && button7.Text == "X"))
            {
                textBox1.Text = "Wygrywa Krzyżyk";
                for (int i = 0; i < total; i++)
                {
                    przyciski[i].Enabled = false;
                }


            }
            if ((button1.Text == "O" && button2.Text == "O" && button3.Text == "O") ||
             (button4.Text == "O" && button5.Text == "O" && button6.Text == "O") ||
             (button7.Text == "O" && button8.Text == "O" && button9.Text == "O") ||
             (button1.Text == "O" && button4.Text == "O" && button7.Text == "O") ||
             (button2.Text == "O" && button5.Text == "O" && button8.Text == "O") ||
             (button3.Text == "O" && button6.Text == "O" && button9.Text == "O") ||
             (button1.Text == "O" && button5.Text == "O" && button9.Text == "O") ||
             (button3.Text == "O" && button5.Text == "O" && button7.Text == "O"))
            {
                textBox1.Text = "Wygrywa Kółko";
                for (int i = 0; i < total; i++)
                {
                    przyciski[i].Enabled = false;
                }

            }
            else if(now==9)
            {
                textBox1.Text = "Remis";
                for (int i = 0; i < total; i++)
                {
                    przyciski[i].Enabled = false;
                }
            }

        }
        

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < total; i++)
            {
                przyciski[i].Enabled = true;
                przyciski[i].Text = "";
                now = 0;
                textBox1.Text = "";
            }
        }
    }
}
