using System;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository repository;
        private readonly IMailRepository mailRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsuarioController(IMapper mapper, IUsuarioRepository repository, IMailRepository mailRepository, IUnitOfWork unitOfWork)
        {
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

            var usuario = mapper.Map<SaveUsuarioResource, Usuario>(usuarioResource);

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