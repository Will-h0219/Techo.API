using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Techo.Core.Contracts.Repositories;
using Techo.Core.Contracts.Services;
using Techo.Models.DataTransferObjects;
using Techo.Models.Models.Entities;

namespace Techo.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IVoluntarioRepository voluntarioRepository;

        public AuthService(IConfiguration configuration,
            IVoluntarioRepository voluntarioRepository)
        {
            this.configuration = configuration;
            this.voluntarioRepository = voluntarioRepository;
        }

        public LoginResponseDTO LoginVolunteer(UserCredentialsDTO userCredentials)
        {
            var voluntario = voluntarioRepository.GetRegisteredVolunteer(userCredentials.Email, userCredentials.Password);

            if (voluntario == null)
            {
                throw new Exception("Error en las credenciales");
            }

            var token = GenerateToken(voluntario);

            var resp = new LoginResponseDTO
            {
                Token = token,
                NombreVoluntario = voluntario.Nombres,
                RolVoluntario = voluntario.Rol.NombreRol
            };

            return resp;

        }

        private string GenerateToken(Voluntario voluntario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, voluntario.Email),
                new Claim(ClaimTypes.Role, voluntario.Rol.NombreRol.ToLower())
            };

            var adminRoles = configuration.GetSection("AdminRoles").Get<List<int>>();

            if (adminRoles.Contains(voluntario.RolId)) claims.Add(new Claim("esAdmin", "1"));

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
