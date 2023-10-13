using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Visualizar_Editar_Excluir_Perfis : Form
    {
        public string Nome_Perfil_Selecionado { get; set; }
        public string CPF_Perfil_Selecionado { get; set; }

        public frm_Visualizar_Editar_Excluir_Perfis()
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
            if (!Funcionario_Ataron_DAO.Cargo_Perfil_Logado.ToLower().Contains("gerente"))
            {
                lbl_Visualizar_Editar_Excluir.Text = "Visualizar Perfil";
                lbl_Visualizar_Editar_Excluir.Location = new Point(260, 40);
                lbl_Selecionar_Perfil.Visible = false;
                cmb_Selecionar_Perfil.Visible = false;
                btn_Voltar.Location = new Point(345, 460);
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
                txb_Certificado_Militar.ReadOnly = true;
                txb_RG.ReadOnly = true;
                chk_Masculino.AutoCheck = false;
                chk_Feminino.AutoCheck = false;
                chk_Nao_Binario.AutoCheck = false;
                txb_Telefone_Celular.ReadOnly = true;
                txb_Telefone_Fixo.ReadOnly = true;
                txb_Titulo_Eleitor.ReadOnly = true;

                // exibir o perfil para não gerentes
                Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Perfil_Para_Nao_Gerente(funcionario_ataron);

                txb_CPF.Text = funcionario_ataron.CPF;
                txb_Senha.Text = funcionario_ataron.Senha;
                txb_Nome.Text = funcionario_ataron.Nome;
                txb_RG.Text = funcionario_ataron.RG;
                txb_PIS.Text = funcionario_ataron.PIS;
                txb_Carteira_Trabalho.Text = funcionario_ataron.Carteira_Trabalho;
                txb_Titulo_Eleitor.Text = funcionario_ataron.Titulo_Eleitor;

                if (funcionario_ataron.Sexo == "Masculino")
                {
                    chk_Masculino.Checked = true;
                    chk_Masculino.CheckState = CheckState.Checked;
                    chk_Feminino.Checked = false;
                    chk_Feminino.CheckState = CheckState.Unchecked;
                    chk_Nao_Binario.Checked = false;
                    chk_Nao_Binario.CheckState = CheckState.Unchecked;
                }

                else if (funcionario_ataron.Sexo == "Feminino")
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

                txb_Certificado_Militar.Text = funcionario_ataron.Certificado_Militar;
                txb_Data_Nascimento.Text = funcionario_ataron.Data_Nascimento;
                txb_Telefone_Fixo.Text = funcionario_ataron.Telefone_Fixo;
                txb_Telefone_Celular.Text = funcionario_ataron.Telefone_Celular;
                txb_Email.Text = funcionario_ataron.Email;
                txb_Matricula.Text = funcionario_ataron.Matricula.ToString();
                txb_Departamento.Text = funcionario_ataron.Departamento;
                txb_Cargo.Text = funcionario_ataron.Cargo;
                txb_Data_Admissao.Text = funcionario_ataron.Data_Admissao;
                txb_CEP.Text = funcionario_ataron.CEP;
            }
        }

        private void cmb_Selecionar_Perfil_DropDown(object sender, EventArgs e)
        {
            // carregar a coluna nome da tabela funcionarios_ataron e exibir na combobox
            this.funcionario_AtaronTableAdapter.Fill(this.acesso_AtaronDataSet.Funcionario_Ataron);
        }

        private void cmb_Selecionar_Perfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ao selecionar um nome na combobox vai preencher todos os campos
            if (cmb_Selecionar_Perfil.SelectedIndex != -1)
            {
                Nome_Perfil_Selecionado = cmb_Selecionar_Perfil.Text;

                Funcionario_Ataron funcionario_ataron = new Funcionario_Ataron();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Perfil_Para_Gerente(funcionario_ataron, Nome_Perfil_Selecionado);

                txb_CPF.Text = funcionario_ataron.CPF;
                txb_Senha.Text = funcionario_ataron.Senha;
                txb_Nome.Text = funcionario_ataron.Nome;
                txb_RG.Text = funcionario_ataron.RG;
                txb_PIS.Text = funcionario_ataron.PIS;
                txb_Carteira_Trabalho.Text = funcionario_ataron.Carteira_Trabalho;
                txb_Titulo_Eleitor.Text = funcionario_ataron.Titulo_Eleitor;

                if (funcionario_ataron.Sexo == "Masculino")
                {
                    chk_Masculino.Checked = true;
                    chk_Masculino.CheckState = CheckState.Checked;
                    chk_Feminino.Checked = false;
                    chk_Feminino.CheckState = CheckState.Unchecked;
                    chk_Nao_Binario.Checked = false;
                    chk_Nao_Binario.CheckState = CheckState.Unchecked;
                }

                else if (funcionario_ataron.Sexo == "Feminino")
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

                txb_Certificado_Militar.Text = funcionario_ataron.Certificado_Militar;
                txb_Data_Nascimento.Text = funcionario_ataron.Data_Nascimento;
                txb_Telefone_Fixo.Text = funcionario_ataron.Telefone_Fixo;
                txb_Telefone_Celular.Text = funcionario_ataron.Telefone_Celular;
                txb_Email.Text = funcionario_ataron.Email;
                txb_Matricula.Text = funcionario_ataron.Matricula.ToString();
                txb_Departamento.Text = funcionario_ataron.Departamento;
                txb_Cargo.Text = funcionario_ataron.Cargo;
                txb_Data_Admissao.Text = funcionario_ataron.Data_Admissao;
                txb_CEP.Text = funcionario_ataron.CEP;

                CPF_Perfil_Selecionado = txb_CPF.Text;
            }

            else
            {
                cmb_Selecionar_Perfil.Text = "";
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Perfil.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Perfil para deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Exclusao_Perfil(CPF_Perfil_Selecionado);

                if (Controle_Validacao.Deletar_Perfil_Validado == true && Funcionario_Ataron_DAO.Perfil_Deletado == true)
                {
                    Controle_Validacao.Deletar_Perfil_Validado = false;
                    Funcionario_Ataron_DAO.Perfil_Deletado = false;

                    this.Hide();
                    frm_Visualizar_Editar_Excluir_Perfis frm_visualizar_editar_excluir_perfis = new frm_Visualizar_Editar_Excluir_Perfis();
                    frm_visualizar_editar_excluir_perfis.Show();
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Perfil.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Perfil para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
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
                controle_validacao.Verificar_Edicao_Perfil(funcionario_ataron, CPF_Perfil_Selecionado);

                if (Controle_Validacao.Editar_Perfil_Validado == true && Funcionario_Ataron_DAO.Perfil_Atualizado == true)
                {
                    Controle_Validacao.Editar_Perfil_Validado = false;
                    Funcionario_Ataron_DAO.Perfil_Atualizado = false;

                    this.Hide();
                    frm_Visualizar_Editar_Excluir_Perfis frm_visualizar_editar_excluir_perfis = new frm_Visualizar_Editar_Excluir_Perfis();
                    frm_visualizar_editar_excluir_perfis.Show();
                }
            }
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

        private void frm_Visualizar_Editar_Excluir_Perfis_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
