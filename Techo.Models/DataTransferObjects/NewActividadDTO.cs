using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    public class NewActividadDTO
    {
        // Verificar el orden de las acciones para guardar la actividad
        // 1. Guardar la actividad y obtener su id (?)
        // 2. Proceder a guardar la mesaTrabajo o la actividadAlt (?)
        // ** verificar si se pueden realizar las acciones de SaveChanges() dos veces, una desde el repo custom y otra desde el repo base (?)
        public DateTime FechaJornada { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool EsMesaTrabajo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int VoluntarioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ComunidadId { get; set; }
        public string Estado => EsMesaTrabajo ? CheckMesaTrabajo() : "No Aplica";
        public MesaTrabajoDTO MesaTrabajo { get; set; }
        public ActividadAlternativaDTO ActividadAlternativa { get; set; }
        public IList<int> VoluntariosIds { get; set; }

        public string CheckMesaTrabajo()
        {
            if (MesaTrabajo is null) { return "No Sistematizado"; }

            var hasNullString = MesaTrabajo.GetType().GetProperties()
                                          .Any(prop => prop.GetValue(MesaTrabajo, null) == null);
                    
            if (hasNullString) return "No Sistematizado";

            return "Sistematizado";
        }
    }
}
