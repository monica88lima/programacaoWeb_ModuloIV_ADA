using APIEventos.Entities;
using APIEventos.Infra.Data.Repository;
using APIEventos.Service.Dto;
using APIEventos.Service.Entities;
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

        public async Task<InformacaoEventReservationDto> SelecionarReservaPorID(long id)
        {
            return (await _eventReservationRepository.SelecionarReservaPorID(id));
        }

        public async Task<List<InformacaoEventReservationDto>> SelecionarReservas(string personName, string title)
        {
            return await _eventReservationRepository.SelecionarEventReservation(personName, title);
        }

        public async Task<bool> InserirNovaReserva(EventReservationEntities novaReserva)
        {

            return await _eventReservationRepository.InserirNovaReserva(novaReserva);
        }

        public async Task<bool> AlterarReserva(long id, EventReservationEntities reserva)
        {
            return await _eventReservationRepository.AlterarReserva(reserva, id); 
        }

        public async Task<bool> DeletarReserva(long id)
        {
            return await _eventReservationRepository.DeletarReserva(id);

        }

        public async Task<bool> VerificaExistenciaReservaPorIDEvento(long idEvent)
        {
            return await _eventReservationRepository.VerificaExistenciaReservaPorIDEvento(idEvent);
        }

    }
}
