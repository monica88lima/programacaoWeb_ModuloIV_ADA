using Microsoft.AspNetCore.Mvc;
using Aula2_API.Repository;
using Aula2_API.Interface;

namespace Aula2_API.Controllers
{
    //esses atributos tambem são chamados de decorators (são os apoios dos metodos)
    [ApiController]
    [Route("[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]
    //Producer e Consumes -> refere-se ao que a Api aceita, pode ser coloca de forma geral ou no metodo
    public class ClienteController : ControllerBase
    {
        public ICliente _repository { get; set; }
              

        public ClienteController(ICliente clienteBd)
        {
            _repository = clienteBd;
        }

        //body->retorno das respostas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Consultar()
        {

            return Ok(_repository.SelecionarClientes());
        }
        //action refere-se a ação
        //producesResponses, produção da resposta o codigo de resposta
        [HttpGet("Filtro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cliente> ConsultarCliente(int id)
        {
            Cliente cliente = _repository.SelecionarCliente(id);
            if (cliente== null)
            {
                return BadRequest();
            }
            return Ok(cliente);
        }
        //modelstate(funcionalidade da ControllerBase) e quem recebe no parametro neste caso e o Cliente (organiza parametros)
        // [FromBody] refere-se que aquele parametro e complexo e vem no corpo, [FromRoute] vem na rota
        //com uma query seria porta/Cliente? tudo depois da interrogação e da query

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<List<Cliente>> Inserir(Cliente cliente)
        {

            if (!_repository.InserirCliente(cliente))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Consultar), cliente);
        }


        //nameof -> responde com o link para consulta do item criado.
        //actionResult -> trata-se do conteudo

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Alterar(int index, Cliente cliente)
        {
            if (!_repository.AlterarCliente(cliente, index))
            {
                return BadRequest();
            }
            return NoContent();
        }
        //nocontent - deu certo mas nao devolvo nada

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(int id)
        {
            if (!_repository.DeletarCliente(id))
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
    //usa-se a interface quando nao se sabe o tipo do retorno


}

