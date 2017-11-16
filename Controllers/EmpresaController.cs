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

        public EmpresaController(IMapper mapper, IEmpresaRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpresa([FromBody] SaveEmpresaResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var empresa = mapper.Map<SaveEmpresaResource, Empresa>(vehicleResource);

            empresa.FechaCreacion = DateTime.Now;

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

            await unitOfWork.CompleteAsync();

            empresa = await repository.GetEmpresa(empresa.Id);

            var result = mapper.Map<Empresa, EmpresaResource>(empresa);

            return Ok(result);
        }
    }
}