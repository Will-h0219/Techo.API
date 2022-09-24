using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Core.Contracts.Services;
using Techo.Data.Repository.Contracts;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models;
using Techo.Models.Models.Entities;

namespace Techo.Core.Services
{
    public class ActividadService : IActividadService
    {
        private readonly IMapper mapper;
        private readonly IActividadRepository actividadRepository;
        private readonly IRepository<MesaTrabajo> workbenchRepository;
        private readonly IRepository<ActividadAlternativa> altActivityRepository;

        public ActividadService(IMapper mapper,
            IActividadRepository actividadRepository,
            IRepository<MesaTrabajo> workbenchRepository,
            IRepository<ActividadAlternativa> altActivityRepository)
        {
            this.mapper = mapper;
            this.actividadRepository = actividadRepository;
            this.workbenchRepository = workbenchRepository;
            this.altActivityRepository = altActivityRepository;
        }

        public string CreateActivity(NewActividadDTO newActivity)
        {
            if (newActivity.VoluntariosIds == null) { throw new Exception("No se puede registrar una actividad sin voluntarios"); }

            var activity = mapper.Map<Actividad>(newActivity);
            actividadRepository.Add(activity);
            actividadRepository.Save();

            if (newActivity.EsMesaTrabajo)
            {
                CreateWorkbenchActivity(newActivity.MesaTrabajo, activity.Id);
            } 
            else
            {
                CreateAlternativeActivity(newActivity.ActividadAlternativa, activity.Id);
            }

            return "Actividad agregada";
        }

        public void CreateWorkbenchActivity(NewMesaTrabajoDTO mesaTrabajo, int actividadId)
        {
            var workbench = mapper.Map<MesaTrabajo>(mesaTrabajo);

            workbench.ActividadId = actividadId;

            workbenchRepository.Add(workbench);
            workbenchRepository.Save();
        }

        public void CreateAlternativeActivity(NewActividadAlternativaDTO actividadAlternativa, int actividadId)
        {
            var altActivity = mapper.Map<ActividadAlternativa>(actividadAlternativa);

            altActivity.ActividadId = actividadId;

            altActivityRepository.Add(altActivity);
            altActivityRepository.Save();
        }

        public PagedList<ActividadDTO> GetActivities(PagingDTO parameters)
        {
            var data = actividadRepository.GetActivities(parameters);

            if (data.Count < 1) { return new PagedList<ActividadDTO>(new List<ActividadDTO>(), 0, 0, 0); }

            var total = actividadRepository.Count();

            var items = mapper.Map<IList<Actividad>, List<ActividadDTO>>(data);

            return new PagedList<ActividadDTO>(items, total, parameters.PageNumber, parameters.PageSize);
        }
    }
}
