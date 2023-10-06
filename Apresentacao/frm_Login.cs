using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            /* cria uma instância da classe funcionario_ataron na camada modelo e os atributos de cpf e senha
            passam a ter o mesmo valor que o valor dos textos das textbox cpf e senha */
            Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();
            funcionario_ataron.CPF = txb_CPF.Text;
            funcionario_ataron.Senha = txb_Senha.Text;

            /* cria uma instância da classe controle_validacao na camada modelo e chama o método
            verificar_tela_login, passando os valores da variável funcionario_ataron para checar se
            os textos digitados não contém erros */
            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Login(funcionario_ataron);

            /* verifica se a variavel estática cargo da classe funcionario_ataron_dao na camada dal tem
            o valor diferente de nulo para fechar a tela de login e abrir a tela de menu */
            if (Controle_Validacao.Login_Validado == true && Funcionario_Ataron_DAO.Cargo_Perfil_Logado != null)
            {
                Controle_Validacao.Login_Validado = false;

                this.Hide();
                frm_Menu frm_menu = new frm_Menu();
                frm_menu.Show();
            }
        }

        private void lnk_Redefinir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // fecha a tela de login e abre a tela de redefinir senha
            this.Hide();
            frm_Redefinir_Senha frm_redefinir_senha = new frm_Redefinir_Senha();
            frm_redefinir_senha.Show();
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            // fechar o programa
            DialogResult pergunta = MessageBox.Show("Deseja fechar o programa?", "Fechar o programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frm_Login_Shown(object sender, EventArgs e)
        {
            // iniciar a tela com o foco do mouse no campo de cpf
            txb_CPF.Focus();

            Funcionario_Ataron_DAO.Cargo_Perfil_Logado = "";
            Funcionario_Ataron_DAO.CPF_Perfil_Logado = "";
        }

        private void txb_CPF_KeyDown(object sender, KeyEventArgs e)
        {
            // pressionar a tecla enter sem preencher o cpf não vai pro campo de senha
            if (txb_CPF.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_CPF.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // pressionar a tecla enter quando preencher o cpf vai pro campo de senha
            else if (txb_CPF.Text != "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txb_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            // pressionar a tecla enter sem preencher a senha não vai automaticamente tentar efetuar o login
            if (txb_Senha.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // pressionar a tecla enter quando preencher a senha vai automaticamente tentar efetuar o login
            else if (txb_Senha.Text != "" && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Login.PerformClick();
            }
        }

        private void txb_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas números, . e - no cpf
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}