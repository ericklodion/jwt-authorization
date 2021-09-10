using ErickEspinosa.WebApiAspNetCore.JWToken.Models;
using ErickEspinosa.WebApiAspNetCore.JWToken.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.JWToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTHelper _jwtHelper;
        public AuthController(JWTHelper jwtHelper)
            => _jwtHelper = jwtHelper;

        [HttpGet]
        public IActionResult Get()
        {
            //Em um projeto real os dados do usuários deveriam ser recebidos na requisição e validados.
            var user = new User
            {
                Guid = Guid.NewGuid().ToString(),
                Password = "123",
                Role = "Admin",
                Username = "erickespinosa"
            };

            return Ok(new
            {
                Token = _jwtHelper.GenerateToken(user),
                User = user
            });
        }
    }
}
