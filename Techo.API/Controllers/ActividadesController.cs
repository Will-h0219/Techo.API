﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("volunteerId:int")]
        public IActionResult GetVolunteerActivities([FromQuery]PagingDTO parameters, int volunteerId)
        {
            try
            {
                var result = actividadService.GetVolunteerActivities(parameters, volunteerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
