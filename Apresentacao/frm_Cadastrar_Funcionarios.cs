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
    public partial class frm_Cadastrar_Funcionarios : Form
    {
        public string Repetir_Senha { get; set; }
        public frm_Cadastrar_Funcionarios()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu frm_menu = new frm_Menu();
            frm_menu.Show();
        }

        private void frm_Cadastrar_Funcionarios_Shown(object sender, EventArgs e)
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

        private void txb_Data_Nascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
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

        private void txb_Dependentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void txb_Admissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void txb_Telefone_Celular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_Telefone_Fixo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-')
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

        private void txb_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Numero_Agencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Numero_Conta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txb_CBO_Cargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        // alterar check de outras checkbox se uma foi checada
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

        private void chk_Nao_CheckedChanged(object sender, EventArgs e)
        {
            chk_Sim.Checked = false;
        }

        private void chk_Sim_CheckedChanged(object sender, EventArgs e)
        {
            chk_Nao.Checked = false;
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Repetir_Senha = txb_Repetir_Senha.Text;

            Funcionario funcionario = new Funcionario();
            Endereco endereco = new Endereco();
            Contrato_Empresa contrato_empresa = new Contrato_Empresa();

            funcionario.Nome = txb_Nome.Text;
            funcionario.CPF = txb_CPF.Text;
            funcionario.RG = txb_RG.Text;
            funcionario.Data_Nascimento = txb_Data_Nascimento.Text;
            funcionario.PIS = txb_PIS.Text;
            funcionario.Carteira_Trabalho = txb_Carteira_Trabalho.Text;
            funcionario.Titulo_Eleitor = txb_Titulo_Eleitor.Text;
            funcionario.Certificado_Militar = txb_Certificado_Militar.Text;

            if (txb_Dependentes.Text.Length == 0)
            {
                txb_Dependentes.Text = "0";
                funcionario.Dependentes = Convert.ToInt32(txb_Dependentes.Text);
            }

            else
            {
                funcionario.Dependentes = Convert.ToInt32(txb_Dependentes.Text);
            }

            if (txb_Matricula.Text.Length == 0)
            {
                funcionario.Matricula = 0;
            }

            else
            {
                funcionario.Matricula = Convert.ToInt32(txb_Matricula.Text);
            }

            contrato_empresa.Departamento = txb_Departamento.Text;
            contrato_empresa.Cargo = txb_Cargo.Text;
            contrato_empresa.Data_Admissao = txb_Admissao.Text;
            contrato_empresa.Tipo_Contrato = txb_Tipo_Contrato.Text;
            contrato_empresa.CBO_Cargo = txb_CBO_Cargo.Text;
            funcionario.Email = txb_Email.Text;
            funcionario.Telefone_Celular = txb_Telefone_Celular.Text;
            funcionario.Telefone_Fixo = txb_Telefone_Fixo.Text;
            endereco.CEP = txb_CEP.Text;
            endereco.Estado = txb_Estado.Text;
            endereco.Cidade = txb_Cidade.Text;
            endereco.Bairro = txb_Bairro.Text;
            endereco.Logradouro = txb_Logradouro.Text;

            if (txb_Numero.Text.Length == 0)
            {
                endereco.Numero = 0;
            }

            else
            {
                endereco.Numero = Convert.ToInt32(txb_Numero.Text);
            }

            endereco.Complemento = txb_Complemento.Text;
            contrato_empresa.Nome_Agencia = txb_Agencia.Text;

            if (txb_Numero_Agencia.Text.Length == 0)
            {
                contrato_empresa.Numero_Agencia = 0;
            }

            else
            {
                contrato_empresa.Numero_Agencia = Convert.ToInt32(txb_Numero_Agencia.Text);
            }

            contrato_empresa.Numero_Conta = txb_Numero_Conta.Text;
            funcionario.Senha = txb_Senha.Text;

            if (chk_Masculino.Checked == true)
            {
                funcionario.Sexo = chk_Masculino.Text;
            }

            else if (chk_Feminino.Checked == true)
            {
                funcionario.Sexo = chk_Feminino.Text;
            }

            else if (chk_Nao_Binario.Checked == true)
            {
                funcionario.Sexo = chk_Nao_Binario.Text;
            }

            else
            {
                funcionario.Sexo = "";
            }

            if (chk_Nao.Checked == true)
            {
                funcionario.PCD = chk_Nao.Text;
            }
            
            else if (chk_Sim.Checked == true)
            {
                funcionario.PCD = chk_Sim.Text;
            }

            else
            {
                funcionario.PCD = "";
            }

            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Cadastro_Funcionario(funcionario, endereco, contrato_empresa, Repetir_Senha);

            if (Controle_Validacao.Cadastro_Funcionario_Validado == true && Funcionario_DAO.Cadastro_Funcionario_Realizado == true)
            {
                Controle_Validacao.Cadastro_Funcionario_Validado = false;
                Funcionario_DAO.Cadastro_Funcionario_Realizado = false;

                txb_Repetir_Senha.Clear();
                txb_Nome.Clear();
                txb_CPF.Clear();
                txb_RG.Clear();
                txb_Data_Nascimento.Clear();
                txb_PIS.Clear();
                txb_Carteira_Trabalho.Clear();
                txb_Titulo_Eleitor.Clear();
                txb_Certificado_Militar.Clear();
                txb_Dependentes.Clear();
                txb_Matricula.Clear();
                txb_Departamento.Clear();
                txb_Cargo.Clear();
                txb_Admissao.Clear();
                txb_Tipo_Contrato.Clear();
                txb_CBO_Cargo.Clear();
                txb_Email.Clear();
                txb_Telefone_Celular.Clear();
                txb_Telefone_Fixo.Clear();
                txb_CEP.Clear();
                txb_Estado.Clear();
                txb_Cidade.Clear();
                txb_Bairro.Clear();
                txb_Logradouro.Clear();
                txb_Numero.Clear();
                txb_Complemento.Clear();
                txb_Agencia.Clear();
                txb_Numero_Agencia.Clear();
                txb_Numero_Conta.Clear();
                txb_Senha.Clear();
                chk_Masculino.Checked = true;
                chk_Masculino.CheckState = CheckState.Checked;
                chk_Feminino.Checked = false;
                chk_Nao_Binario.Checked = false;
                chk_Nao.Checked = true;
                chk_Nao.CheckState = CheckState.Checked;
                chk_Sim.Checked = false;
            }
        }
    }
}
