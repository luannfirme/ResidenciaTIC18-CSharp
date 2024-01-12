using Microsoft.EntityFrameworkCore;
using Techmed.Model;

var context = new TechmedContext();


var maria = context.Pacientes.Where(p => p.CPF == "047.202.303-02").FirstOrDefault();

var Atendimentos = context.Atendimentos.AsNoTrackingWithIdentityResolution()
                    .Include(m => m.Medico)
                    .Include(p => p.Paciente)
                    .Include(e => e.Exames)
                    .ToList();

Atendimentos.ForEach( a => {
    Console.WriteLine($"Paciente: {a.Paciente.Nome} /n Exames: /n {a.Exames.Where(e => e.Atendimento.Paciente == a.Paciente)}");
});