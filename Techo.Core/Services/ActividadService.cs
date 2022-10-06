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
        private readonly IVoluntarioRepository voluntarioRepository;
        private readonly IMesaTrabajoRepository mesaTrabajoRepository;
        private readonly IActividadAlternativaRepository actividadAlternativaRepository;
        private readonly IComunidadRepository comunidadRepository;

        public ActividadService(IMapper mapper,
            IActividadRepository actividadRepository,
            IVoluntarioRepository voluntarioRepository,
            IMesaTrabajoRepository mesaTrabajoRepository,
            IActividadAlternativaRepository actividadAlternativaRepository,
            IComunidadRepository comunidadRepository)
        {
            this.mapper = mapper;
            this.actividadRepository = actividadRepository;
            this.voluntarioRepository = voluntarioRepository;
            this.mesaTrabajoRepository = mesaTrabajoRepository;
            this.actividadAlternativaRepository = actividadAlternativaRepository;
            this.comunidadRepository = comunidadRepository;
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

            mesaTrabajoRepository.Add(workbench);
            mesaTrabajoRepository.Save();
        }

        public void CreateAlternativeActivity(NewActividadAlternativaDTO actividadAlternativa, int actividadId)
        {
            var altActivity = mapper.Map<ActividadAlternativa>(actividadAlternativa);

            altActivity.ActividadId = actividadId;

            actividadAlternativaRepository.Add(altActivity);
            actividadAlternativaRepository.Save();
        }

        public PagedList<ActividadDTO> GetActivities(PagingDTO parameters)
        {
            var data = actividadRepository.GetActivities(parameters);

            if (data.Count < 1) { return new PagedList<ActividadDTO>(new List<ActividadDTO>(), 0, 0, 0); }

            var total = actividadRepository.Count();

            var items = mapper.Map<IList<Actividad>, List<ActividadDTO>>(data);

            return new PagedList<ActividadDTO>(items, total, parameters.PageNumber, parameters.PageSize);
        }

        public PagedList<ActividadDTO> GetVolunteerActivities(PagingDTO parameters, int volunteerId)
        {
            var volunteer = voluntarioRepository.Get(volunteerId);

            if (volunteer == null) { throw new Exception("El voluntario consultado no existe."); }

            var data = actividadRepository.GetVolunteerActivities(parameters, volunteerId);

            if (data.Count < 1) { return new PagedList<ActividadDTO>(new List<ActividadDTO>(), 0, 0, 0); }

            var total = actividadRepository.Get().Where(a => a.VoluntarioId == volunteerId).Count();

            var items = mapper.Map<IList<Actividad>, List<ActividadDTO>>(data);

            return new PagedList<ActividadDTO>(items, total, parameters.PageNumber, parameters.PageSize);
        }

        public PagedList<ActividadDTO> GetCommunityActivities(PagingDTO parameters, int communityId)
        {
            var community = comunidadRepository.Get(communityId);

            if (community == null) { throw new Exception("La comunidad consultada no existe."); }

            var data = actividadRepository.GetCommunityActivities(parameters, communityId);

            if (data.Count < 1) { return new PagedList<ActividadDTO>(new List<ActividadDTO>(), 0, 0, 0); }

            var total = actividadRepository.Get().Where(a => a.ComunidadId == communityId).Count();

            var items = mapper.Map<IList<Actividad>, List<ActividadDTO>>(data);

            return new PagedList<ActividadDTO>(items, total, parameters.PageNumber, parameters.PageSize);
        }

        public MesaTrabajoDTO GetMesaTrabajo(int actividadId)
        {
            var mesaTrabajo = mesaTrabajoRepository.GetByActivityId(actividadId);

            if (mesaTrabajo == null) { throw new Exception("La actividad consultada no existe."); }

            var result = mapper.Map<MesaTrabajoDTO>(mesaTrabajo);
            var generalidades = mapper.Map<ActividadDetalladaDTO>(mesaTrabajo.Actividad);
            result.Generalidades = generalidades;

            return result;
        }

        public ActividadAlternativaDTO GetActividadAlternativa(int actividadId)
        {
            var actividadAlternativa = actividadAlternativaRepository.GetByActividadId(actividadId);

            if (actividadAlternativa == null) { throw new Exception("La actividad consultada no existe."); }

            var result = mapper.Map<ActividadAlternativaDTO>(actividadAlternativa);
            var generalidades = mapper.Map<ActividadDetalladaDTO>(actividadAlternativa.Actividad);
            result.Generalidades = generalidades;

            return result;
        }
    }
}
