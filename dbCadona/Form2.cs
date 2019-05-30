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
            this.ControlBox = false;

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

            this.Text = string.Format("Transação {0}", contTransactions);
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
            if (txtCod.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Os campos Código e Nome precisam ser preenchidos.");
                return;
            }

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

            dataGridView2.Rows.Add(op, txtCod.Text, txtName.Text);

            File.AppendAllText(string.Format(@"C:\dev\transacao{0}.txt", contTransactions), txtCod.Text + "-" + txtName.Text + "-" +  op +  ";\r\n");

            DisplayAlert(string.Format("Operação {0} efetuada.", op));
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show("O campo Código precisa estar preenchido.");
                return;
            }

            File.AppendAllText(string.Format(@"C:\dev\transacao{0}.txt", contTransactions), txtCod.Text + "-" + txtName.Text + "-" + op + ";\r\n");
            dataGridView2.Rows.Add("REMOVER", txtCod.Text, dataGridView1.SelectedCells[0].Value.ToString());

            DisplayAlert("Operação REMOVER efetuada.");
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCod.Text, "  ^ [0-9]"))
            {
                txtCod.Text = "";
            }
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void DisplayAlert(String message, int Interval = 3000)
        {
            var timer = new Timer();
            timer.Interval = Interval;
            lblAlert.Text = message;

            timer.Tick += (s, en) => {
                lblAlert.Text = "Aguardando nova Operação...";
                timer.Stop();
            };

            timer.Start();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
