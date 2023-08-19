using Newtonsoft.Json;
using System.Text;

namespace PruebaTecnica_JohanFranco.Client.Helpers
{
    public class ResponseHelper:IResponseHelper
    {
        public StringContent GenerateStringConent<T>(T content)
        {
            var dataJson = JsonConvert.SerializeObject(content);
            return new StringContent(dataJson, Encoding.UTF8, "application/json");
        }
        public async Task<T> ResolveResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }

            var error = await response.Content.ReadAsStringAsync();
            throw new Exception(error);
        }
    }
}
