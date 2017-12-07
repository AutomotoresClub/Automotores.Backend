using System;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("/api/empresas")]
    public class EmpresaController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmpresaRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMailRepository mailRepository;
        private readonly IIdentityService identityService;

        public EmpresaController(IMapper mapper, IEmpresaRepository repository, IUnitOfWork unitOfWork, IMailRepository mailRepository, IIdentityService identityService)
        {
            this.identityService = identityService;
            this.mailRepository = mailRepository;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpresa([FromBody] SaveEmpresaResource vehicleResource)
        {
            vehicleResource.User.Rol = "Empresa";
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await identityService.ValidateUser(vehicleResource.User.Email, vehicleResource.User.Rol))
            {
                ModelState.AddModelError("User.email", "El correo ya esta registrado");
                return BadRequest(ModelState);
            }

            var userId = await identityService.Register(vehicleResource.User);

            if (userId == "")
            {
                ModelState.AddModelError("User", "Hubo un error al crear el usuario");
                return BadRequest(ModelState);
            }

            var empresa = mapper.Map<SaveEmpresaResource, Empresa>(vehicleResource);

            empresa.FechaCreacion = DateTime.Now;

            empresa.Estado = 1;

            empresa.UserId = userId;

            repository.Add(empresa);

            await unitOfWork.CompleteAsync();

            empresa = await repository.GetEmpresa(empresa.Id);

            var result = mapper.Map<Empresa, EmpresaResource>(empresa);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveEmpresaResource empresaResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var empresa = await repository.GetEmpresa(id);

            if (empresa == null)
                return NotFound();

            mapper.Map<SaveEmpresaResource, Empresa>(empresaResource, empresa);

            empresa.FechaActualizacion = DateTime.Now;
            empresa.Estado = 1;

            await unitOfWork.CompleteAsync();

            empresa = await repository.GetEmpresa(empresa.Id);

            // await mailRepository.SendEmail();

            var result = mapper.Map<Empresa, EmpresaResource>(empresa);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<EmpresaResource> GetEmpresa(int id)
        {
            var empresa = await repository.GetEmpresa(id);

            return mapper.Map<Empresa, EmpresaResource>(empresa);
        }
    }
}