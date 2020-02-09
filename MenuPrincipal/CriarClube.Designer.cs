namespace MenuPrincipal
{
    partial class CriarClube
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriarClube));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTreinador = new System.Windows.Forms.TextBox();
            this.txtEstadio = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Treinador:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estádio:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(156, 32);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(220, 28);
            this.txtNome.TabIndex = 3;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // txtTreinador
            // 
            this.txtTreinador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTreinador.Location = new System.Drawing.Point(156, 66);
            this.txtTreinador.Margin = new System.Windows.Forms.Padding(4);
            this.txtTreinador.Name = "txtTreinador";
            this.txtTreinador.Size = new System.Drawing.Size(220, 28);
            this.txtTreinador.TabIndex = 4;
            this.txtTreinador.TextChanged += new System.EventHandler(this.txtTreinador_TextChanged);
            // 
            // txtEstadio
            // 
            this.txtEstadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadio.Location = new System.Drawing.Point(156, 101);
            this.txtEstadio.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstadio.Name = "txtEstadio";
            this.txtEstadio.Size = new System.Drawing.Size(220, 28);
            this.txtEstadio.TabIndex = 5;
            this.txtEstadio.TextChanged += new System.EventHandler(this.txtEstadio_TextChanged);
            // 
            // btnCriar
            // 
            this.btnCriar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriar.Location = new System.Drawing.Point(59, 178);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(124, 60);
            this.btnCriar.TabIndex = 6;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(248, 178);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 60);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CriarClube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 278);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.txtEstadio);
            this.Controls.Add(this.txtTreinador);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(447, 325);
            this.Name = "CriarClube";
            this.Text = "CriarClube";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CriarEquipa_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtTreinador;
        private System.Windows.Forms.TextBox txtEstadio;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnCancelar;
    }
}