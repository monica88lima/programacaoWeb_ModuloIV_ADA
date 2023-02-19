using APIEventos.Entities;
using APIEventos.Service.Dto;

namespace APIEventos.Infra.Data.Repository
{
    public interface IEventReservationRepository
    {
        Task<List<InformacaoEventReservationDto>> SelecionarEventReservation(string personName, string title);
        Task<bool> InserirNovaReserva(EventReservationEntities novaReserva);
        Task<bool> AlterarReserva(EventReservationEntities reserva, long idREserva);

        Task<InformacaoEventReservationDto> SelecionarReservaPorID(long idReserva);
        Task<bool> DeletarReserva(long idReservation);
        Task<bool> VerificaExistenciaReservaPorIDEvento(long idEvent);
    }
}