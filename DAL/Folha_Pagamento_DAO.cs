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

        public void Visualizar_Funcionario_Tela_Folha_De_Pagamento(Funcionario funcionario,
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

        public void Visualizar_Data_Pagamento_Tela_Folha_De_Pagamento(string cpf_funcionario_selecionado,
            List<String> lista_datas_pagamento)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("select Data_Pagamento from Folha_Pagamento where CPF = @CPF", conexao);
                command.Parameters.AddWithValue("@CPF", cpf_funcionario_selecionado);

                SqlDataReader data_reader;
                data_reader = command.ExecuteReader();

                while (data_reader.Read())
                {
                    lista_datas_pagamento.Add(data_reader["Data_Pagamento"].ToString());
                }

                data_reader.Close();

                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Visualizar_Folha_Pagamento_Por_Funcionario_E_Data_Pagamento(Folha_Pagamento folha_pagamento,
                string cpf_funcionario_selecionado, string data_pagamento_funcionario_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("select Data_Pagamento, Horas_Trabalhadas," +
                    "Valor_Hora, Horas_Faltas, Desconto_Horas_Faltas, Horas_Extras, Valor_Horas_Extras," +
                    "Valor_Vale_Transporte, Valor_Vale_Alimentacao, Desconto_INSS, Desconto_FGTS," +
                    "Desconto_IRRF, Desconto_Vale_Transporte, Desconto_Vale_Alimentacao," +
                    "Desconto_Seguro_Vida, Dias_Ferias, Valor_Ferias, Valor_13_Salario, Salario_Bruto," +
                    "Salario_Liquido from Folha_Pagamento where CPF = @CPF and Data_Pagamento = @Data_Pagamento", conexao);
                command.Parameters.AddWithValue("@CPF", cpf_funcionario_selecionado);
                command.Parameters.AddWithValue("@Data_Pagamento", data_pagamento_funcionario_selecionado);

                SqlDataReader data_reader;
                data_reader = command.ExecuteReader();

                if (data_reader.HasRows)
                {
                    data_reader.Read();

                    folha_pagamento.Data_Pagamento = data_reader["Data_Pagamento"].ToString();
                    folha_pagamento.Horas_Trabalhadas = data_reader.GetInt32(1);
                    folha_pagamento.Valor_Hora = data_reader["Valor_Hora"].ToString();
                    folha_pagamento.Horas_Faltas = data_reader.GetInt32(3);
                    folha_pagamento.Desconto_Horas_Faltas = data_reader["Desconto_Horas_Faltas"].ToString();
                    folha_pagamento.Horas_Extras = data_reader.GetInt32(5);
                    folha_pagamento.Valor_Horas_Extras = data_reader["Valor_Horas_Extras"].ToString();
                    folha_pagamento.Valor_Vale_Transporte = data_reader["Valor_Vale_Transporte"].ToString();
                    folha_pagamento.Valor_Vale_Alimentacao = data_reader["Valor_Vale_Alimentacao"].ToString();
                    folha_pagamento.Desconto_INSS = data_reader["Desconto_INSS"].ToString();
                    folha_pagamento.Desconto_FGTS = data_reader["Desconto_FGTS"].ToString();
                    folha_pagamento.Desconto_IRRF = data_reader["Desconto_IRRF"].ToString();
                    folha_pagamento.Desconto_Vale_Transporte = data_reader["Desconto_Vale_Transporte"].ToString();
                    folha_pagamento.Desconto_Vale_Alimentacao = data_reader["Desconto_Vale_Alimentacao"].ToString();
                    folha_pagamento.Desconto_Seguro_Vida = data_reader["Desconto_Seguro_Vida"].ToString();
                    folha_pagamento.Dias_Ferias = data_reader.GetInt32(15);
                    folha_pagamento.Valor_Ferias = data_reader["Valor_Ferias"].ToString();
                    folha_pagamento.Valor_13_Salario = data_reader["Valor_13_Salario"].ToString();
                    folha_pagamento.Salario_Bruto = data_reader["Salario_Bruto"].ToString();
                    folha_pagamento.Salario_Liquido = data_reader["Salario_Liquido"].ToString();

                    data_reader.Close();
                }

                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Deletar_Folha_Pagamento(string cpf_funcionario_selecionado,
            string data_pagamento_funcionario_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("delete from Folha_Pagamento where CPF = @CPF and Data_Pagamento = @Data_Pagamento", conexao);
                command.Parameters.AddWithValue("@CPF", cpf_funcionario_selecionado);
                command.Parameters.AddWithValue("@Data_Pagamento", data_pagamento_funcionario_selecionado);
                int linhas_afetadas = command.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("A Folha de Pagamento foi deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Folha_De_Pagamento_Deletada = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cadastrar_Folha_Pagamento(Folha_Pagamento folha_pagamento,
            string cpf_funcionario_selecionado)
        {

        }

        public void Editar_Folha_Pagamento(Folha_Pagamento folha_pagamento,
            string cpf_funcionario_selecionado, string data_pagamento_funcionario_selecionado)
        {

        }
    }
}
