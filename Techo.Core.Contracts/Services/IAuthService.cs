using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;

namespace Techo.Core.Contracts.Services
{
    public interface IAuthService
    {
        LoginResponseDTO LoginVolunteer(UserCredentialsDTO userCredentials);
    }
}
