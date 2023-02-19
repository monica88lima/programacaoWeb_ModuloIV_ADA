using APIEventos.Service.Dto;
using APIEventos.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Interface
{
    public interface ICityEventServiceRepository
    {
        Task<bool> AlterarCityEvent(CityEventEntities newEvent, long idEvent);
        Task<bool> DeletarCityEvent(long idEvent);
        Task<bool> InserirCityEvent(CityEventEntities newEvent);
        Task<List<InformacaoCityEventDto>> SelecionarCityEventDataPrice(DateTime data, decimal price);
        Task<List<InformacaoCityEventDto>> SelecionarCityEventLocalData(DateTime data, string local);
        Task<InformacaoCityEventDto> SelecionarCityEventPorId(long IdEvent);
        Task<List<InformacaoCityEventDto>> SelecionarCityEventTitle(string title);




    }
}
