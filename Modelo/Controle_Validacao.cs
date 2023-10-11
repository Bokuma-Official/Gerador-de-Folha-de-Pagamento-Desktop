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
        public static bool Login_Validado { get; set; }
        public static bool Email_Validado { get; set; }
        public int Codigo_Gerado { get; set; }
        public static string Codigo_Seguranca { get; set; }
        public static bool Codigo_Validado { get; set; }
        public static bool Senha_Validada { get; set; }
        public static bool Cadastro_Perfil_Validado { get; set; }
        public static bool Deletar_Perfil_Validado { get; set; }
        public static bool Editar_Perfil_Validado { get; set; }
        public static bool Cadastro_Funcionario_Validado { get; set; }
        public static bool Deletar_Funcionario_Validado { get; set; }
        public static bool Editar_Funcionario_Validado { get; set; }

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
                MessageBox.Show("CPF ou senha inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            /* cria uma instância da classe funcionario_ataron_dao na canada dal e chama o método
            verificar_acesso, passando os valores da variável funcionario_ataron para checar se
            o acesso é válido */
            else
            {
                Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                funcionario_ataron_dao.Fazer_Login(funcionario_ataron);

                Login_Validado = true;
            }
        }

        public void Verificar_Email(Funcionario_Ataron funcionario_ataron)
        {
            if (funcionario_ataron.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email.ToLower().Contains("select") ||
                    funcionario_ataron.Email.ToLower().Contains("insert") ||
                    funcionario_ataron.Email.ToLower().Contains("update") ||
                    funcionario_ataron.Email.ToLower().Contains("delete") ||
                    funcionario_ataron.Email.ToLower().Contains("drop"))
            {
                MessageBox.Show("Email inválido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Email.ToLower().Contains("@") || !funcionario_ataron.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                // gerar o código
                Random random = new Random();
                Codigo_Gerado = random.Next(100000, 999999);
                Codigo_Seguranca = Codigo_Gerado.ToString();

                try
                {
                    // Enviar o e-mail com o código
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("bokuranteoficial@gmail.com");
                    mailMessage.To.Add(funcionario_ataron.Email);
                    mailMessage.Subject = "Ataron - Folhas de Pagamento - Código de Segurança para Redefinição de Senha de Perfil";
                    mailMessage.Body = $"Seu Código de Segurança é: {Codigo_Seguranca}";

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.Credentials = new NetworkCredential("bokuranteoficial@gmail.com", "vdfyziwpuwxerzzv");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);

                    MessageBox.Show("Email enviado com sucesso!\nDigite o Código de Segurança enviado no seu Email" +
                        "\npara Redefinir a Senha.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Email_Validado = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao enviar Email!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Verificar_Codigo(string codigo_seguranca)
        {
            if (codigo_seguranca.ToString() == "")
            {
                MessageBox.Show("Código de Segurança é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (codigo_seguranca.ToString().Length > 6)
            {
                MessageBox.Show("O Código de Segurança deve ter menos que 6 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Codigo_Seguranca != codigo_seguranca)
            {
                MessageBox.Show("Código de Segurança inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Codigo_Validado = true;
            }
        }

        public void Verificar_Senha(Funcionario_Ataron funcionario_ataron, string repetir_senha)
        {
            if (funcionario_ataron.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha == "")
            {
                MessageBox.Show("Repetir a Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha.Length > 20)
            {
                MessageBox.Show("Repetição de Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length < 8)
            {
                MessageBox.Show("Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha.Length < 8)
            {
                MessageBox.Show("Repetição de Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.ToLower().Contains("select") ||
                    funcionario_ataron.Senha.ToLower().Contains("insert") ||
                    funcionario_ataron.Senha.ToLower().Contains("update") ||
                    funcionario_ataron.Senha.ToLower().Contains("delete") ||
                    funcionario_ataron.Senha.ToLower().Contains("drop") ||

                    repetir_senha.ToLower().Contains("select") ||
                    repetir_senha.ToLower().Contains("insert") ||
                    repetir_senha.ToLower().Contains("update") ||
                    repetir_senha.ToLower().Contains("delete") ||
                    repetir_senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha != repetir_senha)
            {
                MessageBox.Show("As Senhas não são iguais", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja redefinir a Senha?", "Redefinição de Senha", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                    funcionario_ataron_dao.Redefinir_Senha(funcionario_ataron);

                    Senha_Validada = true;
                }
            }
        }

        public void Verificar_Cadastro_Perfil(Funcionario_Ataron funcionario_ataron, string repetir_senha)
        {
            // uso de blocos region para ocultar grandes códigos e separar eles por categoria
            #region Campos Vazios
            if (funcionario_ataron.Nome == "")
            {
                MessageBox.Show("Nome é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.RG == "")
            {
                MessageBox.Show("RG é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.PIS == "")
            {
                MessageBox.Show("PIS é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Carteira_Trabalho == "")
            {
                MessageBox.Show("Carteira de Trabalho é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Titulo_Eleitor == "")
            {
                MessageBox.Show("Título de Eleitor é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Certificado_Militar == "" && funcionario_ataron.Sexo == "Masculino")
            {
                MessageBox.Show("Certificado Militar é obrigatório para pessoas do Sexo Masculino", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Sexo == "")
            {
                MessageBox.Show("Sexo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Nascimento == "")
            {
                MessageBox.Show("Data de Nascimento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Celular == "")
            {
                MessageBox.Show("Telefone Celular é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CEP == "")
            {
                MessageBox.Show("CEP é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Matricula == 0)
            {
                MessageBox.Show("Matrícula é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Departamento == "")
            {
                MessageBox.Show("Departamento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Cargo == "")
            {
                MessageBox.Show("Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Admissao == "")
            {
                MessageBox.Show("Data de Admissão é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha == "")
            {
                MessageBox.Show("Repetir a Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region Limite de Caracteres
            else if (funcionario_ataron.Nome.Length > 40)
            {
                MessageBox.Show("Nome deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.RG.Length > 12)
            {
                MessageBox.Show("RG deve ter menos que 12 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.PIS.Length > 14)
            {
                MessageBox.Show("PIS deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Carteira_Trabalho.Length > 20)
            {
                MessageBox.Show("Carteira de Trabalho deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Titulo_Eleitor.Length > 14)
            {
                MessageBox.Show("Título de Eleitor deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Certificado_Militar.Length > 15)
            {
                MessageBox.Show("Certificado Militar deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Nascimento.Length > 10)
            {
                MessageBox.Show("Data de Nascimento deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Celular.Length > 15)
            {
                MessageBox.Show("Telefone Celular deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Fixo.Length > 14)
            {
                MessageBox.Show("Telefone Fixo deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CEP.Length > 9)
            {
                MessageBox.Show("CEP deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Matricula.ToString().Length > 6)
            {
                MessageBox.Show("Matrícula deve ter menos que 6 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Departamento.Length > 40)
            {
                MessageBox.Show("Departamento deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Cargo.Length > 40)
            {
                MessageBox.Show("Cargo deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Admissao.Length > 10)
            {
                MessageBox.Show("Data de Admissão deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha.Length > 20)
            {
                MessageBox.Show("Repetir Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length < 8)
            {
                MessageBox.Show("Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha.Length < 8)
            {
                MessageBox.Show("Repetir Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            else if (funcionario_ataron.Nome.ToLower().Contains("select") ||
                    funcionario_ataron.Nome.ToLower().Contains("insert") ||
                    funcionario_ataron.Nome.ToLower().Contains("update") ||
                    funcionario_ataron.Nome.ToLower().Contains("delete") ||
                    funcionario_ataron.Nome.ToLower().Contains("drop") ||

                    funcionario_ataron.Email.ToLower().Contains("select") ||
                    funcionario_ataron.Email.ToLower().Contains("insert") ||
                    funcionario_ataron.Email.ToLower().Contains("update") ||
                    funcionario_ataron.Email.ToLower().Contains("delete") ||
                    funcionario_ataron.Email.ToLower().Contains("drop") ||

                    funcionario_ataron.Departamento.ToLower().Contains("select") ||
                    funcionario_ataron.Departamento.ToLower().Contains("insert") ||
                    funcionario_ataron.Departamento.ToLower().Contains("update") ||
                    funcionario_ataron.Departamento.ToLower().Contains("delete") ||
                    funcionario_ataron.Departamento.ToLower().Contains("drop") ||

                    funcionario_ataron.Cargo.ToLower().Contains("select") ||
                    funcionario_ataron.Cargo.ToLower().Contains("insert") ||
                    funcionario_ataron.Cargo.ToLower().Contains("update") ||
                    funcionario_ataron.Cargo.ToLower().Contains("delete") ||
                    funcionario_ataron.Cargo.ToLower().Contains("drop") ||

                    funcionario_ataron.Senha.ToLower().Contains("select") ||
                    funcionario_ataron.Senha.ToLower().Contains("insert") ||
                    funcionario_ataron.Senha.ToLower().Contains("update") ||
                    funcionario_ataron.Senha.ToLower().Contains("delete") ||
                    funcionario_ataron.Senha.ToLower().Contains("drop") ||

                    repetir_senha.ToLower().Contains("select") ||
                    repetir_senha.ToLower().Contains("insert") ||
                    repetir_senha.ToLower().Contains("update") ||
                    repetir_senha.ToLower().Contains("delete") ||
                    repetir_senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Email.ToLower().Contains("@") || !funcionario_ataron.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Data_Nascimento.Contains("/"))
            {
                MessageBox.Show("Data de Nascimento precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Data_Admissao.Contains("/"))
            {
                MessageBox.Show("Data de Admissão precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha != repetir_senha)
            {
                MessageBox.Show("As Senhas não são iguais", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja cadastrar o Perfil?", "Cadastrar Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                    funcionario_ataron_dao.Cadastrar_Perfil(funcionario_ataron);

                    Cadastro_Perfil_Validado = true;
                }
            }
        }

        public void Verificar_Visualizacao_Perfil_Para_Nao_Gerente(Funcionario_Ataron funcionario_ataron)
        {
            Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
            funcionario_ataron_dao.Visualizar_Perfil_Para_Nao_Gerente(funcionario_ataron);
        }

        public void Verificar_Visualizacao_Perfil_Para_Gerente(Funcionario_Ataron funcionario_ataron, string nome_perfil_selecionado)
        {
            Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
            funcionario_ataron_dao.Visualizar_Perfil_Para_Gerente(funcionario_ataron, nome_perfil_selecionado);
        }

        public void Verificar_Exclusao_Perfil (string cpf_perfil_selecionado)
        {
            if (Funcionario_Ataron_DAO.CPF_Perfil_Logado == cpf_perfil_selecionado)
            {
                MessageBox.Show("Você não pode deletar o seu próprio Perfil", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja deletar o Perfil?", "Deletar Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                    funcionario_ataron_dao.Deletar_Perfil(cpf_perfil_selecionado);

                    Deletar_Perfil_Validado = true;
                }
            }
        }

        public void Verificar_Edicao_Perfil(Funcionario_Ataron funcionario_ataron, string cpf_perfil_selecionado)
        {
            #region Campos Vazios
            if (funcionario_ataron.Nome == "")
            {
                MessageBox.Show("Nome é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.RG == "")
            {
                MessageBox.Show("RG é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.PIS == "")
            {
                MessageBox.Show("PIS é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Carteira_Trabalho == "")
            {
                MessageBox.Show("Carteira de Trabalho é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Titulo_Eleitor == "")
            {
                MessageBox.Show("Título de Eleitor é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Certificado_Militar == "" && funcionario_ataron.Sexo == "Masculino")
            {
                MessageBox.Show("Certificado Militar é obrigatório para pessoas do Sexo Masculino", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Sexo == "")
            {
                MessageBox.Show("Sexo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Nascimento == "")
            {
                MessageBox.Show("Data de Nascimento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Celular == "")
            {
                MessageBox.Show("Telefone Celular é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CEP == "")
            {
                MessageBox.Show("CEP é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Matricula == 0)
            {
                MessageBox.Show("Matrícula é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Departamento == "")
            {
                MessageBox.Show("Departamento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Cargo == "")
            {
                MessageBox.Show("Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Admissao == "")
            {
                MessageBox.Show("Data de Admissão é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region Limite de Caracteres
            else if (funcionario_ataron.Nome.Length > 40)
            {
                MessageBox.Show("Nome deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.RG.Length > 12)
            {
                MessageBox.Show("RG deve ter menos que 12 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.PIS.Length > 14)
            {
                MessageBox.Show("PIS deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Carteira_Trabalho.Length > 20)
            {
                MessageBox.Show("Carteira de Trabalho deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Titulo_Eleitor.Length > 14)
            {
                MessageBox.Show("Título de Eleitor deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Certificado_Militar.Length > 15)
            {
                MessageBox.Show("Certificado Militar deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Nascimento.Length > 10)
            {
                MessageBox.Show("Data de Nascimento deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Celular.Length > 15)
            {
                MessageBox.Show("Telefone Celular deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Telefone_Fixo.Length > 14)
            {
                MessageBox.Show("Telefone Fixo deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.CEP.Length > 9)
            {
                MessageBox.Show("CEP deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Matricula.ToString().Length > 6)
            {
                MessageBox.Show("Matrícula deve ter menos que 6 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Departamento.Length > 40)
            {
                MessageBox.Show("Departamento deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Cargo.Length > 40)
            {
                MessageBox.Show("Cargo deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Data_Admissao.Length > 10)
            {
                MessageBox.Show("Data de Admissão deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario_ataron.Senha.Length < 8)
            {
                MessageBox.Show("Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            else if (funcionario_ataron.Nome.ToLower().Contains("select") ||
                    funcionario_ataron.Nome.ToLower().Contains("insert") ||
                    funcionario_ataron.Nome.ToLower().Contains("update") ||
                    funcionario_ataron.Nome.ToLower().Contains("delete") ||
                    funcionario_ataron.Nome.ToLower().Contains("drop") ||

                    funcionario_ataron.Email.ToLower().Contains("select") ||
                    funcionario_ataron.Email.ToLower().Contains("insert") ||
                    funcionario_ataron.Email.ToLower().Contains("update") ||
                    funcionario_ataron.Email.ToLower().Contains("delete") ||
                    funcionario_ataron.Email.ToLower().Contains("drop") ||

                    funcionario_ataron.Departamento.ToLower().Contains("select") ||
                    funcionario_ataron.Departamento.ToLower().Contains("insert") ||
                    funcionario_ataron.Departamento.ToLower().Contains("update") ||
                    funcionario_ataron.Departamento.ToLower().Contains("delete") ||
                    funcionario_ataron.Departamento.ToLower().Contains("drop") ||

                    funcionario_ataron.Cargo.ToLower().Contains("select") ||
                    funcionario_ataron.Cargo.ToLower().Contains("insert") ||
                    funcionario_ataron.Cargo.ToLower().Contains("update") ||
                    funcionario_ataron.Cargo.ToLower().Contains("delete") ||
                    funcionario_ataron.Cargo.ToLower().Contains("drop") ||

                    funcionario_ataron.Senha.ToLower().Contains("select") ||
                    funcionario_ataron.Senha.ToLower().Contains("insert") ||
                    funcionario_ataron.Senha.ToLower().Contains("update") ||
                    funcionario_ataron.Senha.ToLower().Contains("delete") ||
                    funcionario_ataron.Senha.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Email.ToLower().Contains("@") || !funcionario_ataron.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Data_Nascimento.Contains("/"))
            {
                MessageBox.Show("Data de Nascimento precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario_ataron.Data_Admissao.Contains("/"))
            {
                MessageBox.Show("Data de Admissão precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja editar o Perfil?", "Editar Perfil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_Ataron_DAO funcionario_ataron_dao = new Funcionario_Ataron_DAO();
                    funcionario_ataron_dao.Editar_Perfil(funcionario_ataron, cpf_perfil_selecionado);

                    Editar_Perfil_Validado = true;
                }
            }
        }
        public void Verificar_Cadastro_Funcionario(Funcionario funcionario, Endereco endereco,
            Contrato_Empresa contrato_empresa, string repetir_senha)
        {
            #region Campos Vazios
            if (repetir_senha == "")
            {
                MessageBox.Show("Repetir a Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Nome == "")
            {
                MessageBox.Show("Nome é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.RG == "")
            {
                MessageBox.Show("RG é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Data_Nascimento == "")
            {
                MessageBox.Show("Data de Nascimento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PIS == "")
            {
                MessageBox.Show("PIS é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Carteira_Trabalho == "")
            {
                MessageBox.Show("Carteira de Trabalho é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Titulo_Eleitor == "")
            {
                MessageBox.Show("Título de Eleitor é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Certificado_Militar == "" && funcionario.Sexo == "Masculino")
            {
                MessageBox.Show("Certificado Militar é obrigatório para pessoas do Sexo Masculino", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Sexo == "")
            {
                MessageBox.Show("Sexo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PCD == "")
            {
                MessageBox.Show("PCD é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Matricula == 0)
            {
                MessageBox.Show("Matrícula é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Departamento == "")
            {
                MessageBox.Show("Departamento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Cargo == "")
            {
                MessageBox.Show("Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Data_Admissao == "")
            {
                MessageBox.Show("Data de Admissão é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Tipo_Contrato == "")
            {
                MessageBox.Show("Tipo de Contrato é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.CBO_Cargo == "")
            {
                MessageBox.Show("CBO do Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Celular == "")
            {
                MessageBox.Show("Telefone Celular é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.CEP == "")
            {
                MessageBox.Show("CEP é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Estado == "")
            {
                MessageBox.Show("Estado é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Cidade == "")
            {
                MessageBox.Show("Cidade é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Bairro == "")
            {
                MessageBox.Show("Bairro é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Logradouro == "")
            {
                MessageBox.Show("Logradouro é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Numero == 0)
            {
                MessageBox.Show("Numero é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Nome_Agencia == "")
            {
                MessageBox.Show("Nome da Agência é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Agencia == 0)
            {
                MessageBox.Show("Numero da Agência é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Conta == "")
            {
                MessageBox.Show("Numero da Conta é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region Limite de Caracteres
            else if (repetir_senha.Length > 20)
            {
                MessageBox.Show("Repetir Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (repetir_senha.Length < 8)
            {
                MessageBox.Show("Repetir Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Nome.Length > 40)
            {
                MessageBox.Show("Nome deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.RG.Length > 12)
            {
                MessageBox.Show("RG deve ter menos que 12 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Data_Nascimento.Length > 10)
            {
                MessageBox.Show("Data de Nascimento deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PIS.Length > 14)
            {
                MessageBox.Show("PIS deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Carteira_Trabalho.Length > 20)
            {
                MessageBox.Show("Carteira de Trabalho deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Titulo_Eleitor.Length > 14)
            {
                MessageBox.Show("Título de Eleitor deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Certificado_Militar.Length > 15)
            {
                MessageBox.Show("Certificado Militar deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Dependentes.ToString().Length > 2)
            {
                MessageBox.Show("Dependentes deve ter menos que 2 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Matricula.ToString().Length > 6)
            {
                MessageBox.Show("Matrícula deve ter menos que 6 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Departamento.Length > 40)
            {
                MessageBox.Show("Departamento deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Cargo.Length > 40)
            {
                MessageBox.Show("Cargo deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Data_Admissao.Length > 10)
            {
                MessageBox.Show("Data de Admissão deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Tipo_Contrato.Length > 15)
            {
                MessageBox.Show("Tipo de Contrato deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.CBO_Cargo.Length > 7)
            {
                MessageBox.Show("CBO do Cargo deve ter menos que 7 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Celular.Length > 15)
            {
                MessageBox.Show("Telefone Celular deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Fixo.Length > 14)
            {
                MessageBox.Show("Telefone Fixo deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.CEP.Length > 9)
            {
                MessageBox.Show("CEP deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Estado.Length > 20)
            {
                MessageBox.Show("Estado deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Cidade.Length > 25)
            {
                MessageBox.Show("Cidade deve ter menos que 25 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Bairro.Length > 25)
            {
                MessageBox.Show("Bairro deve ter menos que 25 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Logradouro.Length > 40)
            {
                MessageBox.Show("Logradouro deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Numero.ToString().Length > 5)
            {
                MessageBox.Show("Número do Endereço deve ter menos que 5 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Complemento.Length > 20)
            {
                MessageBox.Show("Complemento deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Nome_Agencia.Length > 20)
            {
                MessageBox.Show("Nome da Agência deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Agencia.ToString().Length > 4)
            {
                MessageBox.Show("Numero da Agência deve ter menos que 4 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Conta.Length > 9)
            {
                MessageBox.Show("Numero da Conta deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha.Length < 8)
            {
                MessageBox.Show("Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            else if (repetir_senha.ToLower().Contains("select") ||
                    repetir_senha.ToLower().Contains("insert") ||
                    repetir_senha.ToLower().Contains("update") ||
                    repetir_senha.ToLower().Contains("delete") ||
                    repetir_senha.ToLower().Contains("drop") ||

                    funcionario.Nome.ToLower().Contains("select") ||
                    funcionario.Nome.ToLower().Contains("insert") ||
                    funcionario.Nome.ToLower().Contains("update") ||
                    funcionario.Nome.ToLower().Contains("delete") ||
                    funcionario.Nome.ToLower().Contains("drop") ||

                    funcionario.Email.ToLower().Contains("select") ||
                    funcionario.Email.ToLower().Contains("insert") ||
                    funcionario.Email.ToLower().Contains("update") ||
                    funcionario.Email.ToLower().Contains("delete") ||
                    funcionario.Email.ToLower().Contains("drop") ||

                    funcionario.Senha.ToLower().Contains("select") ||
                    funcionario.Senha.ToLower().Contains("insert") ||
                    funcionario.Senha.ToLower().Contains("update") ||
                    funcionario.Senha.ToLower().Contains("delete") ||
                    funcionario.Senha.ToLower().Contains("drop") ||

                    endereco.Logradouro.ToLower().Contains("select") ||
                    endereco.Logradouro.ToLower().Contains("insert") ||
                    endereco.Logradouro.ToLower().Contains("update") ||
                    endereco.Logradouro.ToLower().Contains("delete") ||
                    endereco.Logradouro.ToLower().Contains("drop") ||

                    endereco.Bairro.ToLower().Contains("select") ||
                    endereco.Bairro.ToLower().Contains("insert") ||
                    endereco.Bairro.ToLower().Contains("update") ||
                    endereco.Bairro.ToLower().Contains("delete") ||
                    endereco.Bairro.ToLower().Contains("drop") ||

                    endereco.Complemento.ToLower().Contains("select") ||
                    endereco.Complemento.ToLower().Contains("insert") ||
                    endereco.Complemento.ToLower().Contains("update") ||
                    endereco.Complemento.ToLower().Contains("delete") ||
                    endereco.Complemento.ToLower().Contains("drop") ||

                    endereco.Cidade.ToLower().Contains("select") ||
                    endereco.Cidade.ToLower().Contains("insert") ||
                    endereco.Cidade.ToLower().Contains("update") ||
                    endereco.Cidade.ToLower().Contains("delete") ||
                    endereco.Cidade.ToLower().Contains("drop") ||

                    endereco.Estado.ToLower().Contains("select") ||
                    endereco.Estado.ToLower().Contains("insert") ||
                    endereco.Estado.ToLower().Contains("update") ||
                    endereco.Estado.ToLower().Contains("delete") ||
                    endereco.Estado.ToLower().Contains("drop") ||

                    contrato_empresa.Departamento.ToLower().Contains("select") ||
                    contrato_empresa.Departamento.ToLower().Contains("insert") ||
                    contrato_empresa.Departamento.ToLower().Contains("update") ||
                    contrato_empresa.Departamento.ToLower().Contains("delete") ||
                    contrato_empresa.Departamento.ToLower().Contains("drop") ||

                    contrato_empresa.Cargo.ToLower().Contains("select") ||
                    contrato_empresa.Cargo.ToLower().Contains("insert") ||
                    contrato_empresa.Cargo.ToLower().Contains("update") ||
                    contrato_empresa.Cargo.ToLower().Contains("delete") ||
                    contrato_empresa.Cargo.ToLower().Contains("drop") ||

                    contrato_empresa.Nome_Agencia.ToLower().Contains("select") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("insert") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("update") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("delete") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario.Email.ToLower().Contains("@") || !funcionario.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario.Data_Nascimento.Contains("/"))
            {
                MessageBox.Show("Data de Nascimento precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!contrato_empresa.Data_Admissao.Contains("/"))
            {
                MessageBox.Show("Data de Admissão precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha != repetir_senha)
            {
                MessageBox.Show("As Senhas não são iguais", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja cadastrar o Funcionário?", "Cadastrar Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_DAO funcionario_dao = new Funcionario_DAO();
                    funcionario_dao.Cadastrar_Funcionario(funcionario, endereco, contrato_empresa);

                    Cadastro_Funcionario_Validado = true;
                }
            }
        }

        public void Verificar_Visualizacao_Funcionario(Funcionario funcionario, Endereco endereco,
            Contrato_Empresa contrato_empresa, string nome_funcionario_selecionado)
        {
            Funcionario_DAO funcionario_dao = new Funcionario_DAO();
            funcionario_dao.Visualizar_Funcionario(funcionario, endereco, contrato_empresa, nome_funcionario_selecionado);
        }

        public void Verificar_Exclusao_Funcionario(string cpf_funcionario_selecionado)
        {
            DialogResult pergunta = MessageBox.Show("Deseja deletar o Funcionário?", "Deletar Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (pergunta == DialogResult.Yes)
            {
                Funcionario_DAO funcionario_dao = new Funcionario_DAO();
                funcionario_dao.Deletar_Funcionario(cpf_funcionario_selecionado);

                Deletar_Funcionario_Validado = true;
            }
        }

        public void Verificar_Edicao_Funcionario(Funcionario funcionario, Endereco endereco,
            Contrato_Empresa contrato_empresa, string cpf_Funcionario_selecionado)
        {
            #region Campos Vazios
            if (funcionario.Nome == "")
            {
                MessageBox.Show("Nome é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.CPF == "")
            {
                MessageBox.Show("CPF é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.RG == "")
            {
                MessageBox.Show("RG é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Data_Nascimento == "")
            {
                MessageBox.Show("Data de Nascimento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PIS == "")
            {
                MessageBox.Show("PIS é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Carteira_Trabalho == "")
            {
                MessageBox.Show("Carteira de Trabalho é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Titulo_Eleitor == "")
            {
                MessageBox.Show("Título de Eleitor é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Certificado_Militar == "" && funcionario.Sexo == "Masculino")
            {
                MessageBox.Show("Certificado Militar é obrigatório para pessoas do Sexo Masculino", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Sexo == "")
            {
                MessageBox.Show("Sexo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PCD == "")
            {
                MessageBox.Show("PCD é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Matricula == 0)
            {
                MessageBox.Show("Matrícula é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Departamento == "")
            {
                MessageBox.Show("Departamento é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Cargo == "")
            {
                MessageBox.Show("Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Data_Admissao == "")
            {
                MessageBox.Show("Data de Admissão é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Tipo_Contrato == "")
            {
                MessageBox.Show("Tipo de Contrato é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.CBO_Cargo == "")
            {
                MessageBox.Show("CBO do Cargo é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Email == "")
            {
                MessageBox.Show("Email é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Celular == "")
            {
                MessageBox.Show("Telefone Celular é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.CEP == "")
            {
                MessageBox.Show("CEP é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Estado == "")
            {
                MessageBox.Show("Estado é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Cidade == "")
            {
                MessageBox.Show("Cidade é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Bairro == "")
            {
                MessageBox.Show("Bairro é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Logradouro == "")
            {
                MessageBox.Show("Logradouro é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Numero == 0)
            {
                MessageBox.Show("Numero é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Nome_Agencia == "")
            {
                MessageBox.Show("Nome da Agência é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Agencia == 0)
            {
                MessageBox.Show("Numero da Agência é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Conta == "")
            {
                MessageBox.Show("Numero da Conta é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha == "")
            {
                MessageBox.Show("Senha é obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            #region Limite de Caracteres
            else if (funcionario.Nome.Length > 40)
            {
                MessageBox.Show("Nome deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.CPF.Length > 14)
            {
                MessageBox.Show("CPF deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.RG.Length > 12)
            {
                MessageBox.Show("RG deve ter menos que 12 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Data_Nascimento.Length > 10)
            {
                MessageBox.Show("Data de Nascimento deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.PIS.Length > 14)
            {
                MessageBox.Show("PIS deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Carteira_Trabalho.Length > 20)
            {
                MessageBox.Show("Carteira de Trabalho deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Titulo_Eleitor.Length > 14)
            {
                MessageBox.Show("Título de Eleitor deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Certificado_Militar.Length > 15)
            {
                MessageBox.Show("Certificado Militar deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Dependentes.ToString().Length > 2)
            {
                MessageBox.Show("Dependentes deve ter menos que 2 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Matricula.ToString().Length > 6)
            {
                MessageBox.Show("Matrícula deve ter menos que 6 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Departamento.Length > 40)
            {
                MessageBox.Show("Departamento deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Cargo.Length > 40)
            {
                MessageBox.Show("Cargo deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Data_Admissao.Length > 10)
            {
                MessageBox.Show("Data de Admissão deve ter menos que 10 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Tipo_Contrato.Length > 15)
            {
                MessageBox.Show("Tipo de Contrato deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.CBO_Cargo.Length > 7)
            {
                MessageBox.Show("CBO do Cargo deve ter menos que 7 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Email.Length > 40)
            {
                MessageBox.Show("Email deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Celular.Length > 15)
            {
                MessageBox.Show("Telefone Celular deve ter menos que 15 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Telefone_Fixo.Length > 14)
            {
                MessageBox.Show("Telefone Fixo deve ter menos que 14 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.CEP.Length > 9)
            {
                MessageBox.Show("CEP deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Estado.Length > 20)
            {
                MessageBox.Show("Estado deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Cidade.Length > 25)
            {
                MessageBox.Show("Cidade deve ter menos que 25 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Bairro.Length > 25)
            {
                MessageBox.Show("Bairro deve ter menos que 25 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Logradouro.Length > 40)
            {
                MessageBox.Show("Logradouro deve ter menos que 40 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Numero.ToString().Length > 5)
            {
                MessageBox.Show("Número do Endereço deve ter menos que 5 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (endereco.Complemento.Length > 20)
            {
                MessageBox.Show("Complemento deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Nome_Agencia.Length > 20)
            {
                MessageBox.Show("Nome da Agência deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Agencia.ToString().Length > 4)
            {
                MessageBox.Show("Numero da Agência deve ter menos que 4 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (contrato_empresa.Numero_Conta.Length > 9)
            {
                MessageBox.Show("Numero da Conta deve ter menos que 9 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha.Length > 20)
            {
                MessageBox.Show("Senha deve ter menos que 20 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (funcionario.Senha.Length < 8)
            {
                MessageBox.Show("Senha deve ter no mínimo 8 caracteres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            else if (funcionario.Nome.ToLower().Contains("select") ||
                    funcionario.Nome.ToLower().Contains("insert") ||
                    funcionario.Nome.ToLower().Contains("update") ||
                    funcionario.Nome.ToLower().Contains("delete") ||
                    funcionario.Nome.ToLower().Contains("drop") ||

                    funcionario.Email.ToLower().Contains("select") ||
                    funcionario.Email.ToLower().Contains("insert") ||
                    funcionario.Email.ToLower().Contains("update") ||
                    funcionario.Email.ToLower().Contains("delete") ||
                    funcionario.Email.ToLower().Contains("drop") ||

                    funcionario.Senha.ToLower().Contains("select") ||
                    funcionario.Senha.ToLower().Contains("insert") ||
                    funcionario.Senha.ToLower().Contains("update") ||
                    funcionario.Senha.ToLower().Contains("delete") ||
                    funcionario.Senha.ToLower().Contains("drop") ||

                    endereco.Logradouro.ToLower().Contains("select") ||
                    endereco.Logradouro.ToLower().Contains("insert") ||
                    endereco.Logradouro.ToLower().Contains("update") ||
                    endereco.Logradouro.ToLower().Contains("delete") ||
                    endereco.Logradouro.ToLower().Contains("drop") ||

                    endereco.Bairro.ToLower().Contains("select") ||
                    endereco.Bairro.ToLower().Contains("insert") ||
                    endereco.Bairro.ToLower().Contains("update") ||
                    endereco.Bairro.ToLower().Contains("delete") ||
                    endereco.Bairro.ToLower().Contains("drop") ||

                    endereco.Complemento.ToLower().Contains("select") ||
                    endereco.Complemento.ToLower().Contains("insert") ||
                    endereco.Complemento.ToLower().Contains("update") ||
                    endereco.Complemento.ToLower().Contains("delete") ||
                    endereco.Complemento.ToLower().Contains("drop") ||

                    endereco.Cidade.ToLower().Contains("select") ||
                    endereco.Cidade.ToLower().Contains("insert") ||
                    endereco.Cidade.ToLower().Contains("update") ||
                    endereco.Cidade.ToLower().Contains("delete") ||
                    endereco.Cidade.ToLower().Contains("drop") ||

                    endereco.Estado.ToLower().Contains("select") ||
                    endereco.Estado.ToLower().Contains("insert") ||
                    endereco.Estado.ToLower().Contains("update") ||
                    endereco.Estado.ToLower().Contains("delete") ||
                    endereco.Estado.ToLower().Contains("drop") ||

                    contrato_empresa.Departamento.ToLower().Contains("select") ||
                    contrato_empresa.Departamento.ToLower().Contains("insert") ||
                    contrato_empresa.Departamento.ToLower().Contains("update") ||
                    contrato_empresa.Departamento.ToLower().Contains("delete") ||
                    contrato_empresa.Departamento.ToLower().Contains("drop") ||

                    contrato_empresa.Cargo.ToLower().Contains("select") ||
                    contrato_empresa.Cargo.ToLower().Contains("insert") ||
                    contrato_empresa.Cargo.ToLower().Contains("update") ||
                    contrato_empresa.Cargo.ToLower().Contains("delete") ||
                    contrato_empresa.Cargo.ToLower().Contains("drop") ||

                    contrato_empresa.Nome_Agencia.ToLower().Contains("select") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("insert") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("update") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("delete") ||
                    contrato_empresa.Nome_Agencia.ToLower().Contains("drop"))
            {
                MessageBox.Show("Campos inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario.Email.ToLower().Contains("@") || !funcionario.Email.ToLower().Contains("."))
            {
                MessageBox.Show("Email precisa ter @ e .", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!funcionario.Data_Nascimento.Contains("/"))
            {
                MessageBox.Show("Data de Nascimento precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!contrato_empresa.Data_Admissao.Contains("/"))
            {
                MessageBox.Show("Data de Admissão precisa ter /", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult pergunta = MessageBox.Show("Deseja editar o Funcionário?", "Editar Funcionário", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (pergunta == DialogResult.Yes)
                {
                    Funcionario_DAO funcionario_dao = new Funcionario_DAO();
                    funcionario_dao.Editar_Funcionario(funcionario, endereco, contrato_empresa, cpf_Funcionario_selecionado);

                    Editar_Funcionario_Validado = true;
                }
            }
        }
    }
 }
