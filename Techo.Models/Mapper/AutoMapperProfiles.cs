using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;
using Techo.Models.DataTransferObjects.CataloguesDTO;
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
            CreateMap<NewMesaTrabajoDTO, MesaTrabajo>();
            CreateMap<NewActividadAlternativaDTO, ActividadAlternativa>();
            CreateMap<Voluntario, VoluntarioDTO>()
                .ForMember(voluntarioDTO => voluntarioDTO.Rol, opt => opt.MapFrom(v => v.Rol.NombreRol))
                .ForMember(voluntarioDTO => voluntarioDTO.Comunidad, opt => opt.MapFrom(v => v.Comunidad.Nombre));
            CreateMap<Actividad, ActividadDTO>()
                .ForMember(actividadDTO => actividadDTO.NombreVoluntario, opt => opt.MapFrom(a => a.Voluntario.Nombres))
                .ForMember(actividadDTO => actividadDTO.NombreComunidad, opt => opt.MapFrom(a => a.Comunidad.Nombre))
                .ForMember(actividadDTO => actividadDTO.Asistentes, opt => opt.MapFrom(a => a.Asistencia.Count));
            CreateMap<Comunidad, ComunidadDTO>()
                .ForMember(comunidadDTO => comunidadDTO.NombreComuna, opt => opt.MapFrom(c => c.Comuna.NombreComuna));
            CreateMap<Rol, RolDTO>()
                .ForMember(rolDTO => rolDTO.Nombre, opt => opt.MapFrom(r => r.NombreRol));
            CreateMap<Voluntario, VoluntarioCatalogueDTO>();
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
