using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.DataTransferObjects.CataloguesDTO;

namespace Techo.Core.Contracts.Services
{
    public interface ICataloguesService
    {
        IList<ComunidadVoluntariosDTO> GetAllCommunitiesWithVolunteers();
        IList<ComunidadVoluntariosDTO> GetCommunityVolunteers(int comunidadId);
        IList<ComunidadDTO> GetComunitties();
        IList<RolDTO> GetRoles();
        IList<VoluntarioCatalogueDTO> GetVolunteers();
    }
}
