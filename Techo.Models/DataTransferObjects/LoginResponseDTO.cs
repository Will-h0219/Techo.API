using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.DataTransferObjects
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string NombreVoluntario { get; set; }
        public string RolVoluntario { get; set; }
    }
}
