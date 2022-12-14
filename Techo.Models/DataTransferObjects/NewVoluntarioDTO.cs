using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    public class NewVoluntarioDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "Se excedio la cantidad maxima de caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 15, ErrorMessage = "Se excedio la cantidad maxima de caracteres")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "Se excedio la cantidad maxima de caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 250, ErrorMessage = "Se excedio la cantidad maxima de caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Instagram { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 45, ErrorMessage = "Se excedio la cantidad maxima de caracteres")]
        public string Estado { get; set; }
        public int RolId { get; set; }
        public int? ComunidadId { get; set; }
        public int? ZonaId { get; set; }
    }
}
