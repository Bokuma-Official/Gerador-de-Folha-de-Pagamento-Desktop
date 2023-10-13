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
    public partial class frm_Visualizar_Editar_Excluir_Folhas_Pagamento : Form
    {
        public string Nome_Funcionario_Selecionado { get; set; }
        public string CPF_Funcionario_Selecionado { get; set; }
        public string Data_Pagamento_Funcionario_Selecionado { get; set; }
        public string Salario_13 { get; set; }

        public frm_Visualizar_Editar_Excluir_Folhas_Pagamento()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Menu frm_menu = new frm_Menu();
            frm_menu.Show();
        }

        private void txb_Horas_Trabalhadas_TextChanged(object sender, EventArgs e)
        {
            int maximo = 200;

            if (int.TryParse(txb_Horas_Trabalhadas.Text, out int valor) && valor >= 0)
            {
                if (valor > 200)
                {
                    txb_Horas_Trabalhadas.Text = "200";

                    int horas_trabalhadas = Convert.ToInt32(txb_Horas_Trabalhadas.Text);
                    int horas_faltas = maximo - horas_trabalhadas;
                    txb_Horas_Faltas.Text = horas_faltas.ToString();

                    txb_Valor_Hora_TextChanged(txb_Valor_Hora, EventArgs.Empty);
                }

                else if (valor == 200)
                {
                    txb_Horas_Extras.ReadOnly = false;
                    txb_Valor_Horas_Extras.ReadOnly = false;

                    txb_Horas_Faltas.Text = "0";

                    txb_Valor_Hora_TextChanged(txb_Valor_Hora, EventArgs.Empty);
                }

                else if (valor == 0)
                {
                    txb_Horas_Faltas.Text = "200";

                    txb_Valor_Hora_TextChanged(txb_Valor_Hora, EventArgs.Empty);
                }

                else
                {
                    txb_Horas_Extras.ReadOnly = true;
                    txb_Valor_Horas_Extras.ReadOnly = true;
                    txb_Horas_Extras.Text = "";
                    txb_Valor_Horas_Extras.Text = "";

                    int horas_trabalhadas = Convert.ToInt32(txb_Horas_Trabalhadas.Text);
                    int horas_faltas = maximo - horas_trabalhadas;
                    txb_Horas_Faltas.Text = horas_faltas.ToString();

                    txb_Valor_Hora_TextChanged(txb_Valor_Hora, EventArgs.Empty);
                }
            }

            else
            {
                txb_Horas_Extras.ReadOnly = true;
                txb_Valor_Horas_Extras.ReadOnly = true;
                txb_Horas_Extras.Text = "";
                txb_Valor_Horas_Extras.Text = "";
                txb_Horas_Faltas.Text = "";
                txb_Desconto_Faltas.Text = "";

                txb_Valor_Hora_TextChanged(txb_Valor_Hora, EventArgs.Empty);
            }
        }

        private void txb_Valor_Hora_TextChanged(object sender, EventArgs e)
        {
            decimal valor_hora;
            int horas_faltas;

            if (decimal.TryParse(txb_Valor_Hora.Text, out valor_hora)
                && int.TryParse(txb_Horas_Faltas.Text, out horas_faltas) && horas_faltas >= 0)
            {
                if (horas_faltas > 0)
                {
                    txb_Desconto_Faltas.Text = (valor_hora * horas_faltas).ToString();

                    txb_Horas_Extras.ReadOnly = true;
                    txb_Valor_Horas_Extras.ReadOnly = true;
                    txb_Horas_Extras.Text = "";
                    txb_Valor_Horas_Extras.Text = "";
                }

                else
                {
                    txb_Desconto_Faltas.Text = "0,00";
                }
            }

            else
            {
                txb_Desconto_Faltas.Text = "";
            }
        }

        private void txb_Dias_Ferias_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txb_Dias_Ferias.Text, out int valor) && valor >= 0)
            {
                if (valor > 30)
                {
                    txb_Dias_Ferias.Text = "30";
                }
            }
        }

        private void txb_Data_Pagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void txb_Valor_Hora_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Valor_Hora.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Horas_Trabalhadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Horas_Extras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Valor_Horas_Extras_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Valor_Horas_Extras.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Dias_Ferias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Valor_Vale_Transporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Valor_Vale_Transporte.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Vale_Transporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Desconto_Vale_Transporte.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Valor_Vale_Alimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Valor_Vale_Alimentacao.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Vale_Alimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Desconto_Vale_Alimentacao.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Seguro_Vida_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Desconto_Seguro_Vida.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_INSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Desconto_INSS.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_IRRF_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool numero = Char.IsNumber(e.KeyChar);
            bool outra_tecla = Char.IsControl(e.KeyChar);
            bool virgula = e.KeyChar == ',';

            if (virgula)
            {
                if (txb_Desconto_IRRF.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!numero && !outra_tecla)
            {
                e.Handled = true;
            }
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
            this.funcionarioTableAdapter.Fill(this.folha_Pagamento_Ataron_Funcionario_DataSet.Funcionario);
            cmb_Pagamento.SelectedItem = null;
        }

        private void cmb_Selecionar_Funcionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex != -1)
            {
                Nome_Funcionario_Selecionado = cmb_Selecionar_Funcionario.Text;

                cmb_Pagamento.Enabled = true;

                Funcionario funcionario = new Funcionario();
                Contrato_Empresa contrato_empresa = new Contrato_Empresa();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Funcionario_Tela_Folha_De_Pagamento
                    (funcionario, contrato_empresa, Nome_Funcionario_Selecionado);

                txb_CPF.Text = funcionario.CPF;
                txb_Cargo.Text = contrato_empresa.Cargo;
                txb_Dependentes.Text = funcionario.Dependentes.ToString();

                CPF_Funcionario_Selecionado = txb_CPF.Text;
            }

            else
            {
                cmb_Selecionar_Funcionario.Text = "";
            }
        }

        private void cmb_Pagamento_DropDown(object sender, EventArgs e)
        {
            /* uma lista será criada para armazenar na combobox de pagamento as datas de pagamento
            de acordo com o funcionário selecionado na combobox de funcionário */
            List<string> lista_datas_pagamento = new List<string>();

            Controle_Validacao controle_validacao = new Controle_Validacao();
            controle_validacao.Verificar_Visualizacao_Data_Pagamento_Tela_Folha_De_Pagamento
                (CPF_Funcionario_Selecionado, lista_datas_pagamento);

            cmb_Pagamento.DataSource = lista_datas_pagamento;
        }

        private void cmb_Pagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex != -1)
            {
                Data_Pagamento_Funcionario_Selecionado = cmb_Pagamento.Text;

                Folha_Pagamento folha_pagamento = new Folha_Pagamento();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Folha_Pagamento_Por_Funcionario_E_Data_Pagamento
                    (folha_pagamento, CPF_Funcionario_Selecionado, Data_Pagamento_Funcionario_Selecionado);

                txb_Data_Pagamento.Text = folha_pagamento.Data_Pagamento;
                txb_Horas_Trabalhadas.Text = folha_pagamento.Horas_Trabalhadas.ToString();
                txb_Valor_Hora.Text = folha_pagamento.Valor_Hora;
                txb_Horas_Extras.Text = folha_pagamento.Horas_Extras.ToString();
                txb_Valor_Horas_Extras.Text = folha_pagamento.Valor_Horas_Extras;
                txb_Valor_Vale_Transporte.Text = folha_pagamento.Valor_Vale_Transporte;
                txb_Desconto_Vale_Transporte.Text = folha_pagamento.Desconto_Vale_Transporte;
                txb_Valor_Vale_Alimentacao.Text = folha_pagamento.Valor_Vale_Alimentacao;
                txb_Desconto_Vale_Alimentacao.Text = folha_pagamento.Desconto_Vale_Alimentacao;
                txb_Desconto_Seguro_Vida.Text = folha_pagamento.Desconto_Seguro_Vida;
                txb_Dias_Ferias.Text = folha_pagamento.Dias_Ferias.ToString();
                txb_Valor_Ferias.Text = folha_pagamento.Valor_Ferias;
                txb_13_Salario.Text = folha_pagamento.Valor_13_Salario;

                if (txb_13_Salario.Text == "0,00")
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

                txb_Desconto_FGTS.Text = folha_pagamento.Desconto_FGTS;
                txb_Desconto_INSS.Text = folha_pagamento.Desconto_INSS;
                txb_Desconto_IRRF.Text = folha_pagamento.Desconto_IRRF;
                txb_Horas_Faltas.Text = folha_pagamento.Horas_Faltas.ToString();
                txb_Desconto_Faltas.Text = folha_pagamento.Desconto_Horas_Faltas;
                txb_Salario_Bruto.Text = folha_pagamento.Salario_Bruto;
                txb_Salario_Liquido.Text = folha_pagamento.Salario_Liquido;
            }

            else
            {
                cmb_Pagamento.Text = "";
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex == -1 || cmb_Pagamento.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Funcionário e uma " +
                    "Data de Pagamento para deletar uma Folha de Pagamento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Exclusao_Folha_Pagamento(CPF_Funcionario_Selecionado,
                    Data_Pagamento_Funcionario_Selecionado);

                if (Controle_Validacao.Deletar_Folha_De_Pagamento_Validado == true && Folha_Pagamento_DAO.Folha_De_Pagamento_Deletada == true)
                {
                    Controle_Validacao.Deletar_Folha_De_Pagamento_Validado = false;
                    Folha_Pagamento_DAO.Folha_De_Pagamento_Deletada = false;

                    this.Hide();
                    frm_Visualizar_Editar_Excluir_Folhas_Pagamento frm_visualizar_editar_excluir_folhas_pagamento = new frm_Visualizar_Editar_Excluir_Folhas_Pagamento();
                    frm_visualizar_editar_excluir_folhas_pagamento.Show();
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex == -1 || cmb_Pagamento.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um Funcionário e uma " +
                    "Data de Pagamento para editar uma Folha de Pagamento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                Folha_Pagamento folha_pagamento = new Folha_Pagamento();

                folha_pagamento.Data_Pagamento = txb_Data_Pagamento.Text;

                if (txb_Horas_Trabalhadas.Text.Length == 0)
                {
                    folha_pagamento.Horas_Trabalhadas = 0;
                }

                else
                {
                    folha_pagamento.Horas_Trabalhadas = Convert.ToInt32(txb_Horas_Trabalhadas.Text);
                }

                folha_pagamento.Valor_Hora = txb_Valor_Hora.Text;

                if (txb_Horas_Extras.Text.Length == 0 || txb_Horas_Extras.Text == "0")
                {
                    txb_Horas_Extras.Text = "0";
                    txb_Valor_Horas_Extras.Text = "0,00";
                    folha_pagamento.Horas_Extras = Convert.ToInt32(txb_Horas_Extras.Text);
                }

                else
                {
                    folha_pagamento.Horas_Extras = Convert.ToInt32(txb_Horas_Extras.Text);
                }

                if (txb_Valor_Horas_Extras.Text.Length == 0)
                {
                    txb_Valor_Horas_Extras.Text = "0,00";
                    folha_pagamento.Valor_Horas_Extras = txb_Valor_Horas_Extras.Text;
                }

                else
                {
                    folha_pagamento.Valor_Horas_Extras = txb_Valor_Horas_Extras.Text;
                }

                folha_pagamento.Valor_Vale_Transporte = txb_Valor_Vale_Transporte.Text;

                if (txb_Desconto_Vale_Transporte.Text.Length == 0)
                {
                    txb_Desconto_Vale_Transporte.Text = "0,00";
                    folha_pagamento.Desconto_Vale_Transporte = txb_Desconto_Vale_Transporte.Text;
                }

                else
                {
                    folha_pagamento.Desconto_Vale_Transporte = txb_Desconto_Vale_Transporte.Text;
                }

                folha_pagamento.Valor_Vale_Alimentacao = txb_Valor_Vale_Alimentacao.Text;

                if (txb_Desconto_Vale_Alimentacao.Text.Length == 0)
                {
                    txb_Desconto_Vale_Alimentacao.Text = "0,00";
                    folha_pagamento.Desconto_Vale_Alimentacao = txb_Desconto_Vale_Alimentacao.Text;
                }

                else
                {
                    folha_pagamento.Desconto_Vale_Alimentacao = txb_Desconto_Vale_Alimentacao.Text;
                }

                folha_pagamento.Desconto_Seguro_Vida = txb_Desconto_Seguro_Vida.Text;

                if (txb_Dias_Ferias.Text == "")
                {
                    txb_Dias_Ferias.Text = "0";
                    folha_pagamento.Dias_Ferias = Convert.ToInt32(txb_Dias_Ferias.Text);

                }

                else
                {
                    folha_pagamento.Dias_Ferias = Convert.ToInt32(txb_Dias_Ferias.Text);
                }

                if (txb_Horas_Faltas.Text.Length == 0)
                {
                    folha_pagamento.Horas_Faltas = 0;
                }

                else
                {
                    folha_pagamento.Horas_Faltas = Convert.ToInt32(txb_Horas_Faltas.Text);
                }

                folha_pagamento.Desconto_Horas_Faltas = txb_Desconto_Faltas.Text;
                folha_pagamento.Desconto_INSS = txb_Desconto_INSS.Text;
                folha_pagamento.Desconto_IRRF = txb_Desconto_IRRF.Text;

                if (chk_Nao.Checked == true)
                {
                    Salario_13 = "Não";
                }

                else if (chk_Sim.Checked == true)
                {
                    Salario_13 = "Sim";
                }

                else
                {
                    Salario_13 = "";
                }

                Controle_Validacao controle_validacao1 = new Controle_Validacao();
                controle_validacao1.Verificar_Folha_Pagamento(folha_pagamento, Salario_13);

                if (Controle_Validacao.Folha_Pagamento_Validado == true)
                {
                    Controle_Validacao.Folha_Pagamento_Validado = false;

                    #region Conta do Valor do Salário Bruto
                    int horas_trabalhadas = int.Parse(txb_Horas_Trabalhadas.Text);
                    decimal valor_hora = decimal.Parse(txb_Valor_Hora.Text);
                    decimal salario_bruto = (horas_trabalhadas * valor_hora);
                    txb_Salario_Bruto.Text = salario_bruto.ToString("F2");
                    #endregion

                    #region Conta do Desconto de FGTS
                    decimal salario_bruto_conta_fgts = Decimal.Parse(txb_Salario_Bruto.Text);
                    decimal desconto_fgts;
                    // 8% de desconto
                    desconto_fgts = salario_bruto_conta_fgts * 0.08m;
                    txb_Desconto_FGTS.Text = desconto_fgts.ToString("F2");
                    folha_pagamento.Desconto_FGTS = txb_Desconto_FGTS.Text;
                    #endregion

                    #region Conta do Valor de Férias
                    decimal salario_bruto_conta_ferias = decimal.Parse(txb_Salario_Bruto.Text);
                    int dias_ferias = int.Parse(txb_Dias_Ferias.Text);
                    decimal desconto_inss_conta_ferias = decimal.Parse(txb_Desconto_INSS.Text);
                    decimal desconto_irrf_conta_ferias = decimal.Parse(txb_Desconto_IRRF.Text);

                    if (dias_ferias == 0)
                    {
                        txb_Valor_Ferias.Text = "0,00";
                        folha_pagamento.Valor_Ferias = txb_Valor_Ferias.Text;
                    }

                    else
                    {
                        decimal valor_ferias = (salario_bruto_conta_ferias / 30 * dias_ferias / 3 * 4) - desconto_inss_conta_ferias - desconto_irrf_conta_ferias;
                        txb_Valor_Ferias.Text = valor_ferias.ToString("F2");
                        folha_pagamento.Valor_Ferias = txb_Valor_Ferias.Text;
                    }
                    #endregion

                    #region Conta do Valor do 13º Salário
                    decimal salario_bruto_conta_13_salario = decimal.Parse(txb_Salario_Bruto.Text);
                    decimal desconto_inss_conta_13_salario = decimal.Parse(txb_Desconto_INSS.Text);
                    decimal desconto_irrf_conta_13_salario = decimal.Parse(txb_Desconto_IRRF.Text);
                    decimal decimo_terceiro_salario = 0.00m;

                    if (chk_Sim.Checked == true)
                    {
                        decimo_terceiro_salario = salario_bruto_conta_13_salario - desconto_inss_conta_13_salario - desconto_irrf_conta_13_salario;
                    }

                    txb_13_Salario.Text = decimo_terceiro_salario.ToString("F2");
                    folha_pagamento.Valor_13_Salario = txb_13_Salario.Text;
                    #endregion

                    #region Conta do Valor do Salário Bruto se tiver Horas Extras, 13º Salário ou Férias
                    decimal salario_bruto_final = decimal.Parse(txb_Salario_Bruto.Text);
                    int horas_extras = int.Parse(txb_Horas_Extras.Text);
                    decimal valor_horas_extras = decimal.Parse(txb_Valor_Horas_Extras.Text);
                    decimal valor_ferias_conta_salario_bruto = decimal.Parse(txb_Valor_Ferias.Text);
                    decimal decimo_terceiro_salario_conta_salario_bruto = decimal.Parse(txb_13_Salario.Text);
                    salario_bruto_final = salario_bruto_final + (horas_extras * valor_horas_extras) + valor_ferias_conta_salario_bruto + decimo_terceiro_salario_conta_salario_bruto;
                    txb_Salario_Bruto.Text = salario_bruto_final.ToString("F2");
                    folha_pagamento.Salario_Bruto = txb_Salario_Bruto.Text;
                    #endregion

                    #region Conta do Salário Líquido
                    decimal salario_bruto_conta_salario_liquido = decimal.Parse(txb_Salario_Bruto.Text);
                    decimal desconto_faltas = decimal.Parse(txb_Desconto_Faltas.Text);
                    decimal desconto_vale_transporte = decimal.Parse(txb_Desconto_Vale_Transporte.Text);
                    decimal desconto_vale_alimentacao = decimal.Parse(txb_Desconto_Vale_Alimentacao.Text);
                    decimal desconto_seguro_vida = decimal.Parse(txb_Desconto_Seguro_Vida.Text);
                    decimal desconto_fgts_conta_salario_liquido = decimal.Parse(txb_Desconto_FGTS.Text);
                    decimal desconto_inss_conta_salario_liquido = decimal.Parse(txb_Desconto_INSS.Text);
                    decimal desconto_irff_conta_salario_liquido = decimal.Parse(txb_Desconto_IRRF.Text);
                    int dependentes = int.Parse(txb_Dependentes.Text);
                    decimal salario_liquido = salario_bruto_conta_salario_liquido -
                        desconto_faltas - desconto_vale_transporte - desconto_vale_alimentacao -
                        desconto_seguro_vida - desconto_fgts_conta_salario_liquido -
                        desconto_inss_conta_salario_liquido - desconto_irff_conta_salario_liquido - (dependentes * 189.59m);
                    txb_Salario_Liquido.Text = salario_liquido.ToString("F2");
                    folha_pagamento.Salario_Liquido = txb_Salario_Liquido.Text;
                    #endregion

                    Controle_Validacao controle_validacao2 = new Controle_Validacao();
                    controle_validacao2.Verificar_Edicao_Folha_Pagamento(folha_pagamento, CPF_Funcionario_Selecionado, Data_Pagamento_Funcionario_Selecionado);

                    if (Controle_Validacao.Editar_Folha_De_Pagamento_Validado == true && Folha_Pagamento_DAO.Folha_De_Pagamento_Atualizada == true)
                    {
                        Controle_Validacao.Editar_Folha_De_Pagamento_Validado = false;
                        Folha_Pagamento_DAO.Folha_De_Pagamento_Atualizada = false;

                        this.Hide();
                        frm_Visualizar_Editar_Excluir_Folhas_Pagamento frm_visualizar_editar_excluir_folhas_pagamento = new frm_Visualizar_Editar_Excluir_Folhas_Pagamento();
                        frm_visualizar_editar_excluir_folhas_pagamento.Show();
                    }
                }
            }
        }
    }
}