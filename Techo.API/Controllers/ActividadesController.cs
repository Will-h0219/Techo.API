using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects;

namespace Techo.API.Controllers
{
    [ApiController]
    [Route("api/{rol}/actividades")]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadService actividadService;

        public ActividadesController(IActividadService actividadService)
        {
            this.actividadService = actividadService;
        }

        [HttpPost]
        public IActionResult PostNewActivity(NewActividadDTO newActivity)
        {
            try
            {
                var result = actividadService.CreateActivity(newActivity);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id:int")]
        public IActionResult GetActivities([FromQuery]PagingDTO parameters, int id)
        {
            try
            {
                var result = actividadService.GetActivities(parameters);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
