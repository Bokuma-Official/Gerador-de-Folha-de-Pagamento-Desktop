using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Controle_Validacao
    {
        public void Verificar_Tela_Login(Acesso acesso)
        {
            // se cpf e senha ficarem vazios
            if (acesso.CPF == "" && acesso.Senha == "")
            {
                MessageBox.Show("CPF e senha são obrigatórios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se cpf ficar vazio
            else if (acesso.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se senha ficar vazio
            else if (acesso.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres do cpf
            else if (acesso.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres da senha
            else if (acesso.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se colocar palavras do banco de dados na senha
            else if (acesso.Senha.Contains("Select") || acesso.Senha.Contains("select") || acesso.Senha.Contains("SELECT") ||
                acesso.Senha.Contains("Insert") || acesso.Senha.Contains("insert") || acesso.Senha.Contains("INSERT") ||
                acesso.Senha.Contains("Update") || acesso.Senha.Contains("update") || acesso.Senha.Contains("UPDATE") ||
                acesso.Senha.Contains("Delete") || acesso.Senha.Contains("delete") || acesso.Senha.Contains("DELETE") ||
                acesso.Senha.Contains("Drop") || acesso.Senha.Contains("drop") || acesso.Senha.Contains("DROP"))
            {
                MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /* cria uma instância da classe acesso_dao na canada dal e chama o método
            verificar_acesso, passando os valores da variável acesso para checar se
            o acesso é válido */
            else
            {
                Acesso_DAO acesso_DAO = new Acesso_DAO();
                acesso_DAO.Verificar_Acesso(acesso);
            }
        }
    }
}
