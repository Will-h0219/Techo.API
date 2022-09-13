using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models
{
    public class ActividadAlternativa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
