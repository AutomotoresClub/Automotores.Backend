using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Controllers
{
    public class ServicioController
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;

        public ServicioController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/servicios")]
        public async Task<IEnumerable<KeyValuePairResource>> GetServicios()
        {
            var servicios = await context.Servicios.ToListAsync();

            return mapper.Map<List<Servicio>, List<KeyValuePairResource>>(servicios);
        }
    }
}