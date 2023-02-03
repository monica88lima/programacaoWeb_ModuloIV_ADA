using Microsoft.AspNetCore.Mvc;

namespace Aula2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("Application/json")]
    [Produces("application/json")]
    //Producer e Consumes -> refere-se ao que a Api aceita, pode ser coloca de forma geral ou no metodo
    public class ClienteController : ControllerBase
    {
        public List<Cliente> cliente = new List<Cliente>();

        public ClienteController()
        {
            cliente.Add(new Cliente
            {
                Nome = "Monica",
                ID_Cliente = 010,
                DataNascimento = new DateTime(1988,04,07)

            });

            cliente.Add(new Cliente
            {
                Nome = "Laura",
                ID_Cliente = 020,
                DataNascimento = new DateTime(2015, 01, 24)

            });

            cliente.Add(new Cliente
            {
                Nome = "Alice",
                ID_Cliente = 030,
                DataNascimento = new DateTime(2018, 11, 29)

            });

        }

        //body->returno das respostas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente> >Consultar()
        {
            return Ok(cliente);
        }
        //action refere-se a ação
        //producesResponses, produção da resposta o codigo de resposta
        [HttpGet("Filtro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cliente> ConsultarClientes(string nome)
        {
            Cliente clienteFiltro = cliente.FirstOrDefault(x => x.Nome == nome);
            return Ok(clienteFiltro);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult <List<Cliente>>Inserir(Cliente pessoa)
        {
            cliente.Add(pessoa);
            return CreatedAtAction(nameof(ConsultarClientes),pessoa);
        }
        //nameof -> responde com o link para consulta do item criado.
        //actionResult -> trata-se do conteudo

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(List<Cliente>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult  Alterar(int index, Cliente pessoa)
        {
            if(index == null)
            {
                return BadRequest();
            }
            cliente[index] = pessoa;
            return Ok(cliente);
            
        }
        //usa-se a interface quando nao se sabe o tipo do retorno

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(string nome)
        {
            Cliente pessoaDeletar = cliente.FirstOrDefault(p => p.Nome == nome);
            if (pessoaDeletar == null)
            {
                return BadRequest();
            }

            cliente.Remove(pessoaDeletar);
            return NoContent();
        }


    }
}