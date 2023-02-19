using APIEventos.Service.Dto;

namespace APIEventos.Service.Interface
{
    public interface IEventReservationService
    {
        Task<List<InformacaoEventReservationDto>> SelecionarReservas(string personName, string title);
    }
}