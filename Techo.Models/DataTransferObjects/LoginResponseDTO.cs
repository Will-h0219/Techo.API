using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.Models;

namespace Techo.Models.DataTransferObjects
{
    public class LoginResponseDTO
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public LoginResult Result { get; set; }
    }
}
