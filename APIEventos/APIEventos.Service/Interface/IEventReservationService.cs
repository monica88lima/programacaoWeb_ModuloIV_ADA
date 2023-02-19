using APIEventos.Entities;
using APIEventos.Service.Dto;

namespace APIEventos.Service.Interface
{
    public interface IEventReservationService
    {
        Task<List<InformacaoEventReservationDto>> SelecionarReservas(string personName, string title);

        Task<bool> InserirNovaReserva(EventReservationEntities novaReserva);
        Task<InformacaoEventReservationDto> SelecionarReservaPorID(long idReserva);
        Task<bool> AlterarReserva(long id, EventReservationEntities reserva);
        Task<bool> DeletarReserva(long idReservation);
        Task<bool> VerificaExistenciaReservaPorIDEvento(long idEvent);


    }
}