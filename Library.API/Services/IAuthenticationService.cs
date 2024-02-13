namespace Library.API.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(Admin user);
    }
}
