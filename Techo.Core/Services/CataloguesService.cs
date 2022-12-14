using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Core.Contracts.Services;
using Techo.Data.Repository.Contracts;
using Techo.Models.DataTransferObjects.CataloguesDTO;
using Techo.Models.Models.Entities;

namespace Techo.Core.Services
{
    public class CataloguesService : ICataloguesService
    {
        private readonly IRepository<Rol> rolRepository;
        private readonly IComunidadRepository comunidadRepository;
        private readonly IVoluntarioRepository voluntarioRepository;
        private readonly IMapper mapper;

        public CataloguesService(IRepository<Rol> rolRepository,
            IComunidadRepository comunidadRepository,
            IVoluntarioRepository voluntarioRepository,
            IMapper mapper)
        {
            this.rolRepository = rolRepository;
            this.comunidadRepository = comunidadRepository;
            this.voluntarioRepository = voluntarioRepository;
            this.mapper = mapper;
        }

        public IList<RolDTO> GetRoles()
        {
            var data = rolRepository.Get();
            var dataDTO = mapper.Map<IEnumerable<Rol>, IList<RolDTO>>(data);
            return dataDTO;
        }

        public IList<ComunidadDTO> GetComunitties()
        {
            var data = comunidadRepository.GetCommunities();
            var dataDTO = mapper.Map<IEnumerable<Comunidad>, IList<ComunidadDTO>>(data);
            return dataDTO;
        }

        public IList<VoluntarioCatalogueDTO> GetVolunteers()
        {
            var data = voluntarioRepository.GetVolunteers();
            var dataDTO = mapper.Map<IList<Voluntario>, IList<VoluntarioCatalogueDTO>>(data);
            return dataDTO;
        }

        public IList<ComunidadVoluntariosDTO> GetAllCommunitiesWithVolunteers()
        {
            var data = comunidadRepository.GetCommunitiesWithVolunteers();
            var dataDTO = mapper.Map<IEnumerable<Comunidad>, IList<ComunidadVoluntariosDTO>>(data);
            return dataDTO;
        }

        public IList<ComunidadVoluntariosDTO> GetCommunityVolunteers(int comunidadId)
        {
            var data = comunidadRepository.GetCommunityWithVolunteers(comunidadId);
            var dataDTO = mapper.Map<Comunidad, ComunidadVoluntariosDTO>(data);
            return new List<ComunidadVoluntariosDTO>() { dataDTO };
        }
    }
}
