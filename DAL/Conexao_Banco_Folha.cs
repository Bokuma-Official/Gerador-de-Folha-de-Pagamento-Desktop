using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Conexao_Banco_Folha
    {
        public static string String_Conexao
        {
            get
            {
                return @"Data Source=Matheus-C5\SQLEXPRESS;" +
                        @"Initial Catalog=Folha_Pagamento_Ataron;" +
                        @"TrustServerCertificate=True;" +
                        @"Integrated Security=True";
            }
        }
    }
}
