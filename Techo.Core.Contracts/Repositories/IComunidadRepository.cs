using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Data.Repository.Contracts;
using Techo.Models.Models.Entities;

namespace Techo.Core.Contracts.Repositories
{
    public interface IComunidadRepository : IRepository<Comunidad>
    {
        IEnumerable<Comunidad> GetCommunities();
        IEnumerable<Comunidad> GetCommunitiesWithVolunteers();
        Comunidad GetCommunityWithVolunteers(int comunidadId);
    }
}
