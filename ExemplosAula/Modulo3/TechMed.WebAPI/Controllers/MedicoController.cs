using Microsoft.AspNetCore.Mvc;
using TechMed.Application.ViewModels;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class MedicoController : ControllerBase
{
   private readonly IMedicoService _medicoService;
   public List<MedicoViewModel> Medicos => _medicoService.GetAll().ToList();
   public MedicoController(IMedicoService service) => _medicoService = service;

   [HttpGet("medicos")]
   public IActionResult Get()
   {
      return Ok(Medicos);
   }

   [HttpGet("medico/{id}")]
   public IActionResult GetById(int id)
   {
      var medico = _medicoService.GetById(id);
      if (medico is null)
         return NoContent();
      return Ok(medico);
   }

   [HttpPost("medico")]
   public IActionResult Post([FromBody] NewMedicoInputModel medico)
   {
      _medicoService.Create(medico);
      return CreatedAtAction(nameof(Get), medico);
 
   }

   [HttpPut("medico/{id}")]
   public IActionResult Put(int id, [FromBody] NewMedicoInputModel medico)
   {
      if (_medicoService.GetById(id) == null)
         return NoContent();
      _medicoService.Update(id, medico);
      return Ok(_medicoService.GetById(id));
   }

   [HttpDelete("medico/{id}")]
   public IActionResult Delete(int id)
   {
      if (_medicoService.GetById(id) == null)
         return NoContent();
      _medicoService.Delete(id);
      return Ok();
   }

   [HttpPost("medico/{id}/Atendimento")]
   public IActionResult PostAtendimento(int id, [FromBody] NewMedicoInputModel medico)
   {
      if (_medicoService.GetById(id) == null)
         return NoContent();
      _medicoService.Update(id, medico);
      return Ok(_medicoService.GetById(id));
   }

}
