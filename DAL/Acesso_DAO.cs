using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // biblioteca para conectar o banco de dados
using Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao;
using System.Windows.Forms;
using Gerador_de_Folha_de_Pagamento_Desktop.Modelo;
using System.Threading;

namespace Gerador_de_Folha_de_Pagamento_Desktop.DAL
{
    public class Acesso_DAO
    {
        Thread Abrir_Tela;

        public bool Verificar_Acesso(string cpf, string senha)
        {
            using (SqlConnection conexao = new SqlConnection(Conexao_Banco_Funcionarios.String_Conexao))
            {
                // Abre a conexão com o banco de dados
                conexao.Open();

                // Cria uma instância da classe SqlCommand
                SqlCommand cmd = new SqlCommand("Select Cargo from Acesso where CPF = @CPF AND Senha = @Senha", conexao);

                // Adiciona os parâmetros à consulta SQL
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@Senha", senha);

                // Executa uma consulta SQL para obter o valor do campo cargo
                string cargo = (string)cmd.ExecuteScalar();

                // Fecha a conexão com o banco de dados
                conexao.Close();

                // Verifica se o valor do campo cargo é gerente ou auxiliar para abrir o tipo de menu"
                if (cargo == "Gerente")
                {
                    Abrir_Tela = new Thread(Abrir_frm_Menu_Gerente);
                    Abrir_Tela.SetApartmentState(ApartmentState.STA);
                    Abrir_Tela.Start();
                    return true;
                }

                else if (cargo == "Auxiliar")
                {
                    Abrir_Tela = new Thread(Abrir_frm_Menu_Auxiliar);
                    Abrir_Tela.SetApartmentState(ApartmentState.STA);
                    Abrir_Tela.Start();
                    return true;
                }

                else
                {
                    MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void Abrir_frm_Menu_Gerente()
        {
            // abrir tela de menu para o gerente de rh
            Application.Run(new frm_Menu_Gerente());
        }

        private void Abrir_frm_Menu_Auxiliar()
        {
            // abrir tela de menu para auxiliares de rh
            Application.Run(new frm_Menu_Auxiliar());
        }
    }
}
