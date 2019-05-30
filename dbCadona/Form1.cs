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
using System.Collections;

namespace dbCadona
{
    public partial class Form1 : Form
    {
        int contTransactions = 0;
        string dbFile;

        public Form1()
        {
            this.dbFile = "C:/dev/dbCadona.txt";

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(@dbFile);

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }

            string[] fileEntries = Directory.GetFiles(@"C:\dev\transacoes");

            foreach (string fileName in fileEntries)
                processBreakFile(fileName);
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            contTransactions++;
            new DbLog("TRANSACAO " + contTransactions + " INICIADA");
            Form2 newForm = new Form2(contTransactions);
            newForm.Show();
        }

        private void btnCheckpoint_Click(object sender, EventArgs e)
        {
            string[] fileEntries = Directory.GetFiles(@"C:\dev\transacoes");

            foreach (string fileName in fileEntries)
                processFile(fileName);
        }

        public static void processBreakFile(string path)
        {
            var lines = File.ReadAllLines(@path);

            var firstLine = lines.First().Split('|').ToList();
            var lastLine = lines.Last().Split('|').ToList();

            if (lastLine[0] != "END")
            {
                Form3 newForm = new Form3(path);
                newForm.ShowDialog();
            }
        }
        
        public static void processFile(string path)
        {
            var lines = File.ReadAllLines(@path);

            var firstLine = lines.First().Split('|').ToList();
            var lastLine = lines.Last().Split('|').ToList();

            if (firstLine[0] == "START" && lastLine[0] == "END")
            {
                if (lastLine[2] == "COMMIT")
                {
                    
                    return;
                }
                else
                {
                    File.Delete(path);
                    return;
                }
            }

            return;
        }
    }
}
