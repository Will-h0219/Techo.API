using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Data.Context;
using Techo.Data.Repository;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Core.Repositories
{
    public class ActividadRepository : Repository<Actividad>, IActividadRepository
    {
        public ActividadRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Actividad> GetActivities(PagingDTO parameters)
        {
            var result = _dbSet.OrderByDescending(a => a.FechaJornada)
                               .Include(a => a.Voluntario)
                               .Include(a => a.Comunidad)
                               .Include(a => a.Asistencia)
                               .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                               .Take(parameters.PageSize)
                               .ToList();
            return result;
        }

        public IList<Actividad> GetVolunteerActivities(PagingDTO parameters, int volunteerId)
        {
            var result = _dbSet.Where(a => a.VoluntarioId == volunteerId)
                               .OrderByDescending(a => a.FechaJornada)
                               .Include(a => a.Voluntario)
                               .Include(a => a.Comunidad)
                               .Include(a => a.Asistencia)
                               .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                               .Take(parameters.PageSize)
                               .ToList();
            return result;
        }

        public IList<Actividad> GetCommunityActivities(PagingDTO parameters, int communityId)
        {
            var result = _dbSet.Where(a => a.ComunidadId == communityId)
                               .OrderByDescending(a => a.FechaJornada)
                               .Include(a => a.Voluntario)
                               .Include(a => a.Comunidad)
                               .Include(a => a.Asistencia)
                               .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                               .Take(parameters.PageSize)
                               .ToList();
            return result;
        }

        public Actividad GetActivityWithVolunteers(int id)
        {
            var result = _dbSet.Include(x => x.Asistencia)
                               .FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
