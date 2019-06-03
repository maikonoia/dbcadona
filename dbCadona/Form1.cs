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
using System.Text.RegularExpressions;

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
            string[] fileEntries = Directory.GetFiles(@"C:\dev\transacoes");

            foreach (string fileName in fileEntries)
                processBreakFile(fileName);

            string[] lines = File.ReadAllLines(@dbFile);

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }
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

            dataGridView1.Rows.Clear();

            string[] lines = File.ReadAllLines(@dbFile);

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }

            dataGridView1.Refresh();

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

            File.Copy("C:/dev/dbCadona.txt", "C:/dev/dbCadonaTemp.txt", true);

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
                            File.AppendAllText("C:/dev/dbCadonaTemp.txt", toDbFile);
                        }
                        if (list[0] == "ALTERAR")
                        {
                            string[] dbFile = File.ReadAllLines("C:/dev/dbCadonaTemp.txt");
                            for (int i = 0; i < dbFile.Length; i++)
                            {
                                var lineFiles = dbFile[i].Split('|');
                                if (lineFiles[0] == list[1])
                                {
                                    dbFile[i] = string.Format(list[2] + "|" + list[3]);
                                    File.WriteAllLines("C:/dev/dbCadonaTemp.txt", dbFile);
                                }
                            }

                        }
                        if (list[0] == "REMOVER")
                        {
                            string[] dbFile = File.ReadAllLines("C:/dev/dbCadonaTemp.txt");
                            for (int i = 0; i < dbFile.Length; i++)
                            {
                                var lineFiles = dbFile[i].Split('|');
                                if (lineFiles[0] == list[1])
                                {
                                    dbFile[i] = null;
                                    File.WriteAllLines("C:/dev/dbCadonaTemp.txt", dbFile);
                                }
                            }
                        }
                    }
                    File.Delete(path);
                }
                else
                {
                    File.Delete(path);
                    return;
                }

                string file = File.ReadAllText("C:/dev/dbCadonaTemp.txt");
                var resultString = Regex.Replace(file, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                File.WriteAllText("C:/dev/dbCadonaTemp.txt", resultString);
                File.Copy("C:/dev/dbCadonaTemp.txt", "C:/dev/dbCadona.txt", true);

                File.Delete("C:/dev/dbCadonaTemp.txt");
            }

            return;
        }
    }
}
