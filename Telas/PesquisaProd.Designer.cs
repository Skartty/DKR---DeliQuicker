namespace ProjetoDKR
{
    partial class PesquisaProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesquisaProd));
            this.iconBusca = new System.Windows.Forms.Label();
            this.iconPerfilProd = new System.Windows.Forms.Label();
            this.txtFiltroMercado = new System.Windows.Forms.Label();
            this.BoxPesquisaProd = new System.Windows.Forms.TextBox();
            this.txtFiltroRestaurante = new System.Windows.Forms.Label();
            this.txtFiltroHortifrutti = new System.Windows.Forms.Label();
            this.painelProd = new System.Windows.Forms.Panel();
            this.IconBuscaProd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // iconBusca
            // 
            this.iconBusca.BackColor = System.Drawing.Color.Transparent;
            this.iconBusca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBusca.Image = ((System.Drawing.Image)(resources.GetObject("iconBusca.Image")));
            this.iconBusca.Location = new System.Drawing.Point(93, 807);
            this.iconBusca.Name = "iconBusca";
            this.iconBusca.Size = new System.Drawing.Size(30, 28);
            this.iconBusca.TabIndex = 6;
            this.iconBusca.Text = "      ";
            this.iconBusca.Click += new System.EventHandler(this.iconBusca_Click);
            // 
            // iconPerfilProd
            // 
            this.iconPerfilProd.BackColor = System.Drawing.Color.Transparent;
            this.iconPerfilProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPerfilProd.Image = ((System.Drawing.Image)(resources.GetObject("iconPerfilProd.Image")));
            this.iconPerfilProd.Location = new System.Drawing.Point(255, 807);
            this.iconPerfilProd.Name = "iconPerfilProd";
            this.iconPerfilProd.Size = new System.Drawing.Size(30, 28);
            this.iconPerfilProd.TabIndex = 7;
            this.iconPerfilProd.Text = "      ";
            this.iconPerfilProd.Click += new System.EventHandler(this.iconPerfilProd_Click);
            // 
            // txtFiltroMercado
            // 
            this.txtFiltroMercado.AutoSize = true;
            this.txtFiltroMercado.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltroMercado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFiltroMercado.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroMercado.Location = new System.Drawing.Point(42, 116);
            this.txtFiltroMercado.Name = "txtFiltroMercado";
            this.txtFiltroMercado.Size = new System.Drawing.Size(58, 19);
            this.txtFiltroMercado.TabIndex = 9;
            this.txtFiltroMercado.Text = "Mercado";
            this.txtFiltroMercado.Click += new System.EventHandler(this.txtFiltroMercado_Click);
            // 
            // BoxPesquisaProd
            // 
            this.BoxPesquisaProd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxPesquisaProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoxPesquisaProd.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxPesquisaProd.Location = new System.Drawing.Point(33, 34);
            this.BoxPesquisaProd.Multiline = true;
            this.BoxPesquisaProd.Name = "BoxPesquisaProd";
            this.BoxPesquisaProd.Size = new System.Drawing.Size(324, 42);
            this.BoxPesquisaProd.TabIndex = 8;
            this.BoxPesquisaProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoxPesquisaProd_KeyDown);
            // 
            // txtFiltroRestaurante
            // 
            this.txtFiltroRestaurante.AutoSize = true;
            this.txtFiltroRestaurante.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltroRestaurante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFiltroRestaurante.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroRestaurante.Location = new System.Drawing.Point(151, 116);
            this.txtFiltroRestaurante.Name = "txtFiltroRestaurante";
            this.txtFiltroRestaurante.Size = new System.Drawing.Size(80, 19);
            this.txtFiltroRestaurante.TabIndex = 9;
            this.txtFiltroRestaurante.Text = "Restaurante";
            this.txtFiltroRestaurante.Click += new System.EventHandler(this.txtFiltroRestaurante_Click);
            // 
            // txtFiltroHortifrutti
            // 
            this.txtFiltroHortifrutti.AutoSize = true;
            this.txtFiltroHortifrutti.BackColor = System.Drawing.Color.Transparent;
            this.txtFiltroHortifrutti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFiltroHortifrutti.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroHortifrutti.Location = new System.Drawing.Point(280, 116);
            this.txtFiltroHortifrutti.Name = "txtFiltroHortifrutti";
            this.txtFiltroHortifrutti.Size = new System.Drawing.Size(68, 19);
            this.txtFiltroHortifrutti.TabIndex = 9;
            this.txtFiltroHortifrutti.Text = "Hortifrutti";
            this.txtFiltroHortifrutti.Click += new System.EventHandler(this.txtFiltroHortifrutti_Click);
            // 
            // painelProd
            // 
            this.painelProd.AutoScroll = true;
            this.painelProd.BackColor = System.Drawing.Color.Transparent;
            this.painelProd.Location = new System.Drawing.Point(1, 155);
            this.painelProd.Name = "painelProd";
            this.painelProd.Size = new System.Drawing.Size(389, 641);
            this.painelProd.TabIndex = 11;
            // 
            // IconBuscaProd
            // 
            this.IconBuscaProd.BackColor = System.Drawing.Color.Transparent;
            this.IconBuscaProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconBuscaProd.Image = ((System.Drawing.Image)(resources.GetObject("IconBuscaProd.Image")));
            this.IconBuscaProd.Location = new System.Drawing.Point(320, 38);
            this.IconBuscaProd.Name = "IconBuscaProd";
            this.IconBuscaProd.Size = new System.Drawing.Size(34, 36);
            this.IconBuscaProd.TabIndex = 12;
            this.IconBuscaProd.Click += new System.EventHandler(this.IconBuscaProd_Click);
            // 
            // PesquisaProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(390, 844);
            this.Controls.Add(this.IconBuscaProd);
            this.Controls.Add(this.painelProd);
            this.Controls.Add(this.txtFiltroHortifrutti);
            this.Controls.Add(this.txtFiltroRestaurante);
            this.Controls.Add(this.txtFiltroMercado);
            this.Controls.Add(this.BoxPesquisaProd);
            this.Controls.Add(this.iconBusca);
            this.Controls.Add(this.iconPerfilProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PesquisaProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliQuicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label iconBusca;
        private System.Windows.Forms.Label iconPerfilProd;
        private System.Windows.Forms.Label txtFiltroMercado;
        private System.Windows.Forms.TextBox BoxPesquisaProd;
        private System.Windows.Forms.Label txtFiltroRestaurante;
        private System.Windows.Forms.Label txtFiltroHortifrutti;
        private System.Windows.Forms.Panel painelProd;
        private System.Windows.Forms.Label IconBuscaProd;
    }
}