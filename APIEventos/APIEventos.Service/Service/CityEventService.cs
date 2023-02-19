﻿
using APIEventos.Service.Dto;
using APIEventos.Service.Entities;
using APIEventos.Service.Interface;
using System.Xml.Linq;

namespace APIEventos.Service.Service
{
    public class CityEventService : ICityEventService
    {
        private ICityEventServiceRepository _cityEventServiceRepository;
        public CityEventService(ICityEventServiceRepository cityEventServiceRepository)
        {
            _cityEventServiceRepository = cityEventServiceRepository;
        }

        public async Task<InformacaoCityEventDto> ConsultarEventosPorId(long idEvent)
        {
            return (await _cityEventServiceRepository.SelecionarCityEventPorId(idEvent));
        }

        public async Task<List<InformacaoCityEventDto>> ConsultarEventosTitle(string title)
        {
            return (await _cityEventServiceRepository.SelecionarCityEventTitle(title));
        }

        public async Task<List<InformacaoCityEventDto>> ConsultarEventosDataLocal(DateTime data, string local)
        {
            return await _cityEventServiceRepository.SelecionarCityEventLocalData(data, local);
        }

        public async Task<List<InformacaoCityEventDto>> ConsultarEventosDataPrice(DateTime data, decimal price)
        {
            return await _cityEventServiceRepository.SelecionarCityEventDataPrice(data, price);
        }


        public async Task<bool> InserirEvento(CityEventEntities newEvent)
        {
            return await _cityEventServiceRepository.InserirCityEvent(newEvent);
        }
        public async Task<bool> AlterarEvento(long id, CityEventEntities cityEventEntities)
        {
            return await _cityEventServiceRepository.AlterarCityEvent(cityEventEntities, id);
        }

        public async Task<bool> ApagarEvento(long id)
        {
            return await _cityEventServiceRepository.DeletarCityEvent(id);

        }

    }
}
