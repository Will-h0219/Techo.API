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
    public class ActividadAlternativaRepository : Repository<ActividadAlternativa>, IActividadAlternativaRepository
    {
        public ActividadAlternativaRepository(AppDbContext context) : base(context)
        {
        }

        public ActividadAlternativa GetByActividadId(int actividadId)
        {
            var result = _dbSet.Where(x => x.ActividadId == actividadId)
                               .Include(x => x.Actividad)
                               .ThenInclude(x => x.Asistencia)
                               .ThenInclude(x => x.Voluntario)
                               .ThenInclude(x => x.Comunidad)
                               .FirstOrDefault();
            return result;
        }
    }
}
