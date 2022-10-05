using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly IHashService hashService;

        public AuthController(IAuthService authService,
            IHashService hashService)
        {
            this.authService = authService;
            this.hashService = hashService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserCredentialsDTO userCredentials)
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
