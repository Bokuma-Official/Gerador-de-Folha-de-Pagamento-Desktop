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
    public class Funcionario_DAO
    {
        public static bool Cadastro_Funcionario_Realizado { get; set; }
        public static bool Funcionario_Deletado { get; set; }
        public static bool Funcionario_Atualizado { get; set; }

        public void Cadastrar_Funcionario(Funcionario funcionario, Endereco endereco,
            Contrato_Empresa contrato_empresa)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command1 = new SqlCommand("insert into Funcionario values (@CPF, @Senha, @Nome," +
                    "@Data_Nascimento, @Sexo, @PCD, @PIS, @RG, @Carteira_Trabalho, @Titulo_Eleitor," +
                    "@Certificado_Militar, @Matricula, @Telefone_Fixo, @Telefone_Celular, @Email, @Dependentes)", conexao);

                command1.Parameters.AddWithValue("@CPF", funcionario.CPF);
                command1.Parameters.AddWithValue("@Senha", funcionario.Senha);
                command1.Parameters.AddWithValue("@Nome", funcionario.Nome);
                command1.Parameters.AddWithValue("@Data_Nascimento", funcionario.Data_Nascimento);
                command1.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                command1.Parameters.AddWithValue("@PCD", funcionario.PCD);
                command1.Parameters.AddWithValue("@PIS", funcionario.PIS);
                command1.Parameters.AddWithValue("@RG", funcionario.RG);
                command1.Parameters.AddWithValue("@Carteira_Trabalho", funcionario.Carteira_Trabalho);
                command1.Parameters.AddWithValue("@Titulo_Eleitor", funcionario.Titulo_Eleitor);
                command1.Parameters.AddWithValue("@Certificado_Militar", funcionario.Certificado_Militar);
                command1.Parameters.AddWithValue("@Matricula", funcionario.Matricula);
                command1.Parameters.AddWithValue("@Telefone_Fixo", funcionario.Telefone_Fixo);
                command1.Parameters.AddWithValue("@Telefone_Celular", funcionario.Telefone_Celular);
                command1.Parameters.AddWithValue("@Email", funcionario.Email);
                command1.Parameters.AddWithValue("@Dependentes", funcionario.Dependentes);

                int linhas_afetadas_tabela_funcionario = command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("insert into Endereco (CEP, Logradouro, Numero," +
                    "Bairro, Complemento, Cidade, Estado, CPF) values (@CEP, @Logradouro, @Numero, @Bairro," +
                    "@Complemento, @Cidade, @Estado, @CPF)", conexao);

                command2.Parameters.AddWithValue("@CEP", endereco.CEP);
                command2.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                command2.Parameters.AddWithValue("@Numero", endereco.Numero);
                command2.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                command2.Parameters.AddWithValue("@Complemento", endereco.Complemento);
                command2.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                command2.Parameters.AddWithValue("@Estado", endereco.Estado);
                command2.Parameters.AddWithValue("@CPF", funcionario.CPF);

                int linhas_afetadas_tabela_endereco = command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand("insert into Contrato_Empresa (Data_Admissao," +
                    "Numero_Conta, Numero_Agencia, Nome_Agencia, Tipo_Contrato, Cargo, CBO_Cargo," +
                    "Departamento, CPF) values (@Data_Admissao, @Numero_Conta, @Numero_Agencia, @Nome_Agencia," +
                    "@Tipo_Contrato, @Cargo, @CBO_Cargo, @Departamento, @CPF)", conexao);

                command3.Parameters.AddWithValue("@Data_Admissao", contrato_empresa.Data_Admissao);
                command3.Parameters.AddWithValue("@Numero_Conta", contrato_empresa.Numero_Conta);
                command3.Parameters.AddWithValue("@Numero_Agencia", contrato_empresa.Numero_Agencia);
                command3.Parameters.AddWithValue("@Nome_Agencia", contrato_empresa.Nome_Agencia);
                command3.Parameters.AddWithValue("@Tipo_Contrato", contrato_empresa.Tipo_Contrato);
                command3.Parameters.AddWithValue("@Cargo", contrato_empresa.Cargo);
                command3.Parameters.AddWithValue("@CBO_Cargo", contrato_empresa.CBO_Cargo);
                command3.Parameters.AddWithValue("@Departamento", contrato_empresa.Departamento);
                command3.Parameters.AddWithValue("@CPF", funcionario.CPF);

                int linhas_afetadas_tabela_contrato_empresa = command3.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas_tabela_funcionario > 0 && linhas_afetadas_tabela_endereco > 0
                    && linhas_afetadas_tabela_contrato_empresa > 0)
                {
                    MessageBox.Show("O Funcionário foi cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cadastro_Funcionario_Realizado = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro de Banco de Dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Visualizar_Funcionario(Funcionario funcionario, Endereco endereco,
            Contrato_Empresa contrato_empresa, string nome_perfil_selecionado)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(Conexao_Banco_Folha.String_Conexao);

                conexao.Open();

                SqlCommand command1 = new SqlCommand("select CPF from Funcionario where Nome = @Nome", conexao);

                command1.Parameters.AddWithValue("@Nome", nome_perfil_selecionado);

                string cpf = (string)command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand("SELECT CPF, Senha, Nome, Data_Nascimento, Sexo," +
                    "PCD, PIS, RG, Carteira_Trabalho, Titulo_Eleitor, Certificado_Militar, Matricula," +
                    "Telefone_Fixo, Telefone_Celular, Email, Dependentes FROM Funcionario WHERE CPF = @CPF", conexao);

                command2.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader data_reader1;

                data_reader1 = command2.ExecuteReader();

                if (data_reader1.HasRows)
                {
                    data_reader1.Read();

                    funcionario.CPF = data_reader1["CPF"].ToString();
                    funcionario.Senha = data_reader1["Senha"].ToString();
                    funcionario.Nome = data_reader1["Nome"].ToString();
                    funcionario.Data_Nascimento = data_reader1["Data_Nascimento"].ToString();
                    funcionario.Sexo = data_reader1["Sexo"].ToString();
                    funcionario.PCD = data_reader1["PCD"].ToString();
                    funcionario.PIS = data_reader1["PIS"].ToString();
                    funcionario.RG = data_reader1["RG"].ToString();
                    funcionario.Carteira_Trabalho = data_reader1["Carteira_Trabalho"].ToString();
                    funcionario.Titulo_Eleitor = data_reader1["Titulo_Eleitor"].ToString();
                    funcionario.Certificado_Militar = data_reader1["Certificado_Militar"].ToString();
                    funcionario.Matricula = data_reader1.GetInt32(11);
                    funcionario.Telefone_Fixo = data_reader1["Telefone_Fixo"].ToString();
                    funcionario.Telefone_Celular = data_reader1["Telefone_Celular"].ToString();
                    funcionario.Email = data_reader1["Email"].ToString();
                    funcionario.Dependentes = data_reader1.GetInt32(15);

                    data_reader1.Close();
                }

                SqlCommand command3 = new SqlCommand("SELECT CEP, Logradouro, Numero, Bairro, Complemento," +
                    "Cidade, Estado FROM Endereco WHERE CPF = @CPF", conexao);

                command3.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader data_reader2;

                data_reader2 = command3.ExecuteReader();

                if (data_reader2.HasRows)
                {
                    data_reader2.Read();

                    endereco.CEP = data_reader2["CEP"].ToString();
                    endereco.Logradouro = data_reader2["Logradouro"].ToString();
                    endereco.Numero = data_reader2.GetInt32(2);
                    endereco.Bairro = data_reader2["Bairro"].ToString();
                    endereco.Complemento = data_reader2["Complemento"].ToString();
                    endereco.Cidade = data_reader2["Cidade"].ToString();
                    endereco.Estado = data_reader2["Estado"].ToString();

                    data_reader2.Close();
                }

                SqlCommand command4 = new SqlCommand("SELECT Data_Admissao, Numero_Conta, Numero_Agencia," +
                    "Nome_Agencia, Tipo_Contrato, Cargo, CBO_Cargo, Departamento FROM Contrato_Empresa WHERE CPF = @CPF", conexao);

                command4.Parameters.AddWithValue("@CPF", cpf);

                SqlDataReader data_reader3;

                data_reader3 = command4.ExecuteReader();

                if (data_reader3.HasRows)
                {
                    data_reader3.Read();

                    contrato_empresa.Data_Admissao = data_reader3["Data_Admissao"].ToString();
                    contrato_empresa.Numero_Conta = data_reader3["Numero_Conta"].ToString();
                    contrato_empresa.Numero_Agencia = data_reader3.GetInt32(2);
                    contrato_empresa.Nome_Agencia = data_reader3["Nome_Agencia"].ToString();
                    contrato_empresa.Tipo_Contrato = data_reader3["Tipo_Contrato"].ToString();
                    contrato_empresa.Cargo = data_reader3["Cargo"].ToString();
                    contrato_empresa.CBO_Cargo = data_reader3["CBO_Cargo"].ToString();
                    contrato_empresa.Departamento = data_reader3["Departamento"].ToString();

                    data_reader3.Close();
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
