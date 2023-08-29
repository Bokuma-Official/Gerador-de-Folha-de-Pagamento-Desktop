using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Contrato_Empresa
    {
        public int ID_Contrato_Empresa { get; set; }
        public string Data_Admissao { get; set; }
        public string Numero_Conta { get; set; }
        public int Numero_Agencia { get; set; }
        public string Nome_Agencia { get; set; }
        public string Tipo_Contrato { get; set; }
        public string CPF_Funcionario { get; set; }
        public string CBO_Cargo { get; set; }
        public int ID_Departamento { get; set; }
    }
}
