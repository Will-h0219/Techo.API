using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techo.Core.Contracts.Services;
using Techo.Data.Context;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.API.Controllers
{
    [ApiController]
    [Route("api/voluntarios")]
    public class VoluntariosController : ControllerBase
    {
        private readonly IVoluntarioService voluntarioService;

        public VoluntariosController(IVoluntarioService voluntarioService)
        {
            this.voluntarioService = voluntarioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var volunteerList = voluntarioService.GetVolunteers();
                return Ok(new { voluntarios = volunteerList });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Post(NewVoluntarioDTO newVoluntario)
        {
            try
            {
                voluntarioService.AddVoluntario(newVoluntario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
