namespace Helpers
{
    public interface IMessage
    {
        Task Error(string Mensaje);
        Task Warning(string mensaje);
        Task Scroll(string IdElement);
        Task Success(string Mensaje);
        Task<bool> Confirm(string Mensaje, string Titulo, TipoMensajeSweetAlert tipo);
        Task<string> Input(string Mensaje, string Titulo, TipoInputSweetAlert input, TipoMensajeSweetAlert tipo, string valor = "", string ValidadorMensaje = "Validar valor");
    }

    public enum TipoMensajeSweetAlert
    {
        warning, error, success, info, question
    }
    public enum TipoInputSweetAlert
    {
        text, email, password, number, tel, range, textarea, select, radio, checkbox, file, url
    }

}
