namespace TechMed.WebAPI.Model
{
    public class Medico : Pessoa
    {
        public string CRM { get; set; }
        public double Salario { get; set; }
        public string Especialidade { get; set; }
    }
}
