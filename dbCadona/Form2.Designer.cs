namespace dbCadona
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTransactions = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnActions = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAlert = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactions.Location = new System.Drawing.Point(243, 9);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(143, 29);
            this.lblTransactions.TabIndex = 5;
            this.lblTransactions.Text = "Transação ";
            this.lblTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Código,
            this.Nome});
            this.dataGridView1.Location = new System.Drawing.Point(12, 49);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(300, 173);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Código
            // 
            this.Código.FillWeight = 101.5228F;
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.FillWeight = 98.47716F;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.operacao,
            this.codigo,
            this.name});
            this.dataGridView2.Location = new System.Drawing.Point(318, 49);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(344, 173);
            this.dataGridView2.TabIndex = 7;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(12, 239);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(300, 45);
            this.btnInserir.TabIndex = 8;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnActions
            // 
            this.btnActions.Location = new System.Drawing.Point(89, 77);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(75, 23);
            this.btnActions.TabIndex = 13;
            this.btnActions.Text = "Actions";
            this.btnActions.UseVisualStyleBackColor = true;
            this.btnActions.Visible = false;
            this.btnActions.Click += new System.EventHandler(this.btnActions_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(170, 77);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(113, 23);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Visible = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(206, 20);
            this.txtName.TabIndex = 10;
            this.txtName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nome:";
            this.label2.Visible = false;
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(77, 14);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(68, 20);
            this.txtCod.TabIndex = 9;
            this.txtCod.Visible = false;
            this.txtCod.TextChanged += new System.EventHandler(this.txtCod_TextChanged);
            this.txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCod_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Código:";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDeletar);
            this.panel1.Controls.Add(this.txtCod);
            this.panel1.Controls.Add(this.btnActions);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Location = new System.Drawing.Point(12, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 112);
            this.panel1.TabIndex = 15;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(318, 239);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(166, 45);
            this.btnCommit.TabIndex = 16;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(490, 239);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(172, 45);
            this.btnRollback.TabIndex = 17;
            this.btnRollback.Text = "Rollback";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblAlert);
            this.panel2.Location = new System.Drawing.Point(319, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 34);
            this.panel2.TabIndex = 18;
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.Location = new System.Drawing.Point(11, 11);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(124, 13);
            this.lblAlert.TabIndex = 0;
            this.lblAlert.Text = "Aguardando Operação...";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(319, 348);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 69);
            this.panel3.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "OBS:\r\nPara alterar e/ou editar um item dê 2 cliques na lista.\r\nPressione COMMIT o" +
    "u ROLLBACK para finalizar a transação.";
            // 
            // operacao
            // 
            this.operacao.HeaderText = "Operação";
            this.operacao.Name = "operacao";
            this.operacao.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Nome";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(673, 429);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnActions;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn operacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}