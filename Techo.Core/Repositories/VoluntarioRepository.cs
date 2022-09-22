using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Core.Contracts.Repositories;
using Techo.Data.Context;
using Techo.Data.Repository;
using Techo.Data.Repository.Contracts;
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
    }
}
