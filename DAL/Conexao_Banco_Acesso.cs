using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Conexao_Banco_Acesso
    {
        public static string String_Conexao
        {
            get
            {
                return $"Data Source=127.0.0.1;Initial Catalog=Acesso_Ataron;" +
                    $"Persist Security Info=True;User ID=bokumatm;Password=bokumatm;" +
                    $"TrustServerCertificate=true;MultipleActiveResultSets=true";
            }
        }
    }
}
