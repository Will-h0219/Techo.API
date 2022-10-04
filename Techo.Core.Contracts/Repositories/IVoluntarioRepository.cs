using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Data.Repository.Contracts;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Core.Contracts.Repositories
{
    public interface IVoluntarioRepository : IRepository<Voluntario>
    {
        bool ExistsByEmail(string email);
        Voluntario GetRegisteredVolunteer(string email, string password);
        IList<Voluntario> GetVolunteers(PagingDTO parameters);
        IList<Voluntario> GetVolunteers();
    }
}
