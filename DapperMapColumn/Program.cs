using Dapper;
using System;
using System.Data.SqlClient;

namespace DapperMapColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            DapperMapper.Mapper<ClienteDominio>();

            try
            {
                using (var conexao = new SqlConnection(@"Data Source=(localDB)\v11.0;Initial Catalog=LOjaDB;Integrated Security=True"))
                {
                    var repositorio = conexao.Query<ClienteRepositorio>("select * from Clientes");
                    foreach (var item in repositorio)
                        Console.WriteLine("{0} - {1} ", item.Id, item.Nome);
                    var dominio = conexao.Query<ClienteDominio>("select * from Clientes");
                    foreach (var item in dominio)
                        Console.WriteLine("{0} - {1} ", item.Id, item.NomeCliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }
}
