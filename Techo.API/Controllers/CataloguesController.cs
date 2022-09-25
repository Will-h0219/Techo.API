using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects.CataloguesDTO;

namespace Techo.API.Controllers
{
    [ApiController]
    [Route("api/catalogo")]
    public class CataloguesController : ControllerBase
    {
        private readonly ICataloguesService cataloguesService;

        public CataloguesController(ICataloguesService cataloguesService)
        {
            this.cataloguesService = cataloguesService;
        }

        [HttpGet("roles")]
        public IList<RolDTO> GetRoles()
        {
            return cataloguesService.GetRoles();
        }

        [HttpGet("comunidades")]
        public IList<ComunidadDTO> GetCommunities()
        {
            return cataloguesService.GetComunitties();
        }
    }
}
