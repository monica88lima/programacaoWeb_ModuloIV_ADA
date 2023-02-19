using APIEventos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]
   
    public class EventReservationController : ControllerBase
    {
        private IEventReservationService _eventReservationService;

        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }
    }
}
