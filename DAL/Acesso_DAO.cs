using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; // biblioteca para conectar no banco de dados
using Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao;
using System.Windows.Forms;
using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using System.Threading;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Acesso_DAO
    {
        // variável estática
        public static string Cargo { get; set; }

        public void Verificar_Acesso(Acesso acesso)
        {
            // pegar a string de conexão na classe conexão na camada dal
            SqlConnection conexao = new SqlConnection(Conexao_Banco_Funcionarios.String_Conexao);
            
            // abre a conexão com o banco de dados
            conexao.Open();

            // selecionar colunas da tabela acesso
            SqlCommand cmd = new SqlCommand("Select Cargo from Acesso where CPF = @CPF AND Senha = @Senha", conexao);

            // adiciona os parâmetros à consulta e verifica se os valores são iguais
            cmd.Parameters.AddWithValue("@CPF", acesso.CPF);
            cmd.Parameters.AddWithValue("@Senha", acesso.Senha);

            // obter o valor da coluna cargo
            Cargo = (string)cmd.ExecuteScalar();

            // se cargo for nulo, também não conseguiu validar os valores de cpf e senha com o banco
            if (Cargo == null)
            {
                MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // fecha a conexão com o banco de dados
            conexao.Close(); 
        }
    }
}