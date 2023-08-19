using PruebaTecnica_JohanFranco.Shared.Access;

namespace PruebaTecnica_JohanFranco.Client.Services
{
    public interface IAuthService
    {
        Task Login(UserToken userToken);
        Task Logout();
        Task TryRenewToken();
    }
}
