using PruebaTecnica_JohanFranco.Shared.Access;
using PruebaTecnica_JohanFranco.Shared;

namespace PruebaTecnica_JohanFranco.Client.Services
{
    public interface IAccessService
    {
        Task<bool> RegisterUser(UserDTO userDTO);
        Task<UserToken> GetUserToken(UserCredentials credentials);
    }
}
