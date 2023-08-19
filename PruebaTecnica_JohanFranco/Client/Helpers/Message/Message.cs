using Microsoft.JSInterop;

namespace Helpers
{
    public class Message : IMessage
    {
        private readonly IJSRuntime js;

        public Message(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task<bool> Confirm(string Mensaje, string Titulo, TipoMensajeSweetAlert tipo)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", Titulo, Mensaje, tipo.ToString());
        }
        public async Task<string> Input(string Mensaje, string Titulo, TipoInputSweetAlert input, TipoMensajeSweetAlert tipo, string valor = "", string ValidadorMensaje = "Validar valor")
        {
            return await js.InvokeAsync<string>("InputConfirm", Titulo, Mensaje, input.ToString(), tipo.ToString(), valor, ValidadorMensaje);
        }

        public async Task Error(string mensaje)
        {
            await MostrarMensaje("Error", mensaje, "error");
        }

        public async Task Success(string mensaje)
        {
            await MostrarMensaje("Exitoso", mensaje, "success");
        }

        public async Task Warning(string mensaje)
        {
            await MostrarMensaje("Advertencia", mensaje, "warning");
        }
        public async Task Scroll(string IdElement)
        {
            await js.InvokeVoidAsync("Scroll", IdElement);
        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }
    }
}
