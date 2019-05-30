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

        private void button1_Click(object sender, EventArgs e)
        {
            contTransactions++;
            Form2 newForm = new Form2(contTransactions);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\dev\teste.txt");

            foreach (var item in lines)
            {
                dataGridView1.Rows.Add(item.Substring(0, 1), item.Substring(3).Replace(";", ""));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    contTransactions++;
        //    BdModel newObject = new BdModel();
        //    //newObject.idPatrimony = dataGridView1.SelectedCells[0].Value.ToString();
        //    //newObject.namePatrimony = dataGridView1.SelectedCells[1].Value.ToString();
        //    Form2 newForm = new Form2(contTransactions);
        //    newForm.Show();
        }
    }
}
