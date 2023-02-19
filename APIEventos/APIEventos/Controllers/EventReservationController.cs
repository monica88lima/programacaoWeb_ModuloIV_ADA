using APIEventos.Entities;
using APIEventos.Service.Entities;
using APIEventos.Service.Interface;
using APIEventos.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]
    [Authorize]


    public class EventReservationController : ControllerBase
    {
        private IEventReservationService _eventReservationService;
        private ICityEventService _cityEventService;

        public EventReservationController(IEventReservationService eventReservationService, ICityEventService cityEventService)
        {
            _eventReservationService = eventReservationService;
            _cityEventService = cityEventService;
        }


        [HttpGet("VisualizarReserva")]
        public async Task<ActionResult<List<EventReservationEntities>>> ConsultarReserva(string nome, string titulo)
        {
            return Ok(await _eventReservationService.SelecionarReservas(nome, titulo));
        }

        
        [HttpPost(Name = "InserirReserva")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EventReservationEntities))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EventReservationEntities>>> InserirReserva(EventReservationEntities novaReserva)
        {
            if (await _cityEventService.ConsultarEventosPorId(novaReserva.IdEvent) is null)
            {
                throw new Exception("id de Evento Inexistente.");
            }

            if (!await _eventReservationService.InserirNovaReserva(novaReserva))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(ConsultarReserva), novaReserva);
        }

        
        [Authorize(Roles = "admin")]
        [HttpPut(Name = "AlterarReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AlterarEvento(long idReserva, EventReservationEntities reserva)
        {
            if (await _eventReservationService.SelecionarReservaPorID(idReserva) is null)
            {
                throw new Exception("id de Reserva Inexistente.");
            }

            if (!await _eventReservationService.AlterarReserva(idReserva,reserva))
            {
                return Conflict("Os dados enviados estão divergentes");
            }
            return Ok();
        }
       
        [Authorize(Roles = "admin")]
        [HttpDelete(Name = "ApagarReserva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApagarReserva(long id )
        {
            //verificar se o id da reserva existe
            if (await _eventReservationService.SelecionarReservaPorID(id) is null)
            {
                throw new Exception("id de Reserva Inexistente.");
            }
           
            if (!await _eventReservationService.DeletarReserva(id))
            {
                return BadRequest();
            }
            return Ok();

        }
    }


}
