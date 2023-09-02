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
        Thread Abrir_Tela;

        public frm_Menu()
        {
            InitializeComponent();
        }

        private void Abrir_frm_Login()
        {
            Application.Run(new frm_Login());
        }

        private void Abrir_frm_Cadastrar_Funcionarios()
        {
            Application.Run(new frm_Cadastrar_Funcionarios());
        }

        private void Abrir_frm_Cadastrar_Folhas_Pagamento()
        {
            Application.Run(new frm_Cadastrar_Folhas_Pagamento());
        }

        private void Abrir_frm_Cadastrar_Perfis()
        {
            Application.Run(new frm_Cadastrar_Perfis());
        }

        private void Abrir_frm_Visualizar_Funcionarios()
        {
            Application.Run(new frm_Visualizar_Funcionarios());
        }

        private void Abrir_frm_Visualizar_Folhas_Pagamento()
        {
            Application.Run(new frm_Visualizar_Folhas_Pagamento());
        }

        private void Abrir_frm_Visualizar_Perfis()
        {
            Application.Run(new frm_Visualizar_Perfis());
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            DialogResult pergunta = MessageBox.Show("Deseja encerrar esta sessão?", "Encerrar sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                this.Hide();
                Abrir_Tela = new Thread(Abrir_frm_Login);
                Abrir_Tela.SetApartmentState(ApartmentState.STA);
                Abrir_Tela.Start();
            }
        }

        private void btn_Cadastrar_Funcionarios_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Cadastrar_Funcionarios);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void btn_Cadastrar_Folhas_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Cadastrar_Folhas_Pagamento);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void btn_Cadastrar_Perfis_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Cadastrar_Perfis);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void btn_Visualizar_Funcionarios_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Visualizar_Funcionarios);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void btn_Visualizar_Folhas_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Visualizar_Folhas_Pagamento);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void btn_Visualizar_Perfis_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Visualizar_Perfis);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void frm_Menu_Load(object sender, EventArgs e)
        {
            // se a variavel cargo da classe Acesso_DAO for diferente de gerente, muda elementos da tela
            if (Acesso_DAO.Cargo != "Gerente")
            {
                btn_Cadastrar_Perfis.Visible = false;
            }
        }
    }
}
