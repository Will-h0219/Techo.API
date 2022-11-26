using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Core.Contracts.Services;
using Techo.Data.Helpers;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models;
using Techo.Models.Models.Entities;

namespace Techo.Core.Services
{
    public class VoluntarioService : IVoluntarioService
    {
        private readonly IVoluntarioRepository voluntarioRepo;
        private readonly IMapper mapper;

        public VoluntarioService(IVoluntarioRepository voluntarioRepo,
            IMapper mapper)
        {
            this.voluntarioRepo = voluntarioRepo;
            this.mapper = mapper;
        }

        public void AddVoluntario(NewVoluntarioDTO newVoluntario)
        {
            var voluntarioExists = voluntarioRepo.ExistsByEmail(newVoluntario.Email);

            if (!!voluntarioExists)
            {
                throw new Exception(message: $"Ya existe un voluntario registrado con el email {newVoluntario.Email}");
            }

            var voluntario = mapper.Map<Voluntario>(newVoluntario);

            voluntario = HashPassword(voluntario);

            voluntarioRepo.Add(voluntario);
            voluntarioRepo.Save();
        }

        public PagedList<VoluntarioDTO> GetVolunteers(PagingDTO parameters)
        {
            var data = voluntarioRepo.GetVolunteers(parameters);

            if (data.Count < 1) { return new PagedList<VoluntarioDTO>(new List<VoluntarioDTO>(), 0, 0, 0); }
            
            var total = voluntarioRepo.Count();

            var items = mapper.Map<IList<Voluntario>, List<VoluntarioDTO>>(data);

            return new PagedList<VoluntarioDTO>(items, total, parameters.PageNumber, parameters.PageSize);
        }

        private static Voluntario HashPassword(Voluntario volunteer)
        {
            var hashResult = HashHelper.Hash(volunteer.Password);
            volunteer.Password = hashResult.Hash;
            volunteer.Salt = hashResult.Sal;
            return volunteer;
        }
    }
}
