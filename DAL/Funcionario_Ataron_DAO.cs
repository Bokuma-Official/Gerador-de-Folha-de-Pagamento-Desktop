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
        public static string CPF { get; set; }
        public static bool Senha_Mudada { get; set; }
        public static bool Cadastro_Realizado { get; set; }

        public void Fazer_Login(Funcionario_Ataron funcionario_ataron)
        {
            try
            {
                // pegar a string de conexão na classe conexão_banco_acesso na camada dal
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                // abre a conexão com o banco de dados
                conexao.Open();

                // selecionar tabela funcionario_ataron
                SqlCommand command = new SqlCommand("Select Cargo from Funcionario_Ataron where CPF = @CPF AND Senha = @Senha", conexao);

                // adiciona os parâmetros à consulta
                command.Parameters.AddWithValue("@CPF", funcionario_ataron.CPF);
                command.Parameters.AddWithValue("@Senha", funcionario_ataron.Senha);

                // obter o valor da coluna cargo e atribuir a variável cargo
                Cargo = (string)command.ExecuteScalar();
                CPF = funcionario_ataron.CPF;

                // fecha a conexão com o banco de dados
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

        public void Redefinir_Senha(Funcionario_Ataron funcionario_ataron)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();

                // selecionar o cpf que tenha o mesmo email digitado e salvar na variavel cpf
                SqlCommand command1 = new SqlCommand("select CPF from Funcionario_Ataron where Email = @Email", conexao);

                command1.Parameters.AddWithValue("@Email", funcionario_ataron.Email);

                CPF = (string)command1.ExecuteScalar();

                // atualizar a senha que tenha o mesmo cpf salvo na variável
                SqlCommand command2 = new SqlCommand("update Funcionario_Ataron set Senha = @Senha where CPF = @CPF", conexao);

                command2.Parameters.AddWithValue("@Senha", funcionario_ataron.Senha);
                command2.Parameters.AddWithValue("@CPF", CPF);

                int linhas_afetadas = command2.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("A Senha foi redefinida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Senha_Mudada = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cadastrar_Funcionario(Funcionario_Ataron funcionario_ataron)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();

                
                SqlCommand command = new SqlCommand("insert into Funcionario_Ataron) values (@CPF, @Senha, @Nome, @RG, @PIS, " +
                    "@Carteira_Trabalho, @Titulo_Eleitor, @Sexo, @Certificado_Militar, @Data_Nascimento, @Telefone_Fixo," +
                    " @Telefone_Celular, @Email, @Matricula, @Departamento, @Cargo, @Data_Admissao, @CEP)", conexao);

                command.Parameters.AddWithValue("@CPF", funcionario_ataron.CPF);
                command.Parameters.AddWithValue("@Senha", funcionario_ataron.Senha);
                command.Parameters.AddWithValue("@Nome", funcionario_ataron.Nome);
                command.Parameters.AddWithValue("@RG", funcionario_ataron.RG);
                command.Parameters.AddWithValue("@PIS", funcionario_ataron.PIS);
                command.Parameters.AddWithValue("@Carteira_Trabalho", funcionario_ataron.Carteira_Trabalho);
                command.Parameters.AddWithValue("@Titulo_Eleitor", funcionario_ataron.Titulo_Eleitor);
                command.Parameters.AddWithValue("@Sexo", funcionario_ataron.Sexo);
                command.Parameters.AddWithValue("@Certificado_Militar", funcionario_ataron.Certificado_Militar);
                command.Parameters.AddWithValue("@Data_Nascimento", funcionario_ataron.Data_Nascimento);
                command.Parameters.AddWithValue("@Telefone_Fixo", funcionario_ataron.Telefone_Fixo);
                command.Parameters.AddWithValue("@Telefone_Celular", funcionario_ataron.Telefone_Celular);
                command.Parameters.AddWithValue("@Email", funcionario_ataron.Email);
                command.Parameters.AddWithValue("@Matricula", funcionario_ataron.Matricula);
                command.Parameters.AddWithValue("@Departamento", funcionario_ataron.Departamento);
                command.Parameters.AddWithValue("@Cargo", funcionario_ataron.Cargo);
                command.Parameters.AddWithValue("@Data_Admissao", funcionario_ataron.Data_Admissao);
                command.Parameters.AddWithValue("@CEP", funcionario_ataron.CEP);

                command.ExecuteNonQuery();

                conexao.Close();

                MessageBox.Show("O funcionário foi cadasstrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cadastro_Realizado = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
