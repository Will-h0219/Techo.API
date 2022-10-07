using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models;
using Techo.Models.Models.Entities;

namespace Techo.Core.Contracts.Services
{
    public interface IActividadService
    {
        string CreateActivity(NewActividadDTO newActivity);
        void DeleteActivity(int actividadId);
        ActividadAlternativaDTO GetActividadAlternativa(int actividadId);
        PagedList<ActividadDTO> GetActivities(PagingDTO parameters);
        PagedList<ActividadDTO> GetCommunityActivities(PagingDTO parameters, int communityId);
        MesaTrabajoDTO GetMesaTrabajo(int actividadId);
        PagedList<ActividadDTO> GetVolunteerActivities(PagingDTO parameters, int volunteerId);
    }
}
