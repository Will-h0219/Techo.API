using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects.CataloguesDTO;

namespace Techo.Models.DataTransferObjects
{
    public class ActividadDetalladaDTO
    {
        public int Id { get; set; }
        public DateTime FechaJornada { get; set; }
        public bool EsMesaTrabajo { get; set; }
        public string Estado { get; set; }
        public string NombreVoluntario { get; set; }
        public string NombreComunidad { get; set; }
        public IList<VoluntarioCatalogueDTO> Asistentes { get; set; }
    }
}
