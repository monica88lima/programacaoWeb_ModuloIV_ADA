using APIEventos.Service.Dto;

namespace APIEventos.Infra.Data.Repository
{
    public interface IEventReservationRepository
    {
        Task<List<InformacaoEventReservationDto>> SelecionarEventReservation(string personName, string title);
    }
}