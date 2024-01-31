namespace TechAdv.Domain.Entities
{
    public sealed class Cliente : Pessoa
    {
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
    }
}
