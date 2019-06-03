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
        string  dbFile = "C:/dev/dbCadona.txt";
        string dbTemp = "C:/dev/dbCadonaTemp.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@dbFile);

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
            string[] lines = File.ReadAllLines(@path);

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
            string[] lines = File.ReadAllLines(@path);

            var firstLine = lines.First().Split('|').ToList();
            var lastLine = lines.Last().Split('|').ToList();
            var lista = lines.ToList();
            lista.RemoveAt(0);
            lista.RemoveAt(lista.Count - 1);
 

            if (firstLine[0] == "START" && lastLine[0] == "END")
            {
                if (lastLine[2] == "COMMIT")
                {
                    foreach (var item in lista)
                    {
                        var list = item.Split('|');
                        if (list[0] == "INSERIR")
                        {
                            string toDbFile = string.Format("{0}|{1}\r\n", list[1], list[2]);
                            File.AppendAllText("C:/dev/dbCadona.txt", toDbFile);
                            //Form1 frmzinho = new Form1();
                            //frmzinho.dataGridView1.Rows.Add(list[1], list[2]);
                            //frmzinho.dataGridView1.Refresh();
                            //frmzinho.Refresh();
                        }
                        if (list[0] == "REMOVER")
                        {
                            string[] dbFile = File.ReadAllLines("C:/dev/dbCadona.txt");
                            for(int i = 0; i<dbFile.Length; i++)
                            {
                                var lineFiles = dbFile[i].Split('|');
                                if(lineFiles[0] == list[1])
                                {
                                    //limpar linha do array aqui
                                    foreach (var toAppend in dbFile)
                                    {
                                        File.AppendAllText("C:/dev/dbCadona.txt", toAppend + "\r\t");
                                    }
                                    
                                }
                            }
                        }
                    }
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
