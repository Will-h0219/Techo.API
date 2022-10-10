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
    public class MesaTrabajoRepository : Repository<MesaTrabajo>, IMesaTrabajoRepository
    {
        public MesaTrabajoRepository(AppDbContext context) : base(context)
        {
        }

        public MesaTrabajo GetByActivityId(int activityId)
        {
            var result = _dbSet.Where(mt => mt.ActividadId == activityId)
                               .Include(mt => mt.Actividad)
                                   .ThenInclude(act => act.Asistencia)
                                   .ThenInclude(ast => ast.Voluntario)
                               .Include(mt => mt.Actividad)
                                   .ThenInclude(mt => mt.Voluntario)
                                   .ThenInclude(v => v.Comunidad)
                               .FirstOrDefault();
            return result;
        }
    }
}
