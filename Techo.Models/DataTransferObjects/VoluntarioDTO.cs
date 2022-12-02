using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects.CataloguesDTO;

namespace Techo.Models.DataTransferObjects
{
    public class VoluntarioDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Instagram { get; set; }
        public string Estado { get; set; }
        public string Rol { get; set; }
        public string Comunidad { get; set; }
        public ZonaDTO Zona { get; set; }
    }
}
