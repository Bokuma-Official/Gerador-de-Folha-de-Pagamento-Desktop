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
    public class Funcionario_Ataron_DAO
    {
        // variável estática
        public static string Cargo { get; set; }
        public static bool Mudanca { get; set; }

        public void Verificar_Acesso(Funcionario_Ataron acesso)
        {
            // pegar a string de conexão na classe conexão na camada dal
            SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

            try
            {
                // abre a conexão com o banco de dados
                conexao.Open();

                // selecionar colunas da tabela acesso
                SqlCommand cmd = new SqlCommand("Select Cargo from Acesso where CPF = @CPF AND Senha = @Senha", conexao);

                // adiciona os parâmetros à consulta e verifica se os valores são iguais
                cmd.Parameters.AddWithValue("@CPF", acesso.CPF);
                cmd.Parameters.AddWithValue("@Senha", acesso.Senha);

                // obter o valor da coluna cargo e atribui a variável cargo
                Cargo = (string)cmd.ExecuteScalar();

                conexao.Close();

                // se cargo for nulo, também não conseguiu validar os valores de cpf e senha com o banco
                if (Cargo == null)
                {
                    MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Redefinir_Senha(Funcionario_Ataron acesso)
        {
            SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

            try
            {
                conexao.Open();

                SqlCommand cmd = new SqlCommand("update Acesso set Senha = @Senha where CPF = @CPF", conexao);

                cmd.Parameters.AddWithValue("@CPF", acesso.CPF);
                cmd.Parameters.AddWithValue("@Senha", acesso.Senha);

                int linhas_afetadas = cmd.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("A Senha foi redefinida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mudanca = true;
                }

                else
                {
                    MessageBox.Show("Nenhum registro encontrado com esse CPF!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}