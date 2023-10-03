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
        public string Codigo_Seguranca { get; set; }

        public frm_Redefinir_Senha()
        {
            InitializeComponent();
        }

        private void frm_Redefinir_Senha_Load(object sender, EventArgs e)
        {
            lbl_Codigo.Visible = false;
            txb_Codigo.Visible = false;
            btn_Validar_Codigo.Visible = false;
            lbl_Senha.Visible = false;
            txb_Senha.Visible = false;
            lbl_Maximo.Visible = false;
            lbl_Repetir_Senha.Visible = false;
            txb_Repetir_Senha.Visible = false;
            btn_Redefinir.Visible = false;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Login frm_login = new frm_Login();
            frm_login.Show();
        }

        private void btn_Enviar_Email_Click(object sender, EventArgs e)
        {
            Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();
            funcionario_ataron.Email = txb_Email.Text;

            Controle_Validacao controle = new Controle_Validacao();
            controle.Verificar_Email(funcionario_ataron);

            if (Controle_Validacao.Email_Validado == true)
            {
                Controle_Validacao.Email_Validado = false;

                lbl_Email.Visible = false;
                txb_Email.Visible = false;
                btn_Enviar_Email.Visible = false;
                lbl_Codigo.Visible = true;
                txb_Codigo.Visible = true;
                txb_Codigo.Focus();
                btn_Validar_Codigo.Visible = true;
            }
        }

        private void btn_Validar_Codigo_Click(object sender, EventArgs e)
        {
            Codigo_Seguranca = txb_Codigo.Text;

            Controle_Validacao controle = new Controle_Validacao();
            controle.Verificar_Codigo(Codigo_Seguranca);

            if (Controle_Validacao.Codigo_Validado == true)
            {
                Controle_Validacao.Codigo_Validado = false;

                lbl_Codigo.Visible = false;
                txb_Codigo.Visible = false;
                btn_Validar_Codigo.Visible = false;
                lbl_Senha.Visible = true;
                txb_Senha.Visible = true;
                txb_Senha.Focus();
                lbl_Maximo.Visible = true;
                lbl_Repetir_Senha.Visible = true;
                txb_Repetir_Senha.Visible = true;
                btn_Redefinir.Visible = true;
            }
        }

        private void btn_Redefinir_Click(object sender, EventArgs e)
        {
            Repetir_Senha = txb_Repetir_Senha.Text;

            Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();
            funcionario_ataron.Email = txb_Email.Text;
            funcionario_ataron.Senha = txb_Senha.Text;

            Controle_Validacao controle = new Controle_Validacao();
            controle.Verificar_Senha(funcionario_ataron, Repetir_Senha);

            if (Controle_Validacao.Senha_Validada == true && Funcionario_Ataron_DAO.Senha_Mudada == true)
            {
                Controle_Validacao.Senha_Validada = false;

                this.Hide();
                frm_Login frm_login = new frm_Login();
                frm_login.Show();
            }
        }

        private void frm_Redefinir_Senha_Shown(object sender, EventArgs e)
        {
            txb_Email.Focus();
        }

        private void txb_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (txb_Email.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Email.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            else if (txb_Email.Text != "" && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Enviar_Email.PerformClick();
            }
        }

        private void txb_Codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txb_Codigo.Text == "" && e.KeyCode == Keys.Enter)
            {
                txb_Codigo.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            else if (txb_Codigo.Text != "" && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_Validar_Codigo.PerformClick();
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
