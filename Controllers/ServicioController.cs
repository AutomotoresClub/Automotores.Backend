using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Controllers
{
    [Route("/api/servicios")]
    public class ServicioController
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;

        public ServicioController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Servicio>> GetServicios()
        {
            var servicios = await context.Servicios.ToListAsync();

            return servicios;
        }
    }
}