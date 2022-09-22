using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects;
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
            voluntarioRepo.Add(voluntario);
            voluntarioRepo.Save();
        }

        public IEnumerable<Voluntario> GetVolunteers()
        {
            return voluntarioRepo.Get();
        }
    }
}
