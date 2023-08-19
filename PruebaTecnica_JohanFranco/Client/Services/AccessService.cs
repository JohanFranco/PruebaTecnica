using Newtonsoft.Json;
using PruebaTecnica_JohanFranco.Client.Helpers;
using PruebaTecnica_JohanFranco.Shared;
using PruebaTecnica_JohanFranco.Shared.Access;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace PruebaTecnica_JohanFranco.Client.Services
{
    public class AccessService : IAccessService
    {
        private readonly string baseURL = "api/v1/Access";

        private readonly IResponseHelper responseHelper;
        private readonly HttpClient httpClient;

        public AccessService(IResponseHelper responseHelper, HttpClient httpClient)
        {
            this.responseHelper = responseHelper;
            this.httpClient = httpClient;
        }

        public async Task<UserToken> GetUserToken(UserCredentials credentials)
        {
            credentials.Password = sha256_hash(credentials.Password);
            var response = await httpClient.PostAsync($"{baseURL}", responseHelper.GenerateStringConent(credentials));
            var sContentResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserToken>(sContentResponse);
            }
            var responseError = await response.Content.ReadAsStringAsync();
            throw new Exception(responseError);
        }
    
        public async Task<bool> RegisterUser(UserDTO userDTO)
        {
            userDTO.Password = sha256_hash(userDTO.Password);
            var response = await httpClient.PostAsync($"{baseURL}/register", responseHelper.GenerateStringConent(userDTO));
            var sContentResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
