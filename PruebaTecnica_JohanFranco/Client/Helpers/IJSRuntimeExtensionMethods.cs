using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js,
              DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initializeInactivityTimer", dotNetObjectReference);
        }
        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>(
                "localStorage.setItem",
                key, content
                );

        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
            => js.InvokeAsync<string>(
                "localStorage.getItem",
                key
                );

        public static ValueTask<object> RemoveItem(this IJSRuntime js, string key)
            => js.InvokeAsync<object>(
                "localStorage.removeItem",
                key);

    }
    public static class ObjectExtensions

    {

        public static string ToDisplayName(this object value, string propName)

        {

            try

            {

                Type type = value.GetType();



                MemberInfo[] memInfo = type.GetMember(propName);



                if (memInfo.Length == 0) return propName;



                DisplayAttribute[] attributes = memInfo[0].GetCustomAttributes<DisplayAttribute>(false).ToArray();



                return (attributes.Length == 0) ? propName : (attributes[0].Name ?? propName);

            }

            catch (Exception)

            {

                return propName;

            }

        }

    }
}

