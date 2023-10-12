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
    public partial class frm_Cadastrar_Folhas_Pagamento : Form
    {
        public string Nome_Funcionario_Selecionado { get; set; }
        public string CPF_Funcionario_Selecionado { get; set; }

        public frm_Cadastrar_Folhas_Pagamento()
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
            // quando o campo de horas trabalhadas for alterado, outros campos também serão alterados
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
            // quando o campo de valor por hora trabalhado for alterado, outros campos também serão alterados
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

        private void frm_Cadastrar_Folhas_Pagamento_Shown(object sender, EventArgs e)
        {
            txb_Data_Pagamento.Focus();
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Vale_Transporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Valor_Vale_Alimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Vale_Alimentacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Seguro_Vida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Dias_Ferias_TextChanged(object sender, EventArgs e)
        {
            // quando o campo de dias de férias for maior que 30, voltará a ficar no valor máximo permitido que é 30
            if (int.TryParse(txb_Dias_Ferias.Text, out int valor) && valor >= 0)
            {
                if (valor > 30)
                {
                    txb_Dias_Ferias.Text = "30";
                }
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
        }

        private void cmb_Selecionar_Funcionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Selecionar_Funcionario.SelectedIndex != -1)
            {
                Nome_Funcionario_Selecionado = cmb_Selecionar_Funcionario.Text;

                Funcionario funcionario = new Funcionario();
                Contrato_Empresa contrato_empresa = new Contrato_Empresa();

                Controle_Validacao controle_validacao = new Controle_Validacao();
                controle_validacao.Verificar_Visualizacao_Funcionario_Folha_De_Pagamento(funcionario, contrato_empresa, Nome_Funcionario_Selecionado);

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
    }
}