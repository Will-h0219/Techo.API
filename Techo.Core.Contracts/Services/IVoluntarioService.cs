using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Core.Contracts.Services
{
    public interface IVoluntarioService
    {
        void AddVoluntario(NewVoluntarioDTO newVoluntario);
        IEnumerable<Voluntario> GetVolunteers();
    }
}
