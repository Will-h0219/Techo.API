using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models;
using Techo.Models.Models.Entities;

namespace Techo.Core.Contracts.Services
{
    public interface IActividadService
    {
        string CreateActivity(NewActividadDTO newActivity);
        PagedList<ActividadDTO> GetActivities(PagingDTO parameters);
    }
}
