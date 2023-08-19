using PruebaTecnica_JohanFranco.Shared;
using PruebaTecnica_JohanFranco.Shared.Access;

namespace PruebaTecnica_JohanFranco.Server.Repositories
{
    public interface IAccesRepository
    {
        Task<bool> RegisterUser(UserDTO userDTO);
        Task<UserToken> GetUserToken(UserCredentials credentials);
    }
}
