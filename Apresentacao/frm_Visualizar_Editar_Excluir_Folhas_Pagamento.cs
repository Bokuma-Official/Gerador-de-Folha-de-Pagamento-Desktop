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
    public partial class frm_Visualizar_Editar_Excluir_Folhas_Pagamento : Form
    {
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
                txb_Desconto_Horas_Faltas.Text = "";

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
                    txb_Desconto_Horas_Faltas.Text = (valor_hora * horas_faltas).ToString();

                    txb_Horas_Extras.ReadOnly = true;
                    txb_Valor_Horas_Extras.ReadOnly = true;
                    txb_Horas_Extras.Text = "";
                    txb_Valor_Horas_Extras.Text = "";
                }

                else
                {
                    txb_Desconto_Horas_Faltas.Text = "0,00";
                }
            }

            else
            {
                txb_Desconto_Horas_Faltas.Text = "";
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

        private void txb_Valor_Ferias_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txb_13_Salario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txb_Desconto_INSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_FGTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_IRRF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Horas_Faltas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txb_Desconto_Horas_Faltas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Salario_Bruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txb_Salario_Liquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
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

        private void txb_Valor_Ferias_TextChanged(object sender, EventArgs e)
        {
            if (txb_Valor_Ferias.Text != "")
            {
                txb_Dias_Ferias.ReadOnly = false;
            }

            else
            {
                txb_Dias_Ferias.ReadOnly = true;
                txb_Dias_Ferias.Text = "";
            }
        }
    }
}