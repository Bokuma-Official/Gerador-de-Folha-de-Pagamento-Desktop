using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Folha_Pagamento_DAO
    {
        public static bool Cadastro_Folha_De_Pagamento_Realizado { get; set; }
        public static bool Folha_De_Pagamento_Deletada { get; set; }
        public static bool Folha_De_Pagamento_Atualizada { get; set; }

        public void Visualizar_Funcionario_Folha_De_Pagamento(Funcionario funcionario,
            Contrato_Empresa contrato_empresa, string nome_funcionario_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command1 = new SqlCommand("select CPF from Funcionario where Nome = @Nome", conexao);
                command1.Parameters.AddWithValue("@Nome", nome_funcionario_selecionado);
                string cpf = (string)command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand("select CPF, Dependentes from Funcionario where CPF = @CPF", conexao);
                command2.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader data_reader1;
                data_reader1 = command2.ExecuteReader();

                if (data_reader1.HasRows)
                {
                    data_reader1.Read();

                    funcionario.CPF = data_reader1["CPF"].ToString();
                    funcionario.Dependentes = data_reader1.GetInt32(1);

                    data_reader1.Close();
                }

                SqlCommand command3 = new SqlCommand("select Cargo from Contrato_Empresa where CPF = @CPF", conexao);
                command3.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader data_reader2;
                data_reader2 = command3.ExecuteReader();

                if (data_reader2.HasRows)
                {
                    data_reader2.Read();

                    contrato_empresa.Cargo = data_reader2["Cargo"].ToString();

                    data_reader2.Close();
                }
                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
