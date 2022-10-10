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
            var result = _dbSet.Where(aa => aa.ActividadId == actividadId)
                               .Include(aa => aa.Actividad)
                                   .ThenInclude(aa => aa.Asistencia)
                                   .ThenInclude(ast => ast.Voluntario)
                               .Include(aa => aa.Actividad)
                                   .ThenInclude(aa => aa.Voluntario)
                                   .ThenInclude(v => v.Comunidad)
                               .FirstOrDefault();
            return result;
        }
    }
}
