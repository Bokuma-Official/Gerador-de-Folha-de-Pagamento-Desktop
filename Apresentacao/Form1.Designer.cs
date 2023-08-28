namespace protótipo_da_folha_de_pagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_Login = new System.Windows.Forms.Label();
            this.lbl_CPF = new System.Windows.Forms.Label();
            this.txb_CPF = new System.Windows.Forms.TextBox();
            this.lbl_Senha = new System.Windows.Forms.Label();
            this.txb_Senha = new System.Windows.Forms.TextBox();
            this.lnk_Redefinir = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lnk_Cadastrar = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_Login
            // 
            resources.ApplyResources(this.lbl_Login, "lbl_Login");
            this.lbl_Login.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_Login.Name = "lbl_Login";
            // 
            // lbl_CPF
            // 
            resources.ApplyResources(this.lbl_CPF, "lbl_CPF");
            this.lbl_CPF.Name = "lbl_CPF";
            // 
            // txb_CPF
            // 
            resources.ApplyResources(this.txb_CPF, "txb_CPF");
            this.txb_CPF.Name = "txb_CPF";
            this.txb_CPF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Email_KeyDown);
            // 
            // lbl_Senha
            // 
            resources.ApplyResources(this.lbl_Senha, "lbl_Senha");
            this.lbl_Senha.Name = "lbl_Senha";
            // 
            // txb_Senha
            // 
            resources.ApplyResources(this.txb_Senha, "txb_Senha");
            this.txb_Senha.Name = "txb_Senha";
            this.txb_Senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Senha_KeyDown);
            // 
            // lnk_Redefinir
            // 
            this.lnk_Redefinir.ActiveLinkColor = System.Drawing.Color.Cyan;
            resources.ApplyResources(this.lnk_Redefinir, "lnk_Redefinir");
            this.lnk_Redefinir.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnk_Redefinir.Name = "lnk_Redefinir";
            this.lnk_Redefinir.TabStop = true;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.btn_Login, "btn_Login");
            this.btn_Login.ForeColor = System.Drawing.Color.Snow;
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lnk_Cadastrar
            // 
            this.lnk_Cadastrar.ActiveLinkColor = System.Drawing.Color.Cyan;
            resources.ApplyResources(this.lnk_Cadastrar, "lnk_Cadastrar");
            this.lnk_Cadastrar.Name = "lnk_Cadastrar";
            this.lnk_Cadastrar.TabStop = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnk_Cadastrar);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lnk_Redefinir);
            this.Controls.Add(this.txb_Senha);
            this.Controls.Add(this.lbl_Senha);
            this.Controls.Add(this.txb_CPF);
            this.Controls.Add(this.lbl_CPF);
            this.Controls.Add(this.lbl_Login);
            this.Name = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.Label lbl_CPF;
        private System.Windows.Forms.TextBox txb_CPF;
        private System.Windows.Forms.Label lbl_Senha;
        private System.Windows.Forms.TextBox txb_Senha;
        private System.Windows.Forms.LinkLabel lnk_Redefinir;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel lnk_Cadastrar;
    }
}

