using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models.Entities
{
    public class Actividad
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaJornada { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool EsMesaTrabajo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Estado { get; set; }
        public int HabitantesParticipantes { get; set; }
        public int VoluntariosEquipoComunidad { get; set; }


        public int? VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }

        public int? ComunidadId { get; set; }
        public Comunidad Comunidad { get; set; }

        public List<Asistencia> Asistencia { get; set; }
    }
}
