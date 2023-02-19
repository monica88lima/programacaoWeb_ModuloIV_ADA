using APIEventos.Infra.Data.Repository;
using APIEventos.Service.Dto;
using APIEventos.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Service.Service
{
    public class EventReservationService : IEventReservationService
    {

        IEventReservationRepository _eventReservationRepository;

        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }

        public async Task<List<InformacaoEventReservationDto>> SelecionarReservas(string personName, string title)
        {
            return await _eventReservationRepository.SelecionarEventReservation(personName, title);
        }
    }
}
