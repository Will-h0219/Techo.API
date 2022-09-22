using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Models.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NewVoluntarioDTO, Voluntario>();
            CreateMap<NewActividadDTO, Actividad>()
                .ForMember(actividad => actividad.Asistencia, opt => opt.MapFrom(MapAsistencia));
            CreateMap<MesaTrabajoDTO, MesaTrabajo>();
            CreateMap<ActividadAlternativaDTO, ActividadAlternativa>();
        }

        private List<Asistencia> MapAsistencia(NewActividadDTO newActividad, Actividad actividad)
        {
            var result = new List<Asistencia>();

            if (newActividad.VoluntariosIds == null) return result;

            foreach (var voluntarioId in newActividad.VoluntariosIds)
            {
                result.Add(new Asistencia() { VoluntarioId = voluntarioId });
            }

            return result;
        }
    }
}
