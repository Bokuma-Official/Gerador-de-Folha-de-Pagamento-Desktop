﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Funcionario
    {
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Data_Nascimento { get; set; }
        public string Sexo { get; set; }
        public string PCD { get; set; }
        public string PIS { get; set; }
        public string RG { get; set; }
        public string Carteira_Trabalho { get; set; }
        public string Titulo_Eleitor { get; set; }
        public string Certificado_Militar { get; set; }
        public int Matricula { get; set; }
        public string Telefone_Fixo { get; set; }
        public string Telefone_Celular { get; set; }
        public string Email { get; set; }
        public int Dependentes { get; set; }

        public DAL.Funcionario_DAO Funcionario_DAO
        {
            get => default;
            set
            {
            }
        }
    }
}
