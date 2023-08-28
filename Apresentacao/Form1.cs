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
    public partial class Form1 : Form
    {
        Thread Abrir_Telas;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // se o campo email e senha ficarem vazios
            if (txb_CPF.Text == "" && txb_Senha.Text == "")
            {
                MessageBox.Show("O campo email e senha são obrigatórios!",
                    "Dados Vazios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo email ficar vazio
            else if (txb_CPF.Text == "")
            {
                MessageBox.Show("O campo email é obrigatório!", "Dados Vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo senha ficar vazio
            else if (txb_Senha.Text == "")
            {
                MessageBox.Show("O campo senha é obrigatório!", "Dados Vazios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se o campo email e senha não estiverem vazios
            else if (MessageBox.Show(this, "Deseja realmente fazer o login?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                // depois de checar os dados do banco vai abrir a tela de menu
                this.Close();
                Abrir_Telas = new Thread(Abrir_Tela);
                Abrir_Telas.SetApartmentState(ApartmentState.STA);
                Abrir_Telas.Start();
            }
        }

        private void Abrir_Tela()
        {
            // abrir tela de menu
            Application.Run(new frm_Menu_Gerente());
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // iniciar a tela com o foco do mouse no campo de email
            txb_CPF.Focus();
        }

        private void txb_Email_KeyDown(object sender, KeyEventArgs e)
        {
            // pressionar a tecla enter sem preencher o campo de email não vai pro campo de senha
            if (txb_CPF.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_CPF.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // pressionar a tecla enter quando preencher as email vai pro campo de senha
            else if (txb_CPF.Text != "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txb_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            // pressionar a tecla enter sem preencher o campo senha não vai exibir a mensagem de confirmação
            if (txb_Senha.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Senha.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            // pressionar a tecla enter quando preencher o campo senha vai exibir a mensagem de confirmação
            else if (txb_Senha.Text != "" && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Login.PerformClick();
            }
        }
    }
}
