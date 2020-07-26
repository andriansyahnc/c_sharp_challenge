namespace Challenge.Models
{
    public interface ISessionHelper
    {
        AuthenticatedUsers Authenticate(string username, string password);
    }
}