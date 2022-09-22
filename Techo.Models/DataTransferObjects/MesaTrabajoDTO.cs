using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    public class MesaTrabajoDTO
    {
        public string TemasTratados { get; set; }
        public string Compromisos { get; set; }
        public string LinkActa { get; set; }
        public int HabitantesParticipantes { get; set; }
    }
}
