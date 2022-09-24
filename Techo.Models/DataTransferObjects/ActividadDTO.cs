using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    [JsonObject(IsReference = false)]
    public class ActividadDTO
    {
        public int Id { get; set; }
        public DateTime FechaJornada { get; set; }
        public bool EsMesaTrabajo { get; set; }
        public string Estado { get; set; }
        public string NombreVoluntario { get; set; }
        public string NombreComunidad { get; set; }
        public int Asistentes { get; set; }
    }
}
