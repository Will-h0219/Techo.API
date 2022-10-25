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
    public interface IActividadRepository: IRepository<Actividad>
    {
        IList<Actividad> GetActivities(PagingDTO parameters);
        Actividad GetActivityWithVolunteers(int id);
        IList<Actividad> GetCommunityActivities(PagingDTO parameters, int communityId);
        IList<Actividad> GetVolunteerActivities(PagingDTO parameters, int volunteerId);
    }
}
