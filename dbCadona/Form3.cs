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
using System.Text.RegularExpressions;

namespace dbCadona
{
    public partial class Form3 : Form
    {
        string filePath;
        string dbFile;

        public Form3(string path)
        {
            this.ControlBox = false;
            this.filePath = path;
            this.dbFile = "C:/dev/dbCadona.txt";

            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            new DbLog("RECUPERACAO DE FALHA ARQUIVO DE TRANSACAO " + filePath + " INICIADO");

            var lines = File.ReadAllLines(@dbFile);

            foreach (var item in lines)
            {
                var line = item.Split('|').ToList();
                dataGridView1.Rows.Add(line[0], line[1].Replace(";", ""));
            }

            lines = File.ReadAllLines(@filePath);

            foreach (var item in lines.Skip(1))
            {
                var line = item.Split('|').ToList();
                if (line[0] == "ALTERAR")
                {
                    dataGridView2.Rows.Add(line[0], line[2], line[3].Replace(";", ""));
                }
                else
                {
                    dataGridView2.Rows.Add(line[0], line[1], line[2].Replace(";", ""));
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            new DbLog("ARQUIVO DE TRANSACAO " + dbFile + " DESFEITO(UNDO)");
            File.Delete(filePath);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processFile(filePath);
            this.Close();
        }

        public static void processFile(string path)
        {
            string[] lines = File.ReadAllLines(@path);

            var lista = lines.ToList();

            File.Copy("C:/dev/dbCadona.txt", "C:/dev/dbCadonaTemp.txt", true);

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

            string file = File.ReadAllText("C:/dev/dbCadonaTemp.txt");
            var resultString = Regex.Replace(file, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            File.WriteAllText("C:/dev/dbCadonaTemp.txt", resultString);
            File.Copy("C:/dev/dbCadonaTemp.txt", "C:/dev/dbCadona.txt", true);

            File.Delete("C:/dev/dbCadonaTemp.txt");

        }
    }
}
