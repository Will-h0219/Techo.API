﻿using AutoMapper;
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
        public IActionResult Get([FromQuery] PagingDTO parameters)
        {
            try
            {
                var volunteerList = voluntarioService.GetVolunteers(parameters);
                return Ok(volunteerList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(NewVoluntarioDTO newVoluntario)
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