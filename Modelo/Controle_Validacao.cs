using Gerador_de_Folha_de_Pagamento_Desktop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Modelo
{
    public class Controle_Validacao
    {
        public static bool Email_Validado { get; set; }
        public static int Codigo_Gerado { get; set; }
        public static int Codigo_Seguranca { get; set; }
        public static bool Codigo_Validado { get; set; }

        public void Verificar_Login(Funcionario_Ataron funcionario_ataron)
        {
            // se cpf ficar vazio
            if (funcionario_ataron.CPF == "")
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

        public void Verificar_Email(Funcionario_Ataron funcionario_email)
        {
            if (funcionario_email.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_email.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_email.Email.ToLower().Contains("select") ||
                    funcionario_email.Email.ToLower().Contains("insert") ||
                    funcionario_email.Email.ToLower().Contains("update") ||
                    funcionario_email.Email.ToLower().Contains("delete") ||
                    funcionario_email.Email.ToLower().Contains("drop"))
            {
                MessageBox.Show("Email inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!funcionario_email.Email.ToLower().Contains("@") || !funcionario_email.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                // gerar o código
                Random random = new Random();
                Codigo_Gerado = random.Next(100000, 999999);
                Codigo_Seguranca = Codigo_Gerado;

                try
                {
                    // Enviar o e-mail com o código
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("bokuranteoficial@gmail.com");
                    mailMessage.To.Add(funcionario_email.Email);
                    mailMessage.Subject = "Ataron - Código de Segurança - Redefinição de Senha ";
                    mailMessage.Body = $"Seu Código de Segurança é: {Codigo_Seguranca}";

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.Credentials = new NetworkCredential("bokuranteoficial@gmail.com", "vdfyziwpuwxerzzv");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);

                    MessageBox.Show("Email enviado com sucesso!\nDigite o Código de Segurança enviado no seu Email" +
                        "\npara Redefinir a Senha", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Email_Validado = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao enviar Email!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Verificar_Codigo(int codigo_seguranca)
        {
            if (codigo_seguranca.ToString() == "")
            {
                MessageBox.Show("Código de segurança é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (codigo_seguranca.ToString() == $"{Codigo_Seguranca}")
            {
                Codigo_Validado = true;
            }

            else
            {
                MessageBox.Show("Código de segurança inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Verificar_Senha(Funcionario_Ataron funcionario_ataron, string Repetir_Senha)
        {
            if (funcionario_ataron.CPF == "")
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

            else if(funcionario_ataron.CPF.Length > 14)
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
