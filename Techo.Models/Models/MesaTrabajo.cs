using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models
{
    public class MesaTrabajo
    {
        public int Id { get; set; }
        public string TemasTratados { get; set; }
        public string Compromisos { get; set; }
        public string LinkActa { get; set; }
        public int HabitantesParticipantes { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
