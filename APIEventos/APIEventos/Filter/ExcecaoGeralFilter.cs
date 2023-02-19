using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIEventos.Filter
{
    public class ExcecaoGeralFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problema = new ProblemDetails
            {
                Title = "Erro Inesperado.",
                Detail = context.Exception?.Message,
                Type = context.Exception.GetType().Name 

            };

            switch (context.Exception)
            {
                case ArgumentNullException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problema);
                    break;

                case ArgumentException:
                    problema.Detail = " Erro Banco de Dados";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(problema);
                    break;

               
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problema);
                    break;

            }
        }
        // tem as informações da requisição e da excecao
    }
}
