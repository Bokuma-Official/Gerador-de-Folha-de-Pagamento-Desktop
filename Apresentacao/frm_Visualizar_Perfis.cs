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
            if (Funcionario_Ataron_DAO.Cargo != "Gerente" || Funcionario_Ataron_DAO.Cargo != "gerente")
            {
                lbl_Visualizar.Text = "Visualizar Perfil";
                lbl_Visualizar.Location = new Point (175, 25);
                lbl_Selecionar_Perfil.Visible = false;
                cmb_Selecionar_Perfil.Visible = false;
                lbl_Feminino.Visible = false;
                lbl_Senha.Visible = false;
                txb_Senha.Visible = false;
                lbl_Maximo.Visible = false;
                lbl_Repetir_Senha.Visible = false;
                txb_Repetir_Senha.Visible = false;
                btn_Voltar.Location = new Point (260, 460);
                btn_Deletar.Visible = false;
                btn_Editar.Visible = false;
                btn_Salvar.Visible = false;
            }
        }
    }
}
