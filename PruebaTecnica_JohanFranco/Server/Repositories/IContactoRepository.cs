using PruebaTecnica_JohanFranco.Shared;

namespace PruebaTecnica_JohanFranco.Server.Repositories
{
    public interface IContactoRepository
    {
        Task<List<ContactDTO>> GetContactsByIdUser(int idUser);
        Task<bool> SaveContact(ContactDTO contact);
        Task<bool> DeleteContact(int idContact);
        Task<bool> UpdateContact(ContactDTO contact);
    }
}
