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
    public partial class Main : Form
    {
        private List<Student> studenci = new List<Student>();

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajStudenta addStudentForm = new DodajStudenta(this);
            DialogResult dr = addStudentForm.ShowDialog();
            if(dr == DialogResult.OK)
            {
                MessageBox.Show("Dodano Studenta");
            }
        }
        public void DodajStudenta(Student s)
        {
            studenci.Add(s);
        }
        public void DodajStudentaDoDataGridView(Student s)
        {
            dataGridView1.Rows.Add(s.Imie, s.Nazwisko, s.Nr_indeksu, s.Kierunek);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}
