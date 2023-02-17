using APIEventos.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {

        private readonly ILogger<CityEventController> _logger;

        public CityEventController(ILogger<CityEventController> logger)
        {
            _logger = logger;
        }

        //Consultar todos os Eventos
        [HttpGet(Name = "VisualizarEventos")]
        public ActionResult<List<CityEventEntities>> ConsultarEventos()
        {
            return Ok(new List<CityEventEntities>());
        }
        //Consultar Evento especifico
        [HttpGet(Name = "VisualizarEventoIndividual")]
        public ActionResult ConsultarEventosIndividual(int id)
        {
            CityEventEntities entities = new CityEventEntities();
            return Ok(entities);
        }

        //inserir Novo Evento
        [HttpPost(Name = "InserirEvento")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityEventEntities))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CityEventEntities>> InserirEvento(CityEventEntities cityEventEntities)
        {
            return CreatedAtAction(nameof(ConsultarEventosIndividual), cityEventEntities);
        }

        //Altera informações do Eventos
        [HttpPut(Name = "AlterarEvento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AlterarEvento(long id, CityEventEntities cityEventEntities)
        {
            return Ok();
        }

        //Deletar Evento
        [HttpDelete(Name = "ApagarEvento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ApagarEvento(long id)
        {
            return Ok();

        }

    }
}