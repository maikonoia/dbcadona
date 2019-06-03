﻿using System;
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
        string dbFile;
        string dbFileTemp;

        public Form1()
        {
            this.dbFile = "C:/dev/dbCadona.txt";
            this.dbFileTemp = "C:/dev/dbCadonaTemp.txt";

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
        
        public void processFile(string path)
        {
            string[] lines = File.ReadAllLines(@path);

            var firstLine = lines.First().Split('|').ToList();
            var lastLine = lines.Last().Split('|').ToList();
            var lista = lines.ToList();
            lista.RemoveAt(0);
            lista.RemoveAt(lista.Count - 1);

            File.Copy(dbFile, dbFileTemp, true);

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
                            File.AppendAllText(dbFileTemp, toDbFile);
                        }
                        if (list[0] == "ALTERAR")
                        {
                            string[] dbFile = File.ReadAllLines(dbFileTemp);
                            for (int i = 0; i < dbFile.Length; i++)
                            {
                                var lineFiles = dbFile[i].Split('|');
                                if (lineFiles[0] == list[1])
                                {
                                    dbFile[i] = string.Format(list[2] + "|" + list[3]);
                                    File.WriteAllLines(dbFileTemp, dbFile);
                                }
                            }

                        }
                        if (list[0] == "REMOVER")
                        {
                            string[] dbFile = File.ReadAllLines(dbFileTemp);
                            for (int i = 0; i < dbFile.Length; i++)
                            {
                                var lineFiles = dbFile[i].Split('|');
                                if (lineFiles[0] == list[1])
                                {
                                    dbFile[i] = null;
                                    File.WriteAllLines(dbFileTemp, dbFile);
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

                string file = File.ReadAllText(dbFileTemp);
                var resultString = Regex.Replace(file, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                File.WriteAllText(dbFileTemp, resultString);
                File.Copy(dbFileTemp, dbFile, true);

                File.Delete(dbFileTemp);
            }

            return;
        }
    }
}
