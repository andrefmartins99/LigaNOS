namespace MenuPrincipal
{
    partial class MenuPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblclubeInfo = new System.Windows.Forms.Label();
            this.btnCriarClube = new System.Windows.Forms.Button();
            this.listBoxClubes = new System.Windows.Forms.ListBox();
            this.btnComecar = new System.Windows.Forms.Button();
            this.btnEditarClube = new System.Windows.Forms.Button();
            this.btnApagarClube = new System.Windows.Forms.Button();
            this.dgvJornadas = new System.Windows.Forms.DataGridView();
            this.cbJornadas = new System.Windows.Forms.ComboBox();
            this.lblJornadasInfo = new System.Windows.Forms.Label();
            this.btnMostrarClassificacao = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGerarResultados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblclubeInfo
            // 
            this.lblclubeInfo.AutoSize = true;
            this.lblclubeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclubeInfo.Location = new System.Drawing.Point(243, 290);
            this.lblclubeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblclubeInfo.Name = "lblclubeInfo";
            this.lblclubeInfo.Size = new System.Drawing.Size(64, 25);
            this.lblclubeInfo.TabIndex = 0;
            this.lblclubeInfo.Text = "label1";
            // 
            // btnCriarClube
            // 
            this.btnCriarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarClube.Location = new System.Drawing.Point(93, 272);
            this.btnCriarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCriarClube.Name = "btnCriarClube";
            this.btnCriarClube.Size = new System.Drawing.Size(141, 58);
            this.btnCriarClube.TabIndex = 1;
            this.btnCriarClube.Text = "Criar Clube";
            this.btnCriarClube.UseVisualStyleBackColor = true;
            this.btnCriarClube.Visible = false;
            this.btnCriarClube.Click += new System.EventHandler(this.btnCriarClube_Click);
            // 
            // listBoxClubes
            // 
            this.listBoxClubes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClubes.FormattingEnabled = true;
            this.listBoxClubes.ItemHeight = 25;
            this.listBoxClubes.Location = new System.Drawing.Point(93, 338);
            this.listBoxClubes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxClubes.Name = "listBoxClubes";
            this.listBoxClubes.Size = new System.Drawing.Size(463, 204);
            this.listBoxClubes.TabIndex = 2;
            // 
            // btnComecar
            // 
            this.btnComecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComecar.Location = new System.Drawing.Point(403, 272);
            this.btnComecar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComecar.Name = "btnComecar";
            this.btnComecar.Size = new System.Drawing.Size(152, 58);
            this.btnComecar.TabIndex = 3;
            this.btnComecar.Text = "Começar Campeonato";
            this.btnComecar.UseVisualStyleBackColor = true;
            this.btnComecar.Visible = false;
            this.btnComecar.Click += new System.EventHandler(this.btnComecar_Click);
            // 
            // btnEditarClube
            // 
            this.btnEditarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarClube.Location = new System.Drawing.Point(141, 560);
            this.btnEditarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarClube.Name = "btnEditarClube";
            this.btnEditarClube.Size = new System.Drawing.Size(149, 53);
            this.btnEditarClube.TabIndex = 4;
            this.btnEditarClube.Text = "Editar Clube";
            this.btnEditarClube.UseVisualStyleBackColor = true;
            this.btnEditarClube.Click += new System.EventHandler(this.btnEditarClube_Click);
            // 
            // btnApagarClube
            // 
            this.btnApagarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarClube.Location = new System.Drawing.Point(350, 560);
            this.btnApagarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApagarClube.Name = "btnApagarClube";
            this.btnApagarClube.Size = new System.Drawing.Size(160, 53);
            this.btnApagarClube.TabIndex = 5;
            this.btnApagarClube.Text = "Apagar Clube";
            this.btnApagarClube.UseVisualStyleBackColor = true;
            this.btnApagarClube.Click += new System.EventHandler(this.btnApagarClube_Click);
            // 
            // dgvJornadas
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJornadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvJornadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJornadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvJornadas.Location = new System.Drawing.Point(453, 92);
            this.dgvJornadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvJornadas.Name = "dgvJornadas";
            this.dgvJornadas.ReadOnly = true;
            this.dgvJornadas.RowHeadersVisible = false;
            this.dgvJornadas.RowHeadersWidth = 51;
            this.dgvJornadas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvJornadas.Size = new System.Drawing.Size(697, 145);
            this.dgvJornadas.TabIndex = 6;
            this.dgvJornadas.Visible = false;
            // 
            // cbJornadas
            // 
            this.cbJornadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJornadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJornadas.FormattingEnabled = true;
            this.cbJornadas.Location = new System.Drawing.Point(764, 39);
            this.cbJornadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbJornadas.Name = "cbJornadas";
            this.cbJornadas.Size = new System.Drawing.Size(160, 30);
            this.cbJornadas.TabIndex = 7;
            this.cbJornadas.Visible = false;
            this.cbJornadas.SelectedIndexChanged += new System.EventHandler(this.cbJornadas_SelectedIndexChanged);
            // 
            // lblJornadasInfo
            // 
            this.lblJornadasInfo.AutoSize = true;
            this.lblJornadasInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJornadasInfo.Location = new System.Drawing.Point(659, 46);
            this.lblJornadasInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJornadasInfo.Name = "lblJornadasInfo";
            this.lblJornadasInfo.Size = new System.Drawing.Size(98, 25);
            this.lblJornadasInfo.TabIndex = 8;
            this.lblJornadasInfo.Text = "Jornada:";
            this.lblJornadasInfo.Visible = false;
            // 
            // btnMostrarClassificacao
            // 
            this.btnMostrarClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarClassificacao.Location = new System.Drawing.Point(752, 468);
            this.btnMostrarClassificacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrarClassificacao.Name = "btnMostrarClassificacao";
            this.btnMostrarClassificacao.Size = new System.Drawing.Size(172, 74);
            this.btnMostrarClassificacao.TabIndex = 9;
            this.btnMostrarClassificacao.Text = "Mostrar Classificação";
            this.btnMostrarClassificacao.UseVisualStyleBackColor = true;
            this.btnMostrarClassificacao.Visible = false;
            this.btnMostrarClassificacao.Click += new System.EventHandler(this.btnMostrarClassificacao_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column1.HeaderText = "Data Jogo";
            this.Column1.MinimumWidth = 120;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column2.HeaderText = "Clube Casa";
            this.Column2.MinimumWidth = 140;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column3.HeaderText = "Clube Fora";
            this.Column3.MinimumWidth = 140;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // Column4
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column4.HeaderText = "Resultado";
            this.Column4.MinimumWidth = 120;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // btnGerarResultados
            // 
            this.btnGerarResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarResultados.Location = new System.Drawing.Point(752, 290);
            this.btnGerarResultados.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerarResultados.Name = "btnGerarResultados";
            this.btnGerarResultados.Size = new System.Drawing.Size(172, 74);
            this.btnGerarResultados.TabIndex = 10;
            this.btnGerarResultados.Text = "Jogar Jornada";
            this.btnGerarResultados.UseVisualStyleBackColor = true;
            this.btnGerarResultados.Visible = false;
            this.btnGerarResultados.Click += new System.EventHandler(this.btnGerarResultados_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 657);
            this.Controls.Add(this.btnGerarResultados);
            this.Controls.Add(this.btnMostrarClassificacao);
            this.Controls.Add(this.lblJornadasInfo);
            this.Controls.Add(this.cbJornadas);
            this.Controls.Add(this.dgvJornadas);
            this.Controls.Add(this.btnApagarClube);
            this.Controls.Add(this.btnEditarClube);
            this.Controls.Add(this.btnComecar);
            this.Controls.Add(this.listBoxClubes);
            this.Controls.Add(this.btnCriarClube);
            this.Controls.Add(this.lblclubeInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuPrincipal";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblclubeInfo;
        private System.Windows.Forms.Button btnCriarClube;
        private System.Windows.Forms.ListBox listBoxClubes;
        private System.Windows.Forms.Button btnComecar;
        private System.Windows.Forms.Button btnEditarClube;
        private System.Windows.Forms.Button btnApagarClube;
        private System.Windows.Forms.DataGridView dgvJornadas;
        private System.Windows.Forms.ComboBox cbJornadas;
        private System.Windows.Forms.Label lblJornadasInfo;
        private System.Windows.Forms.Button btnMostrarClassificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnGerarResultados;
    }
}

