using Techmed.Entities;
using Techmed.Model;

var context = new TechmedContext();

Console.WriteLine($"Lendo todos os médicos no banco de dados");
foreach (var med in context.Medicos.OrderBy(m => m.Nome))
{
    Console.WriteLine($"Id: {med.Id} - Nome: {med.Nome} - CRM: {med.CRM}");
}

Console.WriteLine($"Lendo todos os pacientes no banco de dados");
foreach (var pac in context.Pacientes.OrderBy(m => m.Nome))
{
    Console.WriteLine($"Id: {pac.Id} - Nome: {pac.Nome} - CRM: {pac.CPF}");
}