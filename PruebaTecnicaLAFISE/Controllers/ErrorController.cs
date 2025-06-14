using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaLAFISE.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult HandleError()
        {   // Esta ruta se invoca cuando ocurre una excepción no controlada en la aplicación
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context?.Error == null)
            {
                // No hay excepción, responder con 404 para no confundir Swagger
                return NotFound(new { message = "No error found." });
            }
            // Obtener la excepción
            var exception = context.Error;

            //devolver error de validación
            return Problem(
                statusCode: 500,
                title: "Error inesperado",
                detail: exception.Message);
        }

    }
}
