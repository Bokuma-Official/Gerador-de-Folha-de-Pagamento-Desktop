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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Visualizar_Perfis : Form
    {
        public frm_Visualizar_Perfis()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu frm_menu = new frm_Menu();
            frm_menu.Show();
        }

        private void frm_Visualizar_Perfis_Load(object sender, EventArgs e)
        {
            /* se a variavel cargo da classe funcionario_ataron_dao for diferente de gerente,
            muda ou oculta elementos da tela */
            if (!Funcionario_Ataron_DAO.Cargo.ToLower().Contains("gerente"))
            {
                lbl_Visualizar_Editar_Excluir.Text = "Visualizar Perfil";
                lbl_Visualizar_Editar_Excluir.Location = new Point (175, 25);
                lbl_Selecionar_Perfil.Visible = false;
                cmb_Selecionar_Perfil.Visible = false;
                btn_Voltar.Location = new Point (260, 460);
                btn_Deletar.Visible = false;
                btn_Editar.Visible = false;
                btn_Editar.Visible = false;
                txb_Senha.Visible = false;
                lbl_Senha.Visible = false;
                lbl_Maximo.Visible = false;
                txb_Cargo.ReadOnly = true;
                txb_Carteira_Trabalho.ReadOnly = true;
                txb_CEP.ReadOnly = true;
                txb_CPF.ReadOnly = true;
                txb_Data_Admissao.ReadOnly = true;
                txb_Data_Nascimento.ReadOnly = true;
                txb_Departamento.ReadOnly = true;
                txb_Email.ReadOnly = true;
                txb_Matricula.ReadOnly = true;
                txb_Nome.ReadOnly = true;
                txb_PIS.ReadOnly = true;
                txb_RA_Militar.ReadOnly = true;
                txb_RG.ReadOnly = true;
                txb_Sexo.ReadOnly = true;
                txb_Telefone_Celular.ReadOnly = true;
                txb_Telefone_Fixo.ReadOnly = true;
                txb_Titulo_Eleitor.ReadOnly = true;
            }
        }
    }
}
