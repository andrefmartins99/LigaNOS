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
            ((System.ComponentModel.ISupportInitialize)(this.dgvJornadas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblclubeInfo
            // 
            this.lblclubeInfo.AutoSize = true;
            this.lblclubeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclubeInfo.Location = new System.Drawing.Point(176, 275);
            this.lblclubeInfo.Name = "lblclubeInfo";
            this.lblclubeInfo.Size = new System.Drawing.Size(45, 16);
            this.lblclubeInfo.TabIndex = 0;
            this.lblclubeInfo.Text = "label1";
            // 
            // btnCriarClube
            // 
            this.btnCriarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarClube.Location = new System.Drawing.Point(70, 266);
            this.btnCriarClube.Name = "btnCriarClube";
            this.btnCriarClube.Size = new System.Drawing.Size(100, 35);
            this.btnCriarClube.TabIndex = 1;
            this.btnCriarClube.Text = "Criar Clube";
            this.btnCriarClube.UseVisualStyleBackColor = true;
            this.btnCriarClube.Visible = false;
            this.btnCriarClube.Click += new System.EventHandler(this.btnCriarClube_Click);
            // 
            // listBoxClubes
            // 
            this.listBoxClubes.FormattingEnabled = true;
            this.listBoxClubes.Location = new System.Drawing.Point(70, 313);
            this.listBoxClubes.Name = "listBoxClubes";
            this.listBoxClubes.Size = new System.Drawing.Size(303, 108);
            this.listBoxClubes.TabIndex = 2;
            // 
            // btnComecar
            // 
            this.btnComecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComecar.Location = new System.Drawing.Point(266, 260);
            this.btnComecar.Name = "btnComecar";
            this.btnComecar.Size = new System.Drawing.Size(107, 47);
            this.btnComecar.TabIndex = 3;
            this.btnComecar.Text = "Começar Campeonato";
            this.btnComecar.UseVisualStyleBackColor = true;
            this.btnComecar.Visible = false;
            this.btnComecar.Click += new System.EventHandler(this.btnComecar_Click);
            // 
            // btnEditarClube
            // 
            this.btnEditarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarClube.Location = new System.Drawing.Point(92, 442);
            this.btnEditarClube.Name = "btnEditarClube";
            this.btnEditarClube.Size = new System.Drawing.Size(106, 43);
            this.btnEditarClube.TabIndex = 4;
            this.btnEditarClube.Text = "Editar Clube";
            this.btnEditarClube.UseVisualStyleBackColor = true;
            this.btnEditarClube.Click += new System.EventHandler(this.btnEditarClube_Click);
            // 
            // btnApagarClube
            // 
            this.btnApagarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarClube.Location = new System.Drawing.Point(227, 442);
            this.btnApagarClube.Name = "btnApagarClube";
            this.btnApagarClube.Size = new System.Drawing.Size(115, 43);
            this.btnApagarClube.TabIndex = 5;
            this.btnApagarClube.Text = "Apagar Clube";
            this.btnApagarClube.UseVisualStyleBackColor = true;
            this.btnApagarClube.Click += new System.EventHandler(this.btnApagarClube_Click);
            // 
            // dgvJornadas
            // 
            this.dgvJornadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJornadas.Location = new System.Drawing.Point(398, 260);
            this.dgvJornadas.Name = "dgvJornadas";
            this.dgvJornadas.Size = new System.Drawing.Size(370, 110);
            this.dgvJornadas.TabIndex = 6;
            this.dgvJornadas.Visible = false;
            // 
            // cbJornadas
            // 
            this.cbJornadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJornadas.FormattingEnabled = true;
            this.cbJornadas.Location = new System.Drawing.Point(542, 199);
            this.cbJornadas.Name = "cbJornadas";
            this.cbJornadas.Size = new System.Drawing.Size(121, 21);
            this.cbJornadas.TabIndex = 7;
            this.cbJornadas.Visible = false;
            this.cbJornadas.SelectedIndexChanged += new System.EventHandler(this.cbJornadas_SelectedIndexChanged);
            // 
            // lblJornadasInfo
            // 
            this.lblJornadasInfo.AutoSize = true;
            this.lblJornadasInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJornadasInfo.Location = new System.Drawing.Point(457, 200);
            this.lblJornadasInfo.Name = "lblJornadasInfo";
            this.lblJornadasInfo.Size = new System.Drawing.Size(79, 20);
            this.lblJornadasInfo.TabIndex = 8;
            this.lblJornadasInfo.Text = "Jornada:";
            this.lblJornadasInfo.Visible = false;
            // 
            // btnMostrarClassificacao
            // 
            this.btnMostrarClassificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarClassificacao.Location = new System.Drawing.Point(516, 404);
            this.btnMostrarClassificacao.Name = "btnMostrarClassificacao";
            this.btnMostrarClassificacao.Size = new System.Drawing.Size(129, 60);
            this.btnMostrarClassificacao.TabIndex = 9;
            this.btnMostrarClassificacao.Text = "Mostrar Classificação";
            this.btnMostrarClassificacao.UseVisualStyleBackColor = true;
            this.btnMostrarClassificacao.Visible = false;
            this.btnMostrarClassificacao.Click += new System.EventHandler(this.btnMostrarClassificacao_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 534);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

