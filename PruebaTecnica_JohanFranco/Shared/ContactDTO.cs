using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_JohanFranco.Shared
{
    public class ContactDTO
    {
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El número debe tener 10 dígitos")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage ="ingrese un número")]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int IdContacto { get; set; }
        public int IdUser { get; set; }
    }
}
