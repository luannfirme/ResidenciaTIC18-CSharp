namespace TechMed.Infrastructure.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username, string role);
        string ComputeSha256Hash(string pass);
    }
}
