using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v0.1/medicos")]
    public class MedicoController : ControllerBase
    {
        private static List<Medico> Medicos = new List<Medico>();

        [HttpPost(Name = "CreateMedico")]
        public IActionResult Created(Medico medico)
        {
            Medicos.Add(medico);

            return CreatedAtAction(nameof(GetById), new { id = medico.Id }, medico);
        }

        [HttpGet(Name = "GetMedicos")]
        public IActionResult Get()
        {
            return Ok(Medicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var medico = Medicos.FirstOrDefault(m => m.Id == id);

            if(medico == null)
                return BadRequest();

            return Ok(medico);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Medico medico)
        {
            var medicoDb = Medicos.FirstOrDefault(m => m.Id == id);

            if (medicoDb == null)
                return BadRequest();

            medicoDb.Nome = medico.Nome;
            medicoDb.CPF = medico.CPF;
            medicoDb.Especialidade = medico.Especialidade;
            medicoDb.Salario = medico.Salario;
            medicoDb.CRM = medico.CRM;

            return Accepted("");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var medico = Medicos.FirstOrDefault(m => m.Id == id);

            Medicos.Remove(medico);

            return Ok(medico);
        }
    }
}
