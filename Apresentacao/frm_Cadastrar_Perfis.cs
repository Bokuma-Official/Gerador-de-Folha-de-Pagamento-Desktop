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
    public partial class frm_Cadastrar_Perfis : Form
    {
        public string Repetir_Senha { get; set; }

        public frm_Cadastrar_Perfis()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu frm_menu = new frm_Menu();
            frm_menu.Show();
        }

        private void frm_Cadastrar_Perfis_Shown(object sender, EventArgs e)
        {
            txb_Nome.Focus();
        }

        private void txb_CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_RG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_PIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Carteira_Trabalho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Titulo_Eleitor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Certificado_Militar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Data_Nascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void txb_Telefone_Celular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txb_Telefone_Fixo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txb_CEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Matricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Data_Admissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void chk_Masculino_CheckedChanged(object sender, EventArgs e)
        {
            chk_Feminino.Checked = false;
            chk_Nao_Binario.Checked = false;
        }

        private void chk_Feminino_CheckedChanged(object sender, EventArgs e)
        {
            chk_Masculino.Checked = false;
            chk_Nao_Binario.Checked = false;
        }

        private void chk_Nao_Binario_CheckedChanged(object sender, EventArgs e)
        {
            chk_Masculino.Checked = false;
            chk_Feminino.Checked = false;
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Repetir_Senha = txb_Repetir_Senha.Text;

            Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();
            funcionario_ataron.CPF = txb_CPF.Text;
            funcionario_ataron.Senha = txb_Senha.Text;
            funcionario_ataron.Nome = txb_Nome.Text;
            funcionario_ataron.RG = txb_RG.Text;
            funcionario_ataron.PIS = txb_PIS.Text;
            funcionario_ataron.Carteira_Trabalho = txb_Carteira_Trabalho.Text;
            funcionario_ataron.Titulo_Eleitor = txb_Titulo_Eleitor.Text;

            if (chk_Masculino.Checked == true)
            {
                funcionario_ataron.Sexo = chk_Masculino.Text;
            }

            else if (chk_Feminino.Checked == true)
            {
                funcionario_ataron.Sexo = chk_Feminino.Text;
            }

            else if (chk_Nao_Binario.Checked == true)
            {
                funcionario_ataron.Sexo = chk_Nao_Binario.Text;
            }

            else
            {
                funcionario_ataron.Sexo = "";
            }

            funcionario_ataron.Certificado_Militar = txb_Certificado_Militar.Text;
            funcionario_ataron.Data_Nascimento = txb_Data_Nascimento.Text;
            funcionario_ataron.Telefone_Fixo = txb_Telefone_Fixo.Text;
            funcionario_ataron.Telefone_Celular = txb_Telefone_Celular.Text;
            funcionario_ataron.Email = txb_Email.Text;

            if (txb_Matricula.Text.Length == 0)
            {
                funcionario_ataron.Matricula = 0;
            }

            else
            {
                funcionario_ataron.Matricula = Convert.ToInt32(txb_Matricula.Text);
            }

            funcionario_ataron.Departamento = txb_Departamento.Text;
            funcionario_ataron.Cargo = txb_Cargo.Text;
            funcionario_ataron.Data_Admissao = txb_Data_Admissao.Text;
            funcionario_ataron.CEP = txb_CEP.Text;

            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Cadastro_Perfil(funcionario_ataron, Repetir_Senha);

            if (Controle_Validacao.Cadastro_Perfil_Validado == true && Funcionario_Ataron_DAO.Cadastro_Perfil_Realizado == true)
            {
                Controle_Validacao.Cadastro_Perfil_Validado = false;
                Funcionario_Ataron_DAO.Cadastro_Perfil_Realizado = false;

                txb_Repetir_Senha.Clear();
                txb_CPF.Clear();
                txb_Senha.Clear();
                txb_Nome.Clear();
                txb_RG.Clear();
                txb_PIS.Clear();
                txb_Carteira_Trabalho.Clear();
                txb_Titulo_Eleitor.Clear();
                chk_Masculino.Checked = true;
                chk_Feminino.Checked = false;
                chk_Nao_Binario.Checked = false;
                txb_Certificado_Militar.Clear();
                txb_Data_Nascimento.Clear();
                txb_Telefone_Fixo.Clear();
                txb_Telefone_Celular.Clear();
                txb_Email.Clear();
                txb_Matricula.Clear();
                txb_Departamento.Clear();
                txb_Cargo.Clear();
                txb_Data_Admissao.Clear();
                txb_CEP.Clear();
            }
        }
    }
}
