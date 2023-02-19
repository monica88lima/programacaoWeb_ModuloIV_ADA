using APIEventos.Service.Dto;
using Dapper;
using MySqlConnector;

namespace APIEventos.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private string _stringConnection { get; set; }

        public EventReservationRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

        }

        public async Task<List<InformacaoEventReservationDto>> SelecionarEventReservation(string personName, string title)
        {
            string query = "SELECT a.idReservation, a.personName, a.idEvent, a.quantity, b.title " +
                "FROM EventReservation a " +
                "INNER JOIN CityEvent AS b ON b.idEvent = a.idEvent " +
                "WHERE b.title LIKE  '%' @title '%' AND a.personName = @personName ";

            DynamicParameters parametros = new();
            parametros.Add("title", title);
            parametros.Add("IpersonName", personName);

            using MySqlConnection conn = new(_stringConnection);

            return (await conn.QueryAsync<InformacaoEventReservationDto>(query, parametros)).ToList();

        }

    }
}
