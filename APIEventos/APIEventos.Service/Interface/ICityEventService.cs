using APIEventos.Service.Dto;
using APIEventos.Service.Entities;

namespace APIEventos.Service.Interface
{
    public interface ICityEventService
    {

        Task<InformacaoCityEventDto> ConsultarEventosPorId(long idEvent);
        Task<bool> ApagarEvento(long id);
        Task<bool> AlterarEvento(long id, CityEventEntities cityEventEntities);

        Task<List<InformacaoCityEventDto>> ConsultarEventosTitle(string title);
        Task<List<InformacaoCityEventDto>> ConsultarEventosDataLocal(DateTime data, string local);

        Task<List<InformacaoCityEventDto>> ConsultarEventosDataPrice(DateTime data, decimal price);
        Task<bool> InserirEvento(CityEventEntities newEvent);


    }
}