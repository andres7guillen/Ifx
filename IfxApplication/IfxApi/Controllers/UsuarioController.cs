using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IfxApi.Models;
using IfxData.Context;
using IfxData.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IfxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context; 
        public UsuarioController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("AsignarRolUsuario")]
        public async Task<IActionResult> AsignarRolUsuario(EditarRolModel model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.UsuarioEmail);
            if (usuario == null) { return NotFound(); }
            await _userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, model.Rol));
            await _userManager.AddToRoleAsync(usuario, model.Rol);            
            return Ok();
        }

        [HttpPost("RemoverRolUsuario")]
        public async Task<IActionResult> RemoverRolUsuario(EditarRolModel model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.UsuarioEmail);
            if (usuario == null) { return NotFound(); }
            await _userManager.RemoveClaimAsync(usuario, new Claim(ClaimTypes.Role, model.Rol));
            await _userManager.RemoveFromRoleAsync(usuario, model.Rol);
            string Mensaje = $"Se removio el rol = {model.Rol} al usuario {usuario.Email} correctamente";
            return Ok();
        }


    }
}