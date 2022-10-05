using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models.Entities
{
    public class Comunidad
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        public string Sector { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Legalizado { get; set; }
        public string DecretoLegalizacion { get; set; }
        public float? DensidadMujeres { get; set; }
        public float? DensidadHombres { get; set; }
        public int ComunaId { get; set; }
        public Comuna Comuna { get; set; }
        public List<Actividad> ActividadesRegistradas { get; set; }
        public List<Voluntario> Voluntarios { get; set; }
    }
}
