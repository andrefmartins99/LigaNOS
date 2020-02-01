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
            this.SuspendLayout();
            // 
            // lblCampeao
            // 
            this.lblCampeao.AutoSize = true;
            this.lblCampeao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampeao.Location = new System.Drawing.Point(138, 83);
            this.lblCampeao.Name = "lblCampeao";
            this.lblCampeao.Size = new System.Drawing.Size(99, 32);
            this.lblCampeao.TabIndex = 0;
            this.lblCampeao.Text = "label1";
            // 
            // Campeao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCampeao);
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.Name = "Campeao";
            this.Text = "Campeao";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Campeao_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCampeao;
    }
}