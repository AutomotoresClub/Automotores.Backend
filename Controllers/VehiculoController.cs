using System;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehiculoRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public VehiculoController(IMapper mapper, IVehiculoRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> CreateVehiculo([FromBody] SaveVehiculoResource vehiculoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehiculo = mapper.Map<SaveVehiculoResource, Vehiculo>(vehiculoResource);

            vehiculo.Estado = 0;

            vehiculo.FechaCreacion = DateTime.Now;

            repository.Add(vehiculo);

            await unitOfWork.CompleteAsync();

            vehiculo = await repository.GetVehiculo(vehiculo.Id);

            var result = mapper.Map<Vehiculo, VehiculoResource>(vehiculo);

            return Ok(result);

        }
    }
}