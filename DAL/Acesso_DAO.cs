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
        public static string Cargo { get; set; }

        public void Verificar_Acesso(List<String> listaDadosPessoa)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao_Banco_Funcionarios.String_Conexao))
            {
                // abre a conexão com o banco de dados
                conexao.Open();

                // cria uma instância da classe sqlcommand para selecionar colunas da tabela acesso
                SqlCommand cmd = new SqlCommand("Select Cargo from Acesso where CPF = @CPF AND Senha = @Senha", conexao);

                // adiciona os parâmetros à consulta sql e verifica se os valores são iguais
                cmd.Parameters.AddWithValue("@CPF", listaDadosPessoa[0]);
                cmd.Parameters.AddWithValue("@Senha", listaDadosPessoa[1]);

                // Executa uma consulta sql para obter o valor da coluna cargo
                Cargo = (string)cmd.ExecuteScalar();

                // se cargo for nulo, também não conseguiu validar os valores da lista com o banco
                if (Cargo == null)
                {
                    MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // fecha a conexão com o banco de dados
                conexao.Close();
            }
        }
    }
}