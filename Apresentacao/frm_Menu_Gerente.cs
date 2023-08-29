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
    public partial class frm_Menu_Gerente : Form
    {
        Thread Abrir_Tela;

        public frm_Menu_Gerente()
        {
            InitializeComponent();
        }

        private void Abrir_frm_Login()
        {
            // abrir tela de login
            Application.Run(new frm_Login());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // voltar a tela de login
            DialogResult pergunta = MessageBox.Show("Deseja realmente encerrar esta sessão?", "Encerrar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                this.Hide();
                Abrir_Tela = new Thread(Abrir_frm_Login);
                Abrir_Tela.SetApartmentState(ApartmentState.STA);
                Abrir_Tela.Start();
            }

            else
            {
                
            }
        }
    }
}
