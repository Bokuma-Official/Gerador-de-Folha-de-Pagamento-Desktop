using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Folha_Pagamento
    {
        public int ID_Folha_Pagamento { get; set; }
        public string Data_Pagamento { get; set; }
        public int Horas_Trabalhadas { get; set; }
        public decimal Valor_Hora { get; set; }
        public int Horas_Faltas { get; set; }
        public decimal Desconto_Horas_Faltas {get; set; }
        public int Horas_Extras { get; set; }
        public decimal Valor_Horas_Extras { get; set; }
        public decimal Valor_Vale_Transporte { get; set; }
        public decimal Valor_Vale_Alimentacao { get; set; }
        public decimal Desconto_INSS { get; set; }
        public decimal Desconto_FGTS { get; set; }
        public decimal Desconto_IRRF { get; set; }
        public decimal Desconto_Vale_Transporte { get; set; }
        public decimal Desconto_Vale_Alimentacao { get; set; }
        public decimal Desconto_Seguro_Vida { get; set; }
        public int Dias_Ferias { get; set; }
        public decimal Valor_Ferias { get; set; }
        public decimal Valor_13_Salario { get; set; }
        public decimal Salario_Bruto { get; set; }
        public decimal Salario_Liquido { get; set; }
        public int CPF_Funcionario { get; set; }

        public void Cadastrar_Folha_Pagamento()
        {

        }

        public void Editar_Folha_Pagamento()
        {

        }

        public void Visualizar_Folha_Pagamento()
        {

        }
    }
}
