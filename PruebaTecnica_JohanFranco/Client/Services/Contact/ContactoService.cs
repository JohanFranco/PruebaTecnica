using Newtonsoft.Json;
using PruebaTecnica_JohanFranco.Client.Helpers;
using PruebaTecnica_JohanFranco.Shared;
using PruebaTecnica_JohanFranco.Shared.Access;
using System.Net;
using System.Net.Http;

namespace PruebaTecnica_JohanFranco.Client.Services.Contact
{
    public class ContactoService : IContactoService
    {
        private readonly string baseURL = "api/v1/Contacto";
        private readonly HttpClient httpClient;
        private readonly IResponseHelper responseHelper;

        public ContactoService(HttpClient httpClient, IResponseHelper responseHelper)
        {
            this.httpClient = httpClient;
            this.responseHelper = responseHelper;
        }

        public async Task<List<ContactDTO>> GetContactsByIdUser(int idUser)
        {
            try
            {
                var response = await httpClient.GetAsync($"{baseURL}/{idUser}");
                string sContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<ContactDTO>>(sContent);

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> SaveContact(ContactDTO contact)
        {
            try
            {
                var response = await httpClient.PostAsync($"{baseURL}", responseHelper.GenerateStringConent(contact));
                var sContentResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteContact(int idContact)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{baseURL}/{idContact}");
                var sContentResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateContact(ContactDTO contact)
        {
            try
            {
                var response = await httpClient.PutAsync($"{baseURL}", responseHelper.GenerateStringConent(contact));
                var sContentResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
