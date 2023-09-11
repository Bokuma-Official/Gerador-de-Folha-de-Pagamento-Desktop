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
            Acesso acesso = new Acesso();
            acesso.CPF = txb_CPF_RS.Text;
            acesso.Senha = txb_Senha_RS.Text;
            Repetir_Senha = txb_Repetir_Senha.Text;

            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Tela_Redefinir_Senha(acesso, Repetir_Senha);

            this.Hide();
            frm_Login frm_login = new frm_Login();
            frm_login.Show();
        }
    }

}
