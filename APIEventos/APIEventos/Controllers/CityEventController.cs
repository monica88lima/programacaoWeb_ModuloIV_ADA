using APIEventos.Entities;
using APIEventos.Service.Entities;
using APIEventos.Service.Interface;
using APIEventos.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]

    public class CityEventController : ControllerBase
    {

        private ICityEventService _cityEventService;        


        public CityEventController(ICityEventService cityEventService)
        {

            _cityEventService = cityEventService;
            

        }

        [HttpGet("VisualizarEventosPorTitulo")]
        public async Task<ActionResult<List<CityEventEntities>>> ConsultarEventosTitle(string title)
        {
            return Ok(await _cityEventService.ConsultarEventosTitle(title));
        }



        [HttpGet("VisualizarEventosPorDataLocal")]
        public async Task<ActionResult<List<CityEventEntities>>> ConsultarEventosDataLocal(DateTime data, string local)
        {
            return Ok(await _cityEventService.ConsultarEventosDataLocal(data, local));
        }


        [HttpGet("VisualizarEventosPorDataPreco")]
        public async Task<ActionResult<List<CityEventEntities>>> ConsultarEventosDataPrice(DateTime data, decimal price)
        {
            return Ok(await _cityEventService.ConsultarEventosDataPrice(data, price));
        }

        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpPost(Name = "InserirEvento")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CityEventEntities))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CityEventEntities>>> InserirEvento(CityEventEntities newEvent)
        {
            if (!await _cityEventService.InserirEvento(newEvent))
            {
                return BadRequest("");
            }
            return CreatedAtAction(nameof(ConsultarEventosTitle), newEvent);
        }
        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpPut(Name = "AlterarEvento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AlterarEvento(long id, CityEventEntities cityEventEntities)
        {
            if (await _cityEventService.ConsultarEventosPorId(id) is null)
                return NoContent();

            if (!await _cityEventService.AlterarEvento(id, cityEventEntities))
            {
                return Conflict("Os dados enviados estão divergentes");
            }
            return Ok();
        }
        [Authorize]
        [Authorize(Roles = "admin")]
        [HttpDelete(Name = "ApagarEvento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApagarEvento(long id)
        {
            if (!await _cityEventService.ApagarEvento(id))
            {
                return BadRequest();
            }
            return Ok();

        }



        ///Pensar nessa historia para criar o metodo
        ///primeiro verificar se o item existe no banco, retorno NoContent, se não existir.pesquisei mas  <summary>
        /// Pensar nessa historia para criar o metodo

        //não encontrei retorno assim "O dado enviado esta ok, mas vc não existe no meu banco".
        ///Agora se o dado enviado pelo cliente existir, e eu afetei uma linha do banco retorno OK
    }
}