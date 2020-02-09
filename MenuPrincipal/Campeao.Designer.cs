namespace MenuPrincipal
{
    partial class Campeao
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
            this.lblCampeao = new System.Windows.Forms.Label();
            this.btnTerminarCampeonato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCampeao
            // 
            this.lblCampeao.AutoSize = true;
            this.lblCampeao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampeao.Location = new System.Drawing.Point(104, 67);
            this.lblCampeao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCampeao.Name = "lblCampeao";
            this.lblCampeao.Size = new System.Drawing.Size(76, 26);
            this.lblCampeao.TabIndex = 0;
            this.lblCampeao.Text = "label1";
            // 
            // btnTerminarCampeonato
            // 
            this.btnTerminarCampeonato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminarCampeonato.Location = new System.Drawing.Point(435, 277);
            this.btnTerminarCampeonato.Name = "btnTerminarCampeonato";
            this.btnTerminarCampeonato.Size = new System.Drawing.Size(137, 51);
            this.btnTerminarCampeonato.TabIndex = 1;
            this.btnTerminarCampeonato.Text = "Terminar Campeonato";
            this.btnTerminarCampeonato.UseVisualStyleBackColor = true;
            this.btnTerminarCampeonato.Click += new System.EventHandler(this.btnTerminarCampeonato_Click);
            // 
            // Campeao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnTerminarCampeonato);
            this.Controls.Add(this.lblCampeao);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(618, 411);
            this.Name = "Campeao";
            this.Text = "Campeao";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Campeao_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCampeao;
        private System.Windows.Forms.Button btnTerminarCampeonato;
    }
}