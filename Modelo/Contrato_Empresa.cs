using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Contrato_Empresa
    {
        int ID_Contrato_Empresa { get; set; }
        string Data_Admissao { get; set; }
        string Numero_Conta { get; set; }
        int Numero_Agencia { get; set; }
        string Nome_Agencia { get; set; }
        string Funcao_Varchar { get; set; }
        string Tipo_Contrato { get; set; }
        string CPF_Funcionario { get; set; }
        string CBO_Cargo { get; set; }
        int ID_Departamento { get; set; }



    }
}
