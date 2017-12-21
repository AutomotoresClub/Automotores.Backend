using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Automotores.Backend.Controllers
{
    [Authorize(Policy = "OnlyAplicacionMovil")]

    [Route("/api/vehiculos")]
    public class VehiculoController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehiculoRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly FotosConfiguracion fotoConfiguracion;
        private readonly IUploadService uploadService;
        private readonly IMailService mailService;

        public VehiculoController(IMapper mapper, IVehiculoRepository repository, IUnitOfWork unitOfWork, IUploadService uploadService, IMailService mailService, IOptionsSnapshot<FotosConfiguracion> options)
        {
            this.mailService = mailService;
            this.uploadService = uploadService;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
            this.fotoConfiguracion = options.Value;
        }

        [HttpPost]

        public async Task<IActionResult> CreateVehiculo(SaveVehiculoResource vehiculoResource)
        {
            var archivoExiste = false;
            var imagen = vehiculoResource.Imagen;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (imagen != null)
            {
                if (imagen.Length == 0) return BadRequest("Archivo vacio");
                if (imagen.Length > this.fotoConfiguracion.MaxBytes) return BadRequest("Peso del archivo excedido");
                if (!fotoConfiguracion.IsSuported(imagen.FileName)) return BadRequest("El tipo del archivo no es valido");

                archivoExiste = true;
            }

            var vehiculo = mapper.Map<SaveVehiculoResource, Vehiculo>(vehiculoResource);

            vehiculo.Imagen = (archivoExiste) ? await uploadService.UploadFile(imagen, "ac-automotor") : null;

            vehiculo.Estado = 0;

            vehiculo.FechaCreacion = DateTime.Now;

            repository.Add(vehiculo);

            await unitOfWork.CompleteAsync();

            vehiculo = await repository.GetVehiculo(vehiculo.Id);

            var result = mapper.Map<Vehiculo, VehiculoResource>(vehiculo);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehiculo(int id, SaveVehiculoResource vehiculoResource)
        {
            var archivoExiste = false;
            var imagenNueva = vehiculoResource.Imagen;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (imagenNueva != null)
            {
                if (imagenNueva.Length == 0) return BadRequest("Archivo vacio");
                if (imagenNueva.Length > this.fotoConfiguracion.MaxBytes) return BadRequest("Peso del archivo excedido");
                if (!fotoConfiguracion.IsSuported(imagenNueva.FileName)) return BadRequest("El tipo del archivo no es valido");

                archivoExiste = true;
            }

            var vehiculo = await repository.GetVehiculo(id);

            if (vehiculo == null)
                return NotFound();

            vehiculo = mapper.Map<SaveVehiculoResource, Vehiculo>(vehiculoResource, vehiculo);

            if (archivoExiste)
                vehiculo.Imagen = await uploadService.UploadFile(imagenNueva, "ac-automotor");
            else
                vehiculo.Imagen = vehiculo.Imagen;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var vehiculo = await repository.GetVehiculo(id);

            if (vehiculo == null)
                return NotFound();

            repository.Remove(vehiculo);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("validar/placas/{placa}")]
        public IActionResult ValidarPlaca(string placa)
        {
            if (placa == null)
                return NotFound();

            var vehiculoExiste = repository.ValidatePlaca(placa);

            return Ok(new
            {
                existe = vehiculoExiste,
                placa = placa
            });
        }
    }
}