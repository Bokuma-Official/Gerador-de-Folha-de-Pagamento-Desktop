using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao;

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

        public void Verificar_Tela_Redefinir_Senha(Acesso acesso, string Repetir_Senha)
        {
            if (acesso.CPF == "" && acesso.Senha == "" && Repetir_Senha == "")
            {
                MessageBox.Show("Preencha todos os campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (acesso.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (acesso.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Repetir_Senha == "")
            {
                MessageBox.Show("Repetir a Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (acesso.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (acesso.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Repetir_Senha.Length > 20)
            {
                MessageBox.Show("Campo de repetição de Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (acesso.Senha.Contains("Select") || acesso.Senha.Contains("select") || acesso.Senha.Contains("SELECT") ||
                acesso.Senha.Contains("Insert") || acesso.Senha.Contains("insert") || acesso.Senha.Contains("INSERT") ||
                acesso.Senha.Contains("Update") || acesso.Senha.Contains("update") || acesso.Senha.Contains("UPDATE") ||
                acesso.Senha.Contains("Delete") || acesso.Senha.Contains("delete") || acesso.Senha.Contains("DELETE") ||
                acesso.Senha.Contains("Drop") || acesso.Senha.Contains("drop") || acesso.Senha.Contains("DROP"))
            {
                MessageBox.Show("Campos inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Repetir_Senha.Contains("Select") || Repetir_Senha.Contains("select") || Repetir_Senha.Contains("SELECT") ||
                Repetir_Senha.Contains("Insert") || Repetir_Senha.Contains("insert") || Repetir_Senha.Contains("INSERT") ||
                Repetir_Senha.Contains("Update") || Repetir_Senha.Contains("update") || Repetir_Senha.Contains("UPDATE") ||
                Repetir_Senha.Contains("Delete") || Repetir_Senha.Contains("delete") || Repetir_Senha.Contains("DELETE") ||
                Repetir_Senha.Contains("Drop") || Repetir_Senha.Contains("drop") || Repetir_Senha.Contains("DROP"))
            {
                MessageBox.Show("campos inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (acesso.Senha != Repetir_Senha)
            {
                MessageBox.Show("As Senhas não coincidem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja redefinir a senha?", "Redefinição de senha", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Acesso_DAO acesso_DAO = new Acesso_DAO();
                    acesso_DAO.Redefinir_Senha(acesso);
                }
            }
        } 
    }
}
