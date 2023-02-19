using APIEventos.Service.Dto;
using APIEventos.Service.Entities;
using APIEventos.Service.Interface;
using Dapper;
using MySqlConnector;

namespace APIEventos.Infra.Data.Repository;

public class CityEventRepository : ICityEventServiceRepository
{
    private string _stringConnection { get; set; }
    public CityEventRepository()
    {
        _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
    }

    public async Task <InformacaoCityEventDto> SelecionarCityEventPorId(long IdEvent)
    {
        string query = "SELECT * FROM CityEvent WHERE idEvent = @IdEvent";

        DynamicParameters parametros = new();
        parametros.Add("IdEvent", IdEvent);

        using MySqlConnection conn = new(_stringConnection);

        return (await conn.QueryFirstOrDefaultAsync<InformacaoCityEventDto>(query, parametros));

    }

    public async Task<List<InformacaoCityEventDto>> SelecionarCityEventTitle(string title)
    {
        string query = "SELECT * FROM CityEvent WHERE title LIKE  '%' @title '%' ORDER BY title ASC";

        DynamicParameters parametros = new();
        parametros.Add("title", title);

        using MySqlConnection conn = new(_stringConnection);

        return (await conn.QueryAsync<InformacaoCityEventDto>(query, parametros)).ToList();

    }
    public async Task<List<InformacaoCityEventDto>> SelecionarCityEventLocalData(DateTime data, string local)
    {
        string query = "SELECT * FROM CityEvent WHERE CAST(dateHourEvent AS DATE) = @data and local = @local ORDER BY title ASC;";

        DynamicParameters parametros = new();
        parametros.Add("data", data.ToString("yyyy-MM-dd"));
        parametros.Add("local", local);

        using MySqlConnection conn = new(_stringConnection);

        return (await conn.QueryAsync<InformacaoCityEventDto>(query, parametros)).ToList();

    }

    public async Task<List<InformacaoCityEventDto>> SelecionarCityEventDataPrice(DateTime data, decimal price)
    {
        string query = "SELECT * FROM CityEvent WHERE CAST(dateHourEvent AS DATE) = @data and price= @price ORDER BY title ASC;";

        DynamicParameters parametros = new();
        parametros.Add("data", data.ToString("yyyy-MM-dd"));
        parametros.Add("price", price);

        using MySqlConnection conn = new(_stringConnection);

        return (await conn.QueryAsync<InformacaoCityEventDto>(query, parametros)).ToList();

    }
    //o using encerra a conexão com o banco.
    public async Task<bool> InserirCityEvent(CityEventEntities newEvent)
    {
        string query = "INSERT INTO CityEvent (title,description,dateHourEvent,local,address,price,status)" +
            "VALUES (@title,@description,@dateHourEvent,@local,@address,@price,@status)";

        DynamicParameters parametros = new();
        
        parametros.Add("title", newEvent.Title);
        parametros.Add("description", newEvent.Description);
        parametros.Add("dateHourEvent", newEvent.DateHourEvent);
        parametros.Add("local", newEvent.local);
        parametros.Add("address", newEvent.Address);
        parametros.Add("price", newEvent.Price);
        parametros.Add("status", newEvent.Status);

        using MySqlConnection conn = new(_stringConnection);

        int linhasAfetadas =(await conn.ExecuteAsync(query, parametros));

        return linhasAfetadas > 0;
    }

    public async Task<bool> AlterarCityEvent(CityEventEntities newEvent, long idEvent)
    {
        string query = "UPDATE CityEvent set title=@title,description=@description,dateHourEvent=@dateHourEvent,local=@local,address=@address,price=@price,status=@status WHERE idEvent =@idEvent ";


        DynamicParameters parametros = new();

        parametros.Add("idEvent", newEvent.IdEvent);
        parametros.Add("title", newEvent.Title);
        parametros.Add("description", newEvent.Description);
        parametros.Add("dateHourEvent", newEvent.DateHourEvent);
        parametros.Add("local", newEvent.local);
        parametros.Add("address", newEvent.Address);
        parametros.Add("price", newEvent.Price);
        parametros.Add("status", newEvent.Status);

        using MySqlConnection conn = new(_stringConnection);

        int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

        return linhasAfetadas > 0;
    }

    public async Task<bool> DeletarCityEvent(long idEvent)
    {
        string query = "Delete From CityEvent WHERE idEvent =@idEvent";

        DynamicParameters parametros = new();
        parametros.Add("idEvent", idEvent);

        using MySqlConnection conn = new(_stringConnection);

        int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

        return linhasAfetadas > 0;
    }

    public async Task<bool> AlterarStatusCityEvent(bool Status, long idEvent)
    {
        string query = "UPDATE CityEvent set status = @status WHERE idEvent = @idEvent";

        DynamicParameters parametros = new();

        parametros.Add("idEvent", idEvent);
        parametros.Add("status", Status);

        using MySqlConnection conn = new(_stringConnection);

        int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

        return linhasAfetadas > 0;
    }
}

