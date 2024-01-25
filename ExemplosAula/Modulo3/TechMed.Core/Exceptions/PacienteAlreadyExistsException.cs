namespace TechMed.Core.Exceptions
{
    public class PacienteAlreadyExistsException : Exception
    {
           public PacienteAlreadyExistsException() :
                base("Esse paciente já foi cadastrado.")
            {
            }
    }
}
