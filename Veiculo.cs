using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ESTACIONAMENTO
{
    public class Veiculo
    {
        //public string Veiculonome { get; set; } = "";
        public string carro { get; set; } = "";
        public Dictionary<string, string> veiculofinal { get; set; } = new Dictionary<string, string>();
        public string placa { get; set; } = "";
        public void menu()
        {

            Console.WriteLine($"SELECIONE A OPÇÃO: \n0-Cadastrar Empresa \n1-CADASTRAR VEICULO \n2-LISTAR VEICULO \n3-DELETAR VEICULO \n4-Alterar Empresa Cadastro\n5-Ver Empresa");
        }
        public void Cadastrarveiculo()
        {
            try
            {
                Console.WriteLine("Digite o nome do carro");
                carro = Console.ReadLine()!;
                Console.WriteLine("Digite o nome da placa");
                placa = Console.ReadLine()!;

                Console.WriteLine($"Inserindo no banco: Placa={placa}, NomeVeiculo={carro}");
                if (string.IsNullOrWhiteSpace(carro) || string.IsNullOrWhiteSpace(placa))
                {
                    Console.WriteLine("o nome ou placa não podem ser nulas");
                }


                veiculofinal[placa] = carro;
                Console.WriteLine($"CONFERIR FINAL DE FUNÇÃO: Placa={placa}, NomeVeiculo={carro}");
                InsertVeiculo();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: ENTRADA INVÁLIDA. {ex.Message}");
            }
        }
        public void InsertVeiculo()
        {
            string sqlconexao = Conexão.ConexaoBanco;
            string insert = "INSERT INTO Cadastro_Veiculos (NomeVeiculo, Placa) VALUES (@NomeVeiculo, @Placa)";
            Console.WriteLine($"Inserindo no banco: Placa={placa}, NomeVeiculo={carro}");

            try
            {
                using (SqlConnection conexao = new SqlConnection(sqlconexao))
                {
                    using (SqlCommand comando = new SqlCommand(insert, conexao))
                    {
                        comando.Parameters.AddWithValue("@Placa", placa);
                        comando.Parameters.AddWithValue("@NomeVeiculo", carro);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }

                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Erro ao acessar o banco de dados: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar veiculo {ex.Message}", ex);
            }
        }

        public void Listarveiculos()
        {

            string sqlconexao = Conexão.ConexaoBanco;
            string select = "SELECT RegistroVeiculo, NomeVeiculo, Placa FROM Cadastro_Veiculos";
            try
            {
                using (SqlConnection conexao = new SqlConnection(sqlconexao))
                {
                    using (SqlCommand comando = new SqlCommand(select, conexao))
                    {
                        conexao.Open();
                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}", leitor[0], leitor[1]));

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"ERRO ao acessar banco de dados VEICULO: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao fazer SELECT: {ex.Message}", ex);
            }


        }

        public void DeleteVeiculos()
        { Console.WriteLine("Qual desse numeros vc deseja excluir?");
            Listarveiculos();
            string recebido = Console.ReadLine()!;
            try {
                string sqlconexao = Conexão.ConexaoBanco;
                string DELETE = "DELETE FROM Cadastro_Veiculos Where RegistroVeiculo= @RegistroVeiculo";
                using (SqlConnection conexao = new SqlConnection(sqlconexao))
                {
                    using (SqlCommand comando = new SqlCommand(DELETE, conexao))
                    {
                        comando.Parameters.AddWithValue("@RegistroVeiculo", recebido);
                        conexao.Open();
                        comando.ExecuteNonQuery(); 
                        

                    }
                } Console.WriteLine("VEICULO DELETADO COM SUCESSO");
            }
             catch (SqlException ex) {
                throw new Exception($"erro ao remover veiculo {ex.Message}", ex);

            } catch (Exception ex) {
                throw new Exception($"ERRO {ex.Message}", ex);
            }
           }


    }
}

