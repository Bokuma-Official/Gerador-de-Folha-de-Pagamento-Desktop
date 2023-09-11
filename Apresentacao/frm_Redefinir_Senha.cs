using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Redefinir_Senha : Form
    {
        public string Repetir_Senha { get; set; }

        public frm_Redefinir_Senha()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Login frm_login = new frm_Login();
            frm_login.Show();
        }

        private void btn_Redefinir_Click(object sender, EventArgs e)
        {
            Repetir_Senha = txb_Repetir_Senha.Text;

            Acesso acesso = new Acesso();
            acesso.CPF = txb_CPF.Text;
            acesso.Senha = txb_Senha.Text;

            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Tela_Redefinir_Senha(acesso, Repetir_Senha);
            
            if (Acesso_DAO.Mudanca == true)
            {
                this.Hide();
                frm_Login frm_login = new frm_Login();
                frm_login.Show();
            }
        }

        private void frm_Redefinir_Senha_Shown(object sender, EventArgs e)
        {
            txb_CPF.Focus();
        }

        private void txb_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_CPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (txb_CPF.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_CPF.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            else if (txb_CPF.Text != "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txb_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (txb_Senha.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            else if (txb_Senha.Text != "" && e.KeyCode == Keys.Enter)
            {
                txb_Repetir_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txb_Repetir_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (txb_Repetir_Senha.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Repetir_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            else if (txb_Repetir_Senha.Text != "" && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Redefinir.PerformClick();
            }
        }
    }
}
