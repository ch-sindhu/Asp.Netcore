namespace ConsoleAppcore.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}