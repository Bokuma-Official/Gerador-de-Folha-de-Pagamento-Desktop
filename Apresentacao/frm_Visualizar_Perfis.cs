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
    public partial class frm_Visualizar_Perfis : Form
    {
        Thread Abrir_Tela;

        public frm_Visualizar_Perfis()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Menu);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void Abrir_frm_Menu()
        {
            Application.Run(new frm_Menu());
        }

        private void frm_Visualizar_Perfis_Load(object sender, EventArgs e)
        {
            if (Acesso_DAO.Cargo == "Auxiliar")
            {
                lbl_Selecionar_Perfil.Visible = false;
                cmb_Selecionar_Perfil.Visible = false;
                lbl_Senha.Visible = false;
                txb_Senha.Visible = false;
                lbl_Maximo.Visible = false;
                lbl_Repetir_Senha.Visible = false;
                txb_Repetir_Senha.Visible = false;
                btn_Deletar.Visible = false;
                btn_Editar.Visible = false;
                btn_Salvar.Visible = false;
            }
        }
    }
}
