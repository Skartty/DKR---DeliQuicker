namespace ProjetoDKR
{
    partial class TelaLogin
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.txtLogin = new System.Windows.Forms.Label();
            this.BoxLogin = new System.Windows.Forms.TextBox();
            this.BoxSenha = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtNaoPossuiConta = new System.Windows.Forms.Label();
            this.txtCadastrese = new System.Windows.Forms.Label();
            this.BoxUsername = new System.Windows.Forms.TextBox();
            this.lblRetornoMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtLogin.Font = new System.Drawing.Font("Zen Maru Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(159, 438);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(83, 25);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.Text = "LOGIN";
            this.txtLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoxLogin
            // 
            this.BoxLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BoxLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BoxLogin.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxLogin.Location = new System.Drawing.Point(38, 518);
            this.BoxLogin.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.BoxLogin.Multiline = true;
            this.BoxLogin.Name = "BoxLogin";
            this.BoxLogin.Size = new System.Drawing.Size(42, 0);
            this.BoxLogin.TabIndex = 1;
            // 
            // BoxSenha
            // 
            this.BoxSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BoxSenha.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxSenha.Location = new System.Drawing.Point(38, 595);
            this.BoxSenha.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.BoxSenha.Multiline = true;
            this.BoxSenha.Name = "BoxSenha";
            this.BoxSenha.PasswordChar = '*';
            this.BoxSenha.Size = new System.Drawing.Size(314, 42);
            this.BoxSenha.TabIndex = 2;
            this.BoxSenha.UseSystemPasswordChar = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.Font = new System.Drawing.Font("Zen Maru Gothic Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(34, 754);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(325, 53);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Font = new System.Drawing.Font("Zen Maru Gothic", 10.7F);
            this.txtUsername.Location = new System.Drawing.Point(34, 494);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(77, 21);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Font = new System.Drawing.Font("Zen Maru Gothic", 10.7F);
            this.txtPassword.Location = new System.Drawing.Point(34, 571);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(74, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Password";
            // 
            // txtNaoPossuiConta
            // 
            this.txtNaoPossuiConta.AutoSize = true;
            this.txtNaoPossuiConta.BackColor = System.Drawing.Color.Transparent;
            this.txtNaoPossuiConta.Font = new System.Drawing.Font("Zen Maru Gothic", 10.7F);
            this.txtNaoPossuiConta.Location = new System.Drawing.Point(64, 657);
            this.txtNaoPossuiConta.Name = "txtNaoPossuiConta";
            this.txtNaoPossuiConta.Size = new System.Drawing.Size(164, 21);
            this.txtNaoPossuiConta.TabIndex = 6;
            this.txtNaoPossuiConta.Text = "Não possui uma conta?";
            // 
            // txtCadastrese
            // 
            this.txtCadastrese.AutoSize = true;
            this.txtCadastrese.BackColor = System.Drawing.Color.Transparent;
            this.txtCadastrese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCadastrese.Font = new System.Drawing.Font("Zen Maru Gothic", 10.7F);
            this.txtCadastrese.ForeColor = System.Drawing.Color.DarkOrange;
            this.txtCadastrese.Location = new System.Drawing.Point(227, 657);
            this.txtCadastrese.Name = "txtCadastrese";
            this.txtCadastrese.Size = new System.Drawing.Size(94, 21);
            this.txtCadastrese.TabIndex = 7;
            this.txtCadastrese.Text = "Cadastre-se";
            this.txtCadastrese.Click += new System.EventHandler(this.txtCadastrese_Click);
            // 
            // BoxUsername
            // 
            this.BoxUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BoxUsername.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxUsername.Location = new System.Drawing.Point(38, 518);
            this.BoxUsername.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.BoxUsername.Multiline = true;
            this.BoxUsername.Name = "BoxUsername";
            this.BoxUsername.Size = new System.Drawing.Size(314, 42);
            this.BoxUsername.TabIndex = 8;
            // 
            // lblRetornoMsg
            // 
            this.lblRetornoMsg.AutoSize = true;
            this.lblRetornoMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblRetornoMsg.Font = new System.Drawing.Font("Zen Maru Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetornoMsg.ForeColor = System.Drawing.Color.Red;
            this.lblRetornoMsg.Location = new System.Drawing.Point(26, 639);
            this.lblRetornoMsg.Name = "lblRetornoMsg";
            this.lblRetornoMsg.Size = new System.Drawing.Size(0, 19);
            this.lblRetornoMsg.TabIndex = 9;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(390, 844);
            this.Controls.Add(this.lblRetornoMsg);
            this.Controls.Add(this.BoxUsername);
            this.Controls.Add(this.txtCadastrese);
            this.Controls.Add(this.txtNaoPossuiConta);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.BoxSenha);
            this.Controls.Add(this.BoxLogin);
            this.Controls.Add(this.txtLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtLogin;
        private System.Windows.Forms.TextBox BoxLogin;
        private System.Windows.Forms.TextBox BoxSenha;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Label txtNaoPossuiConta;
        private System.Windows.Forms.Label txtCadastrese;
        private System.Windows.Forms.TextBox BoxUsername;
        private System.Windows.Forms.Label lblRetornoMsg;
    }
}

