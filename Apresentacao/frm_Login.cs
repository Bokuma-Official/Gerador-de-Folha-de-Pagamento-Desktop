using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
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
        Thread Abrir_Tela;

        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // se cpf e senha ficarem vazios
            if (txb_CPF.Text == "" && txb_Senha.Text == "")
            {
                MessageBox.Show("CPF e senha são obrigatórios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se cpf ficar vazio
            else if (txb_CPF.Text == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se senha ficar vazio
            else if (txb_Senha.Text == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres do cpf
            else if (txb_CPF.Text.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres da senha
            else if (txb_Senha.Text.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se colocar palavras do banco de dados na senha
            else if (txb_Senha.Text.Contains("Select") || txb_Senha.Text.Contains("select") || txb_Senha.Text.Contains("SELECT") ||
                txb_Senha.Text.Contains("Insert") || txb_Senha.Text.Contains("insert") || txb_Senha.Text.Contains("INSERT") ||
                txb_Senha.Text.Contains("Update") || txb_Senha.Text.Contains("update") || txb_Senha.Text.Contains("UPDATE") ||
                txb_Senha.Text.Contains("Delete") || txb_Senha.Text.Contains("delete") || txb_Senha.Text.Contains("DELETE") ||
                txb_Senha.Text.Contains("Drop") || txb_Senha.Text.Contains("drop") || txb_Senha.Text.Contains("DROP"))
            {
                MessageBox.Show("Senha inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                // criar lista
                List<String> listaDadosPessoa = new List<String>();

                listaDadosPessoa.Add(txb_CPF.Text);
                listaDadosPessoa.Add(txb_Senha.Text);

                /* Cria uma instância da classe Acesso_DAO e verifica se o acesso
                é válido usando o método Verificar_Acesso, passando os valores da lista*/
                Acesso_DAO acesso_DAO = new Acesso_DAO();
                acesso_DAO.Verificar_Acesso(listaDadosPessoa);

                /* verifica se a variavel cargo da classe Acesso_DAO tem
                algum valor para fechar a tela de login e chamar
                o método para abrir a tela de menu */
                if (Acesso_DAO.Cargo != null)
                {
                    this.Close();
                    Abrir_Tela = new Thread(Abrir_frm_Menu);
                    Abrir_Tela.SetApartmentState(ApartmentState.STA);
                    Abrir_Tela.Start();
                }
            }
        }

        private void Abrir_frm_Menu()
        {
            // abrir tela de menu
            Application.Run(new frm_Menu());
        }

        private void lnk_Redefinir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // fecha a tela de login e chama o método para abrir a tela de redefinir senha
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Redefinir_Senha);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void Abrir_frm_Redefinir_Senha()
        {
            // abrir tela de redefinir senha
            Application.Run(new frm_Redefinir_Senha());
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
            // pressionar a tecla enter sem preencher a senha não vai exibir a mensagem de confirmação
            if (txb_Senha.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // pressionar a tecla enter quando preencher a senha vai exibir a mensagem de confirmação
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