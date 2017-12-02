using System;
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
    }
}