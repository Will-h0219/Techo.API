using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Data.Context;
using Techo.Data.Helpers;
using Techo.Data.Repository;
using Techo.Data.Repository.Contracts;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Core.Repositories
{
    public class VoluntarioRepository : Repository<Voluntario>, IVoluntarioRepository
    {
        public VoluntarioRepository(AppDbContext context) : base(context)
        {
        }

        public bool ExistsByEmail(string email)
        {
            return _dbSet.Any(x => x.Email == email);
        }

        public IList<Voluntario> GetVolunteers(PagingDTO parameters)
        {
            var result = _dbSet.OrderBy(v => v.Nombres)
                               .Include(v => v.Rol)
                               .Include(v => v.Comunidad)
                               .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                               .Take(parameters.PageSize)
                               .ToList();

            return result;
        }

        public IList<Voluntario> GetVolunteers()
        {
            var result = _dbSet.Where(v => v.Estado.ToUpper() == "ACTIVO")
                               .OrderBy(v => v.Nombres)
                               .ToList();
            return result;
        }

        public Voluntario GetRegisteredVolunteer(string email, string password)
        {
            var voluntario = _dbSet.Where(v => v.Email == email)
                                   .Include(v => v.Rol)
                                   .FirstOrDefault();

            if (voluntario == null) throw new Exception();

            var hashResult = HashHelper.Hash(password, voluntario.Salt);

            if (hashResult.Hash != voluntario.Password) throw new Exception();

            return voluntario;
        }
    }
}
