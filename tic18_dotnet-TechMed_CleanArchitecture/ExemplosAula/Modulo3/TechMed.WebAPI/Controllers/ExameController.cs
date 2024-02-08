using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class ExameController : ControllerBase
{
    private readonly IExameService _exameService;
    public List<ExameViewModel> Exames => _exameService.GetAll();
    public ExameController(IExameService service) => _exameService = service;

    [HttpGet("exames")]
    public IActionResult Get()
    {
        return Ok(Exames);

    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] NewExameInputModel exame)
    {
        _exameService.Create(exame);
        return CreatedAtAction(nameof(Get), exame);

    }


}
