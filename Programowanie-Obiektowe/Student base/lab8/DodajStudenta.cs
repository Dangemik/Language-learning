using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class DodajStudenta : Form
    {
        public DodajStudenta()
        {
            InitializeComponent();
        }
        private Main mainForm = null;


        public DodajStudenta(Main m)
        {
            InitializeComponent();
            mainForm = m;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxImie.Text == "" || textBoxNazwisko.Text == ""
                || textBoxNrIndeksu.Text == "" || textBoxKierunek.Text=="")
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                try
                {
                    Student s = new Student(textBoxImie.Text, textBoxNazwisko.Text,
                        Convert.ToInt32(textBoxNrIndeksu.Text), textBoxKierunek.Text);
                    mainForm.DodajStudenta(s);
                    mainForm.DodajStudentaDoDataGridView(s);
                    this.DialogResult = DialogResult.OK;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
