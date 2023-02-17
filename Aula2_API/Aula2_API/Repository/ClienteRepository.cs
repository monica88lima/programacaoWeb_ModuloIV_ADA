using MySqlConnector;
using Dapper;
using Aula2_API.Interface;

namespace Aula2_API.Repository
{
    public class ClienteRepository:ICliente
    {
        public string _stringConnection { get; set; }

        public ClienteRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
        public List<Cliente> SelecionarClientes()
        {
            string query = "SELECT * FROM cliente ORDER BY nome ASC";

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<Cliente>(query).ToList();
        }

        public Cliente SelecionarCliente(int id)
        {
            string query = "SELECT * From cliente Where ID_Cliente = @id";

            DynamicParameters parametros = new();
            parametros.Add("id", id);

            using MySqlConnection conn = new(_stringConnection);

            return conn.QueryFirstOrDefault<Cliente>(query, parametros);
        }

        public bool InserirCliente(Cliente cliente)
        {
            string query = "INSERT INTO cliente( nome, dataNascimento, quantidadePorPedido, idade )" +
                "VALUES (@nome, @dataNascimento,@quantidadePorPedido, @idade)";

            DynamicParameters parametros = new();
            parametros.Add("nome", cliente.Nome);
            parametros.Add("dataNascimento", cliente.DataNascimento);
            parametros.Add("quantidadePorPedido", cliente.QuantidadePorPedido);
            parametros.Add("idade", cliente.Idade);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;
        }

        public bool AlterarCliente(Cliente cliente, int id)
        {

            string query = $"UPDATE cliente SET nome = @nome,dataNascimento = @dataNascimento,quantidadePorPedido = @quantidadePorPedido,idade = @idade where ID_Cliente = @id";


            DynamicParameters parametros = new();
            parametros.Add("nome", cliente.Nome);
            parametros.Add("dataNascimento", cliente.DataNascimento);
            parametros.Add("quantidadePorPedido", cliente.QuantidadePorPedido);
            parametros.Add("idade", cliente.Idade);
            parametros.Add("id", cliente.ID_Cliente);

            //id sempre entra nos @ pq ele faz parte da query

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);
            return linhasAfetadas > 0;
        }

        public bool DeletarCliente( int id)
        {
            string query = "DELETE FROM cliente where ID_Cliente = @id";

            DynamicParameters parametros = new();
            parametros.Add("id", id);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query,parametros);
            return linhasAfetadas > 0;

        }
    }
}
