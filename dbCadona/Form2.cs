using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbCadona
{
    public partial class Form2 : Form
    {
        string op;
        string dbFile;
        int contTransactions = 0;

        public Form2(int contTransactions)
        {
            this.dbFile = "C:/dev/dbCadona.txt";
            this.contTransactions = contTransactions;
            this.ControlBox = false;

            InitializeComponent();

            this.Text = string.Format("Transação {0}", contTransactions);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(@dbFile);

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }

            lblTransactions.Text += contTransactions.ToString();

            File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), "START|TRANSACAO" + contTransactions + "\r\n");
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

            var lines = File.ReadAllLines(@dbFile);

            if (op == "INSERIR")
            {
                foreach (var item in lines)
                {
                    var line = item.Split('|').ToList();
                    if (txtCod.Text == line[0])
                    {
                        MessageBox.Show("O Código inserido já existe, utilize outro.");
                        return;
                    }
                }

                foreach (DataGridViewRow dataGridViewRow in dataGridView2.Rows)
                {
                    var item = Convert.ToString(dataGridViewRow.Cells["codigo"].Value);
                    if (txtCod.Text == item)
                    {
                        MessageBox.Show("O Código já foi inserido, utilize outro.");
                        return;
                    }
                }

                File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), op + "|" + txtCod.Text + "|" + txtName.Text + ";\r\n");
            }

            if (op == "ALTERAR")
            {
                foreach (var item in lines)
                {
                    var line = item.Split('|').ToList();
                    if (txtCod.Text != dataGridView1.SelectedCells[0].Value.ToString() && txtCod.Text == line[0])
                    {
                        MessageBox.Show("O Código inserido já existe, utilize outro.");
                        return;
                    }
                }

                foreach (DataGridViewRow dataGridViewRow in dataGridView2.Rows)
                {
                    var item = Convert.ToString(dataGridViewRow.Cells["codigo"].Value);
                    if (txtCod.Text == item)
                    {
                        MessageBox.Show("O Código já foi inserido, utilize outro.");
                        return;
                    }
                }

                File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), op + "|" + dataGridView1.SelectedCells[0].Value.ToString() + "|" + txtCod.Text + "|" + txtName.Text + ";\r\n");
            }

            dataGridView2.Rows.Add(op, txtCod.Text, txtName.Text);

            DisplayAlert(string.Format("Operação {0} efetuada.", op));
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "")
            {
                MessageBox.Show("O campo Código precisa estar preenchido.");
                return;
            }

            File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), "REMOVER|" + txtCod.Text + "|" + txtName.Text + ";\r\n");
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
            File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), "END|TRANSACAO" + contTransactions + "|COMMIT");
            this.Close();
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            new DbLog("TESTE");

            File.AppendAllText(string.Format(@"C:\dev\transacoes\transacao{0}.txt", contTransactions), "END|TRANSACAO" + contTransactions + "|ROLLBACK");
            this.Close();
        }
    }
}
