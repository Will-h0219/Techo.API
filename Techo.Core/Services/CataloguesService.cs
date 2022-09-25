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
        private readonly IMapper mapper;

        public CataloguesService(IRepository<Rol> rolRepository,
            IComunidadRepository comunidadRepository,
            IMapper mapper)
        {
            this.rolRepository = rolRepository;
            this.comunidadRepository = comunidadRepository;
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
    }
}
