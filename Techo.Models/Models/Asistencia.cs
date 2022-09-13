using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models
{
    public class Asistencia
    {
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }

        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
