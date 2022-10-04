using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects;

namespace Techo.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponseDTO> Login([FromBody] UserCredentialsDTO userCredentials)
        {
            try
            {
                var result = authService.LoginVolunteer(userCredentials);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
