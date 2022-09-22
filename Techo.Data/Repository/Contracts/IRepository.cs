using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Data.Repository.Contracts
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity data);
        void Delete(int id);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Save();
        void Update(TEntity data);
    }
}
