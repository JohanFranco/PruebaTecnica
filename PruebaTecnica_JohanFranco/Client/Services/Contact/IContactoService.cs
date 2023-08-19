using PruebaTecnica_JohanFranco.Shared;

namespace PruebaTecnica_JohanFranco.Client.Services.Contact
{
    public interface IContactoService
    {
        Task<List<ContactDTO>> GetContactsByIdUser(int idUser);
        Task<bool> SaveContact(ContactDTO contact);
        Task<bool> DeleteContact(int idContact);
        Task<bool> UpdateContact(ContactDTO contact);
    }
}
