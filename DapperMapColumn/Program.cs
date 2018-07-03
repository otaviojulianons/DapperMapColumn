using Dapper;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DapperMapColumn
{

    class ClienteRepositorio {
        public string Id { get; set; }
        public string Nome { get; set; }
    }

    class ClienteDominio
    {
        public string Id { get; set; }
        [Description("Nome")]
        public string NomeCliente { get; set; }
    }

    static class DapperMapper
    {
        public static void Mapper<T>()
        {
            var map = new CustomPropertyTypeMap(typeof(T),
                        (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttribute(prop) == columnName));
            SqlMapper.SetTypeMap(typeof(T), map);
        }

        static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return attrib == null ? member.Name : attrib.Description;
        }
    }

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
