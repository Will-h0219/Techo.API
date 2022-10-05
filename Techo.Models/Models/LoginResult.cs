using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models
{
    public class LoginResult
    {
        public string Token { get; set; }
        public int VoluntarioId { get; set; }
        public string NombreVoluntario { get; set; }
        public string RolVoluntario { get; set; }
        public bool Coordinador { get; set; }
        public int ComunidadAsignada { get; set; }
    }
}
