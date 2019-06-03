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

        }
    }
}
