using System;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Automotores.Backend.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository repository;
        private readonly IMailRepository mailRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IIdentityService identityService;

        public UsuarioController(IMapper mapper, IUsuarioRepository repository, IMailRepository mailRepository, IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            this.identityService = identityService;
            this.unitOfWork = unitOfWork;
            this.mailRepository = mailRepository;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] SaveUsuarioResource usuarioResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuarioResource.User.Rol = "UsuarioAplicacionMovil";

            if (await identityService.ValidateUser(usuarioResource.User.Email, usuarioResource.User.Rol))
            {
                ModelState.AddModelError("User.email", "El correo ya esta registrado");
                return BadRequest(ModelState);
            }

            var user = await identityService.Register(usuarioResource.User);

            if (user == "")
            {
                ModelState.AddModelError("User", "Hubo un error al crear el usuario");
                return BadRequest(ModelState);
            }

            var usuario = mapper.Map<SaveUsuarioResource, Usuario>(usuarioResource);

            usuario.UserId = user;

            usuario.FechaCreacion = DateTime.Now;

            usuario.Estado = 0;

            repository.Add(usuario);

            await unitOfWork.CompleteAsync();

            usuario = await repository.GetUsuario(usuario.Id);

            var result = mapper.Map<Usuario, UsuarioResource>(usuario);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] SaveUsuarioResource saveUsuarioResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await repository.GetUsuario(id);

            if (usuario == null)
                return NotFound();

            mapper.Map<SaveUsuarioResource, Usuario>(saveUsuarioResource, usuario);

            usuario.FechaActualizacion = DateTime.Now;

            await unitOfWork.CompleteAsync();

            usuario = await repository.GetUsuario(usuario.Id);

            var result = mapper.Map<Usuario, UsuarioResource>(usuario);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<UsuarioResource> GetUsuario(int id)
        {
            var usuario = await repository.GetUsuario(id);

            return mapper.Map<Usuario, UsuarioResource>(usuario);
        }

    }
}