using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Endereco
    {
        int ID_Endereco { get; set; }
        string CEP_Varchar { get; set; }
        string Logradouro { get; set; }
        int Numero { get; set; }
        string Bairro { get; set; }
        string Complemento { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        string CPF_Funcionario { get; set; }

    }
}
