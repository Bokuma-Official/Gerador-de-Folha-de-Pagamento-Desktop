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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Visualizar_Editar_Excluir_Funcionarios : Form
    {
        public string Nome_Funcionario_Selecionado { get; set; }
        public string CPF_Funcionario_Selecionado { get; set; }

        public frm_Visualizar_Editar_Excluir_Funcionarios()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu frm_menu = new frm_Menu();
            frm_menu.Show();
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

        private void cmb_Selecionar_Funcionario_DropDown(object sender, EventArgs e)
        {
            this.funcionarioTableAdapter.Fill(this.folha_Pagamento_AtaronDataSet.Funcionario);
        }

        private void cmb_Selecionar_Funcionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex != -1)
            {
                Nome_Funcionario_Selecionado = cmb_Selecionar_Funcionario.Text;

                Funcionario funcionario = new Funcionario();
                Endereco endereco = new Endereco();
                Contrato_Empresa contrato_empresa = new Contrato_Empresa();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Funcionario(funcionario, endereco, contrato_empresa, Nome_Funcionario_Selecionado);

                txb_Nome.Text = funcionario.Nome;
                txb_CPF.Text = funcionario.CPF;
                txb_RG.Text = funcionario.RG;
                txb_Data_Nascimento.Text = funcionario.Data_Nascimento;
                txb_PIS.Text = funcionario.PIS;
                txb_Carteira_Trabalho.Text = funcionario.Carteira_Trabalho;
                txb_Titulo_Eleitor.Text = funcionario.Titulo_Eleitor;
                txb_Certificado_Militar.Text = funcionario.Certificado_Militar;
                txb_Dependentes.Text = funcionario.Dependentes.ToString();
                txb_Matricula.Text = funcionario.Matricula.ToString();
                txb_Departamento.Text = contrato_empresa.Departamento;
                txb_Cargo.Text = contrato_empresa.Cargo;
                txb_Admissao.Text = contrato_empresa.Data_Admissao;
                txb_Tipo_Contrato.Text = contrato_empresa.Tipo_Contrato;
                txb_CBO_Cargo.Text = contrato_empresa.CBO_Cargo;
                txb_Email.Text = funcionario.Email;
                txb_Telefone_Celular.Text = funcionario.Telefone_Celular;
                txb_Telefone_Fixo.Text = funcionario.Telefone_Fixo;
                txb_CEP.Text = endereco.CEP;
                txb_Estado.Text = endereco.Estado;
                txb_Cidade.Text = endereco.Cidade;
                txb_Bairro.Text = endereco.Bairro;
                txb_Logradouro.Text = endereco.Logradouro;
                txb_Numero.Text = endereco.Numero.ToString();
                txb_Complemento.Text = endereco.Complemento;
                txb_Agencia.Text = contrato_empresa.Nome_Agencia;
                txb_Numero_Agencia.Text = contrato_empresa.Numero_Agencia.ToString();
                txb_Numero_Conta.Text = contrato_empresa.Numero_Conta;
                txb_Senha.Text = funcionario.Senha;

                if (funcionario.Sexo == "Masculino")
                {
                    chk_Masculino.Checked = true;
                    chk_Masculino.CheckState = CheckState.Checked;
                    chk_Feminino.Checked = false;
                    chk_Feminino.CheckState = CheckState.Unchecked;
                    chk_Nao_Binario.Checked = false;
                    chk_Nao_Binario.CheckState = CheckState.Unchecked;
                }

                else if (funcionario.Sexo == "Feminino")
                {
                    chk_Feminino.Checked = true;
                    chk_Feminino.CheckState = CheckState.Checked;
                    chk_Masculino.Checked = false;
                    chk_Masculino.CheckState = CheckState.Unchecked;
                    chk_Nao_Binario.Checked = false;
                    chk_Nao_Binario.CheckState = CheckState.Unchecked;
                }

                else
                {
                    chk_Nao_Binario.Checked = true;
                    chk_Nao_Binario.CheckState = CheckState.Checked;
                    chk_Masculino.Checked = false;
                    chk_Masculino.CheckState = CheckState.Unchecked;
                    chk_Feminino.Checked = false;
                    chk_Feminino.CheckState = CheckState.Unchecked;
                }

                if (funcionario.PCD == "Não")
                {
                    chk_Nao.Checked = true;
                    chk_Nao.CheckState = CheckState.Checked;
                    chk_Sim.Checked = false;
                    chk_Sim.CheckState = CheckState.Unchecked;
                }

                else
                {
                    chk_Sim.Checked = true;
                    chk_Sim.CheckState = CheckState.Checked;
                    chk_Nao.Checked = false;
                    chk_Nao.CheckState = CheckState.Unchecked;
                }

                CPF_Funcionario_Selecionado = txb_CPF.Text;
            }

            else
            {
                cmb_Selecionar_Funcionario.Text = "";
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Funcionário para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Exclusao_Funcionario(CPF_Funcionario_Selecionado);

                if (Controle_Validacao.Deletar_Funcionario_Validado == true && Funcionario_DAO.Funcionario_Deletado == true)
                {
                    Controle_Validacao.Deletar_Funcionario_Validado = false;
                    Funcionario_DAO.Funcionario_Deletado = false;

                    this.Hide();
                    frm_Visualizar_Editar_Excluir_Funcionarios frm_visualizar_editar_excluir_funcionarios = new frm_Visualizar_Editar_Excluir_Funcionarios();
                    frm_visualizar_editar_excluir_funcionarios.Show();
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Funcionário para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
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
                controle_validacao.Verificar_Edicao_Funcionario(funcionario, endereco, contrato_empresa, CPF_Funcionario_Selecionado);

                if (Controle_Validacao.Editar_Funcionario_Validado == true && Funcionario_DAO.Funcionario_Atualizado == true)
                {
                    Controle_Validacao.Editar_Funcionario_Validado = false;
                    Funcionario_DAO.Funcionario_Atualizado = false;

                    this.Hide();
                    frm_Visualizar_Editar_Excluir_Funcionarios frm_visualizar_editar_excluir_funcionarios = new frm_Visualizar_Editar_Excluir_Funcionarios();
                    frm_visualizar_editar_excluir_funcionarios.Show();
                }
            }
        }

        private void frm_Visualizar_Editar_Excluir_Funcionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
