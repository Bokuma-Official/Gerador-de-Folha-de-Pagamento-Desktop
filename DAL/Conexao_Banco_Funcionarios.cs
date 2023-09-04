using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Conexao_Banco_Funcionarios
    {
        public static string String_Conexao
        {
            get
            {
                return $"Data Source=bokumatm.database.windows.net;Initial Catalog=Funcionarios_Ataron;" +
                    $"Persist Security Info=True;User ID=bokumatm;Password=BkmFPRH@9";
            }
        }
    }
}
