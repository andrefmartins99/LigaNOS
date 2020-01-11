namespace LigaNos.Forms
{
    partial class Form1
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
            this.btnCriarClube = new System.Windows.Forms.Button();
            this.lblclubeInfo = new System.Windows.Forms.Label();
            this.listBoxClubes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCriarClube
            // 
            this.btnCriarClube.Location = new System.Drawing.Point(123, 282);
            this.btnCriarClube.Name = "btnCriarClube";
            this.btnCriarClube.Size = new System.Drawing.Size(75, 23);
            this.btnCriarClube.TabIndex = 2;
            this.btnCriarClube.Text = "Criar Clube";
            this.btnCriarClube.UseVisualStyleBackColor = true;
            this.btnCriarClube.Visible = false;
            // 
            // lblclubeInfo
            // 
            this.lblclubeInfo.AutoSize = true;
            this.lblclubeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclubeInfo.Location = new System.Drawing.Point(204, 285);
            this.lblclubeInfo.Name = "lblclubeInfo";
            this.lblclubeInfo.Size = new System.Drawing.Size(45, 16);
            this.lblclubeInfo.TabIndex = 3;
            this.lblclubeInfo.Text = "label1";
            // 
            // listBoxClubes
            // 
            this.listBoxClubes.FormattingEnabled = true;
            this.listBoxClubes.Location = new System.Drawing.Point(123, 311);
            this.listBoxClubes.Name = "listBoxClubes";
            this.listBoxClubes.Size = new System.Drawing.Size(292, 160);
            this.listBoxClubes.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.listBoxClubes);
            this.Controls.Add(this.lblclubeInfo);
            this.Controls.Add(this.btnCriarClube);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCriarClube;
        private System.Windows.Forms.Label lblclubeInfo;
        private System.Windows.Forms.ListBox listBoxClubes;
    }
}

