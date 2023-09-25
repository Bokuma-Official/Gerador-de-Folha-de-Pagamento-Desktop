namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    partial class frm_Redefinir_Senha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Redefinir_Senha));
            this.lbl_Redefinicao = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txb_Email = new System.Windows.Forms.TextBox();
            this.lbl_Senha = new System.Windows.Forms.Label();
            this.lbl_Repetir_Senha = new System.Windows.Forms.Label();
            this.txb_Senha = new System.Windows.Forms.TextBox();
            this.lbl_Maximo = new System.Windows.Forms.Label();
            this.txb_Repetir_Senha = new System.Windows.Forms.TextBox();
            this.btn_Redefinir = new System.Windows.Forms.Button();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.txb_Codigo = new System.Windows.Forms.TextBox();
            this.lbl_Codigo = new System.Windows.Forms.Label();
            this.btn_Enviar_Email = new System.Windows.Forms.Button();
            this.btn_Validar_Codigo = new System.Windows.Forms.Button();
            this.txb_CPF = new System.Windows.Forms.TextBox();
            this.lbl_CPF = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Redefinicao
            // 
            this.lbl_Redefinicao.AutoSize = true;
            this.lbl_Redefinicao.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Redefinicao.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_Redefinicao.Location = new System.Drawing.Point(109, 11);
            this.lbl_Redefinicao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Redefinicao.Name = "lbl_Redefinicao";
            this.lbl_Redefinicao.Size = new System.Drawing.Size(444, 59);
            this.lbl_Redefinicao.TabIndex = 1;
            this.lbl_Redefinicao.Text = "Redefinição de Senha";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(135, 63);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(66, 25);
            this.lbl_Email.TabIndex = 4;
            this.lbl_Email.Text = "Email:";
            // 
            // txb_Email
            // 
            this.txb_Email.Location = new System.Drawing.Point(119, 92);
            this.txb_Email.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.Size = new System.Drawing.Size(254, 22);
            this.txb_Email.TabIndex = 5;
            this.txb_Email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Email_KeyDown);
            // 
            // lbl_Senha
            // 
            this.lbl_Senha.AutoSize = true;
            this.lbl_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Senha.Location = new System.Drawing.Point(135, 282);
            this.lbl_Senha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Senha.Name = "lbl_Senha";
            this.lbl_Senha.Size = new System.Drawing.Size(127, 25);
            this.lbl_Senha.TabIndex = 6;
            this.lbl_Senha.Text = "Nova Senha:";
            // 
            // lbl_Repetir_Senha
            // 
            this.lbl_Repetir_Senha.AutoSize = true;
            this.lbl_Repetir_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Repetir_Senha.Location = new System.Drawing.Point(135, 350);
            this.lbl_Repetir_Senha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Repetir_Senha.Name = "lbl_Repetir_Senha";
            this.lbl_Repetir_Senha.Size = new System.Drawing.Size(190, 25);
            this.lbl_Repetir_Senha.TabIndex = 7;
            this.lbl_Repetir_Senha.Text = "Repetir nova Senha:";
            // 
            // txb_Senha
            // 
            this.txb_Senha.Location = new System.Drawing.Point(119, 314);
            this.txb_Senha.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Senha.Name = "txb_Senha";
            this.txb_Senha.Size = new System.Drawing.Size(254, 22);
            this.txb_Senha.TabIndex = 8;
            this.txb_Senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Senha_KeyDown);
            // 
            // lbl_Maximo
            // 
            this.lbl_Maximo.AutoSize = true;
            this.lbl_Maximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Maximo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_Maximo.Location = new System.Drawing.Point(269, 286);
            this.lbl_Maximo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Maximo.Name = "lbl_Maximo";
            this.lbl_Maximo.Size = new System.Drawing.Size(164, 20);
            this.lbl_Maximo.TabIndex = 9;
            this.lbl_Maximo.Text = "(Máx. 20 caracteres)";
            // 
            // txb_Repetir_Senha
            // 
            this.txb_Repetir_Senha.Location = new System.Drawing.Point(119, 379);
            this.txb_Repetir_Senha.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Repetir_Senha.Name = "txb_Repetir_Senha";
            this.txb_Repetir_Senha.Size = new System.Drawing.Size(254, 22);
            this.txb_Repetir_Senha.TabIndex = 10;
            this.txb_Repetir_Senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Repetir_Senha_KeyDown);
            // 
            // btn_Redefinir
            // 
            this.btn_Redefinir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Redefinir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Redefinir.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Redefinir.Location = new System.Drawing.Point(381, 426);
            this.btn_Redefinir.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Redefinir.Name = "btn_Redefinir";
            this.btn_Redefinir.Size = new System.Drawing.Size(115, 52);
            this.btn_Redefinir.TabIndex = 14;
            this.btn_Redefinir.Text = "Redefinir";
            this.btn_Redefinir.UseVisualStyleBackColor = false;
            this.btn_Redefinir.Click += new System.EventHandler(this.btn_Redefinir_Click);
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_Voltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Voltar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Voltar.Location = new System.Drawing.Point(140, 426);
            this.btn_Voltar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(115, 52);
            this.btn_Voltar.TabIndex = 15;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = false;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // txb_Codigo
            // 
            this.txb_Codigo.Location = new System.Drawing.Point(119, 157);
            this.txb_Codigo.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Codigo.Name = "txb_Codigo";
            this.txb_Codigo.Size = new System.Drawing.Size(254, 22);
            this.txb_Codigo.TabIndex = 17;
            this.txb_Codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Codigo_KeyDown);
            this.txb_Codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_Codigo_KeyPress);
            // 
            // lbl_Codigo
            // 
            this.lbl_Codigo.AutoSize = true;
            this.lbl_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Codigo.Location = new System.Drawing.Point(135, 128);
            this.lbl_Codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Codigo.Name = "lbl_Codigo";
            this.lbl_Codigo.Size = new System.Drawing.Size(209, 25);
            this.lbl_Codigo.TabIndex = 16;
            this.lbl_Codigo.Text = "Código de Segurança:";
            // 
            // btn_Enviar_Email
            // 
            this.btn_Enviar_Email.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Enviar_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enviar_Email.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Enviar_Email.Location = new System.Drawing.Point(393, 84);
            this.btn_Enviar_Email.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Enviar_Email.Name = "btn_Enviar_Email";
            this.btn_Enviar_Email.Size = new System.Drawing.Size(168, 36);
            this.btn_Enviar_Email.TabIndex = 18;
            this.btn_Enviar_Email.Text = "Enviar Email";
            this.btn_Enviar_Email.UseVisualStyleBackColor = false;
            this.btn_Enviar_Email.Click += new System.EventHandler(this.btn_Enviar_Email_Click);
            // 
            // btn_Validar_Codigo
            // 
            this.btn_Validar_Codigo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Validar_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Validar_Codigo.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Validar_Codigo.Location = new System.Drawing.Point(393, 149);
            this.btn_Validar_Codigo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Validar_Codigo.Name = "btn_Validar_Codigo";
            this.btn_Validar_Codigo.Size = new System.Drawing.Size(168, 36);
            this.btn_Validar_Codigo.TabIndex = 19;
            this.btn_Validar_Codigo.Text = "Validar Código";
            this.btn_Validar_Codigo.UseVisualStyleBackColor = false;
            this.btn_Validar_Codigo.Click += new System.EventHandler(this.btn_Validar_Codigo_Click);
            // 
            // txb_CPF
            // 
            this.txb_CPF.Location = new System.Drawing.Point(119, 245);
            this.txb_CPF.Margin = new System.Windows.Forms.Padding(4);
            this.txb_CPF.Name = "txb_CPF";
            this.txb_CPF.Size = new System.Drawing.Size(254, 22);
            this.txb_CPF.TabIndex = 20;
            this.txb_CPF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_CPF_KeyDown);
            this.txb_CPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_CPF_KeyPress);
            // 
            // lbl_CPF
            // 
            this.lbl_CPF.AutoSize = true;
            this.lbl_CPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CPF.Location = new System.Drawing.Point(135, 206);
            this.lbl_CPF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CPF.Name = "lbl_CPF";
            this.lbl_CPF.Size = new System.Drawing.Size(58, 25);
            this.lbl_CPF.TabIndex = 21;
            this.lbl_CPF.Text = "CPF:";
            // 
            // frm_Redefinir_Senha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 503);
            this.Controls.Add(this.lbl_CPF);
            this.Controls.Add(this.txb_CPF);
            this.Controls.Add(this.btn_Validar_Codigo);
            this.Controls.Add(this.btn_Enviar_Email);
            this.Controls.Add(this.txb_Codigo);
            this.Controls.Add(this.lbl_Codigo);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.btn_Redefinir);
            this.Controls.Add(this.txb_Repetir_Senha);
            this.Controls.Add(this.lbl_Maximo);
            this.Controls.Add(this.txb_Senha);
            this.Controls.Add(this.lbl_Repetir_Senha);
            this.Controls.Add(this.lbl_Senha);
            this.Controls.Add(this.txb_Email);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_Redefinicao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Redefinir_Senha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folha de pagamentos Ataron™";
            this.Load += new System.EventHandler(this.frm_Redefinir_Senha_Load);
            this.Shown += new System.EventHandler(this.frm_Redefinir_Senha_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Redefinicao;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txb_Email;
        private System.Windows.Forms.Label lbl_Senha;
        private System.Windows.Forms.Label lbl_Repetir_Senha;
        private System.Windows.Forms.TextBox txb_Senha;
        private System.Windows.Forms.Label lbl_Maximo;
        private System.Windows.Forms.TextBox txb_Repetir_Senha;
        private System.Windows.Forms.Button btn_Redefinir;
        private System.Windows.Forms.Button btn_Voltar;
        private System.Windows.Forms.TextBox txb_Codigo;
        private System.Windows.Forms.Label lbl_Codigo;
        private System.Windows.Forms.Button btn_Enviar_Email;
        private System.Windows.Forms.Button btn_Validar_Codigo;
        private System.Windows.Forms.TextBox txb_CPF;
        private System.Windows.Forms.Label lbl_CPF;
    }
}