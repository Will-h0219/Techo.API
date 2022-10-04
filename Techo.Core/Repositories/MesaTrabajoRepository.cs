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
            var result = _dbSet.Where(x => x.ActividadId == activityId)
                               .Include(x => x.Actividad)
                               .ThenInclude(x => x.Asistencia)
                               .ThenInclude(x => x.Voluntario)
                               .ThenInclude(x => x.Comunidad)
                               .FirstOrDefault();
            return result;
        }
    }
}
