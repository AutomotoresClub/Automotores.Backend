using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("/api/administradores")]
    public class AdministradorController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAdministradorRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMailRepository mailRepository;
        public AdministradorController(AutomotoresDbContext context, IMapper mapper, IAdministradorRepository repository, IUnitOfWork unitOfWork, IMailRepository mailRepository)
        {
            this.mailRepository = mailRepository;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdministrador([FromBody] SaveAdministradorResource administradorResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var administrador = mapper.Map<SaveAdministradorResource, Administrador>(administradorResource);

            administrador.FechaCreacion = DateTime.Now;

            repository.Add(administrador);

            await unitOfWork.CompleteAsync();

            administrador = await repository.GetAdministrador(administrador.Id);

            var result = mapper.Map<Administrador, AdministradorResource>(administrador);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdministrador(int id, [FromBody] SaveAdministradorResource administradorResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var administrador = await repository.GetAdministrador(id);

            if (administrador == null)
                return NotFound();

            mapper.Map<SaveAdministradorResource, Administrador>(administradorResource, administrador);

            administrador.FechaActualizacion = DateTime.Now;

            await unitOfWork.CompleteAsync();

            administrador = await repository.GetAdministrador(administrador.Id);

            // await mailRepository.SendEmail();

            var result = mapper.Map<Administrador, AdministradorResource>(administrador);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<AdministradorResource> GetAdministrador(int id)
        {
            var administrador = await repository.GetAdministrador(id);

            return mapper.Map<Administrador, AdministradorResource>(administrador);
        }

        [Route("~/api/empresa/{id}/administradores")]
        [HttpGet]
        public async Task<IEnumerable<AdministradorResource>> GetAdministradores(int id)
        {
            var administradores = await repository.GetAdministradores(id);

            return mapper.Map<IEnumerable<Administrador>, IEnumerable<AdministradorResource>>(administradores);
        }
    }
}