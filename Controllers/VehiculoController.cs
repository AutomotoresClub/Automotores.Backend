using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Backend.Controllers
{
    [Route("/api/vehiculo")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehiculo(int id, [FromBody] SaveVehiculoResource vehiculoResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehiculo = await repository.GetVehiculo(id);

            if (vehiculo == null)
                return NotFound();

            vehiculo = mapper.Map<SaveVehiculoResource, Vehiculo>(vehiculoResource, vehiculo);

            vehiculo.FechaActualizacion = DateTime.Now;

            await unitOfWork.CompleteAsync();

            vehiculo = await repository.GetVehiculo(vehiculo.Id);

            var result = mapper.Map<Vehiculo, VehiculoResource>(vehiculo);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<VehiculoResource> GetVehiculo(int id)
        {
            var vehiculo = await repository.GetVehiculo(id);

            return mapper.Map<Vehiculo, VehiculoResource>(vehiculo);
        }

        [Route("~/api/usuario/{id}/vehiculos")]
        [HttpGet]
        public async Task<IEnumerable<VehiculoResource>> GetPromociones(int id)
        {
            var vehiculos = await repository.GetVehiculos(id);

            return mapper.Map<IEnumerable<Vehiculo>, IEnumerable<VehiculoResource>>(vehiculos);
        }
    }
}