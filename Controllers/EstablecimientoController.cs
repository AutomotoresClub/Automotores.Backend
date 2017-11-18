using System;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("/api/establecimientos")]
    public class EstablecimientoController : Controller
    {
        private readonly IMailRepository mailRepository;
        private readonly IEstablecimientoRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public EstablecimientoController(IEstablecimientoRepository repository, IMailRepository mailRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
            this.mailRepository = mailRepository;

        }

        [HttpPost]
        public async Task<IActionResult> CreateEstablecimiento([FromBody] SaveEstablecimientoResource establecimientoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var establecimiento = mapper.Map<SaveEstablecimientoResource, Establecimiento>(establecimientoResource);

            establecimiento.FechaCreacion = DateTime.Now;

            establecimiento.Estado = 1;

            repository.Add(establecimiento);

            await unitOfWork.CompleteAsync();

            establecimiento = await repository.GetEstablecimiento(establecimiento.Id);

            var result = mapper.Map<Establecimiento, EstablecimientoResource>(establecimiento);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablecimiento(int id, [FromBody] SaveEstablecimientoResource establecimientoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var establecimiento = await repository.GetEstablecimiento(id);

            if (establecimiento == null)
                return NotFound();

            mapper.Map<SaveEstablecimientoResource, Establecimiento>(establecimientoResource, establecimiento);

            establecimiento.FechaActualizacion = DateTime.Now;
            establecimiento.Estado = 1;

            await unitOfWork.CompleteAsync();

            establecimiento = await repository.GetEstablecimiento(establecimiento.Id);

            await mailRepository.SendEmail();

            var result = mapper.Map<Establecimiento, EstablecimientoResource>(establecimiento);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<EstablecimientoResource> GetEstablecimiento(int id)
        {
            var establecimiento = await repository.GetEstablecimiento(id);

            return mapper.Map<Establecimiento, EstablecimientoResource>(establecimiento);
        }
    }
}