namespace ProjetoDKR.Components
{
    partial class ProdutoItem
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutoItem));
            this.txtQuant = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.Label();
            this.txtProd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImgProd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProd)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuant
            // 
            this.txtQuant.AutoSize = true;
            this.txtQuant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuant.Location = new System.Drawing.Point(295, 12);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(21, 16);
            this.txtQuant.TabIndex = 15;
            this.txtQuant.Text = "05";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AutoSize = true;
            this.txtDescricao.BackColor = System.Drawing.Color.Transparent;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(51, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(157, 16);
            this.txtDescricao.TabIndex = 16;
            this.txtDescricao.Text = "Descrição do Produto 1...";
            // 
            // txtProd
            // 
            this.txtProd.AutoSize = true;
            this.txtProd.BackColor = System.Drawing.Color.Transparent;
            this.txtProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProd.Location = new System.Drawing.Point(51, 3);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(82, 18);
            this.txtProd.TabIndex = 17;
            this.txtProd.Text = "Produto 1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(3, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 10);
            this.label1.TabIndex = 19;
            // 
            // ImgProd
            // 
            this.ImgProd.BackColor = System.Drawing.Color.Transparent;
            this.ImgProd.Image = ((System.Drawing.Image)(resources.GetObject("ImgProd.Image")));
            this.ImgProd.Location = new System.Drawing.Point(4, 3);
            this.ImgProd.Name = "ImgProd";
            this.ImgProd.Size = new System.Drawing.Size(44, 42);
            this.ImgProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgProd.TabIndex = 20;
            this.ImgProd.TabStop = false;
            // 
            // ProdutoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuant);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.ImgProd);
            this.Name = "ProdutoItem";
            this.Size = new System.Drawing.Size(327, 67);
            ((System.ComponentModel.ISupportInitialize)(this.ImgProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtQuant;
        private System.Windows.Forms.Label txtDescricao;
        private System.Windows.Forms.Label txtProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ImgProd;
    }
}
