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
        public void Verificar_Tela_Login(Funcionario_Ataron funcionario_ataron)
        {
            // se cpf e senha ficarem vazios
            if (funcionario_ataron.CPF == "" && funcionario_ataron.Senha == "")
            {
                MessageBox.Show("CPF e senha são obrigatórios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se cpf ficar vazio
            else if (funcionario_ataron.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se senha ficar vazio
            else if (funcionario_ataron.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres do cpf
            else if (funcionario_ataron.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // restringir tamanho de caracteres da senha
            else if (funcionario_ataron.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // se colocar palavras do banco de dados na senha
            else if (funcionario_ataron.Senha.ToLower().Contains("select") ||
                    funcionario_ataron.Senha.ToLower().Contains("insert") || 
                    funcionario_ataron.Senha.ToLower().Contains("update") ||
                    funcionario_ataron.Senha.ToLower().Contains("delete") ||
                    funcionario_ataron.Senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("CPF ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /* cria uma instância da classe funcionario_ataron_dao na canada dal e chama o método
            verificar_acesso, passando os valores da variável funcionario_ataron para checar se
            o acesso é válido */
            else
            {
                Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                funcionario_ataron_dao.Verificar_Acesso(funcionario_ataron);
            }
        }

        public void Verificar_Tela_Redefinir_Senha(Funcionario_Ataron funcionario_ataron, string Repetir_Senha)
        {
            if (funcionario_ataron.CPF == "" && funcionario_ataron.Senha == "" && Repetir_Senha == "")
            {
                MessageBox.Show("Preencha todos os campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Repetir_Senha == "")
            {
                MessageBox.Show("Repetir a Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Repetir_Senha.Length > 20)
            {
                MessageBox.Show("Campo de repetição de Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.ToLower().Contains("select") ||
                    funcionario_ataron.Senha.ToLower().Contains("insert") ||
                    funcionario_ataron.Senha.ToLower().Contains("update") ||
                    funcionario_ataron.Senha.ToLower().Contains("delete") ||
                    funcionario_ataron.Senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Repetir_Senha.ToLower().Contains("select") ||
                    Repetir_Senha.ToLower().Contains("insert") ||
                    Repetir_Senha.ToLower().Contains("update") ||
                    Repetir_Senha.ToLower().Contains("delete") ||
                    Repetir_Senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (funcionario_ataron.Senha != Repetir_Senha)
            {
                MessageBox.Show("As Senhas não são iguais", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja redefinir a senha?", "Redefinição de senha", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                    funcionario_ataron_dao.Redefinir_Senha(funcionario_ataron);
                }
            }
        } 
    }
}
