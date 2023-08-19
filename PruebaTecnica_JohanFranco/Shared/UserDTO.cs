using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_JohanFranco.Shared
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Ingrese su correo electónico")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Ingrese su correo electónico")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
