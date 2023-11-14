using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.Net;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Service;
using Teste.Seguro.Service.Validators;

namespace Teste.Seguro.API.Seguro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeguroController : ControllerBase
{
    private readonly ISeguradoService _baseSeguradoService;
    private readonly ISeguroService _baseSeguroService;

    public SeguroController(ISeguroService baseSeguroService, ISeguradoService baseSeguradoService) =>
        (baseSeguroService, baseSeguradoService) = (_baseSeguroService = baseSeguroService, _baseSeguradoService = baseSeguradoService);

    [HttpGet("contratar")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
    public async Task<IActionResult> SetAddAsync([FromBody] SeguroEntity seguro)
    {
        if (seguro is null)
            return BadRequest("Objeto está nulo.");

        return Ok(_baseSeguroService.AddAsync<SeguroValidator>(seguro));
    }

    [HttpPost("orcamento")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
    public async Task<IActionResult> CalculateAsync(decimal valorVeiculo, decimal margem_seguranca, decimal lucro)
    {
        //if (seguro is null)
        //    return BadRequest("Objeto está nulo.");
        NumberFormatInfo setPrecision = new NumberFormatInfo();
        setPrecision.NumberDecimalDigits = 2;

        var taxaRisco = valorVeiculo * 5 / (valorVeiculo * 2) / 100;
        var premioRisco = taxaRisco * valorVeiculo;
        var premioPuro = premioRisco * (1 + margem_seguranca);
        var premioComercial = lucro * premioPuro;
        Decimal valorSeguro = (premioComercial + premioPuro);
        return Ok(valorSeguro);

        //return new JsonResult(Execute(() => this._baseSeguroService.CalcularSeguroAsync(seguro)));
    }

    [HttpGet("buscar-todos")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
    public async Task<JsonResult> GetAllAsync()
    {
        return new JsonResult(Execute(() => _baseSeguroService.GetAllAsync()));
    }

    [HttpGet("buscar-por-id/{id}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
    public async Task<JsonResult> GetByIdAsync(Guid id)
    {
        return new JsonResult(Execute(() => _baseSeguroService.GetByIdAsync(id)));
    }

    [HttpGet("buscar-por-segurado/{nome}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(JsonResult))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(JsonResult))]
    public async Task<IActionResult> GetByNameAsync(string nome)
    {
        Predicate<SeguradoEntity> predicate = w => w.Nome.Equals(nome);
        var segurado = Execute(() => _baseSeguradoService.GetByPredicateAsync(predicate)) as SeguradoEntity;

        if (segurado is null)
            return NotFound("Segurado não encontrado.");

        Predicate<SeguroEntity> pred = w => w.SeguradoId.Equals(segurado.Id);
        return new JsonResult(Execute(() => _baseSeguroService.GetByPredicateAsync(pred)));
    }

    private IActionResult Execute(Func<object> func)
    {
        try
        {
            return Ok(func());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
