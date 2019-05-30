using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace dbCadona
{
    public partial class Form1 : Form
    {
        int contTransactions = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\dev\teste.txt");

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contTransactions++;
            Form2 newForm = new Form2(contTransactions);
            newForm.Show();
        }
    }
}
