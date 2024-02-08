namespace TechMed.Application.InputModels
{
    public sealed class LoginInputModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
