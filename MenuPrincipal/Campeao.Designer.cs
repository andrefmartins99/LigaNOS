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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Campeao));
            this.lblCampeao = new System.Windows.Forms.Label();
            this.btnTerminarCampeonato = new System.Windows.Forms.Button();
            this.lblEstatisticaCampeao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCampeao
            // 
            this.lblCampeao.AutoSize = true;
            this.lblCampeao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampeao.Location = new System.Drawing.Point(63, 66);
            this.lblCampeao.Name = "lblCampeao";
            this.lblCampeao.Size = new System.Drawing.Size(99, 32);
            this.lblCampeao.TabIndex = 0;
            this.lblCampeao.Text = "label1";
            // 
            // btnTerminarCampeonato
            // 
            this.btnTerminarCampeonato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminarCampeonato.Location = new System.Drawing.Point(580, 341);
            this.btnTerminarCampeonato.Margin = new System.Windows.Forms.Padding(4);
            this.btnTerminarCampeonato.Name = "btnTerminarCampeonato";
            this.btnTerminarCampeonato.Size = new System.Drawing.Size(183, 63);
            this.btnTerminarCampeonato.TabIndex = 1;
            this.btnTerminarCampeonato.Text = "Terminar Campeonato";
            this.btnTerminarCampeonato.UseVisualStyleBackColor = true;
            this.btnTerminarCampeonato.Click += new System.EventHandler(this.btnTerminarCampeonato_Click);
            // 
            // lblEstatisticaCampeao
            // 
            this.lblEstatisticaCampeao.AutoSize = true;
            this.lblEstatisticaCampeao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatisticaCampeao.Location = new System.Drawing.Point(64, 125);
            this.lblEstatisticaCampeao.Name = "lblEstatisticaCampeao";
            this.lblEstatisticaCampeao.Size = new System.Drawing.Size(64, 25);
            this.lblEstatisticaCampeao.TabIndex = 2;
            this.lblEstatisticaCampeao.Text = "label1";
            // 
            // Campeao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.lblEstatisticaCampeao);
            this.Controls.Add(this.btnTerminarCampeonato);
            this.Controls.Add(this.lblCampeao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(818, 495);
            this.Name = "Campeao";
            this.Text = "Campeao";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Campeao_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCampeao;
        private System.Windows.Forms.Button btnTerminarCampeonato;
        private System.Windows.Forms.Label lblEstatisticaCampeao;
    }
}