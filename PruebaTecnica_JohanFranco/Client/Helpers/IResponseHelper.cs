namespace PruebaTecnica_JohanFranco.Client.Helpers
{
    public interface IResponseHelper
    {
        public StringContent GenerateStringConent<T>(T content);
        public Task<T> ResolveResponse<T>(HttpResponseMessage response);
    }
}
