using APIEventos.Entities;
using APIEventos.Service.Dto;
using APIEventos.Service.Entities;
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

        public async Task<InformacaoEventReservationDto> SelecionarReservaPorID(long idReserva)
        {
            string query = "SELECT * FROM EventReservation WHERE idReservation = @idReserva";

            DynamicParameters parametros = new();
            parametros.Add("idReserva", idReserva);

            using MySqlConnection conn = new(_stringConnection);

            return (await conn.QueryFirstOrDefaultAsync<InformacaoEventReservationDto>(query, parametros));

        }
        public async Task<bool> VerificaExistenciaReservaPorIDEvento(long idEvent)
        {
            string query = "SELECT * FROM EventReservation WHERE idEvent = @idEvent";

            DynamicParameters parametros = new();
            parametros.Add("idEvent", idEvent);

            using MySqlConnection conn = new(_stringConnection);

            var linhasAfetadas = (await conn.QueryFirstOrDefaultAsync<InformacaoEventReservationDto>(query, parametros));

            return linhasAfetadas is not null;

        }

        public async Task<List<InformacaoEventReservationDto>> SelecionarEventReservation(string personName, string title)
        {
            string query = "SELECT a.idReservation, a.personName, a.idEvent, a.quantity, b.title " +
                "FROM EventReservation a " +
                "INNER JOIN CityEvent AS b ON b.idEvent = a.idEvent " +
                "WHERE b.title LIKE  '%' @title '%' AND a.personName = @personName ";

            DynamicParameters parametros = new();
            parametros.Add("title", title);
            parametros.Add("personName", personName);

            using MySqlConnection conn = new(_stringConnection);

            return (await conn.QueryAsync<InformacaoEventReservationDto>(query, parametros)).ToList();

        }

        public async Task<bool> InserirNovaReserva(EventReservationEntities novaReserva)
        {
            string query = "INSERT INTO EventReservation (idEvent,personName,quantity)" +
                "VALUES (@idEvent,@personName,@quantity)";

            DynamicParameters parametros = new();

            parametros.Add("idEvent", novaReserva.IdEvent);
            parametros.Add("personName", novaReserva.PersonName);
            parametros.Add("quantity", novaReserva.Quantity);


            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

            return linhasAfetadas > 0;
        }

        public async Task<bool> AlterarReserva(EventReservationEntities reserva, long idREserva)
        {
            string query = "UPDATE EventReservation set quantity=@quantity WHERE idReservation =@idReserva ";


            DynamicParameters parametros = new();

            parametros.Add("quantity", reserva.Quantity);
            parametros.Add("idReserva", reserva.IdReservation);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

            return linhasAfetadas > 0;
        }
        public async Task<bool> DeletarReserva(long idReservation)
        {
            string query = "Delete From EventReservation WHERE idReservation =@idReservation";

            DynamicParameters parametros = new();
            parametros.Add("idReservation", idReservation);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = (await conn.ExecuteAsync(query, parametros));

            return linhasAfetadas > 0;
        }

    }
}
