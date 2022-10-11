using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects;

namespace Techo.API.Controllers
{
    [ApiController]
    [Route("api/actividades")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet("por-voluntario/{voluntario:int}")]
        public IActionResult GetVolunteerActivities([FromQuery]PagingDTO parameters, int voluntario)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var esAdmin = identity.Claims.Where(c => c.Type == "esAdmin").FirstOrDefault();
            
            try
            {
                var result = esAdmin != null ? actividadService.GetActivities(parameters) : actividadService.GetVolunteerActivities(parameters, voluntario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("por-comunidad/{comunidad:int}")]
        public IActionResult GetCommunityActivities([FromQuery] PagingDTO parameters, int comunidad)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var esAdmin = identity.Claims.Where(c => c.Type == "esAdmin").FirstOrDefault();

            try
            {
                var result = esAdmin != null ? actividadService.GetActivities(parameters) : actividadService.GetCommunityActivities(parameters, comunidad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("detalle")]
        public IActionResult GetDetailedActivity([FromQuery] int actividadId, bool esMesaTrabajo)
        {
            try
            {
                if (esMesaTrabajo)
                {
                    var result = actividadService.GetMesaTrabajo(actividadId);
                    return Ok(result);
                }
                else
                {
                    var result = actividadService.GetActividadAlternativa(actividadId);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{actividadId:int}")]
        [Authorize(Policy = "esAdmin")]
        public IActionResult DeleteActivity(int actividadId)
        {
            try
            {
                actividadService.DeleteActivity(actividadId);
                return Ok(new { result = "Actividad eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
