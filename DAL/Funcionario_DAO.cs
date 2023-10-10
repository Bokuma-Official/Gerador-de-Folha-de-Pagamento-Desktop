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

        public void Cadastrar_Funcionario(Funcionario funcionario, Endereco endereco, Cargo cargo,
            Departamento departamento, Contrato_Empresa contrato_empresa)
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
                command1.Parameters.AddWithValue("@Sexo", funcionario.Senha);
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

                SqlCommand command3 = new SqlCommand("insert into Cargo values (@CBO_Cargo, @Nome, @CPF)", conexao);

                command3.Parameters.AddWithValue("@CBO_Cargo", cargo.CBO_Cargo);
                command3.Parameters.AddWithValue("@Nome", cargo.Nome);
                command3.Parameters.AddWithValue("@CPF", funcionario.CPF);

                int linhas_afetadas_tabela_cargo = command3.ExecuteNonQuery();

                SqlCommand command4 = new SqlCommand("insert into Departamento (Nome, CPF, CBO_Cargo)" +
                    "values (@Nome, @CPF, @CBO_Cargo)", conexao);

                command4.Parameters.AddWithValue("@Nome", departamento.Nome);
                command4.Parameters.AddWithValue("@CPF", funcionario.CPF);
                command4.Parameters.AddWithValue("@CBO_Cargo", cargo.CBO_Cargo);

                int linhas_afetadas_tabela_departamento = command4.ExecuteNonQuery();

                SqlCommand command5 = new SqlCommand("select ID_Departamento from Departamento where CPF = @CPF", conexao);

                command5.Parameters.AddWithValue("@CPF", funcionario.CPF);

                int id_departamento = (int)command5.ExecuteScalar();

                SqlCommand command6 = new SqlCommand("insert into Contrato_Empresa (Data_Admissao," +
                    "Numero_Conta, Numero_Agencia, Nome_Agencia, Tipo_Contrato, CPF, CBO_Cargo," +
                    "ID_Departamento) values (@Data_Admissao, @Numero_Conta, @Numero_Agencia, @Nome_Agencia," +
                    "@Tipo_Contrato, @CPF, @CBO_Cargo, @ID_Departamento)", conexao);

                command6.Parameters.AddWithValue("@Data_Admissao", contrato_empresa.Data_Admissao);
                command6.Parameters.AddWithValue("@Numero_Conta", contrato_empresa.Numero_Conta);
                command6.Parameters.AddWithValue("@Numero_Agencia", contrato_empresa.Numero_Agencia);
                command6.Parameters.AddWithValue("@Nome_Agencia", contrato_empresa.Nome_Agencia);
                command6.Parameters.AddWithValue("@Tipo_Contrato", contrato_empresa.Tipo_Contrato);
                command6.Parameters.AddWithValue("@CPF", funcionario.CPF);
                command6.Parameters.AddWithValue("@CBO_Cargo", cargo.CBO_Cargo);
                command6.Parameters.AddWithValue("@ID_Departamento", id_departamento);

                int linhas_afetadas_tabela_contrato_empresa = command6.ExecuteNonQuery();

                conexao.Close();

                if (linhas_afetadas_tabela_funcionario > 0 && linhas_afetadas_tabela_endereco > 0
                    && linhas_afetadas_tabela_cargo > 0 && linhas_afetadas_tabela_departamento > 0
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
    }
}
