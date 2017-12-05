using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("/api/promociones")]
    public class PromocionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMailRepository mailRepository;
        private readonly IPromocionRepository repository;

        public PromocionController(IUnitOfWork unitOfWork, IMapper mapper, IMailRepository mailRepository, IPromocionRepository repository)
        {
            this.repository = repository;
            this.mailRepository = mailRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromocion([FromBody] SavePromocionResource promocionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var promocion = mapper.Map<SavePromocionResource, Promocion>(promocionResource);

            promocion.FechaCreacion = DateTime.Now;

            promocion.Estado = 1;

            repository.Add(promocion);

            await unitOfWork.CompleteAsync();

            promocion = await repository.GetPromocion(promocion.Id);

            var result = mapper.Map<Promocion, PromocionResource>(promocion);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromocion(int id, [FromBody] SavePromocionResource promocionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var promocion = await repository.GetPromocion(id);

            if (promocion == null)
                return NotFound();

            mapper.Map<SavePromocionResource, Promocion>(promocionResource, promocion);

            promocion.FechaActualizacion = DateTime.Now;
            promocion.Estado = 1;

            await unitOfWork.CompleteAsync();

            promocion = await repository.GetPromocion(promocion.Id);

            // await mailRepository.SendEmail();

            var result = mapper.Map<Promocion, PromocionResource>(promocion);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<PromocionResource> GetPromocion(int id)
        {
            var promocion = await repository.GetPromocion(id);

            return mapper.Map<Promocion, PromocionResource>(promocion);
        }

        [Route("~/api/establecimiento/{id}/promociones")]
        [HttpGet]
        public async Task<IEnumerable<PromocionResource>> GetEstablecimientoPromociones(int id)
        {
            var promociones = await repository.GetPromociones(id);

            return mapper.Map<IEnumerable<Promocion>, IEnumerable<PromocionResource>>(promociones);
        }

        [HttpGet("{claseVehiculo}/{servicioVehiculo}")]
        public async Task<IEnumerable<PromocionResource>> GetPromociones(int claseVehiculo, int servicioVehiculo)
        {
            var promociones = await repository.GetPromociones(claseVehiculo, servicioVehiculo, true);

            return mapper.Map<IEnumerable<Promocion>, IEnumerable<PromocionResource>>(promociones);
        }
    }
}