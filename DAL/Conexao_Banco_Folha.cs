﻿using System;
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
                return $"Data Source=bokuma.c5x1dupdjcvc.us-east-2.rds.amazonaws.com,1433;Initial Catalog=Folha_Pagamento_Ataron;Persist Security Info=True;User ID=bokumatm;Password=bokumatm";
            }
        }
    }
}
