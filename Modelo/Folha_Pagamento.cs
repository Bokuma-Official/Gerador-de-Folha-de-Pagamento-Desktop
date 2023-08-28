using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Folha_Pagamento
    {
        int ID_Folha_Pagamento { get; set; }
        string Data_Pagamento { get; set; }
        int Horas_Trabalhadas { get; set; }
        decimal Valor_Hora { get; set; }
        int Horas_Faltas { get; set; }
        decimal Desconto_Horas_Faltas {get; set; }
        int Horas_Extras { get; set; }
        decimal Valor_Horas_Extras { get; set; }
        decimal Valor_Vale_Transporte { get; set; }
        decimal Valor_Vale_Alimentacao { get; set; }
        decimal Desconto_INSS { get; set; }
        decimal Desconto_FGTS { get; set; }
        decimal Desconto_IRRF { get; set; }
        decimal Desconto_Vale_Transporte { get; set; }
        decimal Desconto_Vale_Alimentacao { get; set; }
        decimal Desconto_Seguro_Vida { get; set; }
        int Dias_Ferias { get; set; }
        decimal Valor_Ferias { get; set; }
        decimal Valor_13_Salario { get; set; }
        decimal Salario_Bruto { get; set; }
        decimal Salario_Liquido { get; set; }
        int CPF_Funcionario { get; set; }

        public void Cadastrar_Folha_Pagamento()
        {

        }
        public void editar_Folha_Pagamento()
        {

        }
        public void Visualizar_Folha_Pagamento()
        {

        }


    }
}
