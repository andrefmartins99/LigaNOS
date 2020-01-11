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
            this.SuspendLayout();
            // 
            // lblclubeInfo
            // 
            this.lblclubeInfo.AutoSize = true;
            this.lblclubeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclubeInfo.Location = new System.Drawing.Point(235, 338);
            this.lblclubeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblclubeInfo.Name = "lblclubeInfo";
            this.lblclubeInfo.Size = new System.Drawing.Size(53, 20);
            this.lblclubeInfo.TabIndex = 0;
            this.lblclubeInfo.Text = "label1";
            // 
            // btnCriarClube
            // 
            this.btnCriarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarClube.Location = new System.Drawing.Point(93, 327);
            this.btnCriarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCriarClube.Name = "btnCriarClube";
            this.btnCriarClube.Size = new System.Drawing.Size(133, 43);
            this.btnCriarClube.TabIndex = 1;
            this.btnCriarClube.Text = "Criar Clube";
            this.btnCriarClube.UseVisualStyleBackColor = true;
            this.btnCriarClube.Visible = false;
            this.btnCriarClube.Click += new System.EventHandler(this.btnCriarClube_Click);
            // 
            // listBoxClubes
            // 
            this.listBoxClubes.FormattingEnabled = true;
            this.listBoxClubes.ItemHeight = 16;
            this.listBoxClubes.Location = new System.Drawing.Point(93, 385);
            this.listBoxClubes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxClubes.Name = "listBoxClubes";
            this.listBoxClubes.Size = new System.Drawing.Size(403, 132);
            this.listBoxClubes.TabIndex = 2;
            // 
            // btnComecar
            // 
            this.btnComecar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComecar.Location = new System.Drawing.Point(355, 320);
            this.btnComecar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComecar.Name = "btnComecar";
            this.btnComecar.Size = new System.Drawing.Size(143, 58);
            this.btnComecar.TabIndex = 3;
            this.btnComecar.Text = "Começar Campeonato";
            this.btnComecar.UseVisualStyleBackColor = true;
            this.btnComecar.Visible = false;
            this.btnComecar.Click += new System.EventHandler(this.btnComecar_Click);
            // 
            // btnEditarClube
            // 
            this.btnEditarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarClube.Location = new System.Drawing.Point(123, 544);
            this.btnEditarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarClube.Name = "btnEditarClube";
            this.btnEditarClube.Size = new System.Drawing.Size(141, 53);
            this.btnEditarClube.TabIndex = 4;
            this.btnEditarClube.Text = "Editar Clube";
            this.btnEditarClube.UseVisualStyleBackColor = true;
            this.btnEditarClube.Click += new System.EventHandler(this.btnEditarClube_Click);
            // 
            // btnApagarClube
            // 
            this.btnApagarClube.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarClube.Location = new System.Drawing.Point(303, 544);
            this.btnApagarClube.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApagarClube.Name = "btnApagarClube";
            this.btnApagarClube.Size = new System.Drawing.Size(153, 53);
            this.btnApagarClube.TabIndex = 5;
            this.btnApagarClube.Text = "Apagar Clube";
            this.btnApagarClube.UseVisualStyleBackColor = true;
            this.btnApagarClube.Click += new System.EventHandler(this.btnApagarClube_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 657);
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
    }
}

