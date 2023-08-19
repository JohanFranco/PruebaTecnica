using Dapper;
using PruebaTecnica_JohanFranco.Shared;
using System.Data.SqlClient;

namespace PruebaTecnica_JohanFranco.Server.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly IConfiguration configuration;
        private readonly SqlConnection _context;
        public ContactoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this._context = new SqlConnection(configuration.GetConnectionString("Contactos"));
        }
        public async Task<List<ContactDTO>> GetContactsByIdUser(int idUser)
        {
            string ssql = $@"SELECT * FROM [dbo].[Contacto] WHERE idUser = @IdUser";

            var contactos = await _context.QueryAsync<ContactDTO>(ssql, new { IdUser = idUser });

            return contactos.ToList();
        }

        public async Task<bool> DeleteContact(int idContact)
        {
            string ssql = @"DELETE [dbo].[Contacto] WHERE idContacto = @Id";
            await _context.QueryAsync(ssql, new { Id = idContact });
            return true;
        }

        public async Task<bool> SaveContact(ContactDTO contact)
        {
            string ssql = $@"INSERT INTO [dbo].[Contacto](phoneNumber, idUser)
                                VALUES (@Phone, @User)";

            await _context.QueryAsync(ssql, new
            {
                Phone = contact.PhoneNumber,
                User = contact.IdUser
            });

            return true;
        }

        public async Task<bool> UpdateContact(ContactDTO contact)
        {
            string ssql = @"UPDATE [dbo].[Contacto] SET phoneNumber = @Phone WHERE idContacto = @Id";
            await _context.QueryAsync(ssql, new 
            { 
                Phone = contact.PhoneNumber, 
                Id = contact.IdContacto
            });

            return true;
        }
    }
}
