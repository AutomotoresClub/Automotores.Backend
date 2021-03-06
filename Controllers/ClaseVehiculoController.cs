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
    [Route("/api/claseVehiculo")]
    public class ClaseVehiculoController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;

        public ClaseVehiculoController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ClaseVehiculoResource>> GetClaseVehiculo()
        {
            var servicios = await context.ClaseVehiculo.ToListAsync();

            return mapper.Map<List<ClaseVehiculo>, List<ClaseVehiculoResource>>(servicios);
        }
    }
}