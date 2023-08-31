using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // se o campo cpf e senha ficarem vazios
            if (txb_CPF.Text == "" && txb_Senha.Text == "")
            {
                MessageBox.Show("O campo cpf e senha são obrigatórios!",
                    "Dados Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo cpf ficar vazio
            else if (txb_CPF.Text == "")
            {
                MessageBox.Show("O campo cpf é obrigatório!", "Dados Vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo senha ficar vazio
            else if (txb_Senha.Text == "")
            {
                MessageBox.Show("O campo senha é obrigatório!", "Dados Vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo cpf e senha não estiverem vazios
            else
            {
                Acesso acesso = new Acesso();
                acesso.CPF = txb_CPF.Text;
                acesso.Senha = txb_Senha.Text;

                // Cria uma instância da classe Acesso_DAO e verifica se o acesso é válido usando o método Verificar_Acesso
                Acesso_DAO acesso_DAO = new Acesso_DAO();
                bool acesso_valido = acesso_DAO.Verificar_Acesso(acesso.CPF, acesso.Senha);

                if (acesso_valido)
                {
                    this.Close();
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // iniciar a tela com o foco do mouse no campo de cpf
            txb_CPF.Focus();
        }

        private void txb_Email_KeyDown(object sender, KeyEventArgs e)
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            // fechar o programa
            DialogResult pergunta = MessageBox.Show("Deseja realmente fechar o programa?", "Fechar o programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                Application.Exit();
            }

            else
            {

            }
        }
    }
}
