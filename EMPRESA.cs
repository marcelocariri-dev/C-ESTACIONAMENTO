using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ESTACIONAMENTO
{
    public class EMPRESA
    {
        public string EmpresaNome { get; set; } = "";
        public string Razao { get; set; } = "";
        public string Fantasia { get; set; } = "";
        public string Endereco { get; set; } = "";

        public string Bairro { get; set; } = "";

        public string Cidade { get; set; } = "";
        public string CEP { get; set; } = "";

        public string UF { get; set; } = "";
        public int Numero { get; set; } 
        public string Email { get; set; } = "";

        public string CPF { get; set; } = "";
        private int choiceCadastro { get; set; } //define se será update ou um insert
        int EscolhaAlterar { get; set; } //captura o registro para vc o insert 

        public void CADASTRAREmpresa() {
            Console.WriteLine("Digite o nome da empresa:");
            EmpresaNome = Console.ReadLine();

            Console.WriteLine("Digite a razão social:");
            Razao = Console.ReadLine();

            Console.WriteLine("Digite o nome fantasia:");
            Fantasia = Console.ReadLine();

            Console.WriteLine("Digite o endereço:");
            Endereco = Console.ReadLine();

            Console.WriteLine("Digite o email:");
            Email = Console.ReadLine();

            Console.WriteLine("Digite a cidade:");
            Cidade = Console.ReadLine();

            Console.WriteLine("Digite a UF:");
            UF = Console.ReadLine();

            Console.WriteLine("Digite o CEP:");
            CEP = Console.ReadLine();

            Console.WriteLine("Digite o número:");
            string prenum = Console.ReadLine();
            Numero = Convert.ToInt32(prenum);

            Console.WriteLine("Digite o CPF:");
            CPF = Console.ReadLine();
            if (choiceCadastro == 0)
            {
                // Chama a função de atualização
                Console.WriteLine("Vai entrar na funçao insert");
                INSERTEmpresa();
                
            }
            else
            {
                     Console.WriteLine("Vai entrar na funçao Update");
                AlterarEmpresa();
            }
        }

 public void INSERTEmpresa () {
            string sqlconexao = Conexão.ConexaoBanco;
            string Update = "INSERT INTO Empresa (EmpresaNome, Razao, Fantasia, Endereco, UF, Cidade, Numero, CEP, CPF, email) VALUES (@EmpresaNome, @Razao, @Fantasia, @Endereco, @UF, @Cidade, @Numero, @CEP, @CPF. @email)";
            try
            {
                using (SqlConnection conexao = new SqlConnection(sqlconexao))
                {
                    using (SqlCommand comando = new SqlCommand(Update, conexao))
                    {
                        comando.Parameters.AddWithValue("@EmpresaNome", EmpresaNome);
                        comando.Parameters.AddWithValue("@Razao", Razao);
                        comando.Parameters.AddWithValue("@Fantasia", Fantasia);
                        comando.Parameters.AddWithValue("@Endereco", Endereco);
                        comando.Parameters.AddWithValue("@email", Email);
                        comando.Parameters.AddWithValue("@Cidade", Cidade);
                        comando.Parameters.AddWithValue("@UF", UF);
                        comando.Parameters.AddWithValue("@CEP", CEP);
                        comando.Parameters.AddWithValue("@Numero", Numero);
                        comando.Parameters.AddWithValue("@CPF", CPF);

                        conexao.Open();
                        comando.ExecuteNonQuery();

                    }

                }
                Console.WriteLine("EMPRESA CADASTRADA COM SUCESSO");
            }
            catch (SqlException ex)
            {
                throw new Exception($"ERRO:{ex.Message}", ex);
            }
       
       
        }
        public void UpEmpresa() //FILTRA E JOGA PARA VARIÁVEIS, 
        {  VerEmpresa();
            Console.WriteLine("Escolha qual das empresas deseja alterar");
       string prenum = Console.ReadLine();
            EscolhaAlterar = Convert.ToInt32(prenum);
            Console.WriteLine($"ESTADO DE ESCOLHA ALTERAR função UP{EscolhaAlterar}");
      choiceCadastro = 1;
            Console.WriteLine("Vai entrar na função de Cadastro e inserir informações no input");
            CADASTRAREmpresa();

}        public void AlterarEmpresa () {
    Console.WriteLine($"ESTADO DE ESCOLHA ALTERAR função UP: {EscolhaAlterar}");
            int Registro = EscolhaAlterar;
            Console.WriteLine($" EStado do Registro na função update: {Registro}");
        
          
            string sqlconexao = Conexão.ConexaoBanco;
            string Update = "UPDATE EMPRESA SET EmpresaNome = @EmpresaNome, Razao = @Razao, Fantasia = @Fantasia, Endereco = @Endereco, Email = @Email, Cidade = @Cidade, UF = @UF, CEP = @CEP, NUMERO = @NUMERO, CPF = @CPF WHERE REGISTRO = @Registro";
            try
            {
                using (SqlConnection conexao = new SqlConnection(sqlconexao))
                {
                    using (SqlCommand comando = new SqlCommand(Update, conexao))
                    {
                        comando.Parameters.AddWithValue("@EmpresaNome", EmpresaNome);
                        comando.Parameters.AddWithValue("@Razao", Razao);
                        comando.Parameters.AddWithValue("@Fantasia", Fantasia);
                        comando.Parameters.AddWithValue("@Endereco", Endereco);
                        comando.Parameters.AddWithValue("@Email", Email);
                        comando.Parameters.AddWithValue("@Cidade", Cidade);
                        comando.Parameters.AddWithValue("@UF", UF);
                        comando.Parameters.AddWithValue("@CEP", CEP);
                        comando.Parameters.AddWithValue("@Numero", Numero);
                        comando.Parameters.AddWithValue("@CPF", CPF);
                        comando.Parameters.AddWithValue("@Registro", Registro);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                            
                    }

                }
Console.WriteLine($"UPDATE FEITO COM SUCESSO");
            }
            catch (SqlException ex)
            {
                throw new Exception($"ERRO ao acessar o Banco: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"ERRO: {ex.Message}", ex);
            }
            choiceCadastro = 0;
        }
   
        public void VerEmpresa() {
            string sqlconexao = Conexão.ConexaoBanco;
            string SELECAO = "SELECT REGISTRO, EmpresaNome, Razao  FROM EMPRESA";
            using (SqlConnection conexao = new SqlConnection(sqlconexao)) {
                using(SqlCommand comando = new SqlCommand(SELECAO, conexao))
                {

                    conexao.Open();
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        Console.WriteLine(String.Format("{0},{1}", leitor[0], leitor[1]));
                    }
                }



            }
           
        }

    }
}