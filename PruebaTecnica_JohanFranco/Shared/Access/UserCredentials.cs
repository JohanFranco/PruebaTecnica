using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_JohanFranco.Shared.Access
{
    public class UserCredentials
    {
        [Required(ErrorMessage = "Ingrese su correo electónico")]
        //[RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string User { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string Password { get; set; }     
    }
}
