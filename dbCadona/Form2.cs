using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dbCadona
{
    public partial class Form2 : Form
    {
        string title;
        string op;
        int contTransactions = 0;


        public Form2(int contTransactions)
        {
            this.contTransactions = contTransactions;

            //if (crudMode == "INSERT" )
            //{
            //    BdModel newObject = new BdModel();
            //    title = "INSERIR";
            //    this.contTransactions  = contTransactions;
            //} else if(crudMode == "UPDATE")
            //{
            //    title = "ATUALIZAR";
            //    this.contTransactions = contTransactions;
            //}

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\dev\teste.txt");

            foreach (var item in lines)
            {
                dataGridView1.Rows.Add(item.Substring(0, 1), item.Substring(3).Replace(";", ""));
            }

            lblTransactions.Text += contTransactions.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            op = "ALTERAR";
            txtCod.Visible = true;
            txtName.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            btnActions.Visible = true;
            btnActions.Text = "Alterar";
            btnDeletar.Visible = true;
            
            txtCod.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedCells[1].Value.ToString();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            op = "INSERIR";
            txtCod.Text = "";
            txtName.Text = "";
            btnDeletar.Visible = false;
            txtCod.Visible = true;
            txtName.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            btnActions.Visible = true;
            btnActions.Text = "Inserir";
        }

        private void btnActions_Click(object sender, EventArgs e)
        {
            if (op == "ALTERAR")
            {
                var lines = System.IO.File.ReadAllLines(@"C:\dev\teste.txt");

                for(int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Substring(0, 1) == dataGridView1.SelectedCells[0].Value.ToString())
                    {
                        lines[i] = txtCod.Text + "-" + txtName.Text + "-" + op;
                    }
                }

                //foreach (string item in lines)
                //{
                //    if(item.Substring(0, 1) == txtCod.Text)
                //    {
                //        item = txtCod.Text + "-" + txtName.Text + "-" + op;
                //    }
                //}
            }

           // File.AppendAllText(string.Format(@"C:\dev\transacao{0}.txt", contTransactions), txtCod.Text + "-" + txtName.Text + "-" +  op +  ";\r\n");
        }
    }
}
