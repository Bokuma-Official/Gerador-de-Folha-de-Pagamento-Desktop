namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.lbl_Login = new System.Windows.Forms.Label();
            this.lbl_CPF = new System.Windows.Forms.Label();
            this.txb_CPF = new System.Windows.Forms.TextBox();
            this.lbl_Senha = new System.Windows.Forms.Label();
            this.txb_Senha = new System.Windows.Forms.TextBox();
            this.lnk_Redefinir = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Fechar = new System.Windows.Forms.Button();
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
            this.txb_CPF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_CPF_KeyDown);
            this.txb_CPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_CPF_KeyPress);
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
            this.lnk_Redefinir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_Redefinir_LinkClicked);
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
            // btn_Fechar
            // 
            this.btn_Fechar.BackColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.btn_Fechar, "btn_Fechar");
            this.btn_Fechar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_Fechar.Name = "btn_Fechar";
            this.btn_Fechar.UseVisualStyleBackColor = false;
            this.btn_Fechar.Click += new System.EventHandler(this.btn_Fechar_Click);
            // 
            // frm_Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Fechar);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lnk_Redefinir);
            this.Controls.Add(this.txb_Senha);
            this.Controls.Add(this.lbl_Senha);
            this.Controls.Add(this.txb_CPF);
            this.Controls.Add(this.lbl_CPF);
            this.Controls.Add(this.lbl_Login);
            this.Name = "frm_Login";
            this.Shown += new System.EventHandler(this.frm_Login_Shown);
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
        private System.Windows.Forms.Button btn_Fechar;
    }
}

