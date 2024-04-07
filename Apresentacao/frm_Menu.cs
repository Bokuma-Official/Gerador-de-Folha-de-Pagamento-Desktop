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
    public partial class frm_Menu : Form
    {
        public frm_Menu()
        {
            InitializeComponent();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            DialogResult pergunta = MessageBox.Show("Deseja encerrar esta sessão?", "Encerrar sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                this.Hide();
                frm_Login frm_login = new frm_Login();
                frm_login.Show();
            }
        }

        private void btn_Cadastrar_Funcionarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Cadastrar_Funcionarios frm_cadastrar_funcionarios = new frm_Cadastrar_Funcionarios();
            frm_cadastrar_funcionarios.Show();
        }

        private void btn_Cadastrar_Folhas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Cadastrar_Folhas_Pagamento frm_cadastrar_folhas_pagamento = new frm_Cadastrar_Folhas_Pagamento();
            frm_cadastrar_folhas_pagamento.Show();
        }

        private void btn_Cadastrar_Perfis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Cadastrar_Perfis frm_cadastrar_perfis = new frm_Cadastrar_Perfis();
            frm_cadastrar_perfis.Show();
        }

        private void btn_Visualizar_Funcionarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Visualizar_Editar_Funcionarios frm_visualizar_funcionarios = new frm_Visualizar_Editar_Funcionarios();
            frm_visualizar_funcionarios.Show();
        }

        private void btn_Visualizar_Folhas_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Visualizar_Editar_Folhas_Pagamento frm_visualizar_folhas_pagamento = new frm_Visualizar_Editar_Folhas_Pagamento();
            frm_visualizar_folhas_pagamento.Show();
        }

        private void btn_Visualizar_Perfis_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Visualizar_Editar_Perfis frm_visualizar_perfis = new frm_Visualizar_Editar_Perfis();
            frm_visualizar_perfis.Show();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            // se a variavel cargo da classe funcionario_ataron_dao for diferente de gerente, oculta um botão do menu
            if (!Funcionario_Ataron_DAO.Cargo_Perfil_Logado.ToLower().Contains("gerente"))
            {
                btn_Cadastrar_Perfis.Visible = false;
            }
        }

        private void frm_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
