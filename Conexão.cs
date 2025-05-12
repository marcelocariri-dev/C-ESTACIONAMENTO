using System;

namespace ESTACIONAMENTO
{
    public static class Conexão
    {
        public static string ConexaoBanco { get; } = 
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Central_sql;User Id=sa;Password=qaz@123;TrustServerCertificate=True ";
    }
}