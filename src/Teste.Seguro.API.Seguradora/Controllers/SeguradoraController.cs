using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.API.Seguradora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguradoraController : ControllerBase
    {
        private readonly ISeguradoraService _seguradoraService;

        public SeguradoraController(ISeguradoraService seguradoraService) => (this._seguradoraService) = (seguradoraService);

        [HttpGet("busca-todos")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(this._seguradoraService.GetAllAsync());
        }

        [HttpGet("busca-por-id/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(this._seguradoraService.GetByIdAsync(id));
        }

        [HttpGet("busca-por-nome/{nome}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
        public async Task<IActionResult> GetByPredicateAsync(string nome)
        {
            if (nome is null)
                return NotFound("Valor do objeto esta nulo.");

            Predicate<SeguradoraEntity> predicate = w => w.Nome.Equals(nome);
            var seguradora = this._seguradoraService.GetByPredicateAsync(predicate);

            return Ok(this._seguradoraService.GetAllAsync());
        }
    }
}
