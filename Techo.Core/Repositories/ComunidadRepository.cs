using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Data.Context;
using Techo.Data.Repository;
using Techo.Models.Models.Entities;

namespace Techo.Core.Repositories
{
    public class ComunidadRepository : Repository<Comunidad>, IComunidadRepository
    {
        public ComunidadRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Comunidad> GetCommunities()
        {
            var result = _dbSet.OrderBy(c => c.Nombre)
                               .Include(c => c.Comuna)
                               .ToList();
            return result;
        }

        public IEnumerable<Comunidad> GetCommunitiesWithVolunteers()
        {
            var result = _dbSet.OrderBy(c => c.Nombre)
                               .Include(c => c.Voluntarios.Where(v => v.Estado.ToLower() == "activo"))
                               .ToList();
            return result;
        }

        public Comunidad GetCommunityWithVolunteers(int comunidadId)
        {
            var result = _dbSet.Where(c => c.Id == comunidadId)
                               .Include(c => c.Voluntarios.Where(v => v.Estado.ToLower() == "activo"))
                               .FirstOrDefault();
            return result;
        }
    }
}
