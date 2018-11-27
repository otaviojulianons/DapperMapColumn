using System.ComponentModel;

namespace DapperMapColumn
{
    public class ClienteDominio
    {
        public string Id { get; set; }
        
        [Description("Nome")]
        public string NomeCliente { get; set; }
    }
}