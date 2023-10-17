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
                return "workstation id=Folha_Pagamento_Ataron.mssql.somee.com;packet size=4096;user id=matheusc5_SQLLogin_4;pwd=fr95nw7fgg;data source=Folha_Pagamento_Ataron.mssql.somee.com;persist security info=False;initial catalog=Folha_Pagamento_Ataron;TrustServerCertificate=true;Integrated Security=false";
            }
        }
    }
}
