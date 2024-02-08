using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;
    public List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
    public AtendimentoController(IAtendimentoService service) => _atendimentoService = service;
    [HttpGet("atendimentos")]
    public IActionResult Get()
    {
        return Ok(Atendimentos);

    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] NewAtendimentoInputModel atendimento)
    {
        _atendimentoService.Create(atendimento);
        return CreatedAtAction(nameof(Get), atendimento);

    }


}
