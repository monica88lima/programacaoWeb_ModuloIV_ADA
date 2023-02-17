namespace Aula2_API.Interface
{
    public interface ICliente
    {
        List<Cliente> SelecionarClientes();
        Cliente SelecionarCliente(int id);
        bool InserirCliente(Cliente cliente);
        bool DeletarCliente(int id);
        bool AlterarCliente(Cliente cliente, int id);


    }
}
