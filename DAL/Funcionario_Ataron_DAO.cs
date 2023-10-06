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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Funcionario_Ataron_DAO
    {
        // variável estática
        public static string Cargo_Perfil_Logado { get; set; }
        public static string CPF_Perfil_Logado { get; set; }
        public static bool Senha_Perfil_Mudada { get; set; }
        public static bool Cadastro_Perfil_Realizado { get; set; }
        public static bool Perfil_Deletado { get; set; }
        public static bool Perfil_Atualizado { get; set; }

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
                Cargo_Perfil_Logado = (string)command.ExecuteScalar();
                CPF_Perfil_Logado = funcionario_ataron.CPF;

                // fecha a conexão com o banco de dados
                conexao.Close();

                // se cargo for nulo, também não conseguiu validar os valores de cpf e senha com o banco
                if (Cargo_Perfil_Logado == null)
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

                CPF_Perfil_Logado = (string)command1.ExecuteScalar();

                // atualizar a senha que tenha o mesmo cpf salvo na variável
                SqlCommand command2 = new SqlCommand("update Funcionario_Ataron set Senha = @Senha where CPF = @CPF", conexao);

                command2.Parameters.AddWithValue("@Senha", funcionario_ataron.Senha);
                command2.Parameters.AddWithValue("@CPF", CPF_Perfil_Logado);

                int linhas_afetadas = command2.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("A Senha foi redefinida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Senha_Perfil_Mudada = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cadastrar_Perfil(Funcionario_Ataron funcionario_ataron)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();
                
                SqlCommand command = new SqlCommand("insert into Funcionario_Ataron values (@CPF, @Senha, @Nome, @RG, @PIS, " +
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

                int linhas_afetadas = command.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("O perfil foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cadastro_Perfil_Realizado = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Visualizar_Perfil_Para_Nao_Gerente(Funcionario_Ataron funcionario_ataron)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("select * from Funcionario_Ataron where CPF = @CPF", conexao);

                command.Parameters.AddWithValue("@CPF", CPF_Perfil_Logado);

                /* uso do data reader para pegar os valores selecionados do banco
                e atribuir a classe funcionario_ataron */
                SqlDataReader data_reader;

                data_reader = command.ExecuteReader();

                if (data_reader.HasRows)
                {
                    data_reader.Read();

                    funcionario_ataron.CPF = data_reader["CPF"].ToString();
                    funcionario_ataron.Senha = data_reader["Senha"].ToString();
                    funcionario_ataron.Nome = data_reader["Nome"].ToString();
                    funcionario_ataron.RG = data_reader["RG"].ToString();
                    funcionario_ataron.PIS = data_reader["PIS"].ToString();
                    funcionario_ataron.Carteira_Trabalho = data_reader["Carteira_Trabalho"].ToString();
                    funcionario_ataron.Titulo_Eleitor = data_reader["Titulo_Eleitor"].ToString();
                    funcionario_ataron.Sexo = data_reader["Sexo"].ToString();
                    funcionario_ataron.Certificado_Militar = data_reader["Certificado_Militar"].ToString();
                    funcionario_ataron.Data_Nascimento = data_reader["Data_Admissao"].ToString();
                    funcionario_ataron.Telefone_Fixo = data_reader["Telefone_Fixo"].ToString();
                    funcionario_ataron.Telefone_Celular = data_reader["Telefone_Celular"].ToString();
                    funcionario_ataron.Email = data_reader["Email"].ToString();
                    funcionario_ataron.Matricula = data_reader.GetInt32(13);
                    funcionario_ataron.Departamento = data_reader["Departamento"].ToString();
                    funcionario_ataron.Cargo = data_reader["Cargo"].ToString();
                    funcionario_ataron.Data_Admissao = data_reader["Data_Admissao"].ToString();
                    funcionario_ataron.CEP = data_reader["CEP"].ToString();

                    data_reader.Close();
                }

                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Visualizar_Perfil_Para_Gerente(Funcionario_Ataron funcionario_ataron, string nome_perfil_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("select * from Funcionario_Ataron where Nome = @Nome", conexao);

                command.Parameters.AddWithValue("@Nome", nome_perfil_selecionado);

                SqlDataReader data_reader;

                data_reader = command.ExecuteReader();

                if (data_reader.HasRows)
                {
                    data_reader.Read();

                    funcionario_ataron.CPF = data_reader["CPF"].ToString();
                    funcionario_ataron.Senha = data_reader["Senha"].ToString();
                    funcionario_ataron.Nome = data_reader["Nome"].ToString();
                    funcionario_ataron.RG = data_reader["RG"].ToString();
                    funcionario_ataron.PIS = data_reader["PIS"].ToString();
                    funcionario_ataron.Carteira_Trabalho = data_reader["Carteira_Trabalho"].ToString();
                    funcionario_ataron.Titulo_Eleitor = data_reader["Titulo_Eleitor"].ToString();
                    funcionario_ataron.Sexo = data_reader["Sexo"].ToString();
                    funcionario_ataron.Certificado_Militar = data_reader["Certificado_Militar"].ToString();
                    funcionario_ataron.Data_Nascimento = data_reader["Data_Admissao"].ToString();
                    funcionario_ataron.Telefone_Fixo = data_reader["Telefone_Fixo"].ToString();
                    funcionario_ataron.Telefone_Celular = data_reader["Telefone_Celular"].ToString();
                    funcionario_ataron.Email = data_reader["Email"].ToString();
                    funcionario_ataron.Matricula = data_reader.GetInt32(13);
                    funcionario_ataron.Departamento = data_reader["Departamento"].ToString();
                    funcionario_ataron.Cargo = data_reader["Cargo"].ToString();
                    funcionario_ataron.Data_Admissao = data_reader["Data_Admissao"].ToString();
                    funcionario_ataron.CEP = data_reader["CEP"].ToString();

                    data_reader.Close();
                }

                conexao.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Deletar_Perfil (Funcionario_Ataron funcionario_ataron, string cpf_perfil_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Acesso.String_Conexao);

                conexao.Open();

                SqlCommand command = new SqlCommand("delete from Funcionario_Ataron where CPF = @CPF", conexao);

                command.Parameters.AddWithValue("@CPF", cpf_perfil_selecionado);

                int linhas_afetadas = command.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas > 0)
                {
                    MessageBox.Show("O perfil foi deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Perfil_Deletado = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Editar_Perfil(Funcionario_Ataron funcionario_ataron, string cpf_perfil_selecionado)
        {

        }
    }
}
